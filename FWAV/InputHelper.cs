using System;
using System.Linq;
using Algorithm.Structures;

namespace FWAV
{
    class InputHelper
    {
        private VerticesCollection vertices;

        private EdgesCollection edges;
        
        public Graph GetGraph()
        {
            return new Graph
            {
                Vertices = this.vertices,
                Edges = this.edges
            };
        }

        public void StartVerticesInput()
        {
            this.vertices = new VerticesCollection();

            var input = string.Empty;
            var count = 0;
            
            do
            {
                Console.Write($"Vertex[{count++}] = ");

                input = Console.ReadLine();
                
                try
                {
                    var vertex = new Vertex
                    {
                        Number = int.Parse(input)
                    };

                    this.vertices.AddVertex(vertex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Tab);
        }

        public void StartEdgesInput()
        {
            this.edges = new EdgesCollection(this.vertices);

            Console.WriteLine();

            var input = string.Empty;

            do
            {
                try
                {
                    Console.Write("First Vertex : ");
                    input = Console.ReadLine();
                    var vertex0 = this.vertices.First(v => v.Number == int.Parse(input));

                    Console.Write("Second Vertex : ");
                    input = Console.ReadLine();
                    var vertex1 = this.vertices.First(v => v.Number == int.Parse(input));

                    Console.Write("Direction : ");
                    var direction = Console.ReadLine();
                    var dir = direction == "->" ? EdgeDirection.FromFirstToSecond :
                        direction == "<-" ? EdgeDirection.FromSecondToFirst :
                        direction == "<->" ? EdgeDirection.Both : default(EdgeDirection?);

                    Console.Write("Length : ");
                    var length = int.Parse(Console.ReadLine());

                    var edge = new Edge
                    {
                        First = vertex0,
                        Second = vertex1,
                        Direction = dir.Value,
                        Length = length
                    };

                    this.edges.AddEdge(edge);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Tab);
        }
    }
}