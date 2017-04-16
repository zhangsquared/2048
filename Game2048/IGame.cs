using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2048
{
	public interface IGame
	{
		int Score { get; }
		int[,] CurrentNumbers { get; }
		IBoard InternalBoard { get; }

		IGame DeepCopy();

		void Start();
		void Reset();

		bool Move(Direction dir);
		Task<bool> MoveAsync(Direction dir, CancellationToken token);

		bool PlayerShift(Direction dir);
		void GenerateNextTile();
		bool IsGameOver();
	}
}
