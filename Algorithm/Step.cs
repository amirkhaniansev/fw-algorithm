using Algorithm.Structures;

namespace Algorithm
{
    public class Step
    {
        public int Number { get; set; }

        public SquareMatrix<Cell<double>> A { get; set; }

        public SquareMatrix<Cell<int>> B { get; set; }
    }
}