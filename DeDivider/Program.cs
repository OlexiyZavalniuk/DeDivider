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
            var sw = Stopwatch.StartNew();
            var dictionary = Read("../../../Dictionary/de-dictionary.tsv");
            var input0 = Read("../../../Dictionary/de-test-words.tsv");
            var input = input0.Split("\r\n");
            dictionary = dictionary.ToLower();
            foreach (var s in input)
            {
                Console.Write($"{s} -> ");
                var res = Dividing(s, dictionary, true);
                if (res == "")
                {
                    Console.Write($"{s}\n");
                }
                else
                {
                    Console.Write($"{res}\n");
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        static string Read(string path)
        {
            using StreamReader sr = new(path);
            return sr.ReadToEnd();

        }

        static string Dividing(string word, string dictionary, bool first)
        {
            for (int i = 0; i < word.Length; i++)
            {
                var k = word.Substring(0, word.Length - i);
                if (dictionary.Contains($"\n{k}\n"))
                {
                    if (!first && i == 0)
                    {
                        return k;
                    }
                    var res = Dividing(word.Substring(word.Length - i), dictionary, false);
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
