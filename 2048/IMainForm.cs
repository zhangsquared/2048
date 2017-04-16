using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048.Skins;
using Game2048;

namespace _2048
{
	public interface IMainForm
	{
		event EventHandler<DirectionEventArgs> OnPlayerKeyDown;
		event EventHandler AutoStart;
		event EventHandler AutoStop;
		event EventHandler ResetAll;
		event EventHandler OneStep;

		void InitTiles(int[,] data, ISkin skin);
		void ShowMessage(string msg);

		int[,] Data { set; }
		int Score { set; }

	}

	public class DirectionEventArgs : EventArgs
	{
		public Direction Direction { get; }
		public DirectionEventArgs(Direction dir)
		{
			Direction = dir;
		}
	}
}
