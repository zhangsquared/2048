using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	internal class DynamicMultiStepsSolver : ISolver
	{
		private IPenaltyCalculator penalty;
		private readonly OneStepSolver oneStepSolver;

		internal DynamicMultiStepsSolver(IPenaltyCalculator injectedPenalty)
		{
			if (injectedPenalty == null) injectedPenalty = new NeighborPenaltyCalculator();
			penalty = injectedPenalty;
			oneStepSolver = new OneStepSolver(penalty);
		}

		public Direction Recommend(IGame game)
		{
			RunResult run = InternalCalculation(game, StepNumber(game));
			return run.IsSuccess ? run.Direction : Directions.Default;
		}

		private int StepNumber(IGame game)
		{
			int count = game.InternalBoard.BlankSlots().Count();
			if (count >= 3) return 3;
			return 4;
		}

		private RunResult InternalCalculation(IGame game, int stepNumber)
		{
			if (stepNumber <= 1)
			{
				return oneStepSolver.InternalCalculation(game);
			}

			IDictionary<Direction, double> result = new Dictionary<Direction, double>();
			foreach (Direction dir in Directions.All)
			{
				IGame newGame = game.DeepCopy();
				bool hasShift = newGame.PlayerShift(dir);
				if (!hasShift) continue;

				List<double> scores = new List<double>();
				foreach (Position pos in newGame.InternalBoard.BlankSlots())
				{
					IGame other2 = newGame.DeepCopy();
					other2.InternalBoard.SetNumber(2, pos);
					RunResult run2 = InternalCalculation(other2, stepNumber - 1);
					double penalty2 = run2.IsSuccess ? run2.Penalty : double.MaxValue;

					IGame other4 = newGame.DeepCopy();
					other4.InternalBoard.SetNumber(4, pos);
					RunResult run4 = InternalCalculation(other4, stepNumber - 1);
					double penalty4 = run4.IsSuccess ? run4.Penalty : double.MaxValue;

					scores.Add(penalty2 * 0.9 + penalty4 * 0.1);
				}
				result[dir] = scores.Average();
			}
			if (!result.Any())
			{
				return RunResult.Fail;
			}
			return RunResult.OK(result.OrderBy(x => x.Value).First());
		}

		public Task<Direction> RecommendAsync(IGame game, CancellationToken token)
		{
			Func<Direction> func = () =>
			{
				//Thread.Sleep(50);
				return Recommend(game);
			};
			return Task.Run(func, token);
		}

		public SolverType Type => SolverType.DynamicMultiSteps;
	}
}
