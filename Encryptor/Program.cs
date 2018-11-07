using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Linq;

namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = args.Where(t => File.Exists(t)).ToList();
            if (files.Count == 0)
            {
                Console.WriteLine("ファイルを、exeにドラッグドロップしてください。");
                Console.ReadLine();
                return;
            }

            var name = Path.ChangeExtension(files[0], ".zip");
            if (File.Exists(name))
            {
                Console.WriteLine($"\"{name}\"");
                Console.WriteLine("を作成しようと思いましたが、既に存在します。");
                Console.ReadLine();
                return;
            }

            var zip = ZipFile.Create(name);
            zip.BeginUpdate();

            foreach (var file in files)
            {
                zip.Add(file);
            }

            zip.CommitUpdate();
        }
    }
}
