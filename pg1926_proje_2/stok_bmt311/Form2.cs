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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void button3_Click(object sender, EventArgs e)
        {

            Form6 frm6 = new Form6();
            frm6.Show();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form15 frm15 = new Form15();
            frm15.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDURE_PERSONEL", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox2.Visible = true;
                groupBox4.Visible = false;
                groupBox3.Visible = false;
                tabControl1.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                groupBox4.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                tabControl1.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                groupBox3.Visible = true;
                groupBox2.Visible = false;
                groupBox4.Visible = false;
                tabControl1.Visible = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
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

        private void button13_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
           
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDUREMUSTERI", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView3.DataSource = tablo;
            baglanti.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button18.BackColor = Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form11 frm11 = new Form11();
            frm11.Show();
        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Show();
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
      
            this.WindowState = FormWindowState.Maximized;
            button19.Visible = false;
            button21.Visible = true;
            button18.Location = new Point(1495, 3);
            button21.Location = new Point(1452, 3);
            button20.Location = new Point(1410, 30);



        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button19.Visible = true;
            button21.Visible = false;
            button18.Location = new Point(805,2);
            button20.Location = new Point(718,30);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form16 frm16 = new Form16();
            frm16.Show();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form17 frm17 = new Form17();
            frm17.Show();
          
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form18 frm18 = new Form18();
            frm18.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form20 frm20 = new Form20();
            frm20.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button24_Click(object sender, EventArgs e)
        {
            Form21 frm21 = new Form21();
            frm21.Show();
        }
    }
}
