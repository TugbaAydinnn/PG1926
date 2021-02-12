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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string tcNumarasi = textBox1.Text;
            string ad = textBox2.Text;
            string soyad = textBox3.Text;
            string sifre = textBox4.Text;
            string telNo = maskedTextBox1.Text;
            string cinsiyet = comboBox3.Text;
            string okulDurumu = comboBox1.Text;
            string departman = comboBox2.Text;
            string departmanID = textBox7.Text;
            int maas = Int32.Parse(textBox6.Text.ToString());
            komut.CommandText = "INSERT INTO PersonelBilgileri VALUES ('" + tcNumarasi + "','" + ad + "','" + soyad + "','" + sifre + "','" + telNo + "','" + cinsiyet + "','" + okulDurumu + "','" + departman + "','" + departmanID + "','" + maas + "')";

            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başarıyla eklenmiştir...");
            baglanti.Close();
            //MessageBox.Show("Oracle Veritabanına bağlandınız....");
            //baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Transparent;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.Text== "Kasiyer")
            {
                textBox7.Text = "1";
            }
            else if (comboBox2.Text=="Tezgahtar")
            {
                textBox7.Text = "2";
            }
            else if (comboBox2.Text == "Sekreter")
            {
                textBox7.Text = "3";
            }
            else if (comboBox2.Text == "Hizmetli")
            {
                textBox7.Text = "4";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            maskedTextBox1.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            comboBox3.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
        }
    }
}
