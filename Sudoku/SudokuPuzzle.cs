using System;

namespace Sudoku
{
    /// <summary>
    /// Represents a sudoku puzzle.
    /// </summary>
    public class SudokuPuzzle
    {
        /// <summary>
        /// Represents the highest possible number of rows and columns in a <see cref="SudokuPuzzle"/>. This field is constant.
        /// </summary>
        public const int MaxSize = 9;

        private readonly int _BlockSize;
        private readonly SudokuCell[,] _Cells;

        /// <summary>
        /// Gets the number of rows and columns in the <see cref="SudokuPuzzle"/>.
        /// </summary>
        /// <value>The number of rows and columns in the <see cref="SudokuPuzzle"/>.</value>
        public int Size { get; }

        /// <summary>
        /// Gets or sets the number in the specified cell.
        /// </summary>
        /// <param name="row">The zero-based row index of the cell.</param>
        /// <param name="column">The zero-based column index of the cell.</param>
        /// <value>The number contained in the specified cell.</value>
        /// <exception cref="ArgumentOutOfRangeException"><c><paramref name="row"/></c> is less than 0 or greater than or equal to the <see cref="SudokuPuzzle.Size"/> -or- <c><paramref name="column"/></c> is less than 0 or greater than or equal to the <see cref="SudokuPuzzle.Size"/> -or- on a set operation, <c><paramref name="row"/></c> is less than 0 or greater than the <see cref="SudokuPuzzle.Size"/>.</exception>
        public int this[int row, int column]
		{
            get
			{
                this.Check(row, nameof (row));
                this.Check(column, nameof (column));
                return this._Cells[row, column].Number;
			}

            set
            {
                this.Check(row, nameof (row));
                this.Check(column, nameof (column));
                this.Check(value, "value", true);
                SudokuCell cell = this._Cells[row, column];

                if (cell.IsReadOnly)
				{
                    throw new SudokuCellReadOnlyException(row, column, value);
				}

                cell.Number = value;
            }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuPuzzle"/> class that is empty and contains the specified number of rows and columns.
        /// </summary>
        /// <param name="size">The specified number of rows and columns. This must be a positive square integer.</param>
        /// <exception cref="ArgumentException"><c><paramref name="size"/></c> is not a positive square integer.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><c><paramref name="size"/></c> is less than or equal to 0 or greater than <see cref="SudokuPuzzle.MaxSize"/>.</exception>
        public SudokuPuzzle(int size)
		{
            if (size <= 0 || size > SudokuPuzzle.MaxSize)
			{
                throw new ArgumentOutOfRangeException(nameof (size));
			}

            double sqrt = Math.Sqrt(size);

            if (sqrt != Math.Floor(sqrt))
			{
                throw new ArgumentException(nameof (size));
			}

            this._BlockSize = (int) sqrt;
            this._Cells = new SudokuCell[size, size];
            this.Size = size;

            for (int i = 0; i < size; i ++)
			{
                for (int j = 0; j < size; j ++)
				{
                    this._Cells[i, j] = new SudokuCell();
				}
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="SudokuPuzzle"/> class using numbers copied from the specified puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle to copy.</param>
        /// <exception cref="ArgumentNullException"><c><paramref name="puzzle"/></c> is <c>null</c>.</exception>
        public SudokuPuzzle(SudokuPuzzle puzzle)
		{
            if (puzzle is null)
			{
                throw new ArgumentOutOfRangeException(nameof (puzzle));
			}

            this._BlockSize = puzzle._BlockSize;
            this._Cells = new SudokuCell[puzzle.Size, puzzle.Size];
            this.Size = puzzle.Size;

            for (int i = 0; i < this.Size; i ++)
			{
                for (int j = 0; j < this.Size; j ++)
				{
                    this._Cells[i, j] = new SudokuCell(puzzle._Cells[i, j]);
				}
			}
		}

        private void Check(int arg, String name, bool ignoreUpper = false)
		{
            if (arg < 0 || arg > this.Size || !ignoreUpper && arg == this.Size)
			{
                throw new ArgumentOutOfRangeException(name);
			}
		}

        /// <summary>
        /// Verifies the specified number of rows and columns is permitted for a <see cref="SudokuPuzzle"/>.
        /// </summary>
        /// <param name="size">The number of rows and columns to verify.</param>
        /// <returns><c>true</c> if <c><paramref name="size"/></c> is permissible; otherwise, <c>false</c>.</returns>
        public static bool VerifySize(int size)
		{
            if (size <= 0 || size > SudokuPuzzle.MaxSize)
			{
                return false;
			}

            double sqrt = Math.Sqrt(size);
            return sqrt == Math.Floor(sqrt);
		}
    }
}
