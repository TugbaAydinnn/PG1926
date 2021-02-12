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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string tcNumarasi = maskedTextBox2.Text;
            string ad = textBox2.Text;
            string soyad = textBox3.Text;
            string sifre = textBox4.Text;
            string telNo = maskedTextBox1.Text;
            string cinsiyet = comboBox1.Text;
            komut.CommandText = "INSERT INTO MusteriBilgileri VALUES ('" + tcNumarasi + "','" + ad + "','" + soyad + "','" + sifre + "','" + telNo + "','" + cinsiyet + "')";

            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarıyla eklenmiştir...");
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
