using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DatePlugin
{
    [Version(1, 0)]
    public class DatePlugin : IPlugin
    {
        public string Name => "Дата и место";

        public string Author => "Глеб Чазов, РИС-22-1";

        public void Transform(Bitmap input)
        {
            using (Graphics g = Graphics.FromImage(input))
            {
                string currentDate = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                Font font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
                SolidBrush brush = new SolidBrush(Color.White);
                g.DrawString(currentDate, font, brush, input.Width - 150, input.Height - 50);

                string locationData = "Россия, г. Пермь";
                g.DrawString(locationData, font, brush, input.Width - 150, input.Height - 30);
            }
        }
    }
}
