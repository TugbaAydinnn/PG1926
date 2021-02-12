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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
       
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");

        public void Listele()
        {
            OracleCommand komut1 = new OracleCommand("seleccionarPROCEDURE_PERSONEL", baglanti);
            komut1.CommandType = System.Data.CommandType.StoredProcedure;
            komut1.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut1;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void Form7_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Transparent;
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
