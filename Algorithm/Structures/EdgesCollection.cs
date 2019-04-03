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
            return this.edges.FirstOrDefault(e => 
                     e.First.Equals(from) &&
                     e.Second.Equals(to) &&
                     (e.Direction == EdgeDirection.FromFirstToSecond || e.Direction == EdgeDirection.Both));
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