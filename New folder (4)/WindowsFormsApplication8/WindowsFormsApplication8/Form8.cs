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
    public partial class Form8 : Form
    {
        int i;
        Form2 f2 = new Form2();
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(MID) from MODEL", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = Convert.ToInt32(dr[0]);
                f2.sqlConnection1.Close();
                i++;
            }
            f2.sqlConnection1.Close();
            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("insert into MODEL(MID,NAME,AGE,GENDER,CONTACT,ADDRESS,COST) VALUES(@MID,@NAME,@AGE,@GENDER,@CONTACT,@ADDRESS,@COST)", f2.sqlConnection1);
            cmd1.Parameters.AddWithValue("@MID", i);
            cmd1.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd1.Parameters.AddWithValue("@AGE", textBox2.Text);
            cmd1.Parameters.AddWithValue("@GENDER",textBox3.Text);
            cmd1.Parameters.AddWithValue("@CONTACT", textBox4.Text);
            cmd1.Parameters.AddWithValue("@ADDRESS", textBox5.Text);
            cmd1.Parameters.AddWithValue("@COST", textBox6.Text);
            cmd1.ExecuteNonQuery();
            f2.sqlConnection1.Close();
            MessageBox.Show("Successfully Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
