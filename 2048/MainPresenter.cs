using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _2048.Skins;
using Game2048;
using Solver2048;

namespace _2048
{
	public class MainPresenter
	{
		private const int WIDTH = 4;
		private IMainForm view;
		private CancellationTokenSource cts;

		private IGame game;
		private ISolver solver;

		public MainPresenter(IMainForm form)
		{
			view = form;
			view.OnPlayerKeyDown += View_OnPlayerKeyDown;
			view.AutoStart += View_AutoStart;
			view.AutoStop += View_AutoStop;
			view.ResetAll += View_ResetAll;
			view.OneStep += View_OneStep;

			InitGame();
			RenderView();
		}

		// dependency injection here
		private void InitGame()
		{
			InitBoard();
			InitSolver();
			view.InitTiles(game.CurrentNumbers, InitSkin);
		}
		private ISkin InitSkin => SkinFactory.Generate(SkinType.Vanilla);
		private void InitBoard()
		{
			Board board = new Board(WIDTH);
			ITileGenerator generator = new RandomTileGenerator();
			game = new Game(board, generator);
			game.Start();
		}
		private void InitSolver()
		{
			IPenaltyCalculator calc = CalculatorFactory.Generate(CalculatorType.NeighborMergeAndCorner);
			solver = SolverFactory.Generate(SolverType.WeightedMultiSteps, calc);
		}


		private async Task<bool> PlayGame(Direction dir)
		{
			bool isGameOver = cts == null ? 
				await game.MoveAsync(dir, new CancellationToken()) : await game.MoveAsync(dir, cts.Token);
			RenderView();
			if (isGameOver) view.ShowMessage("Game Over");
			return isGameOver;
		}
		private async Task AutoPlay()
		{
			Direction dir = await solver.RecommendAsync(game.DeepCopy(), cts.Token);
			while (!cts.IsCancellationRequested && !(await PlayGame(dir)))
			{
				dir = await solver.RecommendAsync(game.DeepCopy(), cts.Token);
			}
		}


		private void View_AutoStop(object sender, EventArgs e)
		{
			cts.Cancel();
		}
		private async void View_AutoStart(object sender, EventArgs e)
		{
			cts = new CancellationTokenSource();
			await AutoPlay();
		}
		private async void View_OneStep(object sender, EventArgs e)
		{
			cts = new CancellationTokenSource();
			Direction dir = await solver.RecommendAsync(game.DeepCopy(), cts.Token);
			await PlayGame(dir);
		}
		private void View_ResetAll(object sender, EventArgs e)
		{
			game.Reset();
			game.Start();

			RenderView();
		}
		private async void View_OnPlayerKeyDown(object sender, DirectionEventArgs e)
		{
			await PlayGame(e.Direction);
		}

		private void RenderView()
		{
			view.Data = game.CurrentNumbers;
			view.Score = game.Score;
		}

	}
}
