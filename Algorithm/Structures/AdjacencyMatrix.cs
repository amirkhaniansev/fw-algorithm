namespace Algorithm.Structures
{
    public class AdjacencyMatrix : SquareMatrix<Cell>
    {
        private readonly VerticesCollection vertices;

        private readonly EdgesCollection edges;

        public AdjacencyMatrix(VerticesCollection vertices, EdgesCollection edges) 
            : base(vertices.Count)
        {
            this.vertices = vertices;
            this.edges = edges;

            this.ConstructAdjacencyMatrix();
        }

        private void ConstructAdjacencyMatrix()
        {
            var i = 0;
            var j = 0;
            var edge = new Edge();

            foreach(var v0 in this.vertices)
            {
                foreach(var v1 in this.vertices)
                {
                    edge = this.edges.TryGet(v0, v1);

                    var cell = new Cell
                    {
                        Point = new Point
                        {
                            X = i,
                            Y = j
                        },
                        Color = Color.White
                    };

                    cell.Value = v0 == v1 ? 0M : edge == null ? default(decimal?) : edge.Length;

                    this[i, j++] = cell;
                }

                i++;
            }
        }
    }
}