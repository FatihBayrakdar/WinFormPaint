using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            groupBox1.Cursor = groupBox2.Cursor = groupBox3.Cursor = Cursors.Arrow;

            çizim = this.CreateGraphics();
            kalem = new Pen(Color.Black, 1);
            fırça = new SolidBrush(Color.White);

            checkBox1.CheckedChanged += delegate
            {
                groupBox3.Enabled = checkBox1.Checked;
            };

            this.Cursor = Cursors.Cross;
            this.MouseMove += (o, e) =>
            {
                label8.Text = e.Location.ToString();
            };

        }

        Pen kalem;
        Brush fırça;
        Graphics çizim;
        Point p1, p2;
        Rectangle dörtgen;
        string Şekil;

        private void FırçaAyarları(object sender, EventArgs e)
        {
            int R = (int)numericUpDown5.Value;
            int G = (int)numericUpDown6.Value;
            int B = (int)numericUpDown7.Value;

            panel2.BackColor = Color.FromArgb(R, G, B);
            fırça = new SolidBrush(panel2.BackColor);
        }

        private void ŞekilSeç(object sender, EventArgs e)
        {
            var s = sender as RadioButton;
            if (s.Checked)
                Şekil = s.Text;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            dörtgen = new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y);

            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;
            var r = (int)Math.Sqrt(dx * dx + dy * dy);
            Rectangle kare = new Rectangle(p1.X, p1.Y, r, r);

            switch (Şekil)
            {
                case "Çizgi":
                    çizim.DrawLine(kalem, p1, p2);
                    break;
                case "Dikdörtgen":
                    if (checkBox1.Checked)
                        çizim.FillRectangle(fırça, dörtgen);
                    çizim.DrawRectangle(kalem, dörtgen);
                    break;
                case "Elips":
                    if (checkBox1.Checked)
                        çizim.FillEllipse(fırça, dörtgen);
                    çizim.DrawEllipse(kalem, dörtgen);
                    break;
                case "Kare":
                    if (checkBox1.Checked)
                        çizim.FillRectangle(fırça, kare);
                    çizim.DrawRectangle(kalem, kare);
                    break;
                case "Çember":
                    if (checkBox1.Checked)
                        çizim.FillEllipse(fırça, kare);
                    çizim.DrawEllipse(kalem, kare);
                    break;

            }
        }

        private void KalemAyarları(object sender, EventArgs e)
        {
            int px = (int)numericUpDown1.Value;

            int R = (int)numericUpDown2.Value;
            int G = (int)numericUpDown3.Value;
            int B = (int)numericUpDown4.Value;

            panel1.BackColor = Color.FromArgb(R, G, B);
            kalem = new Pen(panel1.BackColor, px);
        }

      
    }
}
