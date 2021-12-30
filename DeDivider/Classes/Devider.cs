using System.Collections.Generic;


namespace DeDivider.Classes
{
    class Devider
    {
        internal static string Divide(string word, HashSet<string> dictionary, bool first = true)
        {
            int i = first ? 1 : 0;

            if (i == 0 && dictionary.Contains(word))
                return word;
            else if (i == 0)
                i++;

            for (; i < word.Length; i++)
            {
                var w = word.Substring(0, word.Length - i);
                if (dictionary.Contains(w))
                {
                    var res = Divide(word[^i..], dictionary, false);
                    if (res != "")
                        return $"{w}, {res}";
                }
            }
            return "";
        }
    }
}
