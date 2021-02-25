namespace Sudoku
{
	internal class SudokuCell
	{
		internal bool IsReadOnly { get; set; }
		internal int Number { get; set; }
		internal int Solution { get; set; }

		internal SudokuCell() { }

		internal SudokuCell(SudokuCell cell)
		{
			this.IsReadOnly = cell.IsReadOnly;
			this.Number = cell.Number;
			this.Solution = cell.Solution;
		}
	}
}
