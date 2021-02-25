using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku;

namespace SudokuTest
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void TestConstructor_EmptyPuzzle()
        {
            SudokuPuzzle puzzle = new SudokuPuzzle(new SudokuPuzzle(SudokuPuzzle.MaxSize));
            Assert.AreEqual(SudokuPuzzle.MaxSize, puzzle.Size);

            for (int i = 0; i < puzzle.Size; i ++)
			{
                for (int j = 0; j < puzzle.Size; j ++)
				{
                    Assert.AreEqual(0, puzzle[i, j]);
				}
			}
        }

        [TestMethod]
        public void TestConstructor_InvalidSizes()
        {
            Assert.ThrowsException<ArgumentException>(() => new SudokuPuzzle(2));
            Assert.ThrowsException<ArgumentException>(() => new SudokuPuzzle(SudokuPuzzle.MaxSize - 1));
        }

        [TestMethod]
        public void TestConstructor_MaximumSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(Int32.MaxValue));

        [TestMethod]
        public void TestConstructor_MaximumPossibleSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(SudokuPuzzle.MaxSize + 1));

        [TestMethod]
        public void TestConstructor_MinimumSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(Int32.MinValue));

        [TestMethod]
        public void TestConstructor_NegativeOneSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(-1));

        [TestMethod]
        public void TestConstructor_NullPuzzle() => Assert.ThrowsException<ArgumentNullException>(() => new SudokuPuzzle(null));

        [TestMethod]
        public void TestConstructor_ValidPuzzle()
		{
            Random random = new Random();
            SudokuPuzzle oldPuzzle = new SudokuPuzzle(SudokuPuzzle.MaxSize);

            for (int i = 0; i < oldPuzzle.Size; i ++)
			{
                for (int j = 0; j < oldPuzzle.Size; j ++)
				{
                    oldPuzzle[i, j] = random.Next(oldPuzzle.Size) + 1;
				}
			}

            SudokuPuzzle newPuzzle = new SudokuPuzzle(oldPuzzle);
            Assert.AreEqual(oldPuzzle.Size, newPuzzle.Size);

            for (int i = 0; i < newPuzzle.Size; i ++)
			{
                for (int j = 0; j < newPuzzle.Size; j ++)
				{
                    Assert.AreEqual(oldPuzzle[i, j], newPuzzle[i, j]);
				}
			}
		}

        [TestMethod]
        public void TestConstructor_ValidSizes()
        {
            new SudokuPuzzle(1);
            new SudokuPuzzle(SudokuPuzzle.MaxSize);
        }

        [TestMethod]
        public void TestConstructor_ZeroSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(0));
    }
}
