using System.Net;

namespace Algorithms.DynamicProgramming
{
    public class SolutionMatrix
    {
        private int[,] _matrix;

        public SolutionMatrix(int rows, int columns)
        {
            _matrix = new int[rows,columns];
        }

        public void UpdateValue(int row, int column, int value)
        {
            _matrix[row, column] = value;
        }

        public int GetValue(int row, int column)
        {
            return _matrix[row, column];
        }

    }
}