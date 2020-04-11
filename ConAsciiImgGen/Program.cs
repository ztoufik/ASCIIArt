using System;
using System.IO;

namespace ConAsciiImgGen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(" the image file path ? ");
            string filepath =Console.ReadLine();
            if (File.Exists(filepath)
            {
                int[,][] arrpixels = AsciiImgGen.GetPixelArr(filepath);
                string AsciiString = AsciiImgGen.Convert(arrpixels);

                File.WriteAllText("./output.txt", AsciiString);
                System.Diagnostics.Process.Start("CMD.exe", @"/c notepad.exe ./output.txt");
            }

            else
            {
                Console.WriteLine("no such file exists");
            }
        }

    }
}
