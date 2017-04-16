using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2048
{
	public class Game : IGame
	{
		private IBoard board;
		private ITileGenerator tileGenerator;

		public int Score { get; private set; }
		public int[,] CurrentNumbers => board.CurrentNumbers;
		public IBoard InternalBoard => board;

		public Game(IBoard board, ITileGenerator generator)
		{
			this.board = board ?? throw new ArgumentNullException();
			tileGenerator = generator ?? throw new ArgumentNullException();
			Score = 0;
		}

		public IGame DeepCopy()
		{
			IBoard eBoard = board.DeepCopy();
			Game other = new Game(eBoard, tileGenerator);
			return other;
		}
		public void Start()
		{
			GenerateNextTile();
			GenerateNextTile();

			//SeedGenerator.Generate(board);
		}

		public void Reset()
		{
			Score = 0;
			board.Reset();
		}

		public bool Move(Direction dir)
		{
			if(PlayerShift(dir) && HasAvailableSlot)
			{
				GenerateNextTile();
			}
			return IsGameOver();
		}

		public Task<bool> MoveAsync(Direction dir, CancellationToken token)
		{
			return Task.Run(() => Move(dir), token);
		}

		public bool PlayerShift(Direction dir)
		{
			bool hasChanged = false;
			switch (dir)
			{
				case Direction.Left:
					for (int row = 0; row < board.RowNumber; row++)
					{
						for (int col = 0; col < board.ColumnNumber; col++)
						{
							hasChanged |= AddUp(Direction.Left, new Position(row, col));
						}
					}
					for (int row = 0; row < board.RowNumber; row++)
					{
						for (int col = 0; col < board.ColumnNumber; col++)
						{
							hasChanged |= Shift(Direction.Left, new Position(row, col));
						}
					}
					break;
				case Direction.Up:
					for (int col = 0; col < board.ColumnNumber; col++)
					{
						for (int row = 0; row < board.RowNumber; row++)
						{
							hasChanged |= AddUp(Direction.Up, new Position(row, col));
						}
					}
					for (int col = 0; col < board.ColumnNumber; col++)
					{
						for (int row = 0; row < board.RowNumber; row++)
						{
							hasChanged |= Shift(Direction.Up, new Position(row, col));
						}
					}
					break;
				case Direction.Right:
					for (int row = 0; row < board.RowNumber; row++)
					{
						for (int col = board.ColumnNumber - 1; col >= 0; col--)
						{
							hasChanged |= AddUp(Direction.Right, new Position(row, col));
						}
					}
					for (int row = 0; row < board.RowNumber; row++)
					{
						for (int col = board.ColumnNumber - 1; col >= 0; col--)
						{
							hasChanged |= Shift(Direction.Right, new Position(row, col));
						}
					}
					break;
				case Direction.Down:
					for (int col = 0; col < board.ColumnNumber; col++)
					{
						for (int row = board.RowNumber - 1; row >= 0; row--)
						{
							hasChanged |= AddUp(Direction.Down, new Position(row, col));
						}
					}
					for (int col = 0; col < board.ColumnNumber; col++)
					{
						for (int row = board.RowNumber - 1; row >= 0; row--)
						{
							hasChanged |= Shift(Direction.Down, new Position(row, col));
						}
					}
					break;
				default:
					// nothing
					break;
			}
			return hasChanged;
		}
		private bool AddUp(Direction dir, Position currentPosition)
		{
			if (board.IsBlank(currentPosition)) return false;

			Position next = NextPosition(dir, currentPosition);
			while (board.ValidatePosition(next))
			{
				if (!board.IsBlank(next)) break;
				next = NextPosition(dir, next);
			}
			if (!board.ValidatePosition(next)) return false;

			if (board.GetNumber(currentPosition) == board.GetNumber(next))
			{
				Score += board.GetNumber(next);
				board.SetNumber(board.GetNumber(currentPosition) + board.GetNumber(next), currentPosition);
				board.SetBlank(next);
				return true;
			}
			return false;
		}
		private bool Shift(Direction dir, Position currentPosition)
		{
			if (!board.IsBlank(currentPosition)) return false;

			Position next = NextPosition(dir, currentPosition);
			while (board.ValidatePosition(next))
			{
				if (!board.IsBlank(next)) break;
				next = NextPosition(dir, next);
			}
			if (board.ValidatePosition(next))
			{
				board.SetNumber(board.GetNumber(next), currentPosition);
				board.SetBlank(next);
				return true;
			}
			return false;
		}
		private Position NextPosition(Direction dir, Position pos)
		{
			switch (dir)
			{
				case Direction.Left:
					return new Position(pos.RowNum, pos.ColNum + 1);
				case Direction.Up:
					return new Position(pos.RowNum + 1, pos.ColNum);
				case Direction.Right:
					return new Position(pos.RowNum, pos.ColNum - 1);
				case Direction.Down:
					return new Position(pos.RowNum - 1, pos.ColNum);
				default:
					throw new InvalidOperationException();
			}
		}

		private bool HasAvailableSlot => board.BlankSlots().Length > 0;
		public void GenerateNextTile()
		{
			Position[] blanks = board.BlankSlots();
			Tile tile = tileGenerator.Generate(blanks);
			board.SetNumber(tile.Value, tile.Position);
		}

		public bool IsGameOver()
		{
			if (HasAvailableSlot) return false;
			IGame other = DeepCopy();
			if (other.PlayerShift(Direction.Left)) return false;
			other = DeepCopy();
			if (other.PlayerShift(Direction.Up)) return false;
			other = DeepCopy();
			if (other.PlayerShift(Direction.Right)) return false;
			other = DeepCopy();
			if (other.PlayerShift(Direction.Down)) return false;
			return true;
		}
	}
}
