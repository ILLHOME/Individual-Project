using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Project
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connecton_string = $"Data Source=MSIMODERN15;Initial Catalog=PC_SHOP;User ID={textBox1.Text};Password={textBox2.Text}";
            Global.conn = new SqlConnection(connecton_string);
            Global.conn.Open();

            l_status.Text = "Connected!";
            l_status.ForeColor = System.Drawing.Color.Green;

            btnSell.Visible = true;
            btnStock.Visible = true;
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            sell sell_form = new sell();
            sell_form.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            admin admin_form = new admin();
            admin_form.Show();
        }
    }
}
