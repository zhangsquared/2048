using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	public interface ISolver
	{
		Direction Recommend(IGame game);

		Task<Direction> RecommendAsync(IGame game, CancellationToken token);

		SolverType Type { get; }
	}

	public enum SolverType
	{
		Simple,
		OneStep,
		MultiSteps,
		DynamicMultiSteps,
		WeightedMultiSteps
	}

	public static class SolverFactory
	{
		public static ISolver Generate(SolverType type, IPenaltyCalculator calc)
		{
			switch(type)
			{
				case SolverType.Simple:
					return new SimpleSolver();
				case SolverType.OneStep:
					return new OneStepSolver(calc);
				case SolverType.MultiSteps:
					return new MultiStepsSolver(calc);
				case SolverType.DynamicMultiSteps:
					return new DynamicMultiStepsSolver(calc);
				case SolverType.WeightedMultiSteps:
					return new WeightedMultiStepsSolver(calc);
				default:
					throw new InvalidOperationException("What solver type?");
			}
		}
	}


	internal class RunResult
	{
		internal bool IsSuccess { get; }
		internal Direction Direction { get; }
		internal double Penalty { get; }
		private RunResult(bool isSuccess)
		{
			IsSuccess = isSuccess;
		}
		private RunResult(bool isSuccess, KeyValuePair<Direction, double> result)
		{
			IsSuccess = isSuccess;
			Direction = result.Key;
			Penalty = result.Value;
		}
		internal static RunResult OK(KeyValuePair<Direction, double> result) => new RunResult(true, result);
		internal static RunResult Fail => new RunResult(false);
	}
}
