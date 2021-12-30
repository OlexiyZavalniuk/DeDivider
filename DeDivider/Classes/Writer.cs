using System.IO;


namespace DeDivider.Classes
{
    class Writer
    {
        internal static void Write(string input_path, string output_path)
        {
            var dictionary = Reader.Read("../../../Dictionary/de-dictionary.tsv");
            var input = Reader.Read(input_path);
            using StreamWriter streamWriter = new(output_path);

            foreach (var word in input)
            {
                streamWriter.Write($"(in) {word} -> ");
                var result = Devider.Divide(word, dictionary);
                streamWriter.Write($"(out) {result}\n");
            }
        }
    }
}
