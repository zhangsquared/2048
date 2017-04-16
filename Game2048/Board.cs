using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public class Board : IBoard
	{
		private int[,] numbers;
		public int[,] CurrentNumbers => numbers;
		public int ColumnNumber => numbers.GetLength(1);
		public int RowNumber => numbers.GetLength(0);

		public Board(int number)
		{
			numbers = new int[number, number];
		}
		public Board(int rowNumber, int columnNumber)
		{
			numbers = new int[rowNumber, columnNumber];
		}

		public IBoard DeepCopy()
		{
			Board other = new Board(RowNumber, ColumnNumber);
			for (int r = 0; r < RowNumber; r++)
			{
				for (int c = 0; c < ColumnNumber; c++)
				{
					other.numbers[r, c] = numbers[r, c];
				}
			}
			return other;
		}
		public void Reset()
		{
			for (int r = 0; r < RowNumber; r++)
			{
				for (int c = 0; c < ColumnNumber; c++)
				{
					numbers[r, c] = 0;
				}
			}
		}

		public int GetNumber(Position pos)
		{
			return numbers[pos.RowNum, pos.ColNum];
		}
		public void SetNumber(int value, Position pos)
		{
			numbers[pos.RowNum, pos.ColNum] = value;
		}
		public void SetBlank(Position pos)
		{
			numbers[pos.RowNum, pos.ColNum] = 0;
		}
		public bool ValidatePosition(Position pos)
		{
			return (pos.RowNum >= 0 && pos.RowNum <= ColumnNumber - 1)
				&& (pos.ColNum >= 0 && pos.ColNum <= RowNumber - 1);
		}
		public bool IsBlank(Position pos)
		{
			return GetNumber(pos) == 0;
		}

		private Position[] slots;
		public IEnumerable<Position> AllSlots()
		{
			if (slots == null || slots.Any())
			{
				List<Position> list = new List<Position>();
				for (int x = 0; x < RowNumber; x++)
				{
					for (int y = 0; y < ColumnNumber; y++)
					{
						list.Add(new Position(x, y));
					}
				}
				slots = list.ToArray();
			}
			return slots;
		}
		public Position[] BlankSlots() => AllSlots().Where(x => IsBlank(x)).ToArray();
		public Position[] TakenSlots() => AllSlots().Where(x => !IsBlank(x)).ToArray();

		public Position[] Neighbors(Position current)
		{
			List<Position> neighbors = new List<Position>();
			Position[] pos =
			{
				new Position(current.RowNum, current.ColNum + 1),
				new Position(current.RowNum + 1, current.ColNum),
				new Position(current.RowNum, current.ColNum - 1),
				new Position(current.RowNum - 1, current.ColNum)
			};
			foreach (Position next in pos)
			{
				if (ValidatePosition(next))
				{
					neighbors.Add(next);
				}
			}

			return neighbors.ToArray();
		}


		private int Distance(Position position, CornerEnum cornerDirection)
		{
			switch (cornerDirection)
			{
				case CornerEnum.LeftDown:
					return position.ColNum + RowNumber - 1 - position.RowNum;
				case CornerEnum.LeftUp:
					return position.ColNum + position.RowNum;
				case CornerEnum.RightDown:
					return ColumnNumber - 1 - position.ColNum + RowNumber - 1 - position.RowNum;
				case CornerEnum.RightUp:
					return ColumnNumber - 1 - position.ColNum + position.RowNum;
				default:
					// nothing
					return int.MaxValue;
			}
		}
		private int WeightPerPosition(Position position, CornerEnum cornerDirection)
		{
			return GetNumber(position) * Distance(position, cornerDirection);
		}
		public int Skewness()
		{
			int minSkewness = int.MaxValue;
			foreach(CornerEnum coner in CornerEnums.All)
			{
				int sum = 0;
				foreach(Position pos in TakenSlots())
				{
					sum += WeightPerPosition(pos, coner);
				}
				if(sum < minSkewness)
				{
					minSkewness = sum;
				}
			}
			return minSkewness;
		}

	}

}
