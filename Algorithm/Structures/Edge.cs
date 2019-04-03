namespace Algorithm.Structures
{
    public class Edge
    {
        public Vertex First { get; set; }

        public Vertex Second { get; set; }

        public EdgeDirection Direction { get; set; }

        public double Length { get; set; }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge;

            return this.First == edge.First &&
                   this.Second == edge.Second &&
                   this.Direction == edge.Direction;
        }

        public override int GetHashCode()
        {
            return this.First.GetHashCode() ^ this.Second.GetHashCode();
        }

        public bool IsEqual(Edge edge, EdgeDirection? direction = null)
        {
            return this.First == edge.First && 
                this.Second == edge.Second && 
                this.Direction == (direction == null ? edge.Direction : direction);
        }
    }
}