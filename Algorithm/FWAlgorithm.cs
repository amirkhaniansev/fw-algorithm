﻿using System.Linq;
using System.Collections.Generic;
using Algorithm.Structures;

namespace Algorithm
{
    public class FWAlgorithm
    {
        private readonly AdjacencyMatrix initialAdjacencyMatrix;

        private readonly List<Step> steps;

        private readonly int count;

        private int current;

        public Step FirstStep => this.steps.FirstOrDefault();

        public Step LastStep => this.steps.LastOrDefault();

        public FWAlgorithm(AdjacencyMatrix initialAdjacencyMatrix)
        {
            this.initialAdjacencyMatrix = initialAdjacencyMatrix;
            this.count = initialAdjacencyMatrix.Size;
            this.current = -1;

            this.steps = new List<Step>(initialAdjacencyMatrix.Size);
        }

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
            
            for(var i = 0; i < this.count; i++)
            {
                for(var j = 0; j < this.count; j++)
                {   
                    if(j == this.current)
                    {
                        step.B[i, j] = lastB[i, j];

                        if(i == this.current)
                        {
                            step.A[i, j] = lastA[i, j]; continue;
                        }
                    }
                    
                    sum = lastA[i, this.current].Value + lastA[this.current, j].Value;

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

                    step.A[i, j] = new Cell<double>(color, lastA[i, j].Point, aValue);
                    step.B[i, j] = new Cell<int>(color, lastB[i, j].Point, bValue);
                }
            }

            this.current++;
            this.steps.Add(step);

            return true;
        }

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