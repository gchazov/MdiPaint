﻿using System;
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
            
        }
    }
}