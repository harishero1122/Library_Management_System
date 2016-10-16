using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace $safeprojectname$
{
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Supplier Name", "Error");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Address", "Error");
                }
                else if (textBox3.Text == "" || textBox3.Text.All(char.IsLetter))
                {
                    MessageBox.Show("Enter Contact No", "Error");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter Email Address", "Error");
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Website", "Error");
                }
                else
                {
                    MyConnection.Open();
                    // Insertion Query to Users table// Main
                    string cmd = "INSERT INTO dbo.Supplier VALUES ( '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text+ "')";
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();
                    MessageBox.Show("Supplier Inserted Successfully", "Successful", MessageBoxButtons.OK);
                }
            }
            catch (Exception suppexcep)
            {
                MessageBox.Show(suppexcep.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                if (textBox6.Text == "")
                {
                    MessageBox.Show("Enter Book Name", "Error");
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Enter Book Title", "Error");
                }
                else if (textBox8.Text == "")
                {
                    MessageBox.Show("Enter Category", "Error");
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Enter Author Name", "Error");
                }
                else if (textBox10.Text == "")
                {
                    MessageBox.Show("Enter Publication", "Error");
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("Enter Publishing Date", "Error");
                }
                else if (textBox12.Text == "")
                {
                    MessageBox.Show("Enter Price", "Error");
                }
                else
                {
                    MyConnection.Open();
                    // Insertion Query to Users table// Main
                    SqlParameter B_NAME = new SqlParameter("@b_name", SqlDbType.VarChar, 50);
                    SqlParameter B_TITLE = new SqlParameter("@b_title", SqlDbType.VarChar, 50);
                    SqlParameter CATEGORY = new SqlParameter("@category", SqlDbType.VarChar, 50);
                    SqlParameter AUTHOR = new SqlParameter("@author", SqlDbType.VarChar, 50);
                    SqlParameter PUBLICATION = new SqlParameter("@publication", SqlDbType.VarChar, 50);
                    SqlParameter PUB_DATE = new SqlParameter("@pub_date", SqlDbType.VarChar,4);
                    SqlParameter PRICE = new SqlParameter("@price", SqlDbType.Int);
                    SqlParameter ONLINE_LOC = new SqlParameter("@online_loc", SqlDbType.VarChar, 500);
                    B_NAME.Value = textBox6.Text;
                    B_TITLE.Value = textBox7.Text;
                    CATEGORY.Value = textBox8.Text;
                    AUTHOR.Value = textBox9.Text;
                    PUBLICATION.Value = textBox10.Text;
                    PUB_DATE.Value = textBox11.Text;
                    PRICE.Value = textBox12.Text;
                    string cmd;
                    if (textBox13.Text == "")
                    {
                        
                        cmd = "INSERT INTO dbo.Storage_Panel VALUES ( @b_name, @b_title, @category, @author, @publication, @pub_date, @price ," + comboBox2.Text + ", null )";
                    }
                    else
                    {
                        ONLINE_LOC.Value = textBox13;
                        cmd = "INSERT INTO dbo.Storage_Panel VALUES ( @b_name, @b_title, @category, @author, @publication, @pub_date, @price ," + comboBox2.Text + ", @online_loc )";
                    }
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(B_NAME);
                    mycmd.Parameters.Add(B_TITLE);
                    mycmd.Parameters.Add(CATEGORY);
                    mycmd.Parameters.Add(AUTHOR);
                    mycmd.Parameters.Add(PUBLICATION);
                    mycmd.Parameters.Add(PUB_DATE);
                    mycmd.Parameters.Add(PRICE);
                    if (textBox13.Text != "")
                    {
                        mycmd.Parameters.Add(ONLINE_LOC);
                    }
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();
                    MessageBox.Show("Book Entered Successfully", "Successful", MessageBoxButtons.OK);
                }
            }
            catch (Exception Upexcep)
            {
                MessageBox.Show(Upexcep.ToString());
            }
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                
                // Storage Panel Query...//
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select * from Storage_Panel Order by B_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();


                //Selection Query for Supplier//
                MyConnection.Open();
                cmd = "Select SUP_ID from dbo.Supplier";
                mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["SUP_ID"]);
                    comboBox2.Items.Add(reader["SUP_ID"]);
                }
                reader.Dispose();
                mycmd.Dispose();


            }
            catch (Exception RetExcep)
            {
                MessageBox.Show(RetExcep.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.Text != "")
                {
                    SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                    MyConnection.Open();
                    string cmd = "Select * from dbo.Supplier where SUP_ID="+comboBox1.Text;
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    SqlDataReader reader = null;
                    reader = mycmd.ExecuteReader();
                    while (reader.Read())
                    {
                        label11.Text = reader["NAME"].ToString();
                        label12.Text = reader["ADDRESS"].ToString();
                        label13.Text = reader["CONTACT"].ToString();
                        label14.Text = reader["EMAIL"].ToString();
                        label15.Text = reader["WEB"].ToString();
                    }
                    reader.Dispose();
                    mycmd.Dispose();
                }
            }
            catch(Exception comboexcep)
            {
                MessageBox.Show(comboexcep.ToString());
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
