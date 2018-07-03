using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man.Forms
{
    public partial class Form2 : Form
    {
        Form1 parent;

        bool goup, godown, goleft, goright;
        int speed = 5;
        int s_red = 4;
        int s_pink = 4;
        int score = 0;

        Random randomGen = new Random();

        public Form2(Form1 parent)
        {
            this.parent = parent;

            InitializeComponent();
            go_lbl.Visible = false;

            pictureBox1.Location = new Point(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height));
            pictureBox2.Location = new Point(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height));

            async Task TimerasyncShow()
            {
                pictureBox3.Location = new Point(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height));
                pictureBox3.Visible = true;
                await Task.Delay(10000);
                pictureBox3.Visible = true;

                pictureBox4.Location = new Point(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height));
                pictureBox4.Visible = true;
                await Task.Delay(10000);
                pictureBox3.Visible = true;
            }

            async Task TimerasyncWait()
            {
                pictureBox3.Location = new Point(randomGen.Next(0, this.Width), randomGen.Next(0, this.Height));
                pictureBox3.Visible = false;
                await Task.Delay(30000);
                pictureBox3.Visible = true;
            }

            while (true)
            {
                TimerasyncShow();

                if (pictureBox3.Visible=true && pac_man.Bounds == pictureBox3.Bounds)
                {
                    score += 15;
                }
                else
                {
                    
                }

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            timer1.Enabled = true;

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pac_man.Image = Properties.Resources.pacman_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                pac_man.Image = Properties.Resources.pacman_right;
            }
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
                pac_man.Image = Properties.Resources.pacman_up;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                pac_man.Image = Properties.Resources.pacman_down;
            }
        }
        

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var redLeft = pictureBox1.Left;
            var playerLeft = pac_man.Left;
            var redTop = pictureBox1.Top;
            var playerTop = pac_man.Top;
            var pinkLeft = pictureBox2.Left;
            var pinkTop = pictureBox2.Top;

            if (playerLeft < redLeft)
            {
                pictureBox1.Left -= s_red;
            }
            else if (playerLeft > redLeft)
            {
                pictureBox1.Left += s_red;
            }
            if (playerLeft < pinkLeft)
            {
                pictureBox2.Left -= s_pink;
            }
            else if (playerLeft > pinkLeft)
            {
                pictureBox2.Left += s_pink;
            }
            if (playerTop < redTop)
            {
                pictureBox1.Top -= s_red;
            }
            else if (playerTop > redTop)
            {
                pictureBox1.Top += s_red;
            }
            if (playerTop < pinkTop)
            {
                pictureBox2.Top -= s_pink;
            }
            else if (playerTop > pinkTop)
            {
                pictureBox2.Top += s_pink;
            }          

            score_lbl.Text = "Score: " + score;
            
            if (godown)
            {
                pac_man.Top += speed;
            }

            if (goup)
            {
                pac_man.Top -= speed;
            }

            if (goleft)
            {
                pac_man.Left -= speed;
            }

            if (goright)
            {
                pac_man.Left += speed;
            }

            if (pictureBox1.Bounds == pac_man.Bounds || pictureBox2.Bounds == pac_man.Bounds)
            {
                go_lbl.Visible = true;
                MessageBox.Show("");
            }

        }

        private void timerTick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
