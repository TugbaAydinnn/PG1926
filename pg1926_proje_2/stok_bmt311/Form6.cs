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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");
        private void button3_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string tcNumarasi = textBox1.Text;
            komut.CommandText = "DELETE FROM PersonelBilgileri WHERE tcNumarasi='"+textBox1.Text+"' ";

            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt başaıyla silinmiştir...");
            baglanti.Close();
            //MessageBox.Show("Oracle Veritabanına bağlandınız....");
            //baglanti.Close();

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            button4.Visible = false;
            button6.Visible = true;
            button3.Location = new Point(1495, 3);
            button6.Location = new Point(1452, 3);
            button5.Location = new Point(1410, 30);


        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            button4.Visible = true;
            button6.Visible = false;
            button3.Location = new Point(805, 2);
            button5.Location = new Point(718, 30);
        }
    }
}
