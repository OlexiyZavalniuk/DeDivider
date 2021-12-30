using System.IO;


namespace DeDivider.Classes
{
    class Writer
    {
        internal static void Write(string input_path, string output_path)
        {
            var dictionary = Reader.Read("../../../Dictionary/de-dictionary.tsv");
            var input = Reader.Read(input_path);
            using StreamWriter sw = new(output_path);

            foreach (var word in input)
            {
                sw.Write($"(in) {word} -> ");
                var res = Devider.Divide(word, dictionary);
                sw.Write(res == "" ? $"(out) {word}\n" : $"(out) {res}\n");
            }
        }
    }
}
