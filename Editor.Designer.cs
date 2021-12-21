using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace dotnet_Task_05_04
{
    partial class Editor
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
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.groupBoxArgs = new System.Windows.Forms.GroupBox();
            this.groupBoxMethods = new System.Windows.Forms.GroupBox();
            this.groupBoxToExecute = new System.Windows.Forms.GroupBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(142, 9);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(120, 21);
            this.comboBoxTypes.TabIndex = 0;
            this.comboBoxTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypes_SelectedIndexChanged);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(12, 9);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(122, 21);
            this.buttonCreate.TabIndex = 1;
            this.buttonCreate.Text = "создать объект типа";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // groupBoxArgs
            // 
            this.groupBoxArgs.Location = new System.Drawing.Point(12, 36);
            this.groupBoxArgs.Name = "groupBoxArgs";
            this.groupBoxArgs.Size = new System.Drawing.Size(250, 20);
            this.groupBoxArgs.TabIndex = 5;
            this.groupBoxArgs.TabStop = false;
            this.groupBoxArgs.Text = "Аргументы конструктора";
            // 
            // groupBoxMethods
            // 
            this.groupBoxMethods.Location = new System.Drawing.Point(269, 36);
            this.groupBoxMethods.Name = "groupBoxMethods";
            this.groupBoxMethods.Size = new System.Drawing.Size(240, 20);
            this.groupBoxMethods.TabIndex = 6;
            this.groupBoxMethods.TabStop = false;
            this.groupBoxMethods.Text = "Методы объекта";
            // 
            // groupBoxToExecute
            // 
            this.groupBoxToExecute.Location = new System.Drawing.Point(515, 36);
            this.groupBoxToExecute.Name = "groupBoxToExecute";
            this.groupBoxToExecute.Size = new System.Drawing.Size(300, 20);
            this.groupBoxToExecute.TabIndex = 6;
            this.groupBoxToExecute.TabStop = false;
            this.groupBoxToExecute.Text = "Аргументы метода";
            // 
            // labelOutput
            // 
            this.labelOutput.Location = new System.Drawing.Point(822, 36);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(223, 423);
            this.labelOutput.TabIndex = 7;
            this.labelOutput.Text = "Вывод:";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 468);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.groupBoxToExecute);
            this.Controls.Add(this.groupBoxMethods);
            this.Controls.Add(this.groupBoxArgs);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.comboBoxTypes);
            this.Name = "Editor";
            this.Text = "Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.GroupBox groupBoxArgs;
        private System.Windows.Forms.GroupBox groupBoxMethods;
        private System.Windows.Forms.GroupBox groupBoxToExecute;
        private System.Windows.Forms.Label labelOutput;
    }
}