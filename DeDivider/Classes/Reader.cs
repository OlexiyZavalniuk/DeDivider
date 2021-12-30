using System.Collections.Generic;
using System.IO;

namespace DeDivider.Classes
{
    static class Reader
    {
        internal static HashSet<string> Read(string path)
        {
            using StreamReader streamReader = new(path);
            HashSet<string> words = new();
            while (!streamReader.EndOfStream)
            {
                words.Add(streamReader.ReadLine().ToLower());
            }

            return words;
        }
    }
}
