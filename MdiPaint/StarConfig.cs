using System;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class StarConfig : Form
    {
        public StarConfig()
        {
            InitializeComponent();
            number.Text = MainForm.StarConfig.ToString();
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;
            string msgText = "";
            int.TryParse(number.Text, out num);
            if (number.Text != "" && num >= 4)
            {
                MainForm.StarConfig = int.Parse(number.Text);
                this.Close();
            }
            else
            {
                msgText = num < 4 ? "У звезды должно быть хотя бы 4 конца!" : "Не оставляйте поле ввода пустым или нулевым!";
                MessageBox.Show(msgText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
