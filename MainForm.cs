using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class MainForm : Form
    {
        public static Color BrushColor { get; set; } = Color.Black;
        public static int BrushWidth { get; set; } = 15;
        public static int CountMdi { get; set; } = 0;
        public int ImageW { get; set; } = 600;
        public int ImageH { get; set; } = 600;
        public bool IsChanged { get; set; } = false;


        public MainForm()
        {
            InitializeComponent();
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
            CanvasSizeForm csf = new CanvasSizeForm(this);
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

        private void Save_Click(object sender, EventArgs e)
        {
            ((DocumentForm)ActiveMdiChild).Image.Save(ActiveMdiChild.Text);
            IsChanged = true;
            ((DocumentForm)ActiveMdiChild).LocalChanged = false;
        }

        private void SaveAs_Click(object sender, EventArgs e)
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
    }
}
