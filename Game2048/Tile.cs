using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public class Tile
	{
		public int Value { get; }
		public Position Position { get; }
		public Tile(Position pos, int value)
		{
			Position = pos;
			Value = value;
		}
		public override string ToString()
		{
			return Value + ":" + Position.ToString();
		}
	}
}
