using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace dotnet_Task_05_04
{
    public partial class Editor : Form
    {
        private Type interface_type;
        private TextBox[] constructor_args = null;
        private TextBox[] method_args = null;
        private object editable_object;
        public Editor(string path)
        {
            InitializeComponent();//Assembly assembly 
            Assembly assembly = Assembly.LoadFile(path);
            interface_type = assembly.GetType("bases.IBuilding");
            Type[] typelist = assembly.GetTypes().Where(t => interface_type.IsAssignableFrom(t) && !t.IsAbstract).ToArray();
            if (typelist.Length > 0)
                this.comboBoxTypes.Items.AddRange(typelist);
        }

        private void Method_To_Execute(MethodInfo method)
        {
            groupBoxToExecute.Controls.Clear();
            Label method_name_label = new Label();
            Button execute_button = new Button();
            groupBoxToExecute.Controls.Add(method_name_label);
            groupBoxToExecute.Controls.Add(execute_button);

            method_name_label.Text = method.Name;
            method_name_label.Location = new Point(5, 20);
            method_name_label.Size = new Size(120, 20);
            method_name_label.TextAlign = ContentAlignment.MiddleRight;

            execute_button.Text = "Execute";
            execute_button.Location = new Point(125, 20);
            execute_button.Click += new System.EventHandler((sen, ev) => this.Method_Execute(method));

            if (method.GetParameters().Length == 0)
            {
                method_args = new TextBox[]{ };
                Label method_empty_label = new Label();
                groupBoxToExecute.Controls.Add(method_empty_label);
                method_empty_label.Location = new Point(15, 45);
                method_empty_label.Size = new Size(100, 20);
                method_empty_label.Text = "Нет аргументов."; //зря быканул
                groupBoxToExecute.Height = 70;

            }
            else
            {
                method_args = new TextBox[method.GetParameters().Length];
                int j = 1;
                foreach (ParameterInfo param in method.GetParameters())
                {
                    Label label_name = new Label();
                    Label label_type = new Label();
                    TextBox text_box = new TextBox();
                    groupBoxToExecute.Controls.Add(label_name);
                    groupBoxToExecute.Controls.Add(label_type);
                    groupBoxToExecute.Controls.Add(text_box);

                    label_name.Text = param.Name;
                    label_name.Location = new Point(5, 20 + j * 25);
                    label_name.Size = new Size(50, 20);
                    label_name.TextAlign = ContentAlignment.MiddleRight;

                    label_type.Text = param.ParameterType.FullName;
                    label_type.Location = new Point(125, 20 + j * 25);
                    label_type.Size = new Size(90, 20);
                    label_type.TextAlign = ContentAlignment.MiddleLeft;

                    text_box.Location = new Point(55, 20 + j * 25);
                    text_box.Size = new Size(70, 20);
                    method_args[j - 1] = text_box;

                    j++;
                }
                groupBoxToExecute.Height = 30 + j * 25;
            }
        }

        private void Method_Execute(MethodInfo method)
        {
            object[] args = new object[method_args.Length];
            for (int i = 0; i < method_args.Length; i++)
            {
                args[i] = Convert.ChangeType(method_args[i].Text, method.GetParameters()[i].ParameterType);
            }

            object result = method.Invoke(editable_object, args);
            string to_output = "Вывод:\n";
            if (result is IDictionary) {
                foreach (object key in ((IDictionary)result).Keys)
                {
                    to_output += key.ToString() + ": " + ((IDictionary)result)[key].ToString() + "\n"; 
                }
            }
            else if(result is null)
                to_output += "Вернул void";
            else
                to_output += result.ToString();

            labelOutput.Text = to_output;
            
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedItem is null)
                return;

            Type type = (Type)(comboBoxTypes.SelectedItem);
            ConstructorInfo constructor = type.GetConstructors()[0];
            object[] args = new object[constructor_args.Length];
            for(int i = 0; i < constructor_args.Length; i++)
            {
                args[i] = Convert.ChangeType(constructor_args[i].Text, constructor.GetParameters()[i].ParameterType);
            }
            editable_object = type.GetConstructors()[0].Invoke(args);

            groupBoxToExecute.Controls.Clear();
            groupBoxMethods.Controls.Clear();
            groupBoxMethods.Height = 20 + 30 * (type.GetMethods().Length - 4);
            
            for (int i = 0; i < type.GetMethods().Length - 4; i++ )
            {
                MethodInfo method = type.GetMethods()[i];
                Label label_name = new Label();
                Button execute_button = new Button();
                groupBoxMethods.Controls.Add(label_name);
                groupBoxMethods.Controls.Add(execute_button);

                label_name.Text = method.Name;
                label_name.Location = new Point(5, 20 + i * 30);
                label_name.Size = new Size(120, 20);
                label_name.TextAlign = ContentAlignment.MiddleRight;

                execute_button.Text = "To execute";
                execute_button.Location = new Point(125, 20 + i * 30);
                execute_button.Click += new System.EventHandler((sen, ev) => this.Method_To_Execute(method));

            }

        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type type = (Type)(comboBoxTypes.SelectedItem);

            constructor_args = new TextBox[type.GetConstructors()[0].GetParameters().Length];
            groupBoxArgs.Controls.Clear();
            groupBoxArgs.Size = new Size(250, type.GetConstructors()[0].GetParameters().Length * 25 + 30);
            int i = 0;
            foreach (ParameterInfo param in type.GetConstructors()[0].GetParameters())
            {
                Label label_name = new Label();
                Label label_type = new Label();
                TextBox text_box = new TextBox();
                groupBoxArgs.Controls.Add(label_name);
                groupBoxArgs.Controls.Add(label_type);
                groupBoxArgs.Controls.Add(text_box);

                label_name.Text = param.Name;
                label_name.Location = new Point(5, 20 + i * 25);
                label_name.Size = new Size(100, 20);
                label_name.TextAlign = ContentAlignment.MiddleRight;

                label_type.Text = param.ParameterType.FullName;
                label_type.Location = new Point(165, 20 + i * 25);
                label_type.Size = new Size(80, 20);
                label_type.TextAlign = ContentAlignment.MiddleLeft;

                text_box.Location = new Point(105, 20 + i * 25);
                text_box.Size = new Size(60, 20);

                constructor_args[i] = text_box;

                i++;
            }
        }
    }
}
