using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2048;

namespace Solver2048
{
	public class NeighborMergeAndCornerCalculator : IPenaltyCalculator
	{
		public double Calculate(IBoard board, int deltaScore)
		{
			return NeighborPenalty(board) - MergeReward(deltaScore) + SkewnessPenalty(board);
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

		private double MergeReward(int deltaScore)
		{
			return deltaScore * deltaScore;
		}

		private int SkewnessPenalty(IBoard board)
		{
			int res = board.Skewness();
			return res * res * 4;
		}


		public CalculatorType Type => CalculatorType.NeighborMergeAndCorner;
	}
}
