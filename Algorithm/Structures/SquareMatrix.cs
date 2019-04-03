namespace Algorithm.Structures
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly int size;

        public int Size => this.size;

        public SquareMatrix(int size) : base(size, size)
        {
            this.size = size;
        }
        
        public SquareMatrix(SquareMatrix<T> matrix) : this(matrix.size)
        {
            for (var i = 0; i < this.size; i++)
                for (var j = 0; j < this.size; j++)
                    this[i, j] = matrix[i, j];
        }
    }
}