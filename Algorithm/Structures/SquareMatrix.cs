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
    }
}