using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class NameDictionaryGenerator
    {
        private readonly string _initialPath;

        public NameDictionaryGenerator(string initialePath)
        {
            _initialPath = initialePath;
        }

        public void Generate(string outputPath)
        {
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            var names = File.ReadAllLines(_initialPath).Where(s => !s.StartsWith("#"));

            using (var writer = new StreamWriter(outputPath))
            {
                foreach (var name in names)
                {
                    // All lowercase, with diacritics
                    string lowerDia = name.ToLowerInvariant();
                    writer.WriteLine(lowerDia);
                    foreach (string nameWithDate in GetNameWithDate(lowerDia))
                        writer.WriteLine(nameWithDate);

                    // All lowercase, without diacritics
                    string lower = name.RemoveDiacritics().ToLowerInvariant();
                    writer.WriteLine(lower);
                    foreach (string nameWithDate in GetNameWithDate(lower))
                        writer.WriteLine(nameWithDate);

                    // All Uppercase, without diacritics
                    string upper = lower.ToUpperInvariant();
                    writer.WriteLine(upper);
                    foreach (string nameWithDate in GetNameWithDate(upper))
                        writer.WriteLine(nameWithDate);

                    // First character uppercase, with diacritics (except for first character)
                    string val = upper.Substring(0, 1) + lowerDia.Substring(1);
                    writer.WriteLine(val);
                    foreach (string nameWithDate in GetNameWithDate(val))
                        writer.WriteLine(nameWithDate);

                    // First character uppercase, without diacritics
                    val = upper.Substring(0, 1) + lower.Substring(1);
                    writer.WriteLine(val);
                    foreach (string nameWithDate in GetNameWithDate(val))
                        writer.WriteLine(nameWithDate);

                    // 1 Letter on 2 uppercase
                    bool b = true;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < lower.Length; i++)
                    {
                        if (b)
                            sb.Append(upper[i]);
                        else
                            sb.Append(lower[i]);

                        b = !b;
                    }
                    val = sb.ToString();
                    writer.WriteLine(val);
                    foreach (string nameWithDate in GetNameWithDate(val))
                        writer.WriteLine(nameWithDate);

                    // And reverse
                    b = false;
                    sb = new StringBuilder();
                    for (int i = 0; i < lower.Length; i++)
                    {
                        if (b)
                            sb.Append(upper[i]);
                        else
                            sb.Append(lower[i]);

                        b = !b;
                    }
                    val = sb.ToString();
                    writer.WriteLine(val);
                    foreach (string nameWithDate in GetNameWithDate(val))
                        writer.WriteLine(nameWithDate);
                }
            }
        }

        private IList<string> GetNameWithDate(string name)
        {
            DateTime start = new DateTime(2016, 1, 1); // Leap year (bissextile)
            DateTime end = new DateTime(2016, 12, 31);

            var names = new List<string>();
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                names.Add(name + date.ToString("ddMM"));
                names.Add(name + date.ToString("MMdd"));
            }

            return names.Distinct().ToList();
        }
    }
}