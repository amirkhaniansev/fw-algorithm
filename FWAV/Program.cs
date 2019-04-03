using System;
using System.Linq;
using Algorithm;
using Algorithm.Structures;

namespace FWAV
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Input vertices separeted by comma.");

                var verticesInput = Console.ReadLine();
                var vertices = verticesInput.Split(new[] { ',' })
                    .Select(v => new Vertex
                    {
                        Number = int.Parse(v)
                    })
                    .ToList();

                Console.WriteLine("Input edges separated by comma in this way : v1 -> v2 length");

                var edgesInput = Console.ReadLine();
                var edges = edgesInput.Split(new[] { ',' })
                    .Select(e =>
                    {
                        var input = e.Split(new[] { ' ' });

                        return new Edge
                        {
                            First = new Vertex
                            {
                                Number = int.Parse(input[0])
                            },
                            Second = new Vertex
                            {
                                Number = int.Parse(input[2])
                            },
                            Direction = input[1] == "->" ? EdgeDirection.FromFirstToSecond
                                : input[2] == "<-" ? EdgeDirection.FromSecondToFirst
                                : EdgeDirection.Both,
                            Length = int.Parse(input[3])
                        };
                    })
                    .ToList();

                var verticesCollection = new VerticesCollection(vertices);
                var edgesCollection = new EdgesCollection(verticesCollection, edges);
                
                var graph = new Graph
                {
                    Vertices = verticesCollection,
                    Edges = edgesCollection
                };

                var adjacencyMatrix = new AdjacencyMatrix(graph);
                var algorithm = new FWAlgorithm(adjacencyMatrix);

                var printer = new Action<int, string, dynamic>((c, s, m) =>
                {
                    Console.WriteLine($"{s}{c}:");

                    var color = default(ConsoleColor);

                    const string tab = "\t\t";
                    const string space = "    ";

                    for (var i = 0; i < m.Size; i++)
                    {
                        Console.Write(tab);

                        for (var j = 0; j < m.Size; j++)
                        {
                            color = (ConsoleColor)m[i, j].Color;

                            Console.ForegroundColor = color;
                            Console.Write(m[i, j].Value);
                            Console.ResetColor();
                            Console.Write(space);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                });

                var count = 0;
                while (algorithm.Next())
                {
                    var step = algorithm.LastStep;

                    printer.Invoke(count, "A", step.A);
                    printer.Invoke(count, "B", step.B);
                    count++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
    }
}