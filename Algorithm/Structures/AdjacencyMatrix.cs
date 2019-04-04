/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * AdjacencyMatrix
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
**/

namespace Algorithm.Structures
{
    /// <summary>
    /// Adjacency matrix for representing graph.
    /// </summary>
    public class AdjacencyMatrix : SquareMatrix<Cell<double>>
    {
        /// <summary>
        /// Collection of graph vertices.
        /// </summary>
        private readonly VerticesCollection vertices;

        /// <summary>
        /// Collection of graph edges.
        /// </summary>
        private readonly EdgesCollection edges;

        /// <summary>
        /// Creates new instance of <see cref="AdjacencyMatrix"/>
        /// </summary>
        /// <param name="graph">graph</param>
        public AdjacencyMatrix(Graph graph) 
            : base(graph.Vertices.Count)
        {
            // setting fields
            this.vertices = graph.Vertices;
            this.edges = graph.Edges;

            // constructing graph adjacency matrix
            this.ConstructAdjacencyMatrix();
        }

        /// <summary>
        /// Construct adjacency matrix for graph from the vertices and edges
        /// </summary>
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