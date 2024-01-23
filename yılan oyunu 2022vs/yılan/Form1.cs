using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yılan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sağ";

        private void label3_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            panelitemizle();

            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.DeepPink;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);

            timer1.Start();
            elmaOlustur();
        }
        void carpismakontrol()
        {
            for (int i = 2; i< yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible= true;
                    label4.Text = " KAYBETTİNİZ ";
                    timer1.Stop();
                }
            }
        }
        void panelitemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible= false;

        }
        void puankontrol()
        {
            int puan = int.Parse(label2.Text);
            if(puan > 1950)
            {
                label4.Text = " KAZANDINIZ ";
                label4.Visible = true;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            elmaYedim();
            hareket();
            carpismakontrol();
            puankontrol();

            if (yon == "sağ")
            {
                if (locX < 580)

                    locX += 20;
                else
                    locX = 0;

            }
            if (yon == "sol")
            {
                if (locX > 0)

                    locX -= 20;
                else
                    locX = 580;


            }
            if (yon == "aşağı")
            {
                if (locY < 580)

                    locY += 20;
                else
                    locY = 0;
            }
            if (yon == "yukarı")
            {
                if (locY > 0)

                    locY -= 20;
                else
                    locY = 580;
            }

            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && yon != "sol")
                yon = "sağ";
            if (e.KeyCode == Keys.Left && yon != "sağ")
                yon = "sol";
            if (e.KeyCode == Keys.Up && yon != "aşağı")
                yon = "yukarı";
            if (e.KeyCode == Keys.Down && yon != "yukarı")
                yon = "aşağı";
        }

        void elmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor = Color.LightGreen;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);

        }
        void elmaYedim()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 25;
                label2.Text = puan.ToString();

                elmaOlustur();
                parcaEkle();
            }
        }

        void parcaEkle()
        {
            Random rnd = new Random();
            Panel ekParca = new Panel();
            ekParca.Size = new Size(20, 20);
            ekParca.BackColor =Color.DeepPink;
            yilan.Add(ekParca);
            panel1.Controls.Add(ekParca);
        }

        void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
