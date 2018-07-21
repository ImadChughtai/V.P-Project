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
    public partial class Form3 : Form
    {
        int j;
        int i;
        Form2 f2=new Form2();
        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select NAME from MODEL", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["NAME"].ToString());
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
                this.textBox6.Text = dr["GENDER"].ToString();
                this.textBox5.Text = dr["AGE"].ToString();
                this.textBox8.Text = dr["CONTACT"].ToString();
                this.textBox7.Text = dr["ADDRESS"].ToString();
                this.textBox9.Text = dr["COST"].ToString();
                



            }
            f2.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f2.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(SID) from SHOOT", f2.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                i = Convert.ToInt32(dr[0]);
                f2.sqlConnection1.Close();
                i++;
            }
            f2.sqlConnection1.Close();
            f2.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("insert into SHOOT(SID,BNAME,BLOCATION,BCONTACT,BTYPE,MNAME,MAGE,MGENDER,MCONTACT,MADDRESS,COST) VALUES(@SID,@BNAME,@BLOCATION,@BCONTACT,@BTYPE,@MNAME,@MAGE,@MGENDER,@MCONTACT,@MADDRESS,@COST)", f2.sqlConnection1);
            cmd1.Parameters.AddWithValue("@SID", i);
            cmd1.Parameters.AddWithValue("@BNAME", this.textBox1.Text);
            cmd1.Parameters.AddWithValue("@BLOCATION", this.textBox4.Text);
            cmd1.Parameters.AddWithValue("@BCONTACT", this.textBox3.Text);
            cmd1.Parameters.AddWithValue("@BTYPE", this.textBox2.Text);
            cmd1.Parameters.AddWithValue("@MNAME", this.comboBox1.Text);
            cmd1.Parameters.AddWithValue("@MAGE", this.textBox5.Text);
            cmd1.Parameters.AddWithValue("@MGENDER", this.textBox6.Text);
            cmd1.Parameters.AddWithValue("@MCONTACT", this.textBox7.Text);
            cmd1.Parameters.AddWithValue("@MADDRESS", this.textBox8.Text);
            cmd1.Parameters.AddWithValue("@COST", this.textBox9.Text);
            
            cmd1.ExecuteNonQuery();
            f2.sqlConnection1.Close();

            f2.sqlConnection1.Open();
            SqlCommand cmd3 = new SqlCommand("select count(SID) from BRAND", f2.sqlConnection1);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                j = Convert.ToInt32(dr3[0]);
                f2.sqlConnection1.Close();
                j++;
            }
            f2.sqlConnection1.Close();
            f2.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("insert into BRAND(SID,NAME,LOCATION,CONTACT,TYPE) VALUES(@SID,@NAME,@LOCATION,@CONTACT,@TYPE)", f2.sqlConnection1);
            cmd2.Parameters.AddWithValue("@SID", j);
            cmd2.Parameters.AddWithValue("@NAME", this.textBox1.Text);
            cmd2.Parameters.AddWithValue("@LOCATION", this.textBox4.Text);
            cmd2.Parameters.AddWithValue("@CONTACT", this.textBox3.Text);
            cmd2.Parameters.AddWithValue("@TYPE", this.textBox2.Text);
            
            cmd2.ExecuteNonQuery();
            f2.sqlConnection1.Close();
            MessageBox.Show("Your Shoot has been booked");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
