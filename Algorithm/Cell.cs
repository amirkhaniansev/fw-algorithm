namespace Algorithm
{
    public class Cell<TValue>
    {
        public Color Color { get; set; }

        public Point Point { get; set; }

        public TValue Value { get; set; }

        public Cell(Color color, Point point, TValue value)
        {
            this.Color = color;
            this.Point = point;
            this.Value = value;
        }
    }
}