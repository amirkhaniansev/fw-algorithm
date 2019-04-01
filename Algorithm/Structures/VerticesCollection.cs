using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Structures
{
    public class VerticesCollection : IEnumerable<Vertex>
    {
        private readonly HashSet<Vertex> vertices;

        public int Count => this.vertices.Count;

        public VerticesCollection()
        {
            this.vertices = new HashSet<Vertex>();
        }

        public VerticesCollection(IEnumerable<Vertex> source)
        {
            this.vertices = new HashSet<Vertex>(source);
        }

        public bool TryAddVertex(Vertex vertex)
        {
            return this.vertices.Add(vertex);
        }

        public void AddVertex(Vertex vertex)
        {
            if (!this.TryAddVertex(vertex))
                throw new ArgumentException("Vertex already exists.");
        }

        public bool Exists(Vertex vertex)
        {
            return this.vertices.Contains(vertex);
        }

        public IEnumerator<Vertex> GetEnumerator()
        {
            return this.vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}