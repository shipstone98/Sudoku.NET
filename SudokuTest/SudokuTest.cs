using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku;

namespace SudokuTest
{
    [TestClass]
    public class SudokuTest
    {
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
        public void TestConstructor_ValidSizes()
        {
            new SudokuPuzzle(1);
            new SudokuPuzzle(SudokuPuzzle.MaxSize);
        }

        [TestMethod]
        public void TestConstructor_ZeroSize() => Assert.ThrowsException<ArgumentOutOfRangeException>(() => new SudokuPuzzle(0));
    }
}
