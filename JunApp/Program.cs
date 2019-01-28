using System;
using System.IO;

namespace Jun.App
{
    class Program : IIncludeResolver, INameResolver, IStringResolver
    {
        static void Main(string[] args)
        {
            Program prg = new Program();
            string input = File.ReadAllText("test.jc");
            Parser parser = new Parser("TEST", input) {
                IncludeResolver = prg,
                NameResolver = prg,
                StringResolver = prg,
            };

            parser.Process();

            Console.WriteLine(Visualizer.Show(parser.DefinedScripts));

            Console.ReadKey();
        }

        short stringId = 0;
        short nameId = 100;

        public string GetSourceCode(string module)
        {
            return File.ReadAllText(module + ".JC");
        }

        public short GetStringID(string source)
        {
            Console.WriteLine($"(String #{stringId} = {source})");
            return stringId++;
        }

        public short GetNameValue(string name)
        {
            Console.WriteLine($"(Name #{nameId} = {name})");
            return nameId++;
        }
    }
}
