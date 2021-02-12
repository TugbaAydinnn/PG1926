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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

                OracleConnection baglanti = new OracleConnection();
                baglanti.ConnectionString = conString;
                baglanti.Open();
                OracleCommand komut = baglanti.CreateCommand();

                komut.CommandText = "SELECT * FROM PersonelBilgileri ORDER BY ad asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;

                MessageBox.Show("Kayıtlar başarıyla alfabetik olarak sıralanmıştır...");
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
                komut.CommandText = "SELECT * FROM PersonelBilgileri ORDER BY maas asc ";
                komut.ExecuteNonQuery();

                OracleDataAdapter adtr = new OracleDataAdapter();
                adtr.SelectCommand = komut;
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;



                MessageBox.Show("Kayıtlar başaıyla küçükten büyüğe sıralanmıştır...");
                baglanti.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string tcNumarasi = textBox1.Text;
            komut.CommandText = "SELECT * FROM PersonelBilgileri WHERE tcNumarasi='" + textBox1.Text + "' ";
            komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Kayıt başaıyla bulunmuştur...");
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tcNumarasi, ad, soyad, sifre, telNo, cinsiyet, okulDurumu, departman, departmanID;
            int maas;
            tcNumarasi = dataGridView1.CurrentRow.Cells["tcNumarasi"].Value.ToString();
            ad = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            soyad = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            sifre = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
            telNo = dataGridView1.CurrentRow.Cells["telNo"].Value.ToString();

            cinsiyet = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
            okulDurumu = dataGridView1.CurrentRow.Cells["okulDurumu"].Value.ToString();
            departman = dataGridView1.CurrentRow.Cells["departman"].Value.ToString();
            departmanID = dataGridView1.CurrentRow.Cells["departmanID"].Value.ToString();
            maas =Int32.Parse(dataGridView1.CurrentRow.Cells["maas"].Value.ToString());
            baglanti.Open();
            OracleCommand komut = new OracleCommand("UPDATE PersonelBilgileri SET  ad='"+ad+"',soyad='"+soyad+"', sifre='"+sifre+"', telNo='"+telNo+"', cinsiyet='"+cinsiyet+"', okulDurumu='"+ okulDurumu+ "', departman='"+departman+"', departmanID='"+departmanID+"',maas='"+maas+"' WHERE tcNumarasi='"+tcNumarasi+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.DataSource = yenile();
            MessageBox.Show("Veri Güncellenmiştir...");



        }
        DataTable yenile()
        {
            baglanti.Open();
            OracleDataAdapter adtr = new OracleDataAdapter("SELECT * FROM  PersonelBilgileri",baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yenile();
        }
    }
}
