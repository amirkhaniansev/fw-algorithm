/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * FWAlgorithm
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

using System.Linq;
using System.Collections.Generic;
using Algorithm.Structures;

namespace Algorithm
{
    /// <summary>
    /// Floyd-Warshall algorithm implementation.
    /// </summary>
    public class FWAlgorithm
    {
        /// <summary>
        /// Adjacency matrix of graph
        /// </summary>
        private readonly AdjacencyMatrix initialAdjacencyMatrix;

        /// <summary>
        /// Steps of algorithm
        /// </summary>
        private readonly List<Step> steps;

        /// <summary>
        /// Count of algorithm steps
        /// </summary>
        private readonly int count;

        /// <summary>
        /// Count step counter
        /// </summary>
        private int current;

        /// <summary>
        /// Gets first step of algorithm
        /// </summary>
        public Step FirstStep => this.steps.FirstOrDefault();

        /// <summary>
        /// Gets last step of algorithm
        /// </summary>
        public Step LastStep => this.steps.LastOrDefault();

        /// <summary>
        /// Creates new instance of <see cref="FWAlgorithm"/>
        /// </summary>
        /// <param name="initialAdjacencyMatrix">adjacency matrix for graph</param>
        public FWAlgorithm(AdjacencyMatrix initialAdjacencyMatrix)
        {
            // setting fields
            this.initialAdjacencyMatrix = initialAdjacencyMatrix;
            this.count = initialAdjacencyMatrix.Size;
            this.current = -1;

            // initializing steps
            this.steps = new List<Step>(initialAdjacencyMatrix.Size);
        }

        /// <summary>
        /// Does the next step of algorithm.
        /// </summary>
        /// <returns>true, if there is still steps to do and false, otherwise.</returns>
        public bool Next()
        {
            if(this.current == -1)
            {
                this.DoFirstStep();
                return true;
            }

            if (this.current == this.count)
                return false;

            var step = this.CreateStep();
            var lastA = this.LastStep.A;
            var lastB = this.LastStep.B;
            var sum = default(double);
            var aValue = default(double);
            var bValue = default(int);
            var color = default(Color);
            
            // starting iteration
            // the complexity of every step is:
            // O(|V| ^ 2) where V = {v0, v1, ... , vn} set of vertices for G graph
            for(var i = 0; i < this.count; i++)
            {
                for(var j = 0; j < this.count; j++)
                {   
                    // skipping fixed column
                    if(j == this.current)
                    {
                        step.B[i, j] = lastB[i, j];

                        // skipping fixed row
                        if(i == this.current)
                        {
                            step.A[i, j] = lastA[i, j]; continue;
                        }
                    }
                    
                    // counting the sum of fixed cell
                    sum = lastA[i, this.current].Value + lastA[this.current, j].Value;
                    
                    // setting value
                    if(lastA[i, j].Value > sum)
                    {
                        aValue = sum;
                        bValue = lastB[i, this.current].Value;
                        color = Color.Red;
                    }
                    else
                    {
                        aValue = lastA[i, j].Value;
                        bValue = lastB[i, j].Value;
                        color = Color.White;
                    }

                    // initializing cells
                    step.A[i, j] = new Cell<double>(color, lastA[i, j].Point, aValue);
                    step.B[i, j] = new Cell<int>(color, lastB[i, j].Point, bValue);
                }
            }

            // incrementing algorithm step counter
            this.current++;

            // adding step
            this.steps.Add(step);

            return true;
        }

        /// <summary>
        /// Initializes algorithm doing the first step.
        /// </summary>
        private void DoFirstStep()
        {
            var firstStep = this.CreateStep();

            for (var i = 0; i < this.count; i++)
            {
                for (var j = 0; j < this.count; j++)
                {
                    firstStep.A[i, j] = this.initialAdjacencyMatrix[i, j];
                    firstStep.B[i, j] = new Cell<int>(Color.White, new Point(i, j), j + 1);
                }
            }
            
            this.current++;
            this.steps.Add(firstStep);
        }
        
        /// <summary>
        /// Creates step for algorithm
        /// </summary>
        /// <returns>step</returns>
        private Step CreateStep()
        {
            return new Step
            {
                Number = 0,
                A = new SquareMatrix<Cell<double>>(this.count),
                B = new SquareMatrix<Cell<int>>(this.count)
            };
        }
    }
}