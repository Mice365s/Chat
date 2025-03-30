using System.Drawing;
using System;

namespace Chat
{
    public class pic
    {
        public pic()
        {
            displayImage();
        }

        public void displayImage()
        {
            //image path
            string path = "download.jpg";
            Bitmap image = new Bitmap(path);
            int width = 80;  // Adjust width for console
            int height = (int)(image.Height / (image.Width / (double)width));

            Bitmap resized = new Bitmap(image, new Size(width, height));
            string chars = "@%#*+=-:. ";

            for (int y = 0; y < resized.Height; y++)
            {
                for (int x = 0; x < resized.Width; x++)
                {
                    Color pixelColor = resized.GetPixel(x, y);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int index = gray * (chars.Length - 1) / 255;
                    Console.Write(chars[index]);
                }
                Console.WriteLine();
            }
        }
    }
}
