using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public class Position : IEquatable<Position>
	{
		public int RowNum { get; }
		public int ColNum { get; }

		public Position(int row, int col)
		{
			RowNum = row;
			ColNum = col;
		}

		public override string ToString()
		{
			return "[" + RowNum + "," + ColNum + "]";
		}

		public bool Equals(Position other)
		{
			return RowNum == other.RowNum && ColNum == other.ColNum;
		}
	}
}
