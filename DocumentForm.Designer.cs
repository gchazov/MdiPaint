﻿namespace MdiPaint
{
    partial class DocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            this.SuspendLayout();
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DocumentForm";
            this.Text = "DocumentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentForm_FormClosing);
            this.Leave += new System.EventHandler(this.DocumentForm_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}