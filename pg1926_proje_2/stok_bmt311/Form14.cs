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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }


       
        OracleConnection baglanti = new OracleConnection("DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM");//global olarak tanımlanmıştır.
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OracleCommand komut = new OracleCommand("seleccionarPROCEDURE_URUN", baglanti);
            komut.CommandType = System.Data.CommandType.StoredProcedure;
            komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            OracleCommand komut1 = baglanti.CreateCommand();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                //MessageBox.Show("1");
                string c = (dataGridView1.Rows[i].Cells[0].Value.ToString());
                textBox7.Text = c;

                // textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) == 0)
                {
                    MessageBox.Show("2");
                    //komut1.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox7.Text + "' ";
                    komut1.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox7.Text + "'";
                    komut1.ExecuteNonQuery();
                }
            }

            baglanti.Close();

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
            string urun_cinsiyet = comboBox2.Text;
            string beden = comboBox3.Text;
            string urun_renk = comboBox4.Text;
            komut.CommandText = "SELECT * FROM UrunBilgileri WHERE urun_turu='"+comboBox1.Text+"' and urun_ozelligi='" +listBox1.Text+"' and urun_cinsiyet='" +comboBox2.Text+"'and beden='"+comboBox3.Text+ "'and urun_renk='" + comboBox4.Text + "'";
            komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Kayıtlar başarıyla listelenmiştir...");
            baglanti.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
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



            MessageBox.Show("Ürün fiyatları başarıyla küçükten büyüğe sıralanmıştır...");
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";

            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();

            OracleCommand komut = baglanti.CreateCommand();


            string a_fiyat = textBox1.Text;
            string u_fiyat = textBox1.Text;

            komut.CommandText = "SELECT * FROM UrunBilgileri WHERE fiyat BETWEEN '"+textBox1.Text+"' AND '"+textBox2.Text+"'";
            komut.ExecuteNonQuery();
            OracleDataAdapter adtr = new OracleDataAdapter();
            adtr.SelectCommand = komut;
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            MessageBox.Show("Kayıtlar istenişlen aralıkta başarıyla listelenmiştir...");
            baglanti.Close();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                object[] rowData = new object[row.Cells.Count];
                for (int i = 0; i < rowData.Length; ++i)
                {
                    rowData[i] = row.Cells[i].Value;
                }
                this.dataGridView2.Rows.Add(rowData);
            }





        }

        private void Form14_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
          
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Sütun değerlerini toplama
            int toplam = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView2.Rows[i].Cells[6].Value);
            }
            textBox3.Text= toplam.ToString();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";
            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;

     

            baglanti.Open();
            OracleCommand komut = baglanti.CreateCommand();
            OracleCommand komut1 = baglanti.CreateCommand();
            OracleCommand komut2 = baglanti.CreateCommand();
            int satirSayisi = dataGridView2.RowCount - 1;
            //MessageBox.Show(deneme.ToString());
       
        
        for (int i = 0; i < satirSayisi; i++)
             {
                for(int j =0; j < dataGridView1.RowCount-1;j++){ 
                 
                    string a= (dataGridView1.Rows[j].Cells[0].Value.ToString());
                    string b= (dataGridView2.Rows[i].Cells[0].Value.ToString());
                    textBox5.Text = a;
                    textBox6.Text = b;
                    

                    if (dataGridView1.Rows[j].Cells[0].Value == dataGridView2.Rows[i].Cells[0].Value) {   
                      
                        
                   komut.CommandText = "UPDATE UrunBilgileri SET miktar=miktar-1 WHERE urunID='" + textBox6.Text + "' ";
                   komut.ExecuteNonQuery();


                    komut2.CommandText = "INSERT INTO TarihBilgisi VALUES ('" + textBox6.Text + "',TO_DATE('" + dateTimePicker1.Value.Date.ToShortDateString() + "', 'DD/MM/YYYY HH:MI:SS'))";
                    komut2.ExecuteNonQuery();

                        // OracleCommand komut1 = new OracleCommand("PROCEDURE_SATIN_AL", baglanti);
                        //komut1.CommandType = System.Data.CommandType.StoredProcedure; 
                        //komut1.Parameters.Add("IN_URUNID", OracleType.Cursor).Direction = ParameterDirection.Output;
                    } 
                }
                 
          //     komut.CommandType = CommandType.StoredProcedure;
           //    komut.CommandText = "PROCEDURE_SATIN_AL";
             }


            /*komut.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox1.Text + "' ";

            komut.ExecuteNonQuery();*/
            MessageBox.Show("Ürün başarılı bir şekilde satın alınmıştır...");
            dataGridView2.Columns.Clear();
            textBox3.Text = " ";
               

            for (int i = 0; i < satirSayisi; i++)
            {
                string c = (dataGridView1.Rows[i].Cells[1].Value.ToString());
                textBox10.Text = c;
                if (Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) == 0)
                {
                    komut1.CommandText = "DELETE FROM SatisBilgileri WHERE  miktar='" + textBox10.Text + "' ";
                    komut1.ExecuteNonQuery();

                }
                    }
      

            baglanti.Close();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";
            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;


            OracleCommand komut1 = baglanti.CreateCommand();

            baglanti.Open();



            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                //MessageBox.Show("1");
                string c = (dataGridView1.Rows[i].Cells[0].Value.ToString());
                textBox7.Text = c;

                // textBox7.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if (Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) == 0)
                {
                    MessageBox.Show("2");
                    //komut1.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox7.Text + "' ";
                    komut1.CommandText = "DELETE FROM UrunBilgileri WHERE urunID='" + textBox7.Text + "'";
                    komut1.ExecuteNonQuery();
                }
            }

             OracleCommand komut = new OracleCommand("seleccionarPROCEDURE_URUN", baglanti);
               komut.CommandType = System.Data.CommandType.StoredProcedure;
               komut.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

               OracleDataAdapter adtr = new OracleDataAdapter();
               adtr.SelectCommand = komut;
               DataTable tablo = new DataTable();
               adtr.Fill(tablo);
               dataGridView1.DataSource = tablo; 




            MessageBox.Show("Listeler yenilenmiştirr..");
            baglanti.Close();



        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string urunID= textBox4.Text;
            string ad = textBox8.Text;
            string soyad = textBox9.Text;
            string telNo = maskedTextBox1.Text;
            string iadeSebebi = comboBox5.Text;
            string iadeAcıklama= richTextBox1.Text;
            

            String conString = "DATA SOURCE=192.168.1.31:1521/XEPDB1;PASSWORD=baris571;USER ID=SYSTEM";
            OracleConnection baglanti = new OracleConnection();
            baglanti.ConnectionString = conString;
            baglanti.Open();
            OracleCommand komut = baglanti.CreateCommand();
            OracleCommand komutEkle = baglanti.CreateCommand();
            komut.CommandText = "UPDATE UrunBilgileri SET miktar=miktar+1 WHERE urunID='" + textBox4.Text + "' ";
            komut.ExecuteNonQuery();
            komutEkle.CommandText = "INSERT INTO IadeBilgileri VALUES ('" + urunID + "','" + ad + "','" + soyad + "','" + telNo + "','" + iadeSebebi + "','" + iadeAcıklama + "')";
            komutEkle.ExecuteNonQuery();

            MessageBox.Show("Ürün iade edilmiştir");



            baglanti.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        int time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = ımageList1.Images[time];
            if (time == ımageList1.Images.Count - 1)
            {
                time = 0;
            }
            else
            {
                time++;
            }

        }
    }
}
