
namespace dotnet_Task_05_04
{
    partial class Form1
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
            this.PathTextField = new System.Windows.Forms.TextBox();
            this.UseCustomFileButton = new System.Windows.Forms.Button();
            this.UseMyFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathTextField
            // 
            this.PathTextField.Location = new System.Drawing.Point(193, 14);
            this.PathTextField.Name = "PathTextField";
            this.PathTextField.Size = new System.Drawing.Size(335, 20);
            this.PathTextField.TabIndex = 0;
            // 
            // UseCustomFileButton
            // 
            this.UseCustomFileButton.Location = new System.Drawing.Point(12, 12);
            this.UseCustomFileButton.Name = "UseCustomFileButton";
            this.UseCustomFileButton.Size = new System.Drawing.Size(175, 23);
            this.UseCustomFileButton.TabIndex = 1;
            this.UseCustomFileButton.Text = "Использовать свой файл";
            this.UseCustomFileButton.UseVisualStyleBackColor = true;
            this.UseCustomFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // UseMyFileButton
            // 
            this.UseMyFileButton.Location = new System.Drawing.Point(12, 41);
            this.UseMyFileButton.Name = "UseMyFileButton";
            this.UseMyFileButton.Size = new System.Drawing.Size(516, 23);
            this.UseMyFileButton.TabIndex = 2;
            this.UseMyFileButton.Text = "Использовать встроенный (мой) файл";
            this.UseMyFileButton.UseVisualStyleBackColor = true;
            this.UseMyFileButton.Click += new System.EventHandler(this.UseMyFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 70);
            this.Controls.Add(this.UseMyFileButton);
            this.Controls.Add(this.UseCustomFileButton);
            this.Controls.Add(this.PathTextField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathTextField;
        private System.Windows.Forms.Button UseCustomFileButton;
        private System.Windows.Forms.Button UseMyFileButton;
    }
}

