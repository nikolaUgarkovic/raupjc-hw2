using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak1;
using Zadatak5;
using Zadatak_4;
using Zadatak_6_7;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student.Case1();
            //Student.Case2();
            //Student.Case3();
            //int[] intArray = new int[]{2,2,3,1,2,3};
            //string[] result = HomeworkLinqQueries.Linq1(intArray);
            //Console.WriteLine(result[0]);
            //Console.WriteLine(result[1]);
            //Console.WriteLine(result[2]);
            //Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            Parallel.Invoke(() => Class1.LongOperation("A"),
                () => Class1.LongOperation("B"),
                () => Class1.LongOperation("C"),
                () => Class1.LongOperation("D"),
                () => Class1.LongOperation("E"));

            stopwatch.Stop();

            Console.WriteLine("Parallel  long  operation  calls  finished  {0} sec.",
                stopwatch.Elapsed.TotalSeconds);
            var t = Task.Run(() => klasa.LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
            Console.ReadLine();
        }


    }
}

