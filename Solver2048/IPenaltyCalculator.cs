using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	public interface IPenaltyCalculator
	{
		double Calculate(IBoard board, int deltaScore);
		CalculatorType Type { get; }
	}

	public enum CalculatorType
	{
		Neighbor,
		NeighborAndMerge,
		NeighborMergeAndCorner
	}

	public static class CalculatorFactory
	{
		public static IPenaltyCalculator Generate(CalculatorType type)
		{
			switch (type)
			{
				case CalculatorType.Neighbor:
					return new NeighborPenaltyCalculator();
				case CalculatorType.NeighborAndMerge:
					return new NeighborAndMergeCalculator();
				case CalculatorType.NeighborMergeAndCorner:
					return new NeighborMergeAndCornerCalculator();
				default:
					throw new InvalidOperationException("What Penalty Calculator type?");
			}
		}
	}

}
