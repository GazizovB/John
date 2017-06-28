using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DictionaryGenerator
{
    public class SmallWordsDictionaryGenerator
    {
        public void Generate(int maxDepth, string outputPath, bool useLowerLetters, bool useUpperLetters, bool useNumbers, bool useSpacialChars)
        {
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            var charRange = new List<char>();
            if (useNumbers)
            {
                for (int i = 48; i <= 57; ++i)
                    charRange.Add((char) i);
            }
            if (useUpperLetters)
            {
                for (int i = 65; i <= 90; ++i)
                    charRange.Add((char) i);
            }
            if (useLowerLetters)
            {
                for (int i = 97; i <= 122; ++i)
                    charRange.Add((char)i);
            }
            if (useSpacialChars)
            {
                for (int i = 32; i <= 47; ++i)
                    charRange.Add((char)i);
                for (int i = 58; i <= 64; ++i)
                    charRange.Add((char)i);
                for (int i = 91; i <= 96; ++i)
                    charRange.Add((char)i);
                for (int i = 123; i <= 126; ++i)
                    charRange.Add((char)i);
            }

            var sb = new StringBuilder();
            using (var writer = new StreamWriter(outputPath))
            {
                AddSmallWordRecursive(charRange, writer, sb, maxDepth, 1);
            }

        }

        private void AddSmallWordRecursive(List<char> charRange, StreamWriter writer, StringBuilder sb, int maxDepth, int currentDepth)
        {
            for (var i = 0; i < charRange.Count; ++i)
            {
                sb.Append(charRange[i]);
                writer.WriteLine(sb.ToString());
                if (currentDepth < maxDepth)
                    AddSmallWordRecursive(charRange, writer, sb, maxDepth, currentDepth + 1);
                sb.Remove(sb.Length - 1, 1);
            }
        }
    }
}