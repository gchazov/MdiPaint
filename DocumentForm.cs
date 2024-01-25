using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class DocumentForm : Form
    {
        private int x, y;
        private MainForm mainForm;
        private Graphics graphics;
        

        public bool LocalChanged { get; set; }
        public Bitmap Image { get; set; }
        public Bitmap Temp { get; set; }


        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            if (mainForm.tools == Tools.Pen || mainForm.tools == Tools.Eraser)
            {
                graphics = Graphics.FromImage(Image);
                Color paintingColor = mainForm.tools == Tools.Eraser ? Color.White : MainForm.BrushColor;
                var pen = new Pen(paintingColor, MainForm.BrushWidth);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                graphics.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
                Invalidate();
                mainForm.IsChanged = true;
                LocalChanged = true;
                return;
            }
            Temp = new Bitmap(Image.Width, Image.Height);
            graphics = Graphics.FromImage(Temp);
            switch (mainForm.tools)
            {
                case Tools.Line:
                    graphics.DrawLine(new Pen(MainForm.BrushColor, MainForm.BrushWidth), x, y, e.X, e.Y);
                    break;
                case Tools.Ellipse:
                    graphics.DrawEllipse(new Pen(MainForm.BrushColor, MainForm.BrushWidth), x, y, e.X - x, e.Y - y);
                    break;
            }
            Invalidate();
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(Image, 0, 0);
            if (mainForm.tools == Tools.Line || mainForm.tools == Tools.Ellipse || mainForm.tools == Tools.Star)
                e.Graphics.DrawImage(Temp, 0, 0);
        }

        public void ResizeDoc()
        {
            Bitmap tmp = (Bitmap)Image.Clone();
            Image = new Bitmap(mainForm.ImageW, mainForm.ImageH);
            graphics = Graphics.FromImage(Image);
            graphics.Clear(Color.White);
            for (int Xcount = 0; Xcount < tmp.Width && Xcount < Image.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < tmp.Height && Ycount < Image.Height; Ycount++)
                {
                    Image.SetPixel(Xcount, Ycount, tmp.GetPixel(Xcount, Ycount));
                }
            }
            Invalidate();
            mainForm.IsChanged = true;
            LocalChanged = true;
        }

        public DocumentForm(MainForm parent)
        {
            InitializeComponent();
            mainForm = parent;
            Image = new Bitmap(parent.ImageW, parent.ImageH);
            Temp = new Bitmap(Image.Width, Image.Height);
            graphics = Graphics.FromImage(Image);
            graphics.Clear(Color.White);
            LocalChanged = true;    
            this.Text = $"Рисунок {MainForm.CountMdi}";

        }

        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainForm.tools == Tools.Line)
            {
                graphics = Graphics.FromImage(Image);
                graphics.DrawLine(new Pen(MainForm.BrushColor, MainForm.BrushWidth), x, y, e.X, e.Y);
                Temp = new Bitmap(1, 1);
                Invalidate();
                mainForm.IsChanged = true;
                LocalChanged = true;
            }
            if (mainForm.tools == Tools.Ellipse)
            {
                graphics = Graphics.FromImage(Image);
                graphics.DrawEllipse(new Pen(MainForm.BrushColor, MainForm.BrushWidth),x, y, e.X - x, e.Y - y);
                Temp = new Bitmap(1, 1);
                Invalidate();
                mainForm.IsChanged = true;
                LocalChanged = true;
            }
        }


        public DocumentForm(MainForm parent, string file)
        {
            InitializeComponent();
            mainForm = parent;
            using (Stream s = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                Image = new Bitmap(s);
            }
            Temp = new Bitmap(Image.Width, Image.Height);
            Text = file;
            LocalChanged = false;
        }

        public static Bitmap ZoomIn(Image image, Size size)
        {
            Bitmap bitmap = new Bitmap(image, image.Width + (image.Width * size.Width / 100),
                image.Height + (image.Height * size.Height / 100));
            Graphics tempGraphics = Graphics.FromImage(bitmap);
            tempGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bitmap;
        }

        public static Bitmap ZoomOut(Image image, Size size)
        {
            Bitmap bitmap = new Bitmap(image, image.Width - (image.Width * size.Width / 100),
                image.Height - (image.Height * size.Height / 100));
            Graphics tempGraphics = Graphics.FromImage(bitmap);
            tempGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            return bitmap;
        }

    }
}
