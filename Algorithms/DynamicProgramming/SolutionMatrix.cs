using System.Net;

namespace Algorithms.DynamicProgramming
{
    public class SolutionMatrix
    {
        private int _numberOfRows;
        private int _numberOfColumns;
        public int[,] Matrix { get; private set; }

        public SolutionMatrix(int rows, int columns)
        {
            Matrix = new int[rows,columns];
            _numberOfColumns = columns;
            _numberOfRows = rows;
        }

        public void UpdateValue(int row, int column, int value)
        {
            Matrix[row, column] = value;
        }

        public int GetRowGivenValueAndColumn(int value, int column)
        {
            int returnValue = 0;
            for (int row = _numberOfRows - 1; row > 0 ; row--)
            {
                if (Matrix[row, column] == value)
                {
                    returnValue = row;
                }
            }

            return returnValue;
        }
    }
}