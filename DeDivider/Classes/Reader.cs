using System.Collections.Generic;
using System.IO;

namespace DeDivider.Classes
{
    static class Reader
    {
        internal static HashSet<string> Read(string path)
        {
            using StreamReader sr = new(path);
            HashSet<string> words = new();
            while (!sr.EndOfStream)
            {
                words.Add(sr.ReadLine().ToLower());
            }

            return words;
        }
    }
}
