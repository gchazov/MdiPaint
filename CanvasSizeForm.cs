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
    public partial class CanvasSizeForm : Form
    {
        MainForm mf;
        public CanvasSizeForm(MainForm m)
        {
            InitializeComponent();
            mf = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (ValidateIntInput(w.Text) && ValidateIntInput(h.Text))
            {
                this.DialogResult = DialogResult.OK;
                mf.ImageH = int.Parse(h.Text);
                mf.ImageW = int.Parse(w.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введены значения!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateIntInput(string s)
        {
            Regex regex = new Regex(@"[0-9]{1,4}");
            return regex.IsMatch(s);
        }
    }
}
