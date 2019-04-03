namespace Algorithm.Structures
{
    public class AdjacencyMatrix : SquareMatrix<Cell<double>>
    {
        private readonly VerticesCollection vertices;

        private readonly EdgesCollection edges;

        public AdjacencyMatrix(Graph graph) 
            : base(graph.Vertices.Count)
        {
            this.vertices = graph.Vertices;
            this.edges = graph.Edges;

            this.ConstructAdjacencyMatrix();
        }

        private void ConstructAdjacencyMatrix()
        {
            var i = 0;
            var j = 0;
            var length = 0D;
            var edge = new Edge();

            foreach(var v0 in this.vertices)
            {
                j = 0;
                foreach(var v1 in this.vertices)
                {
                    edge = this.edges.TryGet(v0, v1);

                    length = v0 == v1 ? 0D : edge == null ? double.PositiveInfinity : edge.Length;
                    var cell = new Cell<double>(Color.White, new Point(i, j), length);

                    this[i, j++] = cell;
                }

                i++;
            }
        }
    }
}