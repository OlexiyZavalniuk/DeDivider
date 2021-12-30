using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

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
            Console.Write(">");
            var input_path = Console.ReadLine();
            Console.WriteLine("-------------   OK   --------------");
            Console.WriteLine("---  Enter path to write result ---");
            Console.Write(">");
            var output_path = Console.ReadLine();
            Console.WriteLine("-------------   OK   --------------");
            Console.WriteLine("Run...");

            try
            {
                var sw = Stopwatch.StartNew();
                Do(input_path, output_path);
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

        static void Do(string input_path, string output_path)
        {
            var dictionary = Read("../../../Dictionary/de-dictionary.tsv");
            var input = Read(input_path);
            using StreamWriter sw = new(output_path);

            foreach (var s in input)
            {
                sw.Write($"(in) {s} -> ");
                var res = Divide(s, dictionary);
                if (res == "")
                {
                    sw.Write($"(out) {s}\n");
                }
                else
                {
                    sw.Write($"(out) {res}\n");
                }
            }
        }

        static HashSet<string> Read(string path)
        {
            using StreamReader sr = new(path);
            HashSet<string> words = new();
            while (!sr.EndOfStream)
            {
                words.Add(sr.ReadLine().ToLower());
            }

            return words;
        }

        static string Divide(string word, HashSet<string> dictionary, bool first = true)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var k = word.Substring(0, word.Length - i);
                if (dictionary.Contains(k))
                {
                    if (!first && i == 0)
                    {
                        return k;
                    }
                    var res = Divide(word.Substring(word.Length - i), dictionary, false);
                    if (res != "")
                    {
                        return $"{k}, {res}";
                    }
                }
            }
            return "";
        }
    }
}
