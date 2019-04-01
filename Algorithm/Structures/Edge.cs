namespace Algorithm.Structures
{
    public class Edge
    {
        public Vertex First { get; set; }

        public Vertex Second { get; set; }

        public EdgeDirection Direction { get; set; }

        public decimal Length { get; set; }        

        public bool IsEqual(Edge edge, EdgeDirection? direction = null)
        {
            return this.First == edge.First && 
                this.Second == edge.Second && 
                this.Direction == (direction == null ? edge.Direction : direction);
        }
    }
}