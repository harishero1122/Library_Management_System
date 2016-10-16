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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {

                // Storage Panel Query...//
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select B_ID, B_NAME, B_TITLE, CATEGORY, AUTHOR, PUBLICATION, PUB_DATE from Storage_Panel Order by B_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();
                DT.Dispose();


                // Issue_Master Query...//
                MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                cmd = "Select Issue_Master.U_ID,Issue_Master.B_ID, Storage_Panel.B_NAME, Storage_Panel.CATEGORY, Storage_Panel.ONLINE_LOCATION, Issue_Master.ISSUE_DATE, Issue_Master.DUES  from Issue_Master inner join Storage_Panel on Issue_Master.U_ID = "+Form1.U_ID+" and Issue_Master.B_ID = Storage_Panel.B_ID  Order by B_ID ASC";
                mycmd = new SqlCommand(cmd, MyConnection);
                DAdap = new SqlDataAdapter(mycmd);
                DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView2.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();
                DT.Dispose();


                //Selection Query for Storage_Panel//
                
                MyConnection.Open();
                cmd = "Select B_ID,B_NAME from dbo.Storage_Panel";
                mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["B_NAME"]);
                }
                reader.Dispose();
                mycmd.Dispose();

            }
            catch (Exception RetExcep)
            {
                MessageBox.Show(RetExcep.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //selecting Book ID from Storage Panel
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select B_ID from dbo.Storage_Panel where B_NAME = '"+comboBox1.Text+"'";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                string B_ID="";
                while (reader.Read())
                {
                    B_ID = reader["B_ID"].ToString();
                }
                reader.Dispose();
                mycmd.Dispose();
                MyConnection.Close();
                // Starting Execution Of Insertion to Issue Master
                
                MyConnection.Open();
                // Insertion Query to Issue_Master table
                DateTime datenow = DateTime.Now;
                cmd = "INSERT INTO dbo.Issue_Master VALUES (" + Form1.U_ID + ", " + B_ID + " , @issue_date , 'Reserved', null)";
                mycmd = new SqlCommand(cmd, MyConnection);
                mycmd.Parameters.AddWithValue("@issue_date", datenow);
                mycmd.ExecuteNonQuery();
                mycmd.Dispose();
                MessageBox.Show("Book Issued Successfully", "Successful", MessageBoxButtons.OK);
                
            }
            catch (Exception suppexcep)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select Book First", "Error", MessageBoxButtons.OK);
                }
                MessageBox.Show(suppexcep.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                // Storage Panel Query...//
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select B_ID, B_NAME, B_TITLE, CATEGORY, AUTHOR, PUBLICATION, PUB_DATE from Storage_Panel Order by B_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();
                DT.Dispose();


                // Issue_Master Query...//
                MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                cmd = "Select Issue_Master.U_ID,Issue_Master.B_ID, Storage_Panel.B_NAME, Storage_Panel.CATEGORY, Storage_Panel.ONLINE_LOCATION, Issue_Master.ISSUE_DATE, Issue_Master.DUES  from Issue_Master inner join Storage_Panel on Issue_Master.U_ID = " + Form1.U_ID + " and Issue_Master.B_ID = Storage_Panel.B_ID  Order by B_ID ASC";
                mycmd = new SqlCommand(cmd, MyConnection);
                DAdap = new SqlDataAdapter(mycmd);
                DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView2.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();
                DT.Dispose();


                //Selection Query for Storage_Panel//

                MyConnection.Open();
                cmd = "Select B_ID,B_NAME from dbo.Storage_Panel";
                mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["B_NAME"]);
                }
                reader.Dispose();
                mycmd.Dispose();

            }
            catch (Exception RetExcep)
            {
                MessageBox.Show(RetExcep.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
