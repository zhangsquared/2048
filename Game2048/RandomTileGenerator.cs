using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public class RandomTileGenerator : ITileGenerator
	{
		private Random r = new Random();

		public Tile Generate(Position[] positions)
		{
			return new Tile(GeneratePosition(positions), GenerateValue());
		}

		public int GenerateValue()
		{
			const int percentage = 1;
			int val = r.Next(10);
			if (val < percentage) return 4;
			return 2;
		}

		public Position GeneratePosition(Position[] positions)
		{
			int count = positions.Length;
			int index = r.Next(count);
			return positions[index];
		}
	}
}
