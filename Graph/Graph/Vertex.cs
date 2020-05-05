using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    /// <summary> Класс Вершины графа </summary>
    public class Vertex
    {
        

        /// <summary> Номер вершины </summary>
        public int Number { get; set; }

        /// <summary> Конструктор вершины графа</summary>
        public Vertex(int number)
        {
            Number = number;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex vertex)
            {
                return vertex.Number.Equals(Number);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return $"V-{Number}";
        }
    }
}
