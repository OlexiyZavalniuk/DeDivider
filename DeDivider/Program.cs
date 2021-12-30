using System;
using System.Diagnostics;
using DeDivider.Classes;

namespace DeDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-------------  Hello  -------------");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("----  Enter path to read words ----");
            Console.WriteLine("");
            Console.Write(">");
            var input_path = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("-------------   OK   --------------");
            Console.WriteLine("---  Enter path to write result ---");
            Console.WriteLine("");
            Console.Write(">");
            var output_path = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("-------------   OK   --------------");
            Console.WriteLine("Run...");

            try
            {
                var sw = Stopwatch.StartNew();
                Writer.Write(input_path, output_path);
                sw.Stop();

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("DONE!");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Execution time: {sw.Elapsed}");
            }
            catch(Exception)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("ERROR: maybe your path is wrong?");
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-------- Enter sth to exit  -------");
            Console.ReadKey();
        }
    }
}
