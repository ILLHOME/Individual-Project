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
{    public partial class sell : Form
    {
        int choice = 0;
        public sell()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand($"select _id, _name, _amount, _price from Product where _name like '%{textBox1.Text}%' and _amount > 0;",Global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            reader.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            choice = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.SelectedCells[1].Value);
            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = $"insert into Orders(_product_id, _payment_id, _delivery_id) values ({choice},{comboBox1.SelectedIndex},{comboBox2.SelectedIndex});";
            Global.sql_push(query, Global.sql_push_type.insert);

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select mixOPP._name, Delivery_method._name as dm_name, mixOPP.pm_name, mixOPP._time from Delivery_method inner join (select mixOP._delivery_id, Payment_method._name as pm_name, mixOP._name, mixOP._time from Payment_method inner join (select Product._name, Orders._payment_id, Orders._delivery_id, Orders._time from Orders inner join Product on Orders._product_id = Product._id) as mixOP on Payment_method._id = mixOP._payment_id) as mixOPP on Delivery_method._id = mixOPP._delivery_id;", Global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView2.DataSource = dt;
            reader.Close();

            textBox1.Clear();
            textBox1.Enabled = true;
        }

        private void sell_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select mixOPP._name, Delivery_method._name as dm_name, mixOPP.pm_name, mixOPP._time from Delivery_method inner join (select mixOP._delivery_id, Payment_method._name as pm_name, mixOP._name, mixOP._time from Payment_method inner join (select Product._name, Orders._payment_id, Orders._delivery_id, Orders._time from Orders inner join Product on Orders._product_id = Product._id) as mixOP on Payment_method._id = mixOP._payment_id) as mixOPP on Delivery_method._id = mixOPP._delivery_id;", Global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView2.DataSource = dt;
            reader.Close();

        }
    }
}
