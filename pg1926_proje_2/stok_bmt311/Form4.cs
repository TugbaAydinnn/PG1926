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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form12 frm12 = new Form12();
            frm12.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Form13 frm13 = new Form13();
            frm13.Show();
            this.Hide();
        }
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = ımageList1.Images[time];
            if (time == ımageList1.Images.Count - 1)
            {
                time = 0;
            }
            else
            {
                time++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDUREMUSTERI", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();


           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDURE_URUN", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            Form17 frm17 = new Form17();
            frm17.Show();
        }
    }
}
