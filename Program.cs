using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            StreamReader file = new StreamReader("in.txt");
            List<Set> sets = new List<Set>();

            int sets_count = Convert.ToInt32(file.ReadLine());
            Console.WriteLine($"Ilosc zbiorow:{sets_count}" + Environment.NewLine);
            
            string data = file.ReadLine();

            stopwatch.Start();
            while(data != null)
            {
                Set set = new Set();

                string[] values = data.Split(' ');
               
                set.beginning = Int64.Parse(values[0]);
                set.end = Int64.Parse(values[1]);
               
                sets.Add(set);
                data = file.ReadLine();
            }
            stopwatch.Stop();
            Console.WriteLine($"Wczytywanie z pliku:{stopwatch.ElapsedMilliseconds}");

            stopwatch.Start();
            void quick_sort(List<Set> sets,int left,int right)
            {
                if (right <= left) return;

                int i = left - 1, j = right + 1;
                long   pivot = sets[(left + right) / 2].beginning;

                while(true)
                {
                    while (pivot > sets[++i].beginning) ;
                    while (pivot < sets[--j].beginning) ;

                    if (i <= j)
                    {
                        (sets[i].beginning, sets[j].beginning) = (sets[j].beginning, sets[i].beginning);
                        (sets[i].end, sets[j].end) = (sets[j].end, sets[i].end);
                    }
                    else break;
                }

                if (j > left)
                    quick_sort(sets, left, j);
                        if (i < right)
                    quick_sort(sets, i, right);
            }

            quick_sort(sets, 0, sets_count - 1);
            stopwatch.Stop();
            Console.WriteLine($"Sortowanie:{stopwatch.ElapsedMilliseconds}");

            //Console.WriteLine("Posortowane zbiory:");

            //for (int i = 0; i < sets.Count; i++)
            //{
            //    Console.WriteLine($"{i}. {sets[i].beginning} {sets[i].end}");
            //}
            //Console.WriteLine();

            int index = 1;

            List<Set> result = new List<Set>();
            
            result.Add(new Set(sets[0].beginning, sets[0].end));

            var EndToCompare = result[result.Count - 1].end;

            stopwatch.Start();

            while (sets.Count != index)
            {
                var next = sets[index];

                if (EndToCompare >= next.beginning)
                {
                    if (EndToCompare < next.end)
                    {
                        result[result.Count - 1].end = next.end;                     
                    }
                }
                else
                    result.Add(new Set(next.beginning, next.end));

                index++;
                EndToCompare = result[result.Count - 1].end;
     
            }

            stopwatch.Stop();

            Console.WriteLine("Wynik:");
            for(int i=0;i<result.Count;i++)
            {
                Console.WriteLine($"{i}. {result[i].beginning} {result[i].end}");
            }
            Console.WriteLine($"Czas przygotowywania wyniku:{stopwatch.ElapsedMilliseconds}");

            //stopwatch.Start();

            //while (sets.Count != index + 1) 
            //{
            //    var current = sets[index];
            //    var next = sets[index + 1];

            //    if (current.end >= next.beginning)
            //    {
            //        if (current.end < next.end)
            //        {
            //           next.beginning = current.beginning;
                        
            //           sets.Remove(current);
            //        }
            //        else
            //        {
            //            next.beginning = current.beginning;
            //            next.end = current.end;
                        
            //            sets.Remove(current);

            //        }
            //    }
            //    else
            //    {       
            //        index++;                 
            //        if (index == sets.Count - 1)
            //            break;
            //    }
            //}

            //stopwatch.Stop();
            
            //Console.WriteLine($"Wynik:{stopwatch.ElapsedMilliseconds}");

            //Console.WriteLine(Environment.NewLine +"Wynik:");

            //for (int i = 0; i < sets.Count; i++)
            //{
            //    Console.WriteLine($"{i}. {sets[i].beginning} {sets[i].end}");
            //}

        }
    }
}
