using System.IO;
using System.Text;

namespace DictionaryGenerator
{
    public class SmallWordsDictionaryGenerator
    {
        private const int StartIndex = 33;
        private const int EndIndex = 126;
        private const int MaxDepth = 5;

        public void Generate(string outputPath)
        {
            if (File.Exists(outputPath))
                File.Delete(outputPath);


            // We will generate every possible password with length < 6 chars
            var sb = new StringBuilder();

            using (var writer = new StreamWriter(outputPath))
            {
                AddSmallWordRecursive(writer, sb, 1);
            }
        }

        private void AddSmallWordRecursive(StreamWriter writer, StringBuilder sb, int currentDepth)
        {
            for (var i = StartIndex; i <= EndIndex; ++i)
            {
                sb.Append((char) i);
                writer.WriteLine(sb.ToString());
                if (currentDepth < MaxDepth)
                    AddSmallWordRecursive(writer, sb, currentDepth + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}