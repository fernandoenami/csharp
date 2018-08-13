using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MultipleStreams mt = new MultipleStreams();
            Stopwatch sw = Stopwatch.StartNew();
            mt.Run();
            sw.Stop();
            Console.WriteLine("elapsed time:" + sw.Elapsed.TotalMilliseconds + " ms");
            //Console.ReadLine();
        }
    }
}
