using PluginInterface;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MdiPaint
{
    public partial class PlugInfo : Form
    {
        MainForm mf;
        public PlugInfo(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            plugins.Columns.Add(checkColumn);
            plugins.Columns.Add("plugin_name", "Плагин");
            plugins.Columns.Add("plugin_author", "Автор");
            plugins.Columns.Add("plugin_ver", "Версия");
            foreach (var plugin in mf.allPlugins.Values)
            {
                Type pluginType = plugin.GetType();

                VersionAttribute versionAttribute = (VersionAttribute)pluginType.GetCustomAttributes(typeof(VersionAttribute), false).FirstOrDefault();
                int majorVersion = 0;
                int minorVersion = 0;
                if (versionAttribute != null)
                {
                    majorVersion = versionAttribute.Major;
                    minorVersion = versionAttribute.Minor;
                }

                plugins.Rows.Add(mf.pluginsForDisplay.Contains(plugin.Name), plugin.Name, plugin.Author, $"{majorVersion}.{minorVersion}");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            mf.pluginsForDisplay.Clear();
            foreach (DataGridViewRow row in plugins.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    mf.pluginsForDisplay.Add(row.Cells[1].Value.ToString());
                }
            }
            mf.UpdatePluginsMenu();
        }
    }
}
