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
    public partial class Form12 : Form
    {
        public Form12()
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
            OracleCommand komutSil = baglanti.CreateCommand();



            string urunID = textBox1.Text;
            komut.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox1.Text + "' ";
            komut.ExecuteNonQuery();
            komutSil.CommandText = "DELETE FROM SatisBilgileri WHERE urunID='" + textBox2.Text + "' ";
            komutSil.ExecuteNonQuery();

            MessageBox.Show("Kayıt başarıyla silinmiştir...");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
