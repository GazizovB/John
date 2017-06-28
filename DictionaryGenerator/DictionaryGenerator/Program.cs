using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var generator = new NameDictionaryGenerator(@"D:\Perso\Dropbox\Apps\JohnTheRipper\prenoms.lst");
            //generator.Generate(@"C:\Temp\JohnTheRipper\NamesDictionary.lst");

            //var generator = new NumberDictionaryGenerator();
            //generator.Generate(@"C:\Temp\JohnTheRipper\NumbersDictionary.lst");

            var generator = new SmallWordsDictionaryGenerator();
            generator.Generate(@"C:\Temp\JohnTheRipper\SmallWordsDictionary.lst");
        }
    }
}
