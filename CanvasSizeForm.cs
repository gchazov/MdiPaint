using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class CanvasSizeForm : Form
    {
        public CanvasSizeForm()
        {
            InitializeComponent();
            h.Text = MainForm.ImageH.ToString();
            w.Text = MainForm.ImageW.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int height, width;

            int.TryParse(h.Text, out height);
            int.TryParse(w.Text, out width);

            if (ValidateIntInput(w.Text) && ValidateIntInput(h.Text)
                && height > 0 && width > 0 && width <= 1980 && height <= 1080)
            {
                MainForm.ImageH = int.Parse(h.Text);
                MainForm.ImageW = int.Parse(w.Text);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильно введены значения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                h.Text = MainForm.ImageH.ToString();
                w.Text = MainForm.ImageW.ToString();
            }
        }

        private bool ValidateIntInput(string s)
        {
            Regex regex = new Regex(@"[0-9]{1,4}");
            return regex.IsMatch(s);
        }
    }
}
