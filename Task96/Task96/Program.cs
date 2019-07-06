using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task96
{
    class Program
    {
        static void Main(string[] args)
        {
            //      # Task 96. 
            //  При засолке в стеклянную банку вмещается 
            //    3 больших и 1 маленький огурец, либо 
            //    2 больших и 4 маленьких, либо 
            //    1 большой и 8 маленьких, либо 
            //    12 маленьких. 
            List<VariblesJar> variblesJars = new List<VariblesJar>()
            {
                new VariblesJar(3,1),
                new VariblesJar(2,4),
                new VariblesJar(1,8),
                new VariblesJar(0,12)
            };
            //  Определить, хватит ли 4 банок для засолки M маленьких и N больших огурцов, 
            int bigCucumber = 10;
            int smallCucumber = 16;
            //  сколько банок потребуется и 
            //  как они будут заполнены.


            //var jarr = new JarOfCucumber(25, 0);
            //jarr.Distribution();


            var jarr = new JarOfCucumber(bigCucumber, smallCucumber, variblesJars);
            jarr.Distribution();
            jarr.Cons();
            Console.ReadLine();

        }
    }
    public class Jar
    {
        public int BigCucumbers { get; private set; }
        public int SmallCucumbers { get; private set; }
        public Jar(int bigCucumbers, int smallCucumbers)
        {
            BigCucumbers = bigCucumbers;
            SmallCucumbers = smallCucumbers;
        }
        public override string ToString()
        {
            return $"Больших огурцов = {BigCucumbers}, Маленьких огурцов = {SmallCucumbers}.";
        }
    }
    public class VariblesJar
    {
        public int BigCucumber;
        public int SmallCucumber;

        public VariblesJar(int bigCucumber, int smallCucumber)
        {
            BigCucumber = bigCucumber;
            SmallCucumber = smallCucumber;
        }
    }
    public class JarOfCucumber
    {
        public int BigCucumbers { get; private set; }
        public int SmallCucumbers { get; private set; }
        public List<List<Jar>> Jars { get; private set; } = new List<List<Jar>>();

        List<VariblesJar> VariblesJars = new List<VariblesJar>();
        public JarOfCucumber(int bigCucumbers, int smallCucumbers, List<VariblesJar> variblesJars)
        {
            BigCucumbers = bigCucumbers;
            SmallCucumbers = smallCucumbers;
            VariblesJars = variblesJars;
        }

        public void Distribution()
        {
            int[] varible = new int[VariblesJars.Count];
            int[] varibleMax = new int[VariblesJars.Count];
            for (int i = 0; i < VariblesJars.Count; i++)
            {
                varible[i] = 0;
                int maxB = 0;
                int maxS = 0;
                if (VariblesJars[i].BigCucumber > 0)
                { 
                    maxB = BigCucumbers / VariblesJars[i].BigCucumber + 1;
                }
                if (VariblesJars[i].SmallCucumber > 0)
                {
                    maxS = SmallCucumbers / VariblesJars[i].SmallCucumber + 1;
                }

                if (maxB > maxS)
                {
                    varibleMax[i] = maxB;
                }
                else
                {
                    varibleMax[i] = maxS;
                }
            }
            List<int[]> suitableOptions = new List<int[]>();
            bool wh = true;
            while (wh)
            {
                int BigCuc = 0;
                int SmallCuc = 0;
                for (int i = 0; i < VariblesJars.Count; i++)
                {
                    BigCuc += varible[i] * VariblesJars[i].BigCucumber;
                    SmallCuc += varible[i] * VariblesJars[i].SmallCucumber;
                }
                if (BigCuc < BigCucumbers || SmallCuc < SmallCucumbers)
                {
                    varible[0]++;
                }
                else
                {
                    int[] temp = varible.Clone() as int[];
                    suitableOptions.Add(temp);
                    for (int i = 0; i < VariblesJars.Count; i++)
                    {
                        if (varible[i] != 0)
                        {
                            varible[i] = 0;
                            if ((i + 1) < VariblesJars.Count)
                            {
                                varible[i + 1]++;
                                break;
                            }
                            else
                            {
                                wh = false;
                            }
                        }
                    }
                }

                for (int i = 0; i < VariblesJars.Count; i++)
                {
                    if (varible[i] > varibleMax[i])
                    {
                        varible[i] = 0;
                        if ((i + 1) < VariblesJars.Count)
                        {
                            varible[i + 1]++;
                            break;
                        }
                        else
                        {
                            wh = false;
                        }
                    }
                }
            }
            var min = suitableOptions.ConvertAll<int>(x=>x.Sum()).Min();
            var va = suitableOptions.Where(x => x.Sum() <= min).ToList();
            foreach (var item in va)
            {
                var tempSmallCucumbers = SmallCucumbers;
                var tempBigCucumbers = BigCucumbers;
                List<Jar> jarTemp = new List<Jar>();
                for (int i = 0; i < VariblesJars.Count; i++)
                {
                    for (int j = 0; j < item[i]; j++)
                    {
                        int bigCucumbers = tempBigCucumbers < VariblesJars[i].BigCucumber ? tempBigCucumbers : VariblesJars[i].BigCucumber;
                        int smallCucumbers = SmallCucumbers < VariblesJars[i].SmallCucumber ? SmallCucumbers : VariblesJars[i].SmallCucumber;
                        jarTemp.Add(new Jar(bigCucumbers, smallCucumbers));
                        tempSmallCucumbers -= smallCucumbers;
                        tempBigCucumbers -= bigCucumbers;
                    }
                }
                Jars.Add(jarTemp);
            }
        }
        public void Cons()
        {
            Console.WriteLine($"Всего {Jars.Count} вариантов заполнения банок с минимальным их количеством = {Jars[0].Count}.");
            foreach (var item in Jars)
            {
                Console.WriteLine("\tВариант:");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"\t\t{item1} ");
                }
            }
        }
    }
}
