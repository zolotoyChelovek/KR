using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace nim
{    
    public partial class game : Form
    {
        public int[] GetcomputerMove(int[] heaps)
        {
            int nimSum = heaps[0] ^ heaps[1] ^ heaps[2]; // вычисляем ним-сумму (XOR) всех куч
            // ищем кучу, из которой компьютер может взять камни так, чтобы XOR сумма стала равной нулю
            for (int i = 0; i < heaps.Length; i++)
            {
                int xor = nimSum ^ heaps[i];
                if (xor < heaps[i])
                {
                    int stonesToTake = heaps[i] - xor;
                    return new int[] { stonesToTake, i };
                }
            }
            // Если не нашли такую кучу, то компьютер может взять один камень из любой кучи
            for (int i = 0; i < heaps.Length; i++)
            {
                if (heaps[i] > 0)
                {
                    return new int[] { 1, i };
                }
            }
            // Если все кучи пусты, то возвращаем нулевой ход
            return new int[] {0, 0};
        }
        public PictureBox createStoneImage()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("C:/Users/maksz/Downloads/Telegram Desktop/камень.png"); // Замените "путь_к_изображению" на фактический путь к изображению
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Масштабирование изображения для заполнения PictureBox
            pictureBox.Width = 50; // Задайте ширину PictureBox по вашему усмотрению
            pictureBox.Height = 50; // Задайте высоту PictureBox по вашему усмотрению
            return pictureBox;
        }
        
        public void fillingWithPictures()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel3.Controls.Clear();
            for (int i = 0; i < DataBase.Heaps[0]; i++)
            {
                flowLayoutPanel1.Controls.Add(createStoneImage());
            }
            for (int i = 0; i < DataBase.Heaps[1]; i++)
            {
                flowLayoutPanel2.Controls.Add(createStoneImage());
            }
            for (int i = 0; i < DataBase.Heaps[2]; i++)
            {
                flowLayoutPanel3.Controls.Add(createStoneImage());
            }
        }
        
        public async void computerMove()
        {
            label1.Text = "Ход компьютера";
            label1.ForeColor = Color.Red;
            ManualResetEvent pauseEvent = new ManualResetEvent(false);
            await Task.Delay(2000);
            int[] computerMove = GetcomputerMove(DataBase.Heaps);
            DataBase.Heaps[computerMove[1]] -= computerMove[0];
            fillingWithPictures();
            if (computerMove[0] == 0)
            {
                MessageBox.Show("Вы выиграли!", "Победа");
            }
            label1.Text = "Ваш ход";
            label1.ForeColor = Color.Green;
            if (DataBase.Heaps.Sum() == 0)
            {
                MessageBox.Show("Вы проиграли!", "Проигрыш");
            }
        }

        public void userMove()
        {            
            
            DataBase.Heaps[0] -= Convert.ToInt32(numericUpDown1.Value);
            DataBase.Heaps[1] -= Convert.ToInt32(numericUpDown2.Value);
            DataBase.Heaps[2] -= Convert.ToInt32(numericUpDown3.Value);
            fillingWithPictures();
        }
        
        public game()
        {
            InitializeComponent();
            fillingWithPictures();
            DataBase.Heaps = DataBase.HeapsDefault;
            DataBase.FirstStep = DataBase.FirstStepDefault;
            if(!DataBase.FirstStep)
            {
                computerMove();
                label1.Text = "Ход компьютера";
                label1.ForeColor = Color.Red;
            }                
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Есть несколько кучек, в каждой из которых лежит сколько-то камней. " +
                "За один ход игрок может взять из любой одной кучки любое ненулевое число камней. " +
                "Игроки берут камни по очереди. Побеждает тот, кто забирает последние камни.", "Правила игры");
        }

        private void параметрыИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form prop = new properties();
            this.Hide();
            prop.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно выйти?", "Выход из программы",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (DataBase.FirstStep)
            {
                userMove();
                computerMove();
            }
            else
            {
                computerMove();
                userMove();
            }


            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }

        private void новаяИграToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            fillingWithPictures();
            if (!DataBase.FirstStep)
            {
                computerMove();
                label1.Text = "Ход компьютера";
                label1.ForeColor = Color.Red;
            }
            else
            {
                userMove();
                label1.Text = "Ваш ход";
                label1.ForeColor = Color.Green;
            }            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
