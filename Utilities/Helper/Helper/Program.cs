using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string src = @"..\..\..\..\..\..\";
            const string srcPath = src + @"PDn\NPAs";
            const string dstPath = src + @"PDn\NPAs\Texts";
            const string dstPdfPath = src + @"PDn\NPAs\PDFs";
            Console.OutputEncoding = Encoding.UTF8;

            var files = Directory.GetFiles(srcPath, "*.pdf").Select(x => x.Split('\\').Last()).ToArray();
            var textFiles = Directory.GetFiles(dstPath, "*.txt");
            var toFind = new Regex(@"журна[а-я]+ учет", RegexOptions.IgnoreCase); //[а-я]+
            foreach (var file in textFiles)
            {
                var lines = File.ReadAllLines(file);
                var nameWritten = false;
                for (var i = 0; i < lines.Length; i++)
                {
                    if (toFind.IsMatch(lines[i]))
                    {
                        if (!nameWritten)
                        {
                            Console.Write(file.Split('\\').Last());
                            nameWritten = false;
                        }
                        Console.WriteLine($" Line - {i} \nContent - {lines[i]}\n");
                    }
                }
            }
            Console.WriteLine("All done");
            foreach (var file in textFiles)
            {
                var lines = File.ReadAllText(file);
                var nameWritten = false;
                foreach (var mtch in toFind.Matches(lines))
                {
                    if (toFind.IsMatch(lines))
                    {
                        if (!nameWritten)
                        {
                            Console.Write(file.Split('\\').Last());
                            nameWritten = false;
                        }
                        Console.WriteLine($"Content - {mtch}\n");
                    }
                }
            }

            Console.WriteLine("All done");
            Console.ReadLine();
        }
    }
}
