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
    public class ShufflePlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Разбить и перемешать";
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
            int k = 3;
            int width = input.Width / k;
            int height = input.Height / k;

            Bitmap[] imageParts = new Bitmap[k*k];

            int index = 0;
            for (int y = 0; y < k; y++)
            {
                for (int x = 0; x < k; x++)
                {
                    imageParts[index] = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(imageParts[index]))
                    {
                        g.DrawImage(input, new Rectangle(0, 0, width, height), new Rectangle(x * width, y * height, width, height), GraphicsUnit.Pixel);
                    }
                    index++;
                }
            }

            Random random = new Random();
            for (int i = 0; i < imageParts.Length; i++)
            {
                int randomIndex = random.Next(i, imageParts.Length);
                Bitmap temp = imageParts[i];
                imageParts[i] = imageParts[randomIndex];
                imageParts[randomIndex] = temp;
            }

            using (Graphics g = Graphics.FromImage(input))
            {
                index = 0;
                for (int y = 0; y < k; y++)
                {
                    for (int x = 0; x < k; x++)
                    {
                        g.DrawImage(imageParts[index], new Rectangle(x * width, y * height, width, height));
                        index++;
                    }
                }
            }
        }
    }
}