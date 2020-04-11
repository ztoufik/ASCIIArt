
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ConAsciiImgGen
{
    static internal class AsciiImgGen
    {
         static private string AsciiChars =
            "`^\",:;Il!i~+_-?][}{1)(|\\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        static internal int[,][] GetPixelArr( string filepath)
        {
            Bitmap image = new Bitmap(filepath);
            int[,][] outputpixels = new int[image.Width, image.Height][];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    outputpixels[x, y] = new int[3];
                    Color color = image.GetPixel(x, y);
                    outputpixels[x, y][0] = color.R;
                    outputpixels[x, y][1] = color.G;
                    outputpixels[x, y][2] = color.B;
                    
                    
                }
            }
            return outputpixels;
        }

        static private char Map(int[] pixel)
        {
            int value = pixel.Sum() / 3;
            value = value * AsciiChars.Length / 256;
            return AsciiChars[value];
        }

        static internal string Convert(int[,][] pixels)
        {
            StringBuilder output = new StringBuilder();

            for (int y = 0; y < pixels.GetLength(1); y++)
            {
                for (int x = 0; x < pixels.GetLength(0); x++)
                {
                    output.Append(Map(pixels[x, y]));
                    output.Append(Map(pixels[x, y]));
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString(); 
        }

    }
}
