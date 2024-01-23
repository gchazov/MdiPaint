using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            graphics = Graphics.FromImage(Image);
            var pen = new Pen(MainForm.BrushColor, MainForm.BrushWidth);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            graphics.DrawLine(pen, x, y, e.X, e.Y);
            x = e.X;
            y = e.Y;
            Invalidate();
            mainForm.IsChanged = true;
            LocalChanged = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //if (mainForm.tools != Tools.Pen && mainForm.tools != Tools.Eraser)
                e.Graphics.DrawImage(Image, 0, 0);
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
    }
}
