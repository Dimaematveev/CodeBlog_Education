using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Vertex[] vertices = new Vertex[]
            {
                new Vertex(1),
                new Vertex(2),
                new Vertex(3),
                new Vertex(4),
                new Vertex(5),
                new Vertex(6),
                new Vertex(7),
            };
            Edge[] edges = new Edge[]
            {
             new Edge(vertices[0],vertices[1],15),  
             new Edge(vertices[0],vertices[2],7),  
             new Edge(vertices[1],vertices[3],8),  
             new Edge(vertices[1],vertices[4],3),  
             new Edge(vertices[2],vertices[5],4),  
             new Edge(vertices[3],vertices[4],1),  
             new Edge(vertices[4],vertices[3],1),  
            };
            var graph1 = new Graph();
            graph1.AddVertex(vertices);
            graph1.AddEdge(edges);

            ConsoleWriteGraphMatrix(graph1);

            Console.WriteLine();

            foreach (var item in vertices)
            {
                ConsoleWriteGraphVertexList(graph1, item);
            }
            Console.WriteLine();
            ConsoleWriteFromTo(graph1.Wave1,vertices[0], vertices[5]);
            Console.WriteLine();
            ConsoleWriteFromTo(graph1.Wave1,vertices[0], vertices[6]);
            Console.WriteLine();
            ConsoleWriteFromTo(graph1.Deep, vertices[0], vertices[5]);
            Console.ReadKey();
        }
        private static void ConsoleWriteFromTo(Func<Vertex,Vertex, List<Vertex>> function, Vertex from, Vertex to)
        {
            Console.WriteLine($"Путь из {from} в {to}");
            var tmp = function(from, to);
            if (tmp==null || tmp.Count == 0) 
            {
                Console.Write("Нет такого пути!!");
            }
            else
            {
                foreach (var item in function(from, to))
                {
                    Console.Write($"{item},");
                }
            }
            
            Console.WriteLine();
        }
        private static void ConsoleWriteGraphMatrix(Graph graph)
        {
            
            Console.WriteLine();
            Console.WriteLine("Выведем матрицу для графа");
            Console.WriteLine();
            var matrix = graph.GetMatrix();
            int count = 0;
            foreach (var item in matrix)
            {
                int tmp = item.ToString().Length;
                if (count < tmp)
                {
                    count = tmp;
                }
                
            }
            foreach (var item in graph.Vertices)
            {
                int tmp = item.Number.ToString().Length;
                if (count < tmp)
                {
                    count = tmp;
                }
            }
            count++;
            List<string> str = new List<string>();

            string temp = $"{'x'}".PadLeft(count,' ');
            temp += $"|";
            for (int i = 0; i < graph.CountVertex; i++)
            {
                temp+=$"{graph.Vertices[i].Number}".PadLeft(count, ' ');
                temp +=$"|";
            }
            str.Add(temp);
            str.Add(new string('_', temp.Length));
            
            for (int i = 0; i < graph.CountVertex; i++)
            {
                temp = $"{graph.Vertices[i].Number}".PadLeft(count, ' ');
                temp += $"|";
                for (int j = 0; j < graph.CountVertex; j++)
                {
                    temp += $"{matrix[i,j]}".PadLeft(count, ' ');
                    temp += $"|";
                }
                str.Add(temp);
            }

            foreach (var item in str)
            {
                Console.WriteLine(item);
            }
        }


        private static void ConsoleWriteGraphVertexList(Graph graph, Vertex vertex)
        {
            Console.WriteLine();
            string str = "";
            str += $"{vertex.Number}: ";
            foreach (var item in graph.GetVertexList(vertex))
            {
                str += $"{item.Number}, ";
            }
            str = str.Remove(str.Length - 2);
            str += $".";
            Console.WriteLine(str);
        }
    }
}
