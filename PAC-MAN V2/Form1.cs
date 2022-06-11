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
using System.Collections;

namespace PAC_MAN_V2
{
    public partial class Form1 : Form
    {
        PictureBox[,] yemler = new PictureBox[29, 26];
        Random rasgele = new Random();
        int YenenYem = 0;
        Byte hak = 3;

        byte yön;
        byte İstenenYön;

        int karakterKonumuX = 14;
        int karakterKonumuY = 0;


        byte H_yön = 1;
        byte H_İstenenYön = 1;
        int KırmızıHayaletX = 14;
        int KırmızıHayaletY = 10;

        public Form1()
        {
            InitializeComponent();
        }



        //---------------------------------- yemmmmmm ---------------------------------------------
        void YemYerleştir()
        {
            int yatay = 21;
            int dikey = 21;

            for (int Satır = 0; Satır < 29; Satır++)
            {
                for (int sütun = 0; sütun < 26; sütun++)
                {

                    yemler[Satır, sütun] = new PictureBox();
                    yemler[Satır, sütun].Name = Convert.ToString(Satır + "-" + sütun);
                    yemler[Satır, sütun].Size = new Size(5, 5);
                    yemler[Satır, sütun].Location = new Point(yatay, dikey);
                    yemler[Satır, sütun].BackColor = Color.Yellow;

                    yatay += 16;

                    panel2.Controls.Add(yemler[Satır, sütun]);
                }
                yatay = 21;
                dikey += 16;
            }
        }

        void YemSil(byte başlangıçNoktasıY, byte başlangıçNoktasıX, byte uzunlukY, byte uzunlukX)
        {

            int yatay = başlangıçNoktasıY;
            int dikey = başlangıçNoktasıX;

            for (int Satır = yatay; Satır < yatay + uzunlukY; Satır++)
            {
                for (int sütun = dikey; sütun < dikey + uzunlukX; sütun++)
                {
                    yemler[Satır, sütun].BackColor = Color.Transparent;

                }
            }
        }

        void BütünYemleriSil()
        {
            //Ymax = 29
            //Xmax = 25
            YemSil(1, 1, 3, 4);
            YemSil(1, 6, 3, 5);
            YemSil(0, 12, 4, 2);
            YemSil(1, 15, 3, 5);
            YemSil(1, 21, 3, 4);
            YemSil(5, 1, 2, 4);
            YemSil(8, 0, 5, 5);
            YemSil(14, 0, 5, 5);
            YemSil(23, 0, 2, 2);
            YemSil(5, 9, 2, 8);
            YemSil(5, 21, 2, 4);
            YemSil(5, 6, 8, 2);
            YemSil(6, 12, 4, 2);
            YemSil(5, 18, 8, 2);
            YemSil(8, 21, 5, 5);
            YemSil(14, 21, 5, 5);
            YemSil(8, 8, 2, 3);
            YemSil(8, 15, 2, 3);
            YemSil(11, 9, 5, 8);
            YemSil(26, 1, 2, 10);
            YemSil(26, 15, 2, 10);
            YemSil(23, 6, 3, 2);
            YemSil(23, 9, 2, 8);
            YemSil(23, 12, 5, 2);
            YemSil(23, 18, 5, 2);
            YemSil(20, 1, 2, 4);
            YemSil(20, 6, 2, 5);
            YemSil(20, 15, 2, 5);
            YemSil(20, 21, 2, 4);
            YemSil(22, 3, 3, 2);
            YemSil(22, 21, 3, 2);
            YemSil(23, 24, 2, 2);
            YemSil(14, 6, 5, 2);
            YemSil(14, 18, 5, 2);
            YemSil(17, 9, 2, 8);
            YemSil(19, 12, 3, 2);

        }

        //---------------------------------- yemmmmmm ---------------------------------------------

        //---------------------------------- karakter ---------------------------------------------

        Point PAC_MAN(int Y, int X)
        {
            int y = yemler[Y, X].Location.Y;
            int x = yemler[Y, X].Location.X;

            Point nokta = new Point(x - 7, y - 7);

            return nokta;
        }

