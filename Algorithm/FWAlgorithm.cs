using System.Collections.Generic;
using Algorithm.Structures;

namespace Algorithm
{
    public class FWAlgorithm
    {
        private readonly AdjacencyMatrix initialAdjacencyMatrix;

        private readonly List<Step> steps;

        public FWAlgorithm(AdjacencyMatrix initialAdjacencyMatrix)
        {
            this.initialAdjacencyMatrix = initialAdjacencyMatrix;
            this.steps = new List<Step>();

            this.DoFirstStep();
        }

        private void DoFirstStep()
        {
            var firstStep = new Step
            {
                Number = 0,
                A = this.initialAdjacencyMatrix
            };

            firstStep.B = new SupportanceMatrix(this.initialAdjacencyMatrix.Size);

            var size = firstStep.B.Size;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    firstStep.B[i, j] = new Cell
                    {
                        Point = new Point
                        {
                            X = i,
                            Y = j
                        },
                        Color = Color.White,
                        Value = 
                    };
                }
            }
        } 
    }
}
