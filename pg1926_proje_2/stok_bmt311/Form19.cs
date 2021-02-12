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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void Form19_Load(object sender, EventArgs e)
        {
           String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            DataTable tablo = new DataTable();
            baglanti.Open();
            OracleCommand komut = baglanti.CreateCommand();
            OracleDataAdapter adtr = new OracleDataAdapter("SELECT urunID,ilkMiktar,miktar FROM SATISBIL_V", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
          
            int satirSayisi = dataGridView1.RowCount - 1;
            for (int i = 0; i < satirSayisi; i++)
            {
              
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                
                if (dataGridView1.Rows[i].Cells[2].Value.ToString()=="null"|| dataGridView1.Rows[i].Cells[2].Value.ToString() == "")
                {
                    textBox3.Text = "0";
                    dataGridView1.Rows[i].Cells[2].Value = 0.ToString();
                   
                }
                else
                {
                    textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
                int fark = Int32.Parse(textBox2.Text) - Int32.Parse(textBox3.Text);
                textBox4.Text = fark.ToString();
                chart1.Series["Satıs Miktar"].Points.AddXY(textBox1.Text, textBox4.Text);
            }
            baglanti.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            DataTable tabloTarih = new DataTable();
            baglanti.Open();
            OracleCommand komutTarih = baglanti.CreateCommand();
            OracleDataAdapter adtrTarih = new OracleDataAdapter("SELECT * FROM SATISTARIH_V", baglanti);
            adtrTarih.Fill(tabloTarih);
            dataGridView2.DataSource = tabloTarih;
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();
            string tarih = textBox5.Text;
            string sql = "SELECT * FROM SATISTARİH_V Where @tarih='";

       
            //komut.CommandText = "SELECT * FROM SATISTARIH_V WHERE tarih='" + textBox5.Text + "',TO_DATE('" + textBox5.Text+ "', 'DD/MM/YYYY HH:MI:SS'))";
            //komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter(sql, baglanti);
            //adtr.SelectCommand = komut;
           // adtr.SelectCommand.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;

            MessageBox.Show("Ürünler aranan tarihe göre bulunmuştur...");
            baglanti.Close();*/
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();

        }
    }
}
