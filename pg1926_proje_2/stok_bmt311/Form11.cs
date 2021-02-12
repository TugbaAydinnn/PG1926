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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            if (comboBox1.SelectedIndex == 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Denim Ceket");
                listBox1.Items.Add("Blazer Ceket");
                listBox1.Items.Add("Deri Ceket");
                listBox1.Items.Add("Polar Ceket");
                listBox1.Items.Add("Bomber Ceket");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Balıkçı Yaka Kazak");
                listBox1.Items.Add("V Yaka Kazak");
                listBox1.Items.Add("Basic Yaka Kazak");


            }
            else if (comboBox1.SelectedIndex == 2)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Polo T-shirt");
                listBox1.Items.Add("Baskılı T-shirt");
                listBox1.Items.Add("Basic T-shirt ");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Boru Paça Pantolon");
                listBox1.Items.Add("İspanyol Paça Pantolon");
                listBox1.Items.Add("Geniş Paça Pantolon ");
                listBox1.Items.Add("Kargo Pantolon ");
                listBox1.Items.Add("Denizci Pantolon ");
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Pileli Etek");
                listBox1.Items.Add("Kot Etek");
                listBox1.Items.Add("Midi Boy Etek");
                listBox1.Items.Add("Fırfırlı  Etek");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

             OracleConnection baglanti = new OracleConnection();
             baglanti.ConnectionString = conString;
             baglanti.Open();

             OracleCommand komut = baglanti.CreateCommand();
           
            string urunID = textBox1.Text;
             int miktar =Int32.Parse( textBox2.Text.ToString());
             string urun_turu = comboBox1.Text;
            String urun_ozelligi = Convert.ToString(listBox1.SelectedItem);


                string urun_cinsiyet = comboBox3.Text;
                string beden = comboBox4.Text;
                int fiyat = Int32.Parse(textBox3.Text.ToString());
                string urun_renk = comboBox5.Text;
                komut.CommandText = "INSERT INTO UrunBilgileri VALUES ('" + urunID + "','" + miktar + "','" + urun_turu + "','" + urun_ozelligi + "','" + urun_cinsiyet + "','" + beden + "','" + fiyat + "','" + urun_renk + "')";
               

            komut.ExecuteNonQuery();
            OracleCommand komutView = baglanti.CreateCommand();
            komutView.CommandText = "INSERT INTO SatisBilgileri VALUES ('" + textBox4.Text.ToString() + "','" + Int32.Parse(textBox5.Text.ToString()) + "')";
            komutView.ExecuteNonQuery();

            MessageBox.Show("Kayıt başarıyla eklenmiştir...");
            baglanti.Close();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox2.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            listBox1.Items.Clear();
            comboBox1.Text = " ";
            comboBox3.Text = " ";
            comboBox4.Text = " ";
            comboBox5.Text = " ";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
