using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipleTasks mt = new MultipleTasks();
            Stopwatch sw = Stopwatch.StartNew();
            mt.Run();
            sw.Stop();
            Console.WriteLine("elapsed time:" + sw.Elapsed.TotalMilliseconds + " ms");
            //Console.ReadLine();
        }
    }
}
