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

        public Step FirstStep
        {
            get; set;
        }

        public Step LastStep
        {
            get; set;
        }

        public FWAlgorithm(AdjacencyMatrix initialAdjacencyMatrix)
        {
            this.initialAdjacencyMatrix = initialAdjacencyMatrix;
            this.count = initialAdjacencyMatrix.Size;
            this.steps = new List<Step>(initialAdjacencyMatrix.Size);

            this.DoFirstStep();
        }

        public bool Next()
        {
            if (this.current == this.count - 1)
                return false;


            return false;
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
                    firstStep.B[i, j] = new Cell<int>
                    {
                        Point = new Point
                        {
                            X = i,
                            Y = j
                        },
                        Color = Color.White,
                        Value = j
                    };
                }
            }

            this.FirstStep = this.LastStep = firstStep;
            this.steps.Add(firstStep);
            this.current++;
        } 
    }
}
