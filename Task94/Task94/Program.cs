using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task94
{
    class Program
    {
        static void Main(string[] args)
        {

            //    # Task 94. 
            //  Вводятся 2 целых числа: M и N (M<999, N<999). 
            //  N - число субъектов, M - число слов в считалочке. 
            //  Счет начинается с первого субъекта (по одному слову на каждого) и продолжается по кругу. 
            //  Субъект, на которого выпадает последнее слово, выбывает. 
            //  Счет продолжается со следующего субъекта. 
            //  Напечатать номер последнего оставшегося субъекта.
            int N = 325;
            int M = 32;
            

            List<int> subj = new List<int>();
            for (int i = 0; i < N; i++)
            {
                subj.Add(i);
            }
            while (subj.Count>1)
            {
                subj.RemoveAt(M % subj.Count);
            }

            Console.WriteLine(subj[0]);
            Console.ReadLine();
        }
    }
}
