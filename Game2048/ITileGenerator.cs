using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
	public interface ITileGenerator
	{
		Tile Generate(Position[] positions);

		int GenerateValue();
		Position GeneratePosition(Position[] positions);
	}
}
