using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	internal class NeighborPenaltyCalculator : IPenaltyCalculator
	{
		public double Calculate(IBoard board, int deltaScore)
		{
			return NeighborPenalty(board);
		}

		private double NeighborPenalty(IBoard board)
		{
			double penalty = 0.0;
			foreach (Position current in board.AllSlots())
			{
				foreach (Position neighbor in board.Neighbors(current))
				{
					int diff = board.GetNumber(neighbor) - board.GetNumber(current);
					penalty += diff * diff;
				}
			}
			return penalty;
		}

		public CalculatorType Type => CalculatorType.Neighbor;
	}
}
