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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string tcNumarasi = maskedTextBox1.Text;
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string telNo = maskedTextBox2.Text;
            string sifre= textBox5.Text;
            string cinsiyet = comboBox1.Text;
            komut.CommandText = "INSERT INTO MusteriBilgileri VALUES ('" + tcNumarasi + "','" + ad + "','" + soyad + "','" + sifre + "','" + telNo + "','" + cinsiyet + "')";

            komut.ExecuteNonQuery();
            MessageBox.Show("Tebrikler!\n STA Stok Programına Kayıt Oldunuz...");
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
