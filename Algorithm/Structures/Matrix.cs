namespace Algorithm.Structures
{
    public class Matrix<T>
    {
        private readonly T[][] baseMatrix;

        private readonly int countOfRows;

        private readonly int countOfColumns;

        public Matrix(int countOfRows, int countOfColumns)
        {
            this.countOfRows = countOfRows;
            this.countOfColumns = countOfColumns;

            this.baseMatrix = new T[countOfRows][];
            for (var i = 0; i < countOfRows; i++)
                this.baseMatrix[i] = new T[countOfColumns];
        }

        public bool IsSquare()
        {
            return this.countOfRows == this.countOfColumns;
        }

        public T this[int rowNumber, int columnNumber]
        {
            get => this.baseMatrix[rowNumber][columnNumber];

            set => this.baseMatrix[rowNumber][columnNumber] = value;
        }
    }
}