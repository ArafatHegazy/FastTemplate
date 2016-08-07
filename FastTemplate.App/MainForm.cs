using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastTemplate.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            logTextbox.Clear();
            logTextbox.Text = "Generation started.\n";
            try
            {
                Engine.Engine.ProcessTemplate(configuraitonFileTextbox.Text, templateTextbox.Text, outputTextbox.Text);
                logTextbox.Text += "Generation finished successfully.\n";
            }
            catch (Exception ex)
            {
                logTextbox.Text += "An error occurs during generation , details: " + ex.Message + "\n";
            }
        }
    }
}
