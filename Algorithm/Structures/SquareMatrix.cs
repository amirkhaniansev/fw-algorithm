/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * SquareMatrix
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
    /// Class for modeling square matrix.
    /// </summary>
    /// <typeparam name="T">Type of cell in matrix.</typeparam>
    public class SquareMatrix<T> : Matrix<T>
    {
        /// <summary>
        /// Size of square matrix
        /// </summary>
        private readonly int size;

        /// <summary>
        /// Gets the size of matrix
        /// </summary>
        public int Size => this.size;

        /// <summary>
        /// Creates new instance of <see cref="SquareMatrix{T}"/>
        /// </summary>
        /// <param name="size">size of matrix</param>
        public SquareMatrix(int size) : base(size, size)
        {
            this.size = size;
        }
        
        /// <summary>
        /// Creates new instance of <see cref="SquareMatrix{T}"/> copying the given matrix.
        /// </summary>
        /// <param name="matrix">matrix that will be copied</param>
        public SquareMatrix(SquareMatrix<T> matrix) : this(matrix.size)
        {
            for (var i = 0; i < this.size; i++)
                for (var j = 0; j < this.size; j++)
                    this[i, j] = matrix[i, j];
        }
    }
}