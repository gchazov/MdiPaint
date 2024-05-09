using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;
using System.Drawing;
using System.Globalization;

namespace ReversePlugin
{
    [Version(1, 0)]
    public class SobelPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Фильтр Собеля";
            }
        }

        public string Author
        {
            get
            {
                return "Глеб Чазов, РИС-22-1";
            }
        }

        public void Transform(Bitmap input)
        {
            int width = input.Width;
            int height = input.Height;

            Bitmap output = new Bitmap(width, height);

            int[,] sobelX = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
            };

            int[,] sobelY = {
            { -1, -2, -1 },
            { 0, 0, 0 },
            { 1, 2, 1 }
            };

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    int pixelX = 0;
                    int pixelY = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = input.GetPixel(x + j, y + i);
                            int gray = (int)(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11);

                            pixelX += gray * sobelX[i + 1, j + 1];
                            pixelY += gray * sobelY[i + 1, j + 1];
                        }
                    }

                    int magnitude = (int)Math.Sqrt(pixelX * pixelX + pixelY * pixelY);
                    magnitude = Math.Min(255, Math.Max(0, magnitude));

                    output.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    input.SetPixel(x, y, output.GetPixel(x, y));
                }
            }

        }
    }

}
