using System.Collections.Generic;


namespace DeDivider.Classes
{
    class Divider
    {
        internal static string Divide(string word, HashSet<string> dictionary, bool first = true)
        {
            for (int i = 1; i < word.Length; i++)
            {
                var section = word.Substring(0, word.Length - i);
                if (dictionary.Contains(section))
                {
                    var result = Divide(word[^i..], dictionary, false);
                    if (result != "")
                        return $"{section}, {result}";
                }
            }
            return dictionary.Contains(word) || first ? word : "";
        }
    }
}
