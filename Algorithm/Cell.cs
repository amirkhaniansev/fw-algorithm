namespace Algorithm
{
    public class Cell<TValue>
    {
        public Color Color { get; set; }

        public Point Point { get; set; }

        public TValue Value { get; set; }
    }
}