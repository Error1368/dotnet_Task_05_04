using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace dotnet_Task_05_04
{
    public partial class Form1 : Form
    {
        private string my_path = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName 
            + "\\ClassLibrary\\bin\\Debug\\netstandard2.0\\ClassLibrary.dll";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = PathTextField.Text;
            new Editor(path).ShowDialog();
        }

        private void UseMyFileButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(my_path);
            new Editor(my_path).ShowDialog();
        }
    }
}
