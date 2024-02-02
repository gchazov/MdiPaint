namespace MdiPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.рисунокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasSize = new System.Windows.Forms.ToolStripMenuItem();
            this.кратностьПриближенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FivetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TentoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FifteentoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TventyfiveStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.FourtytoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.окноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascade = new System.Windows.Forms.ToolStripMenuItem();
            this.leftToRight = new System.Windows.Forms.ToolStripMenuItem();
            this.UpDown = new System.Windows.Forms.ToolStripMenuItem();
            this.Arrange = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.красныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.синийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зелёныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.другойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.PenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EllipseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.StarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StarConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EraserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zoom_in = new System.Windows.Forms.ToolStripButton();
            this.zoom_out = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.coord = new System.Windows.Forms.ToolStripStatusLabel();
            this.brushWidth = new System.Windows.Forms.NumericUpDown();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.рисунокToolStripMenuItem,
            this.окноToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.окноToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.Save,
            this.SaveAs,
            this.exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.DropDownOpening += new System.EventHandler(this.FileToolStripMenuItem_Click);
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.ShortcutKeyDisplayString = "Crtl+N";
            this.новыйToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.открытьToolStripMenuItem.Text = "Открыть...";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeyDisplayString = "Ctrl+S";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(291, 26);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(291, 26);
            this.SaveAs.Text = "Сохранить как...";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.ShortcutKeyDisplayString = "";
            this.exit.Size = new System.Drawing.Size(291, 26);
            this.exit.Text = "Выход";
            this.exit.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // рисунокToolStripMenuItem
            // 
            this.рисунокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canvasSize,
            this.кратностьПриближенияToolStripMenuItem});
            this.рисунокToolStripMenuItem.Name = "рисунокToolStripMenuItem";
            this.рисунокToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.рисунокToolStripMenuItem.Text = "Рисунок";
            this.рисунокToolStripMenuItem.DropDownOpening += new System.EventHandler(this.CanvasToolStripMenuItem_DropDownOpening);
            // 
            // canvasSize
            // 
            this.canvasSize.Name = "canvasSize";
            this.canvasSize.Size = new System.Drawing.Size(274, 26);
            this.canvasSize.Text = "Размер холста...";
            this.canvasSize.Click += new System.EventHandler(this.canvasSize_Click);
            // 
            // кратностьПриближенияToolStripMenuItem
            // 
            this.кратностьПриближенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FivetoolStripMenuItem,
            this.TentoolStripMenuItem,
            this.FifteentoolStripMenuItem,
            this.TventyfiveStripMenuItem2,
            this.FourtytoolStripMenuItem2});
            this.кратностьПриближенияToolStripMenuItem.Name = "кратностьПриближенияToolStripMenuItem";
            this.кратностьПриближенияToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.кратностьПриближенияToolStripMenuItem.Text = "Кратность приближения...";
            // 
            // FivetoolStripMenuItem
            // 
            this.FivetoolStripMenuItem.Name = "FivetoolStripMenuItem";
            this.FivetoolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.FivetoolStripMenuItem.Text = "5%";
            this.FivetoolStripMenuItem.Click += new System.EventHandler(this.FivetoolStripMenuItem_Click);
            // 
            // TentoolStripMenuItem
            // 
            this.TentoolStripMenuItem.Name = "TentoolStripMenuItem";
            this.TentoolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.TentoolStripMenuItem.Text = "10%";
            this.TentoolStripMenuItem.Click += new System.EventHandler(this.TentoolStripMenuItem_Click);
            // 
            // FifteentoolStripMenuItem
            // 
            this.FifteentoolStripMenuItem.Name = "FifteentoolStripMenuItem";
            this.FifteentoolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.FifteentoolStripMenuItem.Text = "15%";
            this.FifteentoolStripMenuItem.Click += new System.EventHandler(this.FifteentoolStripMenuItem_Click);
            // 
            // TventyfiveStripMenuItem2
            // 
            this.TventyfiveStripMenuItem2.Name = "TventyfiveStripMenuItem2";
            this.TventyfiveStripMenuItem2.Size = new System.Drawing.Size(120, 26);
            this.TventyfiveStripMenuItem2.Text = "25%";
            this.TventyfiveStripMenuItem2.Click += new System.EventHandler(this.TventyfiveStripMenuItem2_Click);
            // 
            // FourtytoolStripMenuItem2
            // 
            this.FourtytoolStripMenuItem2.Name = "FourtytoolStripMenuItem2";
            this.FourtytoolStripMenuItem2.Size = new System.Drawing.Size(120, 26);
            this.FourtytoolStripMenuItem2.Text = "40%";
            this.FourtytoolStripMenuItem2.Click += new System.EventHandler(this.FourtytoolStripMenuItem2_Click);
            // 
            // окноToolStripMenuItem
            // 
            this.окноToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascade,
            this.leftToRight,
            this.UpDown,
            this.Arrange});
            this.окноToolStripMenuItem.Name = "окноToolStripMenuItem";
            this.окноToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.окноToolStripMenuItem.Text = "Окно";
            this.окноToolStripMenuItem.DropDownOpening += new System.EventHandler(this.WindowToolStripMenuItem_DropDownOpening);
            // 
            // cascade
            // 
            this.cascade.Name = "cascade";
            this.cascade.Size = new System.Drawing.Size(236, 26);
            this.cascade.Text = "Каскадом";
            this.cascade.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // leftToRight
            // 
            this.leftToRight.Name = "leftToRight";
            this.leftToRight.Size = new System.Drawing.Size(236, 26);
            this.leftToRight.Text = "Слева направо";
            this.leftToRight.Click += new System.EventHandler(this.LeftToRightToolStripMenuItem_Click);
            // 
            // UpDown
            // 
            this.UpDown.Name = "UpDown";
            this.UpDown.Size = new System.Drawing.Size(236, 26);
            this.UpDown.Text = "Сверху вниз";
            this.UpDown.Click += new System.EventHandler(this.UpdownToolStripMenuItem_Click);
            // 
            // Arrange
            // 
            this.Arrange.Name = "Arrange";
            this.Arrange.Size = new System.Drawing.Size(236, 26);
            this.Arrange.Text = "Упорядочить значки";
            this.Arrange.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(211, 26);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.zoom_in,
            this.zoom_out,
            this.toolStripSeparator2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1067, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.красныйToolStripMenuItem,
            this.синийToolStripMenuItem,
            this.зелёныйToolStripMenuItem,
            this.другойToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            // 
            // красныйToolStripMenuItem
            // 
            this.красныйToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("красныйToolStripMenuItem.Image")));
            this.красныйToolStripMenuItem.Name = "красныйToolStripMenuItem";
            this.красныйToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.красныйToolStripMenuItem.Text = "Красный";
            this.красныйToolStripMenuItem.Click += new System.EventHandler(this.RedToolStripMenuItem_Click);
            // 
            // синийToolStripMenuItem
            // 
            this.синийToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("синийToolStripMenuItem.Image")));
            this.синийToolStripMenuItem.Name = "синийToolStripMenuItem";
            this.синийToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.синийToolStripMenuItem.Text = "Синий";
            this.синийToolStripMenuItem.Click += new System.EventHandler(this.BlueToolStripMenuItem_Click);
            // 
            // зелёныйToolStripMenuItem
            // 
            this.зелёныйToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("зелёныйToolStripMenuItem.Image")));
            this.зелёныйToolStripMenuItem.Name = "зелёныйToolStripMenuItem";
            this.зелёныйToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.зелёныйToolStripMenuItem.Text = "Зелёный";
            this.зелёныйToolStripMenuItem.Click += new System.EventHandler(this.GreenToolStripMenuItem_Click);
            // 
            // другойToolStripMenuItem
            // 
            this.другойToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("другойToolStripMenuItem.Image")));
            this.другойToolStripMenuItem.Name = "другойToolStripMenuItem";
            this.другойToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.другойToolStripMenuItem.Text = "Другой...";
            this.другойToolStripMenuItem.Click += new System.EventHandler(this.AnotherToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PenToolStripMenuItem,
            this.LineToolStripMenuItem,
            this.EllipseToolStripMenuItem1,
            this.StarToolStripMenuItem,
            this.EraserToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(62, 24);
            this.toolStripDropDownButton2.Text = "Кисть";
            // 
            // PenToolStripMenuItem
            // 
            this.PenToolStripMenuItem.Name = "PenToolStripMenuItem";
            this.PenToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.PenToolStripMenuItem.Text = "Перо";
            this.PenToolStripMenuItem.Click += new System.EventHandler(this.PenToolStripMenuItem_Click);
            // 
            // LineToolStripMenuItem
            // 
            this.LineToolStripMenuItem.Name = "LineToolStripMenuItem";
            this.LineToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.LineToolStripMenuItem.Text = "Линия";
            this.LineToolStripMenuItem.Click += new System.EventHandler(this.LineToolStripMenuItem_Click);
            // 
            // EllipseToolStripMenuItem1
            // 
            this.EllipseToolStripMenuItem1.Name = "EllipseToolStripMenuItem1";
            this.EllipseToolStripMenuItem1.Size = new System.Drawing.Size(163, 26);
            this.EllipseToolStripMenuItem1.Text = "Эллипс";
            this.EllipseToolStripMenuItem1.Click += new System.EventHandler(this.EllipseToolStripMenuItem1_Click);
            // 
            // StarToolStripMenuItem
            // 
            this.StarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StarConfToolStripMenuItem});
            this.StarToolStripMenuItem.Name = "StarToolStripMenuItem";
            this.StarToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.StarToolStripMenuItem.Text = "Звёздочка";
            this.StarToolStripMenuItem.Click += new System.EventHandler(this.StarToolStripMenuItem_Click);
            // 
            // StarConfToolStripMenuItem
            // 
            this.StarConfToolStripMenuItem.Name = "StarConfToolStripMenuItem";
            this.StarConfToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.StarConfToolStripMenuItem.Text = "Количество вершин...";
            this.StarConfToolStripMenuItem.Click += new System.EventHandler(this.StarConfToolStripMenuItem_Click);
            // 
            // EraserToolStripMenuItem
            // 
            this.EraserToolStripMenuItem.Name = "EraserToolStripMenuItem";
            this.EraserToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.EraserToolStripMenuItem.Text = "Ластик";
            this.EraserToolStripMenuItem.Click += new System.EventHandler(this.EraserToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // zoom_in
            // 
            this.zoom_in.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoom_in.Image = ((System.Drawing.Image)(resources.GetObject("zoom_in.Image")));
            this.zoom_in.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom_in.Name = "zoom_in";
            this.zoom_in.Size = new System.Drawing.Size(29, 24);
            this.zoom_in.Text = "Увеличить";
            this.zoom_in.Click += new System.EventHandler(this.zoom_in_Click);
            // 
            // zoom_out
            // 
            this.zoom_out.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoom_out.Image = ((System.Drawing.Image)(resources.GetObject("zoom_out.Image")));
            this.zoom_out.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoom_out.Name = "zoom_out";
            this.zoom_out.Size = new System.Drawing.Size(29, 24);
            this.zoom_out.Text = "Уменьшить";
            this.zoom_out.Click += new System.EventHandler(this.zoom_out_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(105, 24);
            this.toolStripLabel1.Text = "Размер кисти:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1067, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // coord
            // 
            this.coord.Name = "coord";
            this.coord.Size = new System.Drawing.Size(52, 20);
            this.coord.Text = "X:0 Y:0";
            // 
            // brushWidth
            // 
            this.brushWidth.Location = new System.Drawing.Point(323, 34);
            this.brushWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.brushWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushWidth.Name = "brushWidth";
            this.brushWidth.Size = new System.Drawing.Size(50, 22);
            this.brushWidth.TabIndex = 6;
            this.brushWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.brushWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.brushWidth.ValueChanged += new System.EventHandler(this.brushWidth_ValueChanged);
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("blackToolStripMenuItem.Image")));
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.blackToolStripMenuItem.Text = "Чёрный";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.brushWidth);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MDIPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brushWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ToolStripMenuItem рисунокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasSize;
        private System.Windows.Forms.ToolStripMenuItem окноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascade;
        private System.Windows.Forms.ToolStripMenuItem leftToRight;
        private System.Windows.Forms.ToolStripMenuItem UpDown;
        private System.Windows.Forms.ToolStripMenuItem Arrange;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem красныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem синийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зелёныйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другойToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem PenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EllipseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem StarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EraserToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown brushWidth;
        private System.Windows.Forms.ToolStripMenuItem StarConfToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton zoom_in;
        private System.Windows.Forms.ToolStripButton zoom_out;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem кратностьПриближенияToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel coord;
        private System.Windows.Forms.ToolStripMenuItem FivetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TentoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FifteentoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TventyfiveStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem FourtytoolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
    }
}

