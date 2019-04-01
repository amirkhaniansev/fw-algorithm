using Algorithm;
using Algorithm.Structures;

namespace FWAV
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var inputHelper = new InputHelper();

            inputHelper.StartVerticesInput();
            inputHelper.StartEdgesInput();

            var graph = inputHelper.GetGraph();
            var adjacencyMatrix = new AdjacencyMatrix(graph);
            var algorithm = new FWAlgorithm(adjacencyMatrix);
            
        }
    }
}