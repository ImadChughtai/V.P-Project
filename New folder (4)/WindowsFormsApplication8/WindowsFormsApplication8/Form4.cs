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
    public partial class Form4 : Form
    {
    
        Form2 f2=new Form2();
        public Form4()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from SHOOT where SID='" + this.comboBox2.Text + "'", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr["BNAME"].ToString();
                this.textBox2.Text = dr["BTYPE"].ToString();
                this.textBox3.Text = dr["BCONTACT"].ToString();
                this.textBox4.Text = dr["BLOCATION"].ToString();
               
                




            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("update SHOOT set BNAME=@BNAME,BLOCATION=@BLOCATION,BCONTACT=@BCONTACT,MNAME=@MNAME,MAGE=@MAGE,MGENDER=@MGENDER,MCONTACT=@MCONTACT,MADDRESS=@MADDRESS,COST=@COST WHERE SID=@SID", f2.sqlConnection1);
            
            cmd1.Parameters.AddWithValue("@BNAME", this.textBox1.Text);
            cmd1.Parameters.AddWithValue("@BTYPE", this.textBox2.Text);
            
            cmd1.Parameters.AddWithValue("@BLOCATION", this.textBox4.Text);
            cmd1.Parameters.AddWithValue("@BCONTACT", this.textBox3.Text);
            cmd1.Parameters.AddWithValue("@MNAME", this.textBox10.Text);
            cmd1.Parameters.AddWithValue("@MAGE", this.textBox5.Text);
            cmd1.Parameters.AddWithValue("@MGENDER", this.textBox6.Text);
            cmd1.Parameters.AddWithValue("@MADDRESS", this.textBox7.Text);
            cmd1.Parameters.AddWithValue("@MCONTACT", this.textBox8.Text);
            cmd1.Parameters.AddWithValue("@COST", this.textBox9.Text);
          
            cmd1.Parameters.AddWithValue("@SID", this.comboBox2.Text);

            cmd1.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("UPDATE BRAND set NAME=@NAME,LOCATION=@LOCATION,CONTACT=@CONTACT,TYPE=@TYPE WHERE SID=@SID", f2.sqlConnection1);

            cmd2.Parameters.AddWithValue("@NAME", this.textBox1.Text);
            cmd2.Parameters.AddWithValue("@TYPE", this.textBox2.Text);

            cmd2.Parameters.AddWithValue("@LOCATION", this.textBox4.Text);
            cmd2.Parameters.AddWithValue("@CONTACT", this.textBox3.Text);
         

            cmd2.Parameters.AddWithValue("@SID", this.comboBox2.Text);

            cmd2.ExecuteNonQuery();
            f2.sqlConnection1.Close();
            MessageBox.Show("BOOKING Updated Successfully !");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select SID from SHOOT", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["SID"].ToString());
            }
            f2.sqlConnection1.Close();
            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select NAME from MODEL", f2.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox1.Items.Add(dr1["NAME"].ToString());
            }
            f2.sqlConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from MODEL where NAME='" + this.comboBox1.Text + "'", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox5.Text = dr["AGE"].ToString();
                this.textBox6.Text = dr["GENDER"].ToString();
                this.textBox8.Text = dr["CONTACT"].ToString();
                this.textBox7.Text = dr["ADDRESS"].ToString();
                this.textBox9.Text = dr["COST"].ToString();
                this.textBox10.Text = dr["NAME"].ToString();



            }
            f2.sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
