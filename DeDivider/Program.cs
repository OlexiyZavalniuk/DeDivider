using System;
using System.Diagnostics;
using DeDivider.Classes;

namespace DeDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------\n" +
                              "-------------  Hello  -------------\n" +
                              "-----------------------------------\n" +
                              "----  Enter path to read words ----\n");
            Console.Write(">");
            var input_path = Console.ReadLine();
            Console.WriteLine("\n-------------   OK   --------------\n" +
                              "---  Enter path to write result ---");
            Console.Write("\n>");
            var output_path = Console.ReadLine();
            Console.WriteLine("\n-------------   OK   --------------\n" +
                              "Run...");

            try
            {
                var sw = Stopwatch.StartNew();
                Writer.Write(input_path, output_path);
                sw.Stop();

                Console.WriteLine("-----------------------------------\n" +
                                  "DONE!\n" +
                                  "-----------------------------------\n" +
                                  $"Execution time: {sw.Elapsed}");
            }
            catch(Exception)
            {
                Console.WriteLine("-----------------------------------\n" +
                                  "ERROR: maybe your path is wrong?");
            }

            Console.WriteLine("-----------------------------------\n" +
                              "-------- Enter sth to exit  -------");
            Console.ReadKey();
        }
    }
}
