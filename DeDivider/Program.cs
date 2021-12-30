using System;
using System.Diagnostics;
using DeDivider.Classes;

namespace DeDivider
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input_path = args[0];
                var output_path = args[1];
                var sw = Stopwatch.StartNew();
                Writer.Write(input_path, output_path);
                sw.Stop();

                Console.WriteLine("\nDONE!\n" +
                                 $"Execution time: {sw.Elapsed}");
            }
            catch(Exception)
            {
                Console.WriteLine("\nERROR: maybe your path is wrong?");
            }
        }
    }
}
