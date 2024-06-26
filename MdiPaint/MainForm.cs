﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PluginInterface;

namespace MdiPaint
{
    public enum Tools
    {
        Pen,
        Line,
        Ellipse,
        Star,
        Eraser
    }
    public partial class MainForm : Form
    {
        public static Color BrushColor { get; set; } = Color.Black;
        public static int BrushWidth { get; set; } = 5;
        public static int CountMdi { get; set; } = 0;
        public static int ImageW { get; set; } = 600;
        public static int ImageH { get; set; } = 600;
        public bool IsChanged { get; set; } = false;
        public static int StarConfig { get; set; } = 5;
        public static int SaveCount { get; set; } = 0;
        public static float Zoom { get; set; } = 1.0f;
        public static float ZoomRange { get; set; } = 0.05f;
        public Tools Tools { get; set; }
        public Dictionary<string, IPlugin> allPlugins = new Dictionary<string, IPlugin>();
        public List<string> pluginsForDisplay = new List<string>();



        public void FindPlugins()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();

            string configFileName = "PluginsConnect.config";
            string configFilePath;
            try
            {
                configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFileName);
            }
            catch (FileNotFoundException)
            {
                return;
            }
            configFileMap.ExeConfigFilename = configFilePath;

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            string pluginPathsValue;
            try
            {
                pluginPathsValue = config.AppSettings.Settings["PluginConnect"].Value;
            }
            catch (NullReferenceException)
            {
                return;
            }
            string[] pluginPaths = pluginPathsValue.Split(';');

            foreach (string path in pluginPaths)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(path);

                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            allPlugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки плагина ({path})\n" + ex.Message);
                }
            }
        }
        public void CreatePluginsMenu()
        {
            foreach (var p in allPlugins)
            {
                var item = filterToolStripMenuItem.DropDownItems.Add(p.Value.Name);
                pluginsForDisplay.Add(p.Value.Name);
                item.Click += OnPluginClick;
            }
        }

        public void UpdatePluginsMenu()
        {
            var itemsToRemove = new List<ToolStripItem>();

            foreach (ToolStripItem dropDownItem in filterToolStripMenuItem.DropDownItems)
            {
                if (!(dropDownItem is ToolStripMenuItem menuItem && menuItem.Text.Contains("Информация о плагинах")))
                {
                    itemsToRemove.Add(dropDownItem);
                }
            }

            foreach (var item in itemsToRemove)
            {
                filterToolStripMenuItem.DropDownItems.Remove(item);
            }

            foreach (var p in pluginsForDisplay)
            {
                var item = filterToolStripMenuItem.DropDownItems.Add(p);
                item.Click += OnPluginClick;
            }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = allPlugins[((ToolStripMenuItem)sender).Text];
            try
            {
                plugin.Transform((Bitmap)((DocumentForm)ActiveMdiChild).Image);
                ((DocumentForm)ActiveMdiChild).Invalidate();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Вы не выбрали изображение!");
            }
        }

        public MainForm()
        {
            InitializeComponent();
            PenToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
            FivetoolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
            brushWidth.Text = BrushWidth.ToString();
            FindPlugins();
            CreatePluginsMenu();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
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
            CanvasSizeForm csf = new CanvasSizeForm();
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

        public void Save_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null)
            {
                return;
            }
            Regex regex = new Regex(@"^Рисунок*");
            if (regex.IsMatch(ActiveMdiChild.Text))
            {
                SaveAs_Click(sender, e);
            }
            else
            {
                ((DocumentForm)ActiveMdiChild).Image.Save(ActiveMdiChild.Text);
                IsChanged = true;
                ((DocumentForm)ActiveMdiChild).LocalChanged = false;
            }
        }

        public void SaveAs_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null)
            {
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.bmp|*.bmp|*.jpg|*.jpg|*.png|*.png|All files|*.*";
            sfd.FileName = $"{((DocumentForm)ActiveMdiChild).Text}";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ((DocumentForm)ActiveMdiChild).Image.Save(sfd.FileName);
                IsChanged = true;
                ((DocumentForm)ActiveMdiChild).LocalChanged = false;
                ActiveMdiChild.Text = sfd.FileName;
            }
        }

        private void DeleteIcons()
        {
            PenToolStripMenuItem.Image = null;
            LineToolStripMenuItem.Image = null;
            EllipseToolStripMenuItem1.Image = null;
            StarToolStripMenuItem.Image = null;
            EraserToolStripMenuItem.Image = null;
        }

        private void PenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tools = Tools.Pen;
            DeleteIcons();
            PenToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void LineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tools = Tools.Line;
            DeleteIcons();
            LineToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void EllipseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Tools = Tools.Ellipse;
            DeleteIcons();
            EllipseToolStripMenuItem1.Image = MdiPaint.Properties.Resources.choice;
        }

        private void StarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tools = Tools.Star;
            DeleteIcons();
            StarToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void EraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Tools = Tools.Eraser;
            DeleteIcons();
            EraserToolStripMenuItem.Image = MdiPaint.Properties.Resources.choice;
        }

        private void brushWidth_ValueChanged(object sender, EventArgs e)
        {
            MainForm.BrushWidth = (int)brushWidth.Value;
        }

        private void zoom_in_Click(object sender, EventArgs e)
        {
            try
            {
                ((DocumentForm)ActiveMdiChild).ZoomIn();
            }
            catch { }
        }

        private void zoom_out_Click(object sender, EventArgs e)
        {
            try
            {
                ((DocumentForm)ActiveMdiChild).ZoomOut();
            }
            catch { }
        }

        private void DeleteZoomIcons()
        {
            FivetoolStripMenuItem.Image = null;
            TentoolStripMenuItem.Image = null;
            FifteentoolStripMenuItem.Image = null;
        }

        private void FivetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            FivetoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomRange = 0.05f;
        }

        private void TentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            TentoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomRange = 0.1f;
        }

        private void FifteentoolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteZoomIcons();
            FifteentoolStripMenuItem.Image = Properties.Resources.choice;
            MainForm.ZoomRange = 0.15f;
        }


        private void StarConfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarConfig sc = new StarConfig();
            sc.ShowDialog();
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrushColor = Color.Black;
        }

        private void PlugInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PlugInfo(this).Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
