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