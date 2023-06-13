using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ООП_ЛР_23__Чеботарьов_О._
{
    public partial class Form1 : Form
    {
        private double x0, y0; // Початкові координати
        private double R; //Радіус
        private double tMin, tMax, dt; // Початковий т, кінцевий т та розмір кроку

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!double.TryParse(txtR.Text, out R) || !double.TryParse(txtT.Text, out tMax))
            {
                MessageBox.Show("Invalid input!");
                return;
            }

            x0 = 0;
            y0 = 0;
            tMin = 0;
            dt = 0.01;

            double t = tMin;
            double x = x0 + R * t * Math.Cos(t);
            double y = y0 + R * t * Math.Sin(t);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawLine(Pens.Black, 0, height / 2, width, height / 2);
            for (int i = -10; i <= 10; i += 2)
            {
                int xCoord = width / 2 + i * width / 10;
                g.DrawLine(Pens.Black, xCoord, height / 2 - 3, xCoord, height / 2 + 3);
                g.DrawString(i.ToString(), Font, Brushes.Black, xCoord, height / 2 + 3);
            }
            g.DrawString("x", Font, Brushes.Black, width - 10, height / 2 + 3);
            g.DrawLine(Pens.Black, width / 2, 0, width / 2, height);
            for (int i = -10; i <= 10; i += 2)
            {
                int yCoord = height / 2 - i * height / 10;
                g.DrawLine(Pens.Black, width / 2 - 3, yCoord, width / 2 + 3, yCoord);
                g.DrawString(i.ToString(), Font, Brushes.Black, width / 2 + 3, yCoord);
            }
            g.DrawString("y", Font, Brushes.Black, width / 2 + 3, 0);

            while (t <= tMax)
            {
                double nextX = x0 + R * t * Math.Cos(t);
                double nextY = y0 + R * t * Math.Sin(t);
                g.DrawLine(Pens.DarkRed, (float)(width / 2 + x * width / 20),
                           (float)(height / 2 - y * height / 20),
                           (float)(width / 2 + nextX * width / 20), (float)(height / 2 - nextY * height / 20));
                x = nextX;
                y = nextY;
                t += dt;
            }

            pictureBox1.Image = bmp;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.DrawLine(Pens.Black, 0, height / 2, width, height / 2);
            for (int i = -10; i <= 10; i += 2)
            {
                int x = width / 2 + i * width / 10;
                g.DrawLine(Pens.Black, x, height / 2 - 3, x, height / 2 + 3);
                g.DrawString(i.ToString(), Font, Brushes.Black, x, height / 2 + 3);
            }
            g.DrawString("x", Font, Brushes.Black, width - 10, height / 2 + 3);
            g.DrawLine(Pens.Black, width / 2, 0, width / 2, height);
            for (int i = -10; i <= 10; i += 2)
            {
                int y = height / 2 - i * height / 10;
                g.DrawLine(Pens.Black, width / 2 - 3, y, width / 2 + 3, y);
                g.DrawString(i.ToString(), Font, Brushes.Black, width / 2 + 3, y);
            }
            g.DrawString("y", Font, Brushes.Black, width / 2 + 3, 0);
            pictureBox1.Image = bmp;
        }
        
    }
}
