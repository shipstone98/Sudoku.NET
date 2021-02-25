using System;

namespace Sudoku
{
	/// <summary>
	/// Represents the error that is thrown when an attempt to modify the number in a read-only cell in a <see cref="SudokuPuzzle"/> is made.
	/// </summary>
	public class SudokuCellReadOnlyException : Exception
	{
		/// <summary>
		/// Gets the column index of the cell the attempt was made at.
		/// </summary>
		/// <value>The zero-based column index of the cell the attempt was made at.</value>
		public int Column { get; }

		/// <summary>
		/// Gets the number the cell was attempted to be set to.
		/// </summary>
		/// <value>The number the cell was attempted to be set to.</value>
		public int Number { get; }

		/// <summary>
		/// Gets the row index of the cell the attempt was made at.
		/// </summary>
		/// <value>The zero-based row index of the cell the attempt was made at.</value>
		public int Row { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="SudokuCellReadOnlyException"/> class with the specified attempt data.
		/// </summary>
		/// <param name="row">The zero-based row index of the cell the attempt was made at.</param>
		/// <param name="column">The zero-based column index of the cell the attempt was made at.</param>
		/// <param name="n">The number the cell was attempted to be set to.</param>
		public SudokuCellReadOnlyException(int row, int column, int n) : this(row, column, n, null) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SudokuCellReadOnlyException"/> class with the specified attempt data and a specified error message.
		/// </summary>
		/// <param name="row">The zero-based row index of the cell the attempt was made at.</param>
		/// <param name="column">The zero-based column index of the cell the attempt was made at.</param>
		/// <param name="n">The number the cell was attempted to be set to.</param>
		/// <param name="message">The message that describes the error.</param>
		public SudokuCellReadOnlyException(int row, int column, int n, String message) : this(row, column, n, message, null) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SudokuCellReadOnlyException"/> class with the specified attempt data, a specified error message, and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="row">The zero-based row index of the cell the attempt was made at.</param>
		/// <param name="column">The zero-based column index of the cell the attempt was made at.</param>
		/// <param name="n">The number the cell was attempted to be set to.</param>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference (<c>Nothing</c> in Visual Basic) if no inner exception is specified.</param>
		public SudokuCellReadOnlyException(int row, int column, int n, String message, Exception innerException) : base(message, innerException)
		{
			if (row < 0)
			{
				throw new ArgumentOutOfRangeException(nameof (row));
			}

			if (column < 0)
			{
				throw new ArgumentOutOfRangeException(nameof (column));
			}

			if (n < 0)
			{
				throw new ArgumentOutOfRangeException(nameof (n));
			}

			this.Column = column;
			this.Number = n;
			this.Row = row;
		}
	}
}
