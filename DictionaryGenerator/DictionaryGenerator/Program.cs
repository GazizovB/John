namespace DictionaryGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var generator = new NameDictionaryGenerator(@"D:\Perso\Dropbox\Apps\JohnTheRipper\prenoms.lst");
            //generator.Generate(@"C:\Temp\JohnTheRipper\NamesDictionary.lst");

            //var generator = new NumberDictionaryGenerator();
            //generator.Generate(@"C:\Temp\JohnTheRipper\NumbersDictionary.lst");

            var generator = new SmallWordsDictionaryGenerator();
            generator.Generate(5, @"C:\Temp\JohnTheRipper\SimpleWordsNumbersDictionary.lst", true, false, true, false);
        }
    }
}