/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * Edge
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
    /// Edge of graph
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Gets or sets first vertex of graph edge.
        /// </summary>
        public Vertex First { get; set; }

        /// <summary>
        /// Gest or sets second vertex of graph edge.
        /// </summary>
        public Vertex Second { get; set; }

        /// <summary>
        /// Gets or sets direction of edge.
        /// </summary>
        public EdgeDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets length of edge.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Checks if the edges are equal.
        /// </summary>
        /// <param name="obj">edge that will be compared</param>
        /// <returns>true, if edges are equal and false, otherwise</returns>
        public override bool Equals(object obj)
        {
            var edge = obj as Edge;

            return this.First == edge.First &&
                   this.Second == edge.Second &&
                   this.Direction == edge.Direction;
        }

        /// <summary>
        /// Gets hashcode of edge.
        /// </summary>
        /// <returns>hashcode of edge.</returns>
        public override int GetHashCode()
        {
            return this.First.GetHashCode() ^ this.Second.GetHashCode();
        }

        /// <summary>
        /// Check if the edges are equal with the given direction.
        /// </summary>
        /// <param name="edge">edge to be compared</param>
        /// <param name="direction">direction</param>
        /// <returns>true, if the edges are equal, false otherwise</returns>
        public bool IsEqual(Edge edge, EdgeDirection? direction = null)
        {
            return this.First == edge.First && 
                this.Second == edge.Second && 
                this.Direction == (direction == null ? edge.Direction : direction);
        }
    }
}