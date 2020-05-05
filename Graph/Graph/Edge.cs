using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary> Класс ребра </summary>
    public class Edge
    {
        /// <summary> Из какой вершины идет ребро </summary>
        public Vertex From { get; set; }
        /// <summary> В какую вершину идет ребро </summary>
        public Vertex To { get; set; }
        /// <summary> Вес ребра </summary>
        public int Weight { get; set; }

        /// <summary> Конструктор для Взвешенного графа </summary>
        public Edge(Vertex from, Vertex to, int weight)
        {
            if (from==null || to== null)
            {
                throw new ArgumentNullException("Вершины не должны быть пусты!");
            }
            From = from;
            To = to;
            Weight = weight;
        }
        /// <summary> Конструктор для неориентированного графа </summary>
        public Edge(Vertex from, Vertex to): this(from,to,1)
        { }

    }
}
