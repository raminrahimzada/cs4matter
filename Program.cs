using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;

namespace CSharpFormatter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1&& args.Length != 2)
            {
                Console.WriteLine(@"usage: cs4matter {input-file} [output-file]");
                return -1;
            }

            var inputFile = args[0];
            var outputFile = args.Length == 2 ? args[1] : inputFile;
            try
            {
                
                var source = File.ReadAllText(inputFile);
                var tree = SyntaxFactory.ParseSyntaxTree(SourceText.From(source));
                using (var workspace = new AdhocWorkspace())
                {
                    var formattedRoot = Formatter.Format(tree.GetRoot(), workspace);
                    var actualFormattedText = formattedRoot.ToFullString();
                    File.WriteAllText(outputFile, actualFormattedText);
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -2;
            }
        }
    }
}
