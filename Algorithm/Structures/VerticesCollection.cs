/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * VerticesCollection
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
using System.Collections;
using System.Collections.Generic;

namespace Algorithm.Structures
{
    /// <summary>
    /// Collection of vertices
    /// </summary>
    public class VerticesCollection : IEnumerable<Vertex>
    {
        /// <summary>
        /// Storage for vertices
        /// </summary>
        private readonly HashSet<Vertex> vertices;

        /// <summary>
        /// Gets the count of vertices
        /// </summary>
        public int Count => this.vertices.Count;

        /// <summary>
        /// Creates new instance of <see cref="VerticesCollection"/>
        /// </summary>
        public VerticesCollection()
        {
            this.vertices = new HashSet<Vertex>();
        }

        /// <summary>
        /// Creates new instance of <see cref="VerticesCollection"/> from the source.
        /// </summary>
        /// <param name="source">source of vertices</param>
        public VerticesCollection(IEnumerable<Vertex> source)
        {
            this.vertices = new HashSet<Vertex>(source);
        }

        /// <summary>
        /// Tries to add a new vertex to the collection of vertices.
        /// </summary>
        /// <param name="vertex">vertex that will be added.</param>
        /// <returns>true if vertesx is successfully added, false otherwise.</returns>
        public bool TryAddVertex(Vertex vertex)
        {
            return this.vertices.Add(vertex);
        }

        /// <summary>
        /// Adss vertex to the collection of vertices.
        /// </summary>
        /// <param name="vertex">vertex to be added</param>
        public void AddVertex(Vertex vertex)
        {
            if (!this.TryAddVertex(vertex))
                throw new ArgumentException("Vertex already exists.");
        }

        /// <summary>
        /// Checks if the vertex exists in the collection
        /// </summary>
        /// <param name="vertex">vertex to check</param>
        /// <returns>true, if vertex exists and false, otherwise.</returns>
        public bool Exists(Vertex vertex)
        {
            return this.vertices.Contains(vertex);
        }

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        public IEnumerator<Vertex> GetEnumerator()
        {
            return this.vertices.GetEnumerator();
        }

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}