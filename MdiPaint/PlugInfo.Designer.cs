namespace MdiPaint
{
    partial class PlugInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.plugins = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.plugins)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(181, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список плагинов";
            // 
            // plugins
            // 
            this.plugins.AllowUserToAddRows = false;
            this.plugins.AllowUserToDeleteRows = false;
            this.plugins.AllowUserToResizeRows = false;
            this.plugins.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.plugins.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.plugins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.plugins.Location = new System.Drawing.Point(48, 50);
            this.plugins.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.plugins.Name = "allPlugins";
            this.plugins.RowHeadersVisible = false;
            this.plugins.RowHeadersWidth = 51;
            this.plugins.Size = new System.Drawing.Size(429, 245);
            this.plugins.TabIndex = 1;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(186, 301);
            this.add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(142, 43);
            this.add.TabIndex = 2;
            this.add.Text = "Применить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // PlugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 357);
            this.Controls.Add(this.add);
            this.Controls.Add(this.plugins);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "PlugInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Информация о плагинах";
            ((System.ComponentModel.ISupportInitialize)(this.plugins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView plugins;
        private System.Windows.Forms.Button add;
    }
}