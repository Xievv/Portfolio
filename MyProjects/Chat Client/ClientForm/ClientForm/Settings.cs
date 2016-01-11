using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Settings : Form
    {
        private void Settings_Load(object sender, EventArgs e)
        {
            textBoxUsername.Text = Form1.username;
        }

        public Settings()
        {
            InitializeComponent();
        }

        /*******************************************************
        * Overrides the escape key to close the settings window.
        *******************************************************/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                buttonCancel_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                buttonOk_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Form1.username = textBoxUsername.Text;
            this.Close();
        }

    }
}
