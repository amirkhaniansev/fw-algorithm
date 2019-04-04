/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * Cell
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

namespace Algorithm
{
    /// <summary>
    /// Class for modeling the cell in graph representation matrices.
    /// </summary>
    /// <typeparam name="TValue">Type of cell value</typeparam>
    public class Cell<TValue>
    {
        /// <summary>
        /// Gets or sets color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Gets or sets point
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// Gets or sets value
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Creates new instance of <see cref="Cell{TValue}"/>
        /// </summary>
        /// <param name="color">color of cell</param>
        /// <param name="point">point of cell</param>
        /// <param name="value">value of cell</param>
        public Cell(Color color, Point point, TValue value)
        {
            // setting properties of cell
            this.Color = color;
            this.Point = point;
            this.Value = value;
        }
    }
}