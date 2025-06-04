using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class JuegoDeDados : Form
    {
        private Nent n1, n2;
        private int pts = 0;
        private bool isPlaying = true;
        private SoundPlayer sonido;
        private bool DadoC = true;

        public JuegoDeDados()
        {
            InitializeComponent();
            sonido = new SoundPlayer(Path.Combine(Application.StartupPath, "Sonidos", "casino.wav"));
            sonido.PlayLooping();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n1 = new Nent();
            n2 = new Nent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private async void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            button1.Enabled = false;
            button4.Enabled = true;
            n1.Lanzar();
            textBox2.Text = "";
            int num = n1.Lanzar();
            label2.Text = string.Concat(n1.Descargar());

            label3.Text = "..........";
            n1.Poker();
            n1.VerifGrande();
            n1.Escalera();
            n1.Par();
            n1.Trica();
            n1.Full();
            n1.chanfle();
            n1.doblepar();

            Random r = new Random();
            string baseImgPath = Path.Combine(Application.StartupPath, "Imagenes");
            string baseSoundPath = Path.Combine(Application.StartupPath, "Sonidos");

            if (DadoC)
            {
                for (int i = 1; i <= 6; i++)
                {
                    pictureBox0.Image = Image.FromFile(Path.Combine(baseImgPath, "_" + r.Next(1, 7) + ".png"));
                    pictureBox1.Image = Image.FromFile(Path.Combine(baseImgPath, "_" + r.Next(1, 7) + ".png"));
                    pictureBox2.Image = Image.FromFile(Path.Combine(baseImgPath, "_" + r.Next(1, 7) + ".png"));
                    pictureBox3.Image = Image.FromFile(Path.Combine(baseImgPath, "_" + r.Next(1, 7) + ".png"));
                    pictureBox4.Image = Image.FromFile(Path.Combine(baseImgPath, "_" + r.Next(1, 7) + ".png"));
                    new SoundPlayer(Path.Combine(baseSoundPath, "agitar.wav")).Play();
                    await Task.Delay(200);
                }

                string[] nombres = new string[5];
                for (int i = 0; i < 5; i++)
                    nombres[4 - i] = "_" + ((num / (int)Math.Pow(10, i)) % 10).ToString() + ".png";

                pictureBox0.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[0]));
                pictureBox1.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[1]));
                pictureBox2.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[2]));
                pictureBox3.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[3]));
                pictureBox4.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[4]));
            }
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    pictureBox0.Image = Image.FromFile(Path.Combine(baseImgPath, "_D" + r.Next(1, 7) + ".png"));
                    pictureBox1.Image = Image.FromFile(Path.Combine(baseImgPath, "_D" + r.Next(1, 7) + ".png"));
                    pictureBox2.Image = Image.FromFile(Path.Combine(baseImgPath, "_D" + r.Next(1, 7) + ".png"));
                    pictureBox3.Image = Image.FromFile(Path.Combine(baseImgPath, "_D" + r.Next(1, 7) + ".png"));
                    pictureBox4.Image = Image.FromFile(Path.Combine(baseImgPath, "_D" + r.Next(1, 7) + ".png"));
                    new SoundPlayer(Path.Combine(baseSoundPath, "Futurista.wav")).Play();
                    await Task.Delay(150);
                }

                string[] nombres = new string[5];
                for (int i = 0; i < 5; i++)
                    nombres[4 - i] = "_D" + ((num / (int)Math.Pow(10, i)) % 10).ToString() + ".png";

                pictureBox0.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[0]));
                pictureBox1.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[1]));
                pictureBox2.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[2]));
                pictureBox3.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[3]));
                pictureBox4.Image = Image.FromFile(Path.Combine(baseImgPath, nombres[4]));
            }

            label3.Text = label2.Text;
            button1.Enabled = true;

            if (n1.Poker()) { textBox2.Text = "Poker"; pts += 40; }
            else if (n1.VerifGrande()) { textBox2.Text = "La Grande"; pts += 50; }
            else if (n1.Escalera()) { textBox2.Text = "Escalera"; pts += 25; }
            else if (n1.Full()) { textBox2.Text = "Full"; pts += 30; }
            else if (n1.Trica()) { textBox2.Text = "Trica"; pts += 18; }
            else if (n1.Par()) { textBox2.Text = "Par"; pts += 10; }
            else if (n1.chanfle()) { textBox2.Text = "Chanfle"; }
            else if (n1.doblepar()) { textBox2.Text = "Doble par"; pts += 15; }

            label4.Text = "Pts: " + pts;
            new SoundPlayer(Path.Combine(baseSoundPath, "moneda.wav")).Play();

            if (isPlaying)
            {
                await Task.Delay(450);
                sonido = new SoundPlayer(Path.Combine(baseSoundPath, "casino.wav"));
                sonido.PlayLooping();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { Close(); }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void pictureBox5_Click_2(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            textBox2.DeselectAll();
            label5.Text = "El modelo de sus dados cambiará en la siguiente lanzada";
            DadoC = !DadoC;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isPlaying) sonido.Stop();
            else sonido.PlayLooping();

            isPlaying = !isPlaying;
            button3.Text = isPlaying ? "Detener Canción" : "Reproducir Canción";
        }
    }
}
