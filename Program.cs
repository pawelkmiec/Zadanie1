using System;
using System.IO;
using System.Collections.Generic;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("in.txt");
            List<Set> sets = new List<Set>();

            int sets_count = Convert.ToInt32(file.ReadLine());
            Console.WriteLine($"Ilosc zbiorow:{sets_count}" + Environment.NewLine);
            
            string data = file.ReadLine();

            while(data != null)
            {
                Set set = new Set();

                string[] values = data.Split(' ');
               
                set.beginning = Int32.Parse(values[0]);
                set.end = Int32.Parse(values[1]);

                sets.Add(set);
                data = file.ReadLine();
            }
            
            void quick_sort(List<Set> sets,int left,int right)
            {
                if (right <= left) return;

                int i = left - 1, j = right + 1,
                    pivot = sets[(left + right) / 2].beginning;

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

            Console.WriteLine("Posortowane zbiory:");

            for (int i = 0; i < sets.Count; i++)
            {
                Console.WriteLine($"{i}. {sets[i].beginning} {sets[i].end}");
            }
            Console.WriteLine();
            int index = 0;

            while (true) 
            {
                if (sets[index].end >= sets[index + 1].beginning)
                {
                    if (sets[index].end < sets[index + 1].end)
                    {
                        sets[index + 1].beginning = sets[index].beginning;                      
                        sets.Remove(sets[index]);
                    }
                    else
                    {
                        sets[index + 1].beginning = sets[index].beginning;
                        sets[index + 1].end = sets[index].end;
                        
                        sets.Remove(sets[index]);
                    }
                }
                else
                {       
                    index++;                 
                    if (index == sets.Count - 1)
                        break;
                }
            }
      
            Console.WriteLine(Environment.NewLine +"Wynik:");

            for (int i = 0; i < sets.Count; i++)
            {
                Console.WriteLine($"{i}. {sets[i].beginning} {sets[i].end}");
            }

        }
    }
}
