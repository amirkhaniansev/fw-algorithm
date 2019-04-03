/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * EdgesCollection
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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Algorithm.Structures
{
    public class EdgesCollection : IEnumerable<Edge>
    {
        private readonly HashSet<Edge> edges;

        private readonly VerticesCollection vertices;

        public int Count => this.edges.Count;

        public EdgesCollection(VerticesCollection vertices, IEnumerable<Edge> edges)
        {
            this.vertices = vertices;
            this.edges = new HashSet<Edge>(edges);
        }

        public void AddEdge(Edge edge)
        {
            if (edge == null)
                throw new ArgumentNullException("Edge is null.");

            if (!this.vertices.Exists(edge.First))
                throw new ArgumentException($"Vertex : {edge.First.Number} does not exist.");

            if (!this.vertices.Exists(edge.Second))
                throw new ArgumentException($"Vertex : {edge.Second.Number} does not exist.");

            if (this.edges.Any(e => e.IsEqual(edge)))
                throw new ArgumentException("Edge exists.");

            if (edge.Direction != EdgeDirection.Both)
            {
                var direction = edge.Direction == EdgeDirection.FromFirstToSecond ?
                    EdgeDirection.FromSecondToFirst : EdgeDirection.FromFirstToSecond;
                var oneWayEdge = this.edges.FirstOrDefault(e => e.IsEqual(edge, direction));

                if (oneWayEdge != null)
                {
                    oneWayEdge.Direction = EdgeDirection.Both;
                    return;
                } 
            }

            this.edges.Add(edge);
        }

        public Edge TryGet(Vertex from, Vertex to)
        {
            return this.edges
                .FirstOrDefault(e =>
                    (e.First.Equals(from) && e.Second.Equals(to) && e.Direction == EdgeDirection.FromFirstToSecond) ||
                    (e.First.Equals(from) && e.Second.Equals(to) && e.Direction == EdgeDirection.Both) ||
                    (e.First.Equals(to) && e.Second.Equals(from) && e.Direction == EdgeDirection.Both));
        }

        public IEnumerator<Edge> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}