        void İstenenYönKontrol(int X, int Y, byte istenenYön, byte kim) // Karakter konumu girilecek
        {
            // kim değişkeninde 1 pac_man, 2Kırmızı hayalet

            int x = X;
            int y = Y;

            byte istenenYönn = istenenYön;

            if (istenenYönn == 1)
            {
                if (x++ < 25 && yemler[y, x].BackColor != Color.Transparent)
                {
                    if (kim == 1)
                    {
                        yön = 1;
                    }
                    if (kim == 2)
                    {
                        H_yön = 1;
                    }
                }
            }
            else if (istenenYönn == 2)
            {

                if (x-- > 0 && yemler[y, x].BackColor != Color.Transparent)
                {
                    if (kim == 1)
                    {
                        yön = 2;
                    }
                    if (kim == 2)
                    {
                        H_yön = 2;
                    }
                }
            }
            else if (istenenYönn == 4)
            {
                if (y++ < 28 && yemler[y, x].BackColor != Color.Transparent)
                {
                    if (kim == 1)
                    {
                        yön = 4;
                    }
                    if (kim == 2)
                    {
                        H_yön = 4;
                    }

                }
            }
            else if (istenenYönn == 3)
            {
                if (y-- > 0 && yemler[y, x].BackColor != Color.Transparent)
                {
                    if (kim == 1)
                    {
                        yön = 3;
                    }
                    if (kim == 2)
                    {
                        H_yön = 3;
                    }

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int geçiciX = karakterKonumuX;
            int geçiciY = karakterKonumuY;

            if (YenenYem == 298)
            {

                KırmızıHayalet.Stop();
                timer1.Stop();
                MessageBox.Show("KAZANDIN", "KAZANDIN");
            }

            if (karakterKonumuX == KırmızıHayaletX && karakterKonumuY == KırmızıHayaletY)
            {
                hak--;
                label1.Text = hak.ToString();

                karakterKonumuX = 14;
                karakterKonumuY = 0;

                KırmızıHayaletX = 14;
                KırmızıHayaletY = 10;


                if (hak == 0)
                {

                    KırmızıHayalet.Stop();
                    timer1.Stop();
                    MessageBox.Show("KAYBETTİN", "KAYBETTİN");
                }
                Thread.Sleep(1000);
            }

            if (İstenenYön != yön)
            {
                İstenenYönKontrol(karakterKonumuX, karakterKonumuY, İstenenYön, 1);
            }

            if (yön == 1)
            {
                if (geçiciX++ < 25 && yemler[karakterKonumuY, geçiciX].BackColor != Color.Transparent)
                {
                    if (yemler[karakterKonumuY, karakterKonumuX].BackColor == Color.Yellow)
                    {
                        YenenYem++;
                        yemler[karakterKonumuY, karakterKonumuX].BackColor = Color.Black;
                    }

                    karakterKonumuX++;
                    pictureBox1.Location = PAC_MAN(karakterKonumuY, karakterKonumuX);

                }
            }
            else if (yön == 2)
            {

                if (geçiciX-- > 0 && yemler[karakterKonumuY, geçiciX].BackColor != Color.Transparent)
                {
                    if (yemler[karakterKonumuY, karakterKonumuX].BackColor == Color.Yellow)
                    {
                        YenenYem++;
                        yemler[karakterKonumuY, karakterKonumuX].BackColor = Color.Black;
                    }

                    karakterKonumuX--;
                    pictureBox1.Location = PAC_MAN(karakterKonumuY, karakterKonumuX);
                }
            }
            else if (yön == 4)
            {
                if (geçiciY++ < 28 && yemler[geçiciY, karakterKonumuX].BackColor != Color.Transparent)
                {
                    if (yemler[karakterKonumuY, karakterKonumuX].BackColor == Color.Yellow)
                    {
                        YenenYem++;
                        yemler[karakterKonumuY, karakterKonumuX].BackColor = Color.Black;
                    }
                    karakterKonumuY++;
                    pictureBox1.Location = PAC_MAN(karakterKonumuY, karakterKonumuX);
                }
            }
            else if (yön == 3)
            {
                if (geçiciY-- > 0 && yemler[geçiciY, karakterKonumuX].BackColor != Color.Transparent)
                {
                    if (yemler[karakterKonumuY, karakterKonumuX].BackColor == Color.Yellow)
                    {
                        YenenYem++;
                        yemler[karakterKonumuY, karakterKonumuX].BackColor = Color.Black;
                    }
                    karakterKonumuY--;
                    pictureBox1.Location = PAC_MAN(karakterKonumuY, karakterKonumuX);
                }
            }


            label3.Text = YenenYem.ToString();
            
        }

        //---------------------------------- karakter ---------------------------------------------

        //---------------------------------- Hayalet ---------------------------------------------

        byte yönBul(int x, int y)
        {
            int Y = KırmızıHayaletY;
            int X = KırmızıHayaletX;

            List<byte> liste = new List<byte>();

            if (X++ < 25 && yemler[KırmızıHayaletY, X].BackColor != Color.Transparent)
            {
                liste.Add(1);
            }
            X = KırmızıHayaletX;
            if (X-- > 0 && yemler[KırmızıHayaletY, X].BackColor != Color.Transparent)
            {
                liste.Add(2);
            }
            X = KırmızıHayaletX;
            if (Y++ < 28 && yemler[Y, KırmızıHayaletX].BackColor != Color.Transparent)
            {
                liste.Add(4);
            }
            Y = KırmızıHayaletY;
            if (Y-- > 0 && yemler[Y, KırmızıHayaletX].BackColor != Color.Transparent)
            {
                liste.Add(3);
            }
            int t = liste.Count;
            int b = rasgele.Next(0, t);
            byte a = liste[b];
            return a;
        }
        byte etrafıKontrolEt(int x, int y)
        {
            int Y = KırmızıHayaletY;
            int X = KırmızıHayaletX;

            List<byte> liste = new List<byte>();

            if (X++ < 25 && yemler[KırmızıHayaletY, X].BackColor != Color.Transparent)
            {
                liste.Add(1);
            }
            X = KırmızıHayaletX;
            if (X-- > 0 && yemler[KırmızıHayaletY, X].BackColor != Color.Transparent)
            {
                liste.Add(2);
            }
            X = KırmızıHayaletX;
            if (Y++ < 28 && yemler[Y, KırmızıHayaletX].BackColor != Color.Transparent)
            {
                liste.Add(4);
            }
            Y = KırmızıHayaletY;
            if (Y-- > 0 && yemler[Y, KırmızıHayaletX].BackColor != Color.Transparent)
            {
                liste.Add(3);
            }
            byte t = (byte)liste.Count;
            return t;
        }
        private void KırmızıHayalet_Tick(object sender, EventArgs e)
        {
            int geçiciX = KırmızıHayaletX;
            int geçiciY = KırmızıHayaletY;
            byte a;

            if (karakterKonumuX == KırmızıHayaletX && karakterKonumuY == KırmızıHayaletY)
            {

                KırmızıHayalet.Stop();
                timer1.Stop();

                hak--;
                label1.Text = hak.ToString();

                karakterKonumuX = 14;
                karakterKonumuY = 0;

                KırmızıHayaletX = 14;
                KırmızıHayaletY = 10;


                KırmızıHayalet.Start();
                timer1.Start();
                if (hak == 0)
                {
                    KırmızıHayalet.Stop();
                    timer1.Stop();
                    MessageBox.Show("KAYBETTİN", "KAYBETTİN");
                }

                Thread.Sleep(1000);
            }

            if (H_İstenenYön != H_yön)
            {
                İstenenYönKontrol(KırmızıHayaletX, KırmızıHayaletY, H_İstenenYön, 2);
            }

            // h_yön yönüne hareket etmesini sağlar karşısında duvar varsa durur
            if (H_yön == 1)
            {

                if (geçiciX++ < 25 && yemler[KırmızıHayaletY, geçiciX].BackColor != Color.Transparent)
                {
                    a = etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY);

                    KırmızıHayaletX++;
                    pictureBox2.Location = PAC_MAN(KırmızıHayaletY, KırmızıHayaletX);

                    if (etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY) > a)
                    {
                        H_İstenenYön = yönBul(karakterKonumuX, karakterKonumuY);
                    }
                }
                else
                {
                    H_İstenenYön = yönBul(geçiciX--, geçiciY);
                }
            }
            else if (H_yön == 2)
            {

                if (geçiciX-- > 0 && yemler[KırmızıHayaletY, geçiciX].BackColor != Color.Transparent)
                {

                    a = etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY);

                    KırmızıHayaletX--;
                    pictureBox2.Location = PAC_MAN(KırmızıHayaletY, KırmızıHayaletX);


                    if (etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY) > a)
                    {
                        H_İstenenYön = yönBul(karakterKonumuX, karakterKonumuY);
                    }
                }
                else
                {
                    H_İstenenYön = yönBul(geçiciX++, geçiciY);
                }
            }
            else if (H_yön == 4)
            {
                if (geçiciY++ < 28 && yemler[geçiciY, KırmızıHayaletX].BackColor != Color.Transparent)
                {
                    a = etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY);

                    KırmızıHayaletY++;
                    pictureBox2.Location = PAC_MAN(KırmızıHayaletY, KırmızıHayaletX);


                    if (etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY) > a)
                    {
                        H_İstenenYön = yönBul(karakterKonumuX, karakterKonumuY);
                    }
                }
                else
                {
                    H_İstenenYön = yönBul(geçiciX, geçiciY--);
                }
            }
            else if (H_yön == 3)
            {
                if (geçiciY-- > 0 && yemler[geçiciY, KırmızıHayaletX].BackColor != Color.Transparent)
                {
                    a = etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY);

                    KırmızıHayaletY--;
                    pictureBox2.Location = PAC_MAN(KırmızıHayaletY, KırmızıHayaletX);


                    if (etrafıKontrolEt(KırmızıHayaletX, karakterKonumuY) > a)
                    {
                        H_İstenenYön = yönBul(karakterKonumuX, karakterKonumuY);
                    }
                }
                else
                {
                    H_İstenenYön = yönBul(geçiciX, geçiciY++);
                }
            }

        }


        //---------------------------------- Hayalet ---------------------------------------------



        private void Form1_Load(object sender, EventArgs e)
        {
            YemYerleştir();
            BütünYemleriSil();
            label1.Text = "3";
            label2.Text = "Kalan Hak:";
            pictureBox1.Location = PAC_MAN(karakterKonumuY, karakterKonumuX);
            pictureBox2.Location = PAC_MAN(KırmızıHayaletY, KırmızıHayaletX);
            KırmızıHayalet.Start();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Start();
            if (e.KeyCode == Keys.D)
                İstenenYön = 1;
            if (e.KeyCode == Keys.A)
                İstenenYön = 2;
            if (e.KeyCode == Keys.W)
                İstenenYön = 3;
            if (e.KeyCode == Keys.S)
                İstenenYön = 4;

        }

    }
}
