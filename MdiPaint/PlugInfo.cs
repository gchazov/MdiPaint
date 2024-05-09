using PluginInterface;
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
    public partial class PlugInfo : Form
    {
        public PlugInfo(Dictionary<string, IPlugin> plgns)
        {
            InitializeComponent();
            plugins.Columns.Add("plugin_name", "Плагин");
            plugins.Columns.Add("plugin_author", "Автор");
            foreach (var plugin in plgns.Values)
            {
                plugins.Rows.Add(plugin.Name, plugin.Author);
            }
        }
    }
}
