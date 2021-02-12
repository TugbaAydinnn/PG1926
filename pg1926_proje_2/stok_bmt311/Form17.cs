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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void button1_Click(object sender, EventArgs e)
        {
            String urunID, urun_turu, urun_ozelligi, urun_cinsiyet, beden,urun_renk,urun_kodu;
            int miktar,fiyat;
            urunID = dataGridView1.CurrentRow.Cells["urunID"].Value.ToString();
            miktar = Int32.Parse(dataGridView1.CurrentRow.Cells["miktar"].Value.ToString());
            urun_turu = dataGridView1.CurrentRow.Cells["urun_turu"].Value.ToString();
            urun_ozelligi = dataGridView1.CurrentRow.Cells["urun_ozelligi"].Value.ToString();
            urun_cinsiyet = dataGridView1.CurrentRow.Cells["urun_cinsiyet"].Value.ToString();
            beden = dataGridView1.CurrentRow.Cells["beden"].Value.ToString();
            fiyat = Int32.Parse(dataGridView1.CurrentRow.Cells["fiyat"].Value.ToString());
            urun_renk = dataGridView1.CurrentRow.Cells["urun_renk"].Value.ToString();
            //urun_kodu = dataGridView1.CurrentRow.Cells["urun_kodu"].Value.ToString();
            baglanti.Open();
            OracleCommand komut = new OracleCommand("UPDATE UrunBilgileri SET  miktar='" + miktar + "',urun_turu='" + urun_turu + "',urun_ozelligi='" + urun_ozelligi + "', urun_cinsiyet='" + urun_cinsiyet + "', beden ='" + beden + "', fiyat='" + fiyat + "', urun_renk='" + urun_renk + "' WHERE urunID='" + urunID + "' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.DataSource = yenile();
            MessageBox.Show("Ürün Bilgileri Güncellenmiştir...");
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yenile();
        }
        DataTable yenile()
        {
            baglanti.Open();
            OracleDataAdapter adtr = new OracleDataAdapter("SELECT * FROM  UrunBilgileri", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

                OracleConnection baglanti = new OracleConnection();
                baglanti.ConnectionString = conString;
                baglanti.Open();
                OracleCommand komut = baglanti.CreateCommand();

                komut.CommandText = "SELECT * FROM UrunBilgileri ORDER BY urun_turu asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;

                MessageBox.Show("Kayıtlar başarıyla alfabetik olarak sıralanmıştır...");
                baglanti.Close();
            }
            else if(radioButton2.Checked==true)
            {
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

                OracleConnection baglanti = new OracleConnection();
                baglanti.ConnectionString = conString;
                baglanti.Open();

                OracleCommand komut = baglanti.CreateCommand();


                // string tcNumarasi = textBox1.Text;
                komut.CommandText = "SELECT * FROM UrunBilgileri ORDER BY fiyat asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                MessageBox.Show("Ürünlerin Fiyatı küçükten büyüğe sıralanmıştır...");
                baglanti.Close();

            }
            else if (radioButton3.Checked == true)
            {
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

                OracleConnection baglanti = new OracleConnection();
                baglanti.ConnectionString = conString;
                baglanti.Open();
                OracleCommand komut = baglanti.CreateCommand();

                komut.CommandText = "SELECT * FROM UrunBilgileri ORDER BY urun_ozelligi asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;

                MessageBox.Show("Ürün Özellikleri alfabetik olarak sıralanmıştır...");
                baglanti.Close();
            }
            else
            {
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

                OracleConnection baglanti = new OracleConnection();
                baglanti.ConnectionString = conString;
                baglanti.Open();

                OracleCommand komut = baglanti.CreateCommand();


                // string tcNumarasi = textBox1.Text;
                komut.CommandText = "SELECT * FROM UrunBilgileri ORDER BY miktar asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                MessageBox.Show("Ürünlerin Miktarı küçükten büyüğe sıralanmıştır...");
                baglanti.Close();

            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

            MessageBox.Show("Ürün başarıyla bulunmuştur...");
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
