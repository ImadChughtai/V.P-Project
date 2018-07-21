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
    public partial class Form9 : Form
    {
        Form2 f2 = new Form2();
        public Form9()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from MODEL where MID='" + this.comboBox1.Text + "'", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                this.textBox1.Text = dr["NAME"].ToString();
                this.textBox2.Text = dr["AGE"].ToString();
                this.textBox4.Text = dr["CONTACT"].ToString();
                this.textBox5.Text = dr["ADDRESS"].ToString();
                this.textBox3.Text = dr["GENDER"].ToString();
                this.textBox6.Text = dr["COST"].ToString();





            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("update MODEL set NAME=@NAME,AGE=@AGE,GENDER=@GENDER,CONTACT=@CONTACT,ADDRESS=@ADDRESS,COST=@COST WHERE MID=@MID", f2.sqlConnection1);

           
            cmd1.Parameters.AddWithValue("@NAME", this.textBox1.Text);
            cmd1.Parameters.AddWithValue("@AGE", this.textBox2.Text);
            cmd1.Parameters.AddWithValue("@GENDER", this.textBox3.Text);
            cmd1.Parameters.AddWithValue("@ADDRESS", this.textBox5.Text);
            cmd1.Parameters.AddWithValue("@CONTACT", this.textBox4.Text);
            cmd1.Parameters.AddWithValue("@COST", this.textBox6.Text);

            cmd1.Parameters.AddWithValue("@MID", this.comboBox1.Text);

            cmd1.ExecuteNonQuery();
            f2.sqlConnection1.Close();
            MessageBox.Show("MODEL Updated Successfully !");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select MID from MODEL", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["MID"].ToString());
            }
            f2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
