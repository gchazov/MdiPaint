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
    public partial class MainForm : Form
    {
        public static Color Colour { get; set; }        
        public static int BrushWidth { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Colour = Color.Black;
            BrushWidth = 3; 
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
            var newDoc = new DocumentForm();
            newDoc.MdiParent = this;
            newDoc.Show();
        }

        private void CanvasToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            canvasSize.Enabled = ActiveMdiChild != null;
        }

        private void canvasSize_Click(object sender, EventArgs e)
        {
            new CanvasSizeForm(this).ShowDialog();
        }
    }
}
