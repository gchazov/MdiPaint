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
    public partial class ConfigForm : Form
    {
        public ConfigForm(MainForm mf)
        {
            InitializeComponent();
            foreach (string name in mf.allPlugins.Keys)
            {
                
            }
        }
    }
}
