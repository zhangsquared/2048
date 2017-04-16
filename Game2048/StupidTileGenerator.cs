using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public class StupidTileGenerator : ITileGenerator
	{
		public Tile Generate(Position[] positions)
		{
			return new Tile(GeneratePosition(positions), GenerateValue());
		}

		public int GenerateValue()
		{
			return 2;
			//return 4;
		}

		public Position GeneratePosition(Position[] positions)
		{
			return positions.First();
		}
	}
}
