using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string srcPath = @"D:\Univer\5year\NPAs";
            const string dstPath = @"D:\Univer\5year\NPAs\Texts";
            const string dstPdfPath = @"D:\Univer\5year\NPAs\PDFs";
            Console.OutputEncoding = Encoding.UTF8;

            var files = Directory.GetFiles(srcPath, "*.pdf").Select(x => x.Split('\\').Last()).ToArray();
            var textFiles = Directory.GetFiles(dstPath, "*.txt");
            var toFind = " по обезличиванию";
            foreach (var file in textFiles)
            {
                var lines = File.ReadAllLines(file);
                var nameWritten = false;
                for (var i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(toFind, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!nameWritten)
                        {
                            Console.Write(file.Split('\\').Last());
                        }
                        Console.WriteLine($" Line - {i} \nContent - {lines[i]}\n");
                    }
                }
            }
            Console.WriteLine("All done");
            Console.ReadLine();
        }
    }
}
