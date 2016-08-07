namespace FastTemplate.App
{
    partial class MainForm
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
            this.configuraitonFileTextbox = new System.Windows.Forms.TextBox();
            this.templateTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outputTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.logTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration file";
            // 
            // configuraitonFileTextbox
            // 
            this.configuraitonFileTextbox.Location = new System.Drawing.Point(126, 13);
            this.configuraitonFileTextbox.Name = "configuraitonFileTextbox";
            this.configuraitonFileTextbox.Size = new System.Drawing.Size(667, 22);
            this.configuraitonFileTextbox.TabIndex = 1;
            this.configuraitonFileTextbox.Text = "d:\\ConfigFile.json";
            // 
            // templateTextbox
            // 
            this.templateTextbox.Location = new System.Drawing.Point(126, 41);
            this.templateTextbox.Name = "templateTextbox";
            this.templateTextbox.Size = new System.Drawing.Size(667, 22);
            this.templateTextbox.TabIndex = 3;
            this.templateTextbox.Text = "D:\\Templates\\Noitso.Templates.CSharpLibrary\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template";
            // 
            // outputTextbox
            // 
            this.outputTextbox.Location = new System.Drawing.Point(126, 69);
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.Size = new System.Drawing.Size(667, 22);
            this.outputTextbox.TabIndex = 5;
            this.outputTextbox.Text = "d:\\output\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(718, 97);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // logTextbox
            // 
            this.logTextbox.Location = new System.Drawing.Point(13, 126);
            this.logTextbox.Multiline = true;
            this.logTextbox.Name = "logTextbox";
            this.logTextbox.Size = new System.Drawing.Size(780, 123);
            this.logTextbox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 261);
            this.Controls.Add(this.logTextbox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.templateTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.configuraitonFileTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configuraitonFileTextbox;
        private System.Windows.Forms.TextBox templateTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outputTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox logTextbox;
    }
}

