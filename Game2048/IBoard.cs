using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public interface IBoard
	{
		int[,] CurrentNumbers { get; }

		int ColumnNumber { get; }
		int RowNumber { get; }

		IBoard DeepCopy();
		void Reset();

		int GetNumber(Position pos);
		void SetNumber(int value, Position pos);
		void SetBlank(Position pos);
		bool ValidatePosition(Position pos);
		bool IsBlank(Position pos);

		IEnumerable<Position> AllSlots();
		Position[] BlankSlots();
		Position[] TakenSlots();
		Position[] Neighbors(Position current);

		int Skewness();
	}

	internal enum CornerEnum
	{
		LeftUp,
		LeftDown,
		RightUp,
		RightDown
	}

	internal static class CornerEnums
	{
		public static CornerEnum[] All => new CornerEnum[]
		{
			CornerEnum.LeftDown, CornerEnum.LeftUp, CornerEnum.RightDown, CornerEnum.RightUp
		};

		public static CornerEnum Default => CornerEnum.LeftDown;
	}

}
