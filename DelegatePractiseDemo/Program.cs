using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractiseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //client 1
            ProcessManager pM = new ProcessManager();
            pM.ShowProcessList(NoFilter);
            Console.WriteLine();

            // client 2
            FilterDelegate filter = new FilterDelegate(FilterByName);
            pM.ShowProcessList(filter);
            Console.WriteLine();

            // client 3
            //FilterDelegate filter = new FilterDelegate(FilterBySize);
            //pM.ShowProcessList(filter);
            Console.WriteLine();

            //Anaonymous Delegates - Anaonymous Method
            //pass business logic as a parameter to another business logic
            //pass method as a parameter to another method
            pM.ShowProcessList(delegate (Process p)
                { 
                    return p.ProcessName.EndsWith("a");
                }
            );
            // this method is used very much but just one difficulty, 
            //feedback from developer is that understanding anaonymous delegated
            // is difficult for people except the person who wrote it.

            // so new changes by microsoft launched is Lambdas
            //Lambdas - light weight syntax for anaonymous delegates

            //Lambda statement
            pM.ShowProcessList((Process p) =>
            {
                return p.ProcessName.EndsWith("a");
            }
            );

            // Lanbdas 
            // 1.) statements - it can be many
            // 2) expressions - one

            //Lambda expression
            pM.ShowProcessList(p => p.ProcessName.EndsWith("a"));

            List<int> numbers = new List<int> { 23, 345, 45, 54, 134, 67, 34, 78, 234, 689, 34 };
            //find sum of all
            var s1 = numbers.Sum();
            Console.WriteLine("sum: " + s1);
            //find sum of evens
            var s = numbers.Where(n => n % 2 == 0).Sum();
            Console.WriteLine("sum of evens : " + s);
            //find sum of odds
            var s2 = numbers.Where(n => n % 2 != 0).Sum();
            Console.WriteLine("sum of odds : " + s2);
            //find max
            int s3 = numbers.Max();
            Console.WriteLine("max : " + s3);
            //find min
            int s4 = numbers.Min();
            Console.WriteLine("min : " + s4);
            // find avg
            var s5 = numbers.Average();
            Console.WriteLine("Average : " + s5);
            //find max in even
            int s6 = numbers.Where(n => n % 2 == 0).Max();
            Console.WriteLine("max in evens : " + s6);
            //find min in evens
            int s7 = numbers.Where(n => n % 2 == 0).Min();
            Console.WriteLine("min in evens : " + s7);
            //find max in odds
            int s8 = numbers.Where(n => n % 2 != 0).Max();
            Console.WriteLine("max in odds : " + s8);
            // find even count
            var s9 = numbers.Where(n => n % 2 == 0).Count();
            Console.WriteLine("even count : " + s9);
            //find odd count
            var s10 = numbers.Where(n => n % 2 != 0).Count();
            Console.WriteLine("odd count : " + s10);
        }

        public static bool NoFilter(Process p)
        {
            return true;
        }
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("S");
        }

        public static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 300 * 1024 * 1024;
        }
        public static bool FilterByEndName(Process p)
        {
            return p.ProcessName.EndsWith("a");
        }
    }

    public delegate bool FilterDelegate(Process p);

    class ProcessManager
    {
        //public void ShowProcessList()
        //{
        //    foreach(var p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}

        public void ShowProcessList(FilterDelegate filter)
        {
            
            foreach (var p in Process.GetProcesses())
            {
                if(filter(p))
                    Console.WriteLine(p.ProcessName);
            }
        }

        //public void ShowProcessList(long size)
        //{
        //    foreach (var p in Process.GetProcesses())
        //    {
        //        if(p.WorkingSet64 >= size)
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}
    }
}
