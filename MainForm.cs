using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MdiPaint
{
    public enum Tools
    {
        Pen,
        Line,
        Ellipse,
        Star,
        Eraser
    }
    public partial class MainForm : Form
    {
        public static Color BrushColor { get; set; } = Color.Black;
        public static int BrushWidth { get; set; } = 5;
        public static int CountMdi { get; set; } = 0;
        public static int ImageW { get; set; } = 600;
        public static int ImageH { get; set; } = 600;
        public bool IsChanged { get; set; } = false;
        public static int StarConfig { get; set; } = 5;
        public static Size ZoomSize { get; set; } = new Size((int)(ImageW * 0.05), (int)(ImageH * 0.05));
        public Tools tools { get; set; }


        public MainForm()
        {
            InitializeComponent();
            PenToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
            FivetoolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
            brushWidth.Text = BrushWidth.ToString();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountMdi++;
            var newDoc = new DocumentForm(this);
            newDoc.MdiParent = this;
            newDoc.Show();
        }

        private void CanvasToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            canvasSize.Enabled = ActiveMdiChild != null;
        }

        private void canvasSize_Click(object sender, EventArgs e)
        {
            CanvasSizeForm csf = new CanvasSizeForm();
            if (csf.ShowDialog() == DialogResult.OK)
            {
                ((DocumentForm)ActiveMdiChild).ResizeDoc();
            }
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrushColor = Color.Red;
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrushColor = Color.Blue;
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrushColor = Color.Green;
        }

        private void AnotherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                BrushColor = cd.Color;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void LeftToRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void UpdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save.Enabled = ActiveMdiChild != null;
            SaveAs.Enabled = ActiveMdiChild != null;
        }

        private void WindowToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            leftToRight.Enabled = ActiveMdiChild != null;
            UpDown.Enabled = ActiveMdiChild != null;
            cascade.Enabled = ActiveMdiChild != null;
            Arrange.Enabled = ActiveMdiChild != null;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files|*.*|*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png";
            if (ofd.ShowDialog() == DialogResult.OK && CheckOpenFile(ofd.FileName))
            {
                DocumentForm newDoc = new DocumentForm(this, ofd.FileName);
                newDoc.MdiParent = this;
                newDoc.Show();
            }
        }

        bool CheckOpenFile(string s)
        {
            Regex rgx = new Regex(@"[^\s]+(jpg|bmp|png)$");
            return rgx.IsMatch(s);
        }

        public void Save_Click(object sender, EventArgs e)
        {
            ((DocumentForm)ActiveMdiChild).Image.Save(ActiveMdiChild.Text);
            IsChanged = true;
            ((DocumentForm)ActiveMdiChild).LocalChanged = false;
        }

        public void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|All files|*.*";
            sfd.FileName = $"{((DocumentForm)ActiveMdiChild).Text}";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Save_Click(sender, e);
                ActiveMdiChild.Text = sfd.FileName;
            }
        }

        private void DeleteIcons()
        {
            PenToolStripMenuItem.Image = null;
            LineToolStripMenuItem.Image = null;
            EllipseToolStripMenuItem1.Image = null;
            StarToolStripMenuItem.Image = null;
            EraserToolStripMenuItem.Image = null;
        }

        private void PenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tools = Tools.Pen;
            DeleteIcons();
            PenToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tools = Tools.Line;
            DeleteIcons();
            LineToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void EllipseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tools = Tools.Ellipse;
            DeleteIcons();
            EllipseToolStripMenuItem1.Image = MdiPaint.Properties.Resources.choice;
        }

        private void StarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tools = Tools.Star;
            DeleteIcons();
            StarToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void EraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tools = Tools.Eraser;
            DeleteIcons();
            EraserToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void brushWidth_ValueChanged(object sender, EventArgs e)
        {
            MainForm.BrushWidth = (int)brushWidth.Value;
        }

        private void zoom_in_Click(object sender, EventArgs e)
        {
            try
            {
                ((DocumentForm)ActiveMdiChild).Image = DocumentForm.ZoomIn(((DocumentForm)ActiveMdiChild).Image, ZoomSize);
                ((DocumentForm)ActiveMdiChild).Invalidate();
            }
            catch { }
        }

        private void zoom_out_Click(object sender, EventArgs e)
        {
            try
            {
                ((DocumentForm)ActiveMdiChild).Image = DocumentForm.ZoomOut(((DocumentForm)ActiveMdiChild).Image, ZoomSize);
                ((DocumentForm)ActiveMdiChild).Invalidate();
            }
            catch { }
        }

        private void DeleteZoomIcons()
        {
            FivetoolStripMenuItem.Image = null;
            TentoolStripMenuItem.Image = null;
            FifteentoolStripMenuItem.Image = null;
            TventyfiveStripMenuItem2.Image = null;
            FourtytoolStripMenuItem2.Image = null;
        }

        private void FivetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            FivetoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomSize = new Size((int)(ImageW * 0.005), (int)(ImageH * 0.005));
        }

        private void TentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            TentoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomSize = new Size((int)(ImageW * 0.01), (int)(ImageH * 0.01));
        }

        private void FifteentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            FifteentoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomSize = new Size((int)(ImageW * 0.015), (int)(ImageH * 0.015));
        }

        private void TventyfiveStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            TventyfiveStripMenuItem2.Image = Properties.Resources.choice;
            MainForm.ZoomSize = new Size((int)(ImageW * 0.025), (int)(ImageH * 0.025));
        }

        private void FourtytoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            FourtytoolStripMenuItem2.Image = Properties.Resources.choice;
            MainForm.ZoomSize = new Size((int)(ImageW * 0.05), (int)(ImageH * 0.05));
        }

        private void StarConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarConfig sc = new StarConfig();
            sc.ShowDialog();
        }
    }
}
