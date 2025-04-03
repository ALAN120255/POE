using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    public class ASCIIArt
    {
        public ASCIIArt()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string newPath = path.Replace("bin\\Debug\\", "");
                string fullPath = Path.Combine(newPath, "ascii-text-art.jpg");

                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException("The specified image file was not found.", fullPath);
                }

                Bitmap image = new Bitmap(fullPath);
                image = new Bitmap(image, new Size(50, 100));

                for (int height = 0; height < image.Height; height++)
                {
                    for (int width = 0; width < image.Width; width++)
                    {
                        Color pixelColor = image.GetPixel(width, height);
                        int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        char asciiDesign = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? 'O' : color > 50 ? '#' : '@';
                        Console.Write(asciiDesign);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading ASCII art: {ex.Message}");
            }
        }
    }
}
