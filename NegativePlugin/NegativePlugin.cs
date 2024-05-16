using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegativePlugin
{
    [Version(1, 0)]
    public class NegativePlugin : IPlugin
    {
        public string Name => "Негатив";

        public string Author => "Глеб Чазов, РИС-22-1";

        public void Transform(Bitmap input)
        {
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color pixelColor = input.GetPixel(x, y);

                    int r = 255 - pixelColor.R;
                    int g = 255 - pixelColor.G;
                    int b = 255 - pixelColor.B;

                    input.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
        }
    }
}
