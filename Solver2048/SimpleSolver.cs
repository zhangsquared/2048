using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	internal class SimpleSolver : ISolver
	{
		public Direction Recommend(IGame game)
		{
			foreach(Direction dir in Directions.All)
			{
				IGame trial = game.DeepCopy();
				if ( trial.PlayerShift(dir)) return dir;
			}
			return Directions.Default;
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

		public SolverType Type => SolverType.Simple;

	}
}
