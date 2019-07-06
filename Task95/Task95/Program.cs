using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task95
{
    class Program
    {
        static void Main(string[] args)
        {
            //#Task 95
            //Напечатать все N-значные натуральные числа,
            //в десятичной записи которых нет одинаковых цифр.
            const int N = 6;

            int begin = (int)Math.Pow(10,N-1) ;
            int end = (int)Math.Pow(10, N) -1;
            for (int i = begin; i < end; i++)
            {
               if(i.ToString().Distinct().Count()==N)
                    Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
