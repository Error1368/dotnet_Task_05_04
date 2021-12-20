using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_Task_05_04
{
    public partial class Editor : Form
    {
        private Type interface_type;
        private Type[] typelist = new Type[] { };
        //private interface_type editable_object;
        public Editor(string path)
        {
            InitializeComponent();//Assembly assembly 
            Assembly assembly = Assembly.LoadFile(path);
            interface_type = assembly.GetType("bases.IBuilding");
            typelist = assembly.GetTypes().Where(t => interface_type.IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            if (typelist.Length > 0)
                this.comboBoxTypes.Items.AddRange(typelist);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
