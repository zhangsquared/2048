using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public enum Direction
	{
		Left, Up, Right, Down
	}

	public static class Directions
	{
		public static Direction[] All
			=> new Direction[] { Direction.Down, Direction.Left, Direction.Up, Direction.Right };

		public static Direction Default => Direction.Down;
	}
}
