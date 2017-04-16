using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public static class SeedGenerator
	{
		public static void Generate(IBoard board)
		{
			int[] inputSeeds = seed4;

			int index = 0;
			for (int i = 0; i < board.RowNumber; i++)
			{
				for (int j = 0; j < board.ColumnNumber; j++)
				{
					board.CurrentNumbers[i, j] = inputSeeds[index];
					index++;
				}
			}
		}

		private static readonly int[] seed0 =
		{
			32, 16, 8, 4,
			128, 32, 4, 0,
			512, 8, 4, 0,
			2048, 2, 0, 2
		};
		private static readonly int[] seed1 = 
		{
			4, 2, 2, 0,
			4, 2, 0, 0,
			4, 0, 0, 0,
			2, 0, 0, 2
		};
		private static readonly int[] seed3 =
		{
			0, 0, 0, 0,
			0, 0, 0, 0,
			0, 0, 0, 2,
			4, 4, 2, 0
		};

		private static readonly int[] seed4 =
		{
			0, 0, 0, 0,
			4, 2, 0, 0,
			32, 8, 0, 0,
			1024, 512, 256, 128
		};
	}
}
