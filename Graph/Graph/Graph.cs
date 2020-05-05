using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary> Класс графа </summary>
    public class Graph
    {
       

        /// <summary> Список вершин </summary>
        public List<Vertex> Vertices { get; set; }
        /// <summary> Список ребер </summary>
        public List<Edge> Edges { get; set; }
        /// <summary> Является ориентированным графом </summary>
        public bool IsDirected { get; set; } = true;
        /// <summary> Количество вершин в графе </summary>
        public int CountVertex { get => Vertices.Count; }

        /// <summary> Пустой конструктор графа </summary>
        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }


        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }
        public void AddVertex(IEnumerable<Vertex> vertices)
        {
            Vertices.AddRange(vertices);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
        public void AddEdge(IEnumerable<Edge> edges)
        {
            Edges.AddRange(edges);
        }


        /// <summary>
        /// Получить матрицу смежности
        /// </summary>
        /// <returns>Массив матрицы смежности</returns>
        public int[,] GetMatrix()
        {
            int[,] matrix = new int[Vertices.Count, Vertices.Count];
            foreach (var edge in Edges)
            {
                int row = Vertices.FindIndex(x=>x.Equals(edge.From));
                int column = Vertices.FindIndex(x=>x.Equals(edge.To));
                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        /// <summary>
        /// Список смежных вершин
        /// </summary>
        /// <param name="vertex">Вершина от которой будет делаться список</param>
        /// <returns>Список вершин</returns>
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var vertexList = new List<Vertex>();
            foreach (var edge in Edges)
            {
                if (edge.From.Equals(vertex))
                {
                    vertexList.Add(edge.To);
                }
            }
            return vertexList;
        }
        /// <summary>
        /// Имеется ли путь из одной вершины в другую
        /// </summary>
        /// <param name="start">Вершина от которой ищется путь</param>
        /// <param name="stop">Вершина к которой ищется путь</param>
        /// <returns>истина или ложь</returns>
        public bool Wave(Vertex start, Vertex stop)
        {
            var vertexList = new List<Vertex>()
            {
                start
            };
            for (int i = 0; i < vertexList.Count; i++)
            {
                var list = GetVertexList(vertexList[i]);
                foreach (var item in list)
                {
                    if (!vertexList.Contains(item))
                    {
                        vertexList.Add(item);
                    }
                }
            }
            return vertexList.Contains(stop);
        }

        /// <summary>
        /// путь из одной вершины в другую, Если пусто то пути нет
        /// </summary>
        /// <param name="start">Вершина от которой ищется путь</param>
        /// <param name="stop">Вершина к которой ищется путь</param>
        /// <returns>Список вершин из конечной в начальную</returns>
        public List<Vertex> Wave1(Vertex start, Vertex stop)
        {
            var vertexDic = new Dictionary<Vertex, int>();
            vertexDic.Add(start, -1);

            for (int i = 0; i < vertexDic.Count; i++)
            {
                var dic = vertexDic.ElementAt(i);
                foreach (var item in GetVertexList(dic.Key))
                {
                    if (!vertexDic.ContainsKey(item))
                    {
                        vertexDic.Add(item, i);
                    }
                }
            }
            List<Vertex> res = new List<Vertex>();
            if (vertexDic.ContainsKey(stop))
            {
                var tmp = vertexDic.Where(x=>x.Key.Equals(stop)).ToList();
                for (int i = 0; i < tmp.Count(); i++)
                {
                    res.Add(tmp[i].Key);
                    if (tmp[i].Value > -1) 
                    {
                        tmp.Add(vertexDic.ElementAt(tmp[i].Value));
                    }
                    
                }

            }
            return res;
        }

        public List<Vertex> Deep(Vertex start, Vertex stop)
        {
            return Deep(start,stop,new List<Vertex>());
        }

        private List<Vertex> Deep(Vertex start, Vertex stop, List<Vertex> useVertex)
        {
            useVertex.Add(start);
            if (start.Equals(stop))
            {
                List<Vertex> res = new List<Vertex> { start };
                return res;
            }
            else
            {
                var list = GetVertexList(start);
                foreach (var item in list)
                {
                    if (!useVertex.Contains(item))
                    {
                        var res = Deep(item, stop, useVertex);
                        if (res!=null)
                        {
                            res.Add(start);
                            return res;
                        }
                        
                    }
                       
                }
                useVertex.Remove(start);
                return null;
            }
        }
    }
}
