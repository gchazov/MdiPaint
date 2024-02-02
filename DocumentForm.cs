using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
        private bool IsClosing { get; set; } = false;



        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = (int)(e.X / MainForm.Zoom);
            y = (int)(e.Y / MainForm.Zoom);
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            int x = (int)(e.X / MainForm.Zoom);
            int y = (int)(e.Y / MainForm.Zoom);
            mainForm.coord.Text = $"X:{e.X} Y:{e.Y}";
            if (e.Button != MouseButtons.Left)
                return;
            if (mainForm.Tools == Tools.Pen || mainForm.Tools == Tools.Eraser)
            {
                graphics = Graphics.FromImage(Image);
                Color paintingColor = mainForm.Tools == Tools.Eraser ? Color.White : MainForm.BrushColor;
                var pen = new Pen(paintingColor, MainForm.BrushWidth);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                graphics.DrawLine(pen, this.x, this.y, x, y);
                mainForm.IsChanged = true;
                LocalChanged = true;

                Invalidate();
                this.x = x;
                this.y = y;
            }
            else
            {
                Temp = new Bitmap(Image.Width, Image.Height);
                graphics = Graphics.FromImage(Temp);
                switch (mainForm.Tools)
                {
                    case Tools.Line:
                        graphics.DrawLine(new Pen(MainForm.BrushColor, MainForm.BrushWidth), this.x, this.y, x, y);
                        break;
                    case Tools.Ellipse:
                        graphics.DrawEllipse(new Pen(MainForm.BrushColor, MainForm.BrushWidth), this.x, this.y, x - this.x, y - this.y);
                        break;
                    case Tools.Star:
                        PointF[] pts = StarPoints(MainForm.StarConfig, new Rectangle(new Point(this.x, this.y), new Size(x - this.x, y - this.y)));
                        graphics.DrawPolygon(new Pen(MainForm.BrushColor, MainForm.BrushWidth), pts);
                        break;
                }
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.ScaleTransform(MainForm.Zoom, MainForm.Zoom); // Применяем масштабирование
            e.Graphics.DrawImage(Image, 0, 0); // Рисуем изображение
            if (mainForm.Tools == Tools.Line || mainForm.Tools == Tools.Ellipse || mainForm.Tools == Tools.Star)
                e.Graphics.DrawImage(Temp, 0, 0);
        }

        public void ResizeDoc()
        {
            Bitmap tmp = (Bitmap)Image.Clone();
            Image = new Bitmap(MainForm.ImageW, MainForm.ImageH);
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
            Image = new Bitmap(MainForm.ImageW, MainForm.ImageH);
            Temp = new Bitmap(Image.Width, Image.Height);
            graphics = Graphics.FromImage(Image);
            graphics.Clear(Color.White);
            LocalChanged = true;
            this.Text = $"Рисунок {MainForm.CountMdi}";

        }

        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mainForm.Tools == Tools.Line)
            {
                graphics = Graphics.FromImage(Image);
                graphics.DrawLine(new Pen(MainForm.BrushColor, MainForm.BrushWidth), x, y, (int)(e.X / MainForm.Zoom), (int)(e.Y / MainForm.Zoom));
            }
            if (mainForm.Tools == Tools.Ellipse)
            {
                graphics = Graphics.FromImage(Image);
                graphics.DrawEllipse(new Pen(MainForm.BrushColor, MainForm.BrushWidth), x, y, (int)((e.X / MainForm.Zoom - x)), (int)((e.Y / MainForm.Zoom - y)));
            }
            if (mainForm.Tools == Tools.Star)
            {
                graphics = Graphics.FromImage(Image);
                PointF[] pts = StarPoints(MainForm.StarConfig, new Rectangle(new Point(x, y), new Size((int)((e.X / MainForm.Zoom - x)), (int)((e.Y / MainForm.Zoom - y)))));
                graphics.DrawPolygon(new Pen(MainForm.BrushColor, MainForm.BrushWidth), pts);
            }
            Temp = new Bitmap(1, 1);
            Invalidate();
            mainForm.IsChanged = true;
            LocalChanged = true;
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

        
        private void DocumentForm_Leave(object sender, EventArgs e)
        {
            mainForm.coord.Text = $"X:0 Y:0";
        }

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LocalChanged && !IsClosing)
            {
                switch (MessageBox.Show($"Есть несохранённые изменения в {this.Text}.\nВы хотите сохранить рисунок?",
                    "Сохранение изменений", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|All files|*.*";
                        sfd.FileName = $"{this.Text}";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.Image.Save(sfd.FileName);
                            mainForm.IsChanged = true;
                            this.LocalChanged = false;
                            this.Text = sfd.FileName;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.No:
                        IsClosing = true;
                        this.Close();
                        break;
                }
            }
        }

        public void ZoomOut()
        {
            MainForm.Zoom -= MainForm.ZoomRange;
            Invalidate();
        }

        public void ZoomIn()
        {
            MainForm.Zoom += MainForm.ZoomRange;
            Invalidate();
        }

        private static PointF[] StarPoints(int num_points, Rectangle bounds)
        {
            PointF[] pts = new PointF[num_points * 2];
            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            double theta = -Math.PI / 2;
            double dtheta = Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[2 * i] = new PointF(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                pts[2 * i + 1] = new PointF(
                    (float)(cx + rx / 2 * Math.Cos(theta + dtheta)),
                    (float)(cy + ry / 2 * Math.Sin(theta + dtheta)));
                theta += 2 * dtheta;
            }

            return pts;
        }
    }
}
