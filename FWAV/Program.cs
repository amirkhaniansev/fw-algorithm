/**
 * MIT License
 * 
 * Copyright (c) 2019 Sevak Amirkhanian
 * 
 * Program
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
using System.Linq;
using Algorithm;
using Algorithm.Structures;

namespace FWAV
{
    /// <summary>
    /// Main class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Entry point 
        /// </summary>
        /// <param name="args">arguments of programm</param>
        static void Main(string[] args)
        {
            try
            {
                // testing algorithm implementation

                Console.WriteLine("Input vertices separeted by comma.");

                // reading vertices input
                var verticesInput = Console.ReadLine();
                var vertices = verticesInput.Split(new[] { ',' })
                    .Select(v => new Vertex
                    {
                        Number = int.Parse(v)
                    })
                    .ToList();

                Console.WriteLine("Input edges separated by comma in this way : v1 -> v2 length");

                // reading edges input
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

                // constructing algoritm-specific structures
                var verticesCollection = new VerticesCollection(vertices);
                var edgesCollection = new EdgesCollection(verticesCollection, edges);

                // constructing graph
                var graph = new Graph
                {
                    Vertices = verticesCollection,
                    Edges = edgesCollection
                };

                // constructing adjacency matrix
                var adjacencyMatrix = new AdjacencyMatrix(graph);

                // constructing algoritm instance
                var algorithm = new FWAlgorithm(adjacencyMatrix);

                // constructing printer for printing algorithm step matrices
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
                            Console.Write(m[i, j].Value.ToString().PadLeft(3));
                            Console.ResetColor();
                            Console.Write(space);
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                });

                // executing algorithm
                var count = 0;
                while (algorithm.Next())
                {
                    var step = algorithm.LastStep;

                    printer.Invoke(count, "A", step.A);
                    printer.Invoke(count, "B", step.B);
                    count++;

                    Console.Read();
                }
            }
            catch (Exception ex)
            {
                // printing exception message
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // finalizing
                Console.WriteLine("Hit <Enter> to close...");
                Console.ReadLine();
                Console.WriteLine("Closing...");
            }
        }
    }
}