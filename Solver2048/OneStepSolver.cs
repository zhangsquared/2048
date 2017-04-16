using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	internal class OneStepSolver : ISolver
	{
		private IPenaltyCalculator penaltyCalculator;
		internal OneStepSolver(IPenaltyCalculator injectedPenalty)
		{
			if (injectedPenalty == null) injectedPenalty = new NeighborPenaltyCalculator();
			penaltyCalculator = injectedPenalty;
		}

		public Direction Recommend(IGame game)
		{
			RunResult run = InternalCalculation(game);
			return run.IsSuccess ? run.Direction : Directions.Default;
		}

		internal RunResult InternalCalculation(IGame game)
		{
			IDictionary<Direction, double> penalties = new Dictionary<Direction, double>();
			foreach (Direction dir in Directions.All)
			{
				IGame newGame = game.DeepCopy();
				bool hasShift = newGame.PlayerShift(dir);
				double p = hasShift ? 
					penaltyCalculator.Calculate(newGame.InternalBoard, newGame.Score - game.Score) : double.MaxValue;
				penalties[dir] = p;
			}
			if(!penalties.Any())
			{
				return RunResult.Fail;
			}
			return RunResult.OK(penalties.OrderBy(x => x.Value).First());
		}

		public Task<Direction> RecommendAsync(IGame game, CancellationToken token)
		{
			Func<Direction> func = () =>
			{
				Thread.Sleep(100);
				return Recommend(game);
			};
			return Task.Run(func, token);
		}

		public SolverType Type => SolverType.OneStep;
	}
}
