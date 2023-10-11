class Chessboard
{
	private int _size;
	private bool[,] _board;

	public Chessboard(int size)
	{
		this._size = size;
		this._board = new bool[size, size];
	}

	public bool PlaceQueens(int Y)
	{
		if (Y >= this._size)
		{
			return true;
		}

		for (int X = 0; X < this._size; X++)
		{
			if (IsSafe(X, Y))
			{
				this._board[X, Y] = true;

				if (PlaceQueens(Y + 1))
				{
					return true;
				}

				this._board[X, Y] = false;
			}
		}

		return false;
	}

	private bool IsSafe(int row, int column)
	{
		for (int Y = 0; Y < column; Y++)
		{
			if (this._board[row, Y])
			{
				return false;
			}

			for (int X = 0; X < this._size; X++)
			{
				bool rowDiff = row - X == column - Y;
				bool columnDiff = row - X == Y - column;

				if (this._board[X, Y] && (rowDiff || columnDiff))
				{
					return false;
				}
			}
		}

		return true;
	}


	public void PrintBoard()
	{
		string[] rowText = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
		string[] rowColumn = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };

		for (int X = 0; X < this._size; X++)
		{
			Console.Write(rowColumn[X] + " ");
			for (int Y = 0; Y < this._size; Y++)
			{
				if (this._board[X, Y])
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write("♛ ");
					Console.ResetColor();
				}
				else
				{
					if (X % 2 == Y % 2)
					{
						Console.ForegroundColor = ConsoleColor.Black;
						Console.Write("▢ ");
						Console.ResetColor();
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("▢ ");
						Console.ResetColor();
					}
				}
			}
			Console.WriteLine();
		}

		Console.Write("  ");
		for (int index = 0; index < this._size; index++)
		{
			Console.Write(rowText[index] + " ");
		}
	}

}

class Program
{
	static void Main()
	{
		int boardSize = 8;

		Chessboard chessboard = new(boardSize);

		Console.WriteLine("Шахматна доска:\n");
		//              начинать с A1
		chessboard.PlaceQueens(0);
		chessboard.PrintBoard();

		Console.WriteLine();
	}
}
