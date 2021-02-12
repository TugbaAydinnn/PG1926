using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok_bmt311
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            progressBar1.Maximum = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != progressBar1.Maximum)

                progressBar1.Value = progressBar1.Value + 20;
            else
            {
                timer1.Stop();
                this.Hide();
                Form19 frm19 = new Form19();
                frm19.Show();
            }
        }
    }
}
