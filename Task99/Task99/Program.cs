using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task99
{
    class Program
    {
        static void Main(string[] args)
        {

            //      # Task 99. 
            //  Задачник содержит 300 задач, пронумерованных от 1 до 300. 
            const int startNumberTasks = 1;
            const int endNumberTasks = 300;
            //  У учительницы есть магнитики с цифрами. 
            //  В начале урока она прикрепляет их на доску так, чтобы образовались номера четырех задач, которые разбираются на уроке. 
            //  Какое наименьшее число магнитиков должно быть у учительницы, чтобы она могла задать на уроке любые четыре задачи?
            const int numberOfTasksOnTheBoard = 10;


            List<NumeralWithCount> numeralWithCounts = new List<NumeralWithCount>();
            for (int i = startNumberTasks; i <= endNumberTasks; i++)
            {
                numeralWithCounts.Add(new NumeralWithCount(i));
            }
            
            int maxNumber = 0;
            for (int i = 0; i <= 9; i++)
            {
                //List<int> num = numeralWithCounts.ConvertAll<int>(x => x.Count[i]);
                var num = numeralWithCounts.OrderByDescending(x => x.Count[i]);
                int numberOfDigits = num.Take(numberOfTasksOnTheBoard).Sum(x => x.Count[i]);
                Console.WriteLine($"Число магнитиков с цифрой {i} должно быть не меньше {numberOfDigits}.");
                Console.Write("\t");
                foreach (var item in num.Take(numberOfTasksOnTheBoard))
                {
                    Console.Write($"{item.Number,5},");
                }
                Console.WriteLine();
                if(numberOfDigits >maxNumber)
                {
                    maxNumber = numberOfDigits;
                }
            }
            Console.WriteLine($"Число полных комплектов магнитиков должно быть не меньше {maxNumber}.");
            Console.ReadLine();
        }
    }
    public class NumeralWithCount
    {
        public int Number {get; }
        public List<int> Numeral  { get; }
        public List<int> Count  { get; }
        public NumeralWithCount(int number)
        {
            Numeral = new List<int>();
            Count = new List<int>();
            Number = number;
            for (var ch = '0'; ch <= '9'; ch++)
            {
                int count = number.ToString().Count(x => x == ch);
                Numeral.Add(Convert.ToInt32(ch.ToString()));
                Count.Add(count);
            }
        }
    }
}
