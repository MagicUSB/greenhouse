using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Greenhouse
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
            panel1.Location = new Point(0, 0);
            panel2.Visible = false;
            panel3.Visible = false;
            panel2.Location = new Point(0, 0);
            panel3.Location = new Point(0, 0);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.YellowGreen;
            button1.ForeColor = Color.White;
            button1.Location = new Point(button1.Location.X, button1.Location.Y - 5);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.GreenYellow;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0)
            {
                textBox1.BackColor = Color.Salmon;
                textBox2.BackColor = Color.Salmon;
            }
            else if (textBox1.Text.Length == 0)
            {
                textBox1.BackColor = Color.Salmon;
            }
            else if (textBox2.Text.Length == 0)
            {
                textBox2.BackColor = Color.Salmon;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                button1.Visible = false;
                loading();
            }
        }

        private void loading()
        {
            Timer timer = new Timer();
            timer.Interval = 50;
            int count = 0;
            int max = 50;
            timer.Tick += new EventHandler((o, ev) =>
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y);
                count++;
                if (count == max)
                {
                    Timer t = o as Timer;
                    t.Stop();
                    checkPassword();
                }
            });
            timer.Start();
        }

        private void checkPassword()
        {
            Timer timer = new Timer();
            timer.Interval = 100;
            int count = 0;
            int max = 10;
            int max2 = 12;

            if (textBox1.Text == "v" && textBox2.Text == "1")
            {
                panel1.Visible = false;
                panel3.Visible = true;
            }
            else
            {
                label4.Text = "Помилка";
                timer.Tick += new EventHandler((o, ev) =>
                {
                    if (count <= max)
                    {
                        if (textBox1.BackColor == Color.Salmon)
                        {
                            textBox1.BackColor = Color.LightGreen;
                            textBox2.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            textBox1.BackColor = Color.Salmon;
                            textBox2.BackColor = Color.Salmon;
                        }
                    }
                    count++;
                    if (count == max2)
                    {
                        button1.Location = new Point(351, 304);
                        button1.Visible = true;
                        pictureBox1.Location = new Point(351, 299);
                        pictureBox2.Location = new Point(409, 299);
                        label4.Text = "Перевірка";
                        Timer t = o as Timer;
                        t.Stop();
                    }
                    
                });
                timer.Start();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.LightGreen;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.LightGreen;
        }
    }
}
