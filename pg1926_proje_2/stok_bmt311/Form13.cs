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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");
        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();
            string tcNumarasi = textBox1.Text;
            komut.CommandText = "SELECT * FROM UrunBilgileri WHERE urunID='" + textBox1.Text + "' ";
            komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Kayıt başarıyla bulunmuştur...");
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string urun_turu = comboBox1.Text;
            string urun_ozelligi = listBox1.Text;

            komut.CommandText = "SELECT * FROM UrunBilgileri WHERE urun_turu='" + comboBox1.Text + "' and urun_ozelligi='" + listBox1.Text + "'";
            komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Kayıtlar başarıyla listelenmiştir...");
            baglanti.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            comboBox1.Text = " ";
            listBox1.Items.Clear();
        }
    }
}
