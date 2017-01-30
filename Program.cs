using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();
            var fileSuffix = 0;

            using (var file = File.OpenRead(@"C:\your\target\here.txt"))
            using (var reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());

                    if (list.Count >= 1000000)
                    {
                        File.WriteAllLines(@"C:\your\destination\here" + (++fileSuffix) + ".txt", list);
                        list = new List<string>();
                    }
                }
            }

            File.WriteAllLines(@"C:\your\destination\here" + (++fileSuffix) + ".txt", list);
        }
    }
}
