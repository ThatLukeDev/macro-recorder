using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macro_Recorder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void lightMode_CheckedChanged(object sender, EventArgs e)
        {
            if (lightMode.Checked)
                MessageBox.Show("No");
            lightMode.Checked = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void speed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                speedLabel.Text = "Speed: " + double.Parse(speed.Text).ToString() + "x";
            }
            catch
            {
                speedLabel.Text = "";
            }
        }

        private void speedBar_Scroll(object sender, EventArgs e)
        {
            speed.Text = (double.Parse(speedBar.Value.ToString()) / 2).ToString();
        }
    }
}
