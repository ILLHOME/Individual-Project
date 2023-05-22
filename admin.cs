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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pC_SHOPDataSet1.Product' table. You can move, or remove it, as needed.
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand($"select _id, _name, _amount, _price from Product;", Global.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            reader.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0: 
                    {                        
                        dataGridView1.Visible = true;
                    }
                    break;
                case 1:
                    {
                        label2.Visible = true;
                        label3.Visible = true;
                        label4.Visible = true;
                        label6.Visible = true;
                        label7.Visible = true;
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        textBox3.Visible = true;
                        comboBox2.Visible = true;
                    }
                    break;
            }
            comboBox1.Visible = false;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) 
            {
                case 0:
                    {
                        foreach(DataGridViewRow el in dataGridView1.Rows)
                        {
                            if (el.Cells[0].Value != null)
                                Global.sql_push($"update Product set _amount = {Convert.ToInt32(el.Cells[2].Value)}, _price = {Convert.ToInt32(el.Cells[3].Value)} where _id = {Convert.ToInt32(el.Cells[0].Value)};", Global.sql_push_type.update);
                        }
                    }
                    break;
                case 1:
                    {
                        Global.sql_push($"insert into Product(_name, _amount, _price, _product_type) values ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{comboBox2.SelectedIndex}');", Global.sql_push_type.insert);
                    }
                    break;
            }
            this.Close();
        }
    }
}
