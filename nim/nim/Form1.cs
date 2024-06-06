using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nim
{
    public partial class properties : Form
    {
        public properties()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();
            numericUpDown1.Show();
            label2.Hide();
            numericUpDown2.Hide();
            label3.Hide();
            numericUpDown3.Hide();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();
            numericUpDown1.Show();
            label2.Show();
            numericUpDown2.Show();
            label3.Hide();
            numericUpDown3.Hide();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label1.Show();
            numericUpDown1.Show();
            label2.Show();
            numericUpDown2.Show();
            label3.Show();
            numericUpDown3.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataBase.HeapsDefault[0] = Convert.ToInt32(numericUpDown1.Value);
            DataBase.HeapsDefault[1] = Convert.ToInt32(numericUpDown2.Value);
            DataBase.HeapsDefault[2] = Convert.ToInt32(numericUpDown3.Value);
            if (radioButton1.Checked == false)
                DataBase.FirstStepDefault = true;
            else
                DataBase.FirstStepDefault = false;
            Form g = new game();
            g.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            //задание случайного права первого хода
            if (rnd.Next(0, 2) == 1)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            //задание случайного количества куч и камней в них
            if (rnd.Next(0, 2) == 0)
            {
                radioButton3.Checked = true;
                numericUpDown1.Value = rnd.Next(1, 10);
            }
            else if (rnd.Next(0, 2) == 1)
            {
                radioButton4.Checked = true;
                numericUpDown1.Value = rnd.Next(1, 10);
                numericUpDown2.Value = rnd.Next(1, 10);
            }   
            else
            {
                radioButton5.Checked = true;
                numericUpDown1.Value = rnd.Next(1, 10);
                numericUpDown2.Value = rnd.Next(1, 10);
                numericUpDown3.Value = rnd.Next(1, 10);
            }                
        }
    }
}
