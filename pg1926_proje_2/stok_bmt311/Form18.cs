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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void Form18_Load(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            DataTable tablo = new DataTable();
            baglanti.Open();
            OracleCommand komut = baglanti.CreateCommand();
            OracleDataAdapter adtr = new OracleDataAdapter("SELECT urunID,COUNT(*) AS iadeSayisi FROM IadeBilgileri GROUP BY urunID", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            int satirSayisi = dataGridView1.RowCount - 1;
            for (int i = 0; i<satirSayisi; i++)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                chart1.Series["İade Edilen Ürünler"].Points.AddXY(textBox1.Text, textBox2.Text);
            }
            baglanti.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDURE_IADEBILGILERI", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
