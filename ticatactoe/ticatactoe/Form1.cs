using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ticatactoe
{
    public partial class Form1 : Form
    {
        int sira_sayisi = 0;
        bool yeni = true;
        string sira;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            sira = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt");
            if (sira == "O")
                label1.Text = "Siradaki Oyuncu O";
            else if (sira == "X")
                label1.Text = "Siradaki Oyuncu X";
        }

        private void hakkındaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geliştirici : Hüseyin Karakuş", "Tic Tac Toe");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tikla(object sender, EventArgs e)
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
            sira = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt");
            Button buton = (Button)sender;
            if (sira == "X")
            {
                buton.Text = "X";
                label1.Text = "Siradaki Oyuncu O";
                sira = "O";
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
            }
            else if (sira == "O")
            {
                buton.Text = "O";
                label1.Text = "Siradaki Oyuncu X";
                sira = "X";
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                 sira);
            }
            yeni = false;
            buton.Enabled = false;
            sira_sayisi++;
            kazanan();
        }
        private void kazanan()
        {
            bool kazanan = false;
            //YAN YANA KAZANAN KONTROLÜ
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            { kazanan = true; }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            { kazanan = true; }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            { kazanan = true; }
            //ÜST ÜSTE KAZANAN KONTROLÜ
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            { kazanan = true; }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            { kazanan = true; }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            { kazanan = true; }
            //ÇAPRAZ KAZANAN KONTROLÜ
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            { kazanan = true; }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            { kazanan = true; }

            if (kazanan)
            {
                sira = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt");
                Button[] butonlar = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                for (int i = 0; i < butonlar.Length; i++)
                {
                    butonlar[i].Enabled = false;
                }
                string kazandi = "";
                if (sira == "O")//Eğer sıra x e geldiyse ve kazanan varsa kazanan O dur.
                {
                    kazandi = "X KAZANDI";
                    sira = "O";
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
                }
                else if (sira == "X")
                {
                    kazandi = "O KAZANDI";
                    sira = "X";
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
                }
                MessageBox.Show(kazandi, "Tic Tac Toe");
            }
            else
            {
                if (sira_sayisi == 9)
                {
                    MessageBox.Show("Berabere", "Tic Tac Toe");
                    yeni_oyun_olustur();
                }
            }
        }

        private void yeni_oyun(object sender, EventArgs e)
        {
            if (sira_sayisi == 0)
            {
                yeni = true;
            }
            yeni_oyun_olustur();
            if (yeni)//ilk oyuna başlayınca yeni oyuna tıklandığında sıra değişmesi.
            {
                if (sira == "X")
                {
                    sira = "O";
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                      sira);
                    label1.Text = "Siradaki Oyuncu O";
                }
                else if (sira == "O")
                {
                    sira = "X";
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                      sira);
                    label1.Text = "Siradaki Oyuncu X";
                }
            }
        }
        private void yeni_oyun_olustur()
        {
            sira = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt");
            if (sira == "X")
            {
                sira = "X";
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
            }
            else if (sira == "O")
            {
                sira = "O";
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "sira.txt",
                  sira);
            }
            sira_sayisi = 0;
            Button[] butonlar = new Button[9] { A1, A2, A3, B1, B2, B3, C1, C2, C3 };//butonları bir buton dizisine atadım böylece yeni oyuna başlayınca içlerini boşaltıp enabled disabled yapabiliyorum. 
            for (int i = 0; i < butonlar.Length; i++)
            {
                butonlar[i].Text = "";
                butonlar[i].Enabled = true;
            }
        }
    }
}
