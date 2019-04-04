/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * Matrix
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
    /// Structure for representing generic matrix.
    /// </summary>
    /// <typeparam name="T">Type of cell in matrix.</typeparam>
    public class Matrix<T>
    {
        /// <summary>
        /// Storage for matrix
        /// </summary>
        private readonly T[][] baseMatrix;

        /// <summary>
        /// Count of rows
        /// </summary>
        private readonly int countOfRows;

        /// <summary>
        /// Count of columnss
        /// </summary>
        private readonly int countOfColumns;

        /// <summary>
        /// Creates new instance of <see cref="Matrix{T}"/>
        /// </summary>
        /// <param name="countOfRows">count of rows</param>
        /// <param name="countOfColumns">count of columns</param>
        public Matrix(int countOfRows, int countOfColumns)
        {
            this.countOfRows = countOfRows;
            this.countOfColumns = countOfColumns;

            this.baseMatrix = new T[countOfRows][];
            for (var i = 0; i < countOfRows; i++)
                this.baseMatrix[i] = new T[countOfColumns];
        }

        /// <summary>
        /// Checks if the matrix is square matrix.
        /// </summary>
        /// <returns>true if matrix is square, false otherwise.</returns>
        public bool IsSquare()
        {
            return this.countOfRows == this.countOfColumns;
        }

        /// <summary>
        /// Gets the cell of matrix.
        /// </summary>
        /// <param name="rowNumber">number of row</param>
        /// <param name="columnNumber">number of column</param>
        /// <returns>cell of matrix</returns>
        public T this[int rowNumber, int columnNumber]
        {
            get => this.baseMatrix[rowNumber][columnNumber];

            set => this.baseMatrix[rowNumber][columnNumber] = value;
        }
    }
}