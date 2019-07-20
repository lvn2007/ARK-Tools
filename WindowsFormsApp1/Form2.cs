using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARK_Tools
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Ankylo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Carbonemys;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Dilo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Dimetrodon;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Dimorph;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Dodo;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Gallimimus;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Lystro;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Pachy;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Parasaur;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Pteranodon;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Raptor;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Stego;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Terror_Bird;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = ARK_Tools.Properties.Resources.Trike;
        }
    }
}
