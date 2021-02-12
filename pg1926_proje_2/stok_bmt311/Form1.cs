using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace stok_bmt311
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
         
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox2.Visible = true;//groupbox2'nin ekranda görünmesini sağlar.
                groupBox3.Visible = false;//groupbox3'ün  ekranda görünmemesini sağlar.
            }
            else if (radioButton3.Checked == true)
            {
                groupBox3.Visible = true;
                groupBox2.Visible = false;
            }
            else if (radioButton2.Checked == true)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
            else
                MessageBox.Show("Beklenmedik Bir Hata Oluştu...");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form3 frm3 = new Form3();
            frm3.Show();//Form3 penceresini açar.
            this.Hide();// Form1 penceresini gizler.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "12345678912" && textBox2.Text == "123")
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
                MessageBox.Show("STA Stok Programına \n Hoş Geldiniz..");
            }
            else
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalıdır.");

          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;

            OracleCommand komut1 = baglanti.CreateCommand();
            OracleCommand komut2 = baglanti.CreateCommand();
            baglanti.Open();
        
            OracleCommand ara = new OracleCommand("select count(*) from MusteriBilgileri where tcNumarasi='" + textBox3.Text + "'", baglanti);
            if (ara.ExecuteScalar().ToString() == "1")
            {
                OracleCommand sifre = new OracleCommand("select sifre from MusteriBilgileri where tcNumarasi='" + textBox3.Text + "'", baglanti);
                if (textBox4.Text == sifre.ExecuteScalar().ToString())
                {

                    Form14 frm14 = new Form14();
                    frm14.Show();
                    this.Hide();

                    komut1.CommandText = "Select ad FROM MusteriBilgileri WHERE tcNumarasi='" + textBox3.Text + "'";
                    komut2.CommandText = "Select soyad FROM MusteriBilgileri WHERE tcNumarasi='" + textBox3.Text + "'";
                    textBox5.Text = (string)komut1.ExecuteScalar();
                    textBox6.Text = (string)komut2.ExecuteScalar();
                    MessageBox.Show("STA Stok Programına Hoş Geldiniz.. \n" + "Sayın: "+textBox5.Text+" "+textBox6.Text);
                    frm14.label15.Text= (string)komut1.ExecuteScalar();
                    frm14.label16.Text = (string)komut2.ExecuteScalar();

                }
                else
                    MessageBox.Show("Girdiğiniz Şifre Hatalıdır. \n Lütfen Tekrar Deneyiniz...");
            }
            else
                MessageBox.Show("Girdiğiniz Kullanıcı Adı Bulunamadı...");
            baglanti.Close();
            







         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(3000, "STA", "STA'ya Hoş Geldiniz", ToolTipIcon.Info);
            textBox4.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;

            OracleCommand komut1 = baglanti.CreateCommand();
            OracleCommand komut2 = baglanti.CreateCommand();
            baglanti.Open();

            OracleCommand ara = new OracleCommand("select count(*) from PersonelBilgileri where tcNumarasi='" + textBox1.Text + "'", baglanti);
            if (ara.ExecuteScalar().ToString() == "1")
            {
                OracleCommand sifre = new OracleCommand("select sifre from PersonelBilgileri where tcNumarasi='" + textBox1.Text + "'", baglanti);
                if (textBox2.Text == sifre.ExecuteScalar().ToString())
                {

                    Form4 frm4 = new Form4();
                    frm4.Show();
                    this.Hide();

                    komut1.CommandText = "Select ad FROM PersonelBilgileri WHERE tcNumarasi='" + textBox1.Text + "'";
                    komut2.CommandText = "Select soyad FROM PersonelBilgileri WHERE tcNumarasi='" + textBox1.Text + "'";
                    textBox5.Text = (string)komut1.ExecuteScalar();
                    textBox6.Text = (string)komut2.ExecuteScalar();
                    MessageBox.Show("STA Stok Programına Hoşgeldiniz.. \n" + "Sayın: " + textBox5.Text + " " + textBox6.Text);
                    frm4.label1.Text = (string)komut1.ExecuteScalar();
                    frm4.label2.Text = (string)komut2.ExecuteScalar();


                }
                else
                    MessageBox.Show("Girdiğiniş şifre hatalıdır.Lütfen tekrar deneyiniz...");
            }
            else
                MessageBox.Show("Girdiğiniz kullanıcı adı bulunamadı...");
            baglanti.Close();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState==CheckState.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
                checkBox1.Text = "Şifreyi Gizle";
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
                checkBox1.Text = "Şifreyi Göster";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox2.Text = "Şifreyi Gizle";
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                checkBox2.Text = "Şifreyi Göster";
            }
        }
    }
}
