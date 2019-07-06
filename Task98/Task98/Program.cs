using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task98
{
    class Program
    {
        static void Main(string[] args)
        {

            //      # Task 98. 
            //  Астрономы часто изображают карту звездного неба на бумаге, где каждая звезда имеет декартовы координаты. 
            //  Пусть уровнем звезды будет количество других звезд, которые расположены на карте не выше и не правее данной звезды. 
            //  Астрономы решили узнать уровни всех звезд. 
            //  Требуется определить, сколько звезд каждого уровня имеется на карте.

            //  |
            //  |
            //  |
            //  |  *     *
            //  |
            //  |    *   *
            //  |_______________



            List<Coordinate> coordinates = new List<Coordinate>();
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 1000; i++)
            {
                coordinates.Add(new Coordinate(random.Next(-100, 100), random.Next(-100, 100)));
            }
            var levels = new List<List<Coordinate>>();
            foreach (var item in coordinates)
            {
                var level = coordinates.Where(coordinate => (coordinate.X <= item.X) && (coordinate.Y <= item.Y)).ToList();
                levels.Add(level);
            }

            var groupByLevels = levels.GroupBy(x => x.Count)
                                        .OrderBy(x => x.Key);
            foreach (var item in groupByLevels)
            {
                Console.WriteLine($"Уровень = {item.Key}, Количество звезд = {item.Count()}");
            }
            Console.ReadLine();
        }
        
    }
    public class Coordinate
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public override string ToString()
        {
            return $"[{X,5};{Y,5};{Z,5}]";
        }
    }
}
