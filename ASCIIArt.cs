using System;
using System.IO;

using System.Drawing;
using System.Linq;


namespace POE
{
    public class ASCIIArt
    {
        public ASCIIArt()
        {

            Logo();

        }

        private void Logo()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string newPath = path.Replace("bin\\Debug\\net9.0\\", "");
            string fullPath = Path.Combine(newPath, "text.jpg");

            Bitmap image1 = new Bitmap(fullPath);
            image1 = new Bitmap(image1, new Size(100, 100));

            for (int height = 0; height < image1.Height; height++)
            {
                for (int width = 0; width < image1.Width; width++)
                {
                    Color pixelColor = image1.GetPixel(width, height);
                    int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    char asciiDesign = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? 'O' : color > 50 ? '#' : '@';
                    Console.Write(asciiDesign);
                }
                Console.WriteLine();
            }

        }

    }

}
   
