using System.IO;

namespace DictionaryGenerator
{
    public class NumberDictionaryGenerator
    {
        public void Generate(string outputPath)
        {
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            using (var writer = new StreamWriter(outputPath))
            { 
                for (int i = 0; i < 99999999; ++i)
                {
                    writer.WriteLine(i.ToString());
                }
            }
        }
    }
}