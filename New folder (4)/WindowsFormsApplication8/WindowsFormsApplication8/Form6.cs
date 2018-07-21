using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApplication8
{
    public partial class Form6 : Form
    {
        Form2 f2 = new Form2();
        public Form6()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from SHOOT where SID='" + this.comboBox1.Text + "'", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select *from SHOOT", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            f2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
