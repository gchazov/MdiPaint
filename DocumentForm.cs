using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class DocumentForm : Form
    {
        private int x, y;
        private Bitmap bitmap;

        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(new Pen(MainForm.Colour, MainForm.BrushWidth), x, y, e.X, e.Y);
            Invalidate();
            x = e.X; y = e.Y;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        public DocumentForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(300, 200);

        }
    }
}
