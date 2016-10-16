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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "select dbo.Users.F_NAME, dbo.Users.M_NAME, dbo.Users.L_NAME," +
                    " dbo.Staff.DEPT_NO, dbo.Staff.DESIGNATION, dbo.Teacher.COURSE_DES," +
                    " dbo.Dept.DEPT_NAME from Users inner join Staff on (select U_ID from " +
                    "Users where U_ID = 3) = Staff.U_ID inner join Teacher on staff.U_ID = " +
                    "Teacher.U_ID inner join Dept on Staff.DEPT_NO = Dept.DEPT_NO where " +
                    "Users.U_ID = " + Form1.U_ID + " and Teacher.U_ID = " + Form1.U_ID;
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    Designation.Text = reader["DESIGNATION"].ToString();
                    if (reader["M_NAME"].ToString() == "" || reader["M_NAME"].ToString() == null)
                    {
                        Teacher_Name.Text = reader["F_NAME"].ToString() + " " + reader["L_NAME"].ToString();
                    }
                    else
                    {
                        Teacher_Name.Text = reader["F_NAME"].ToString() + " " + reader["M_NAME"].ToString() + " " + reader["L_NAME"].ToString();
                    }
                    Dept_No.Text = reader["DEPT_NO"].ToString();
                    Dept_Name.Text = reader["DEPT_NAME"].ToString();
                    Course_Des.Text = reader["COURSE_DES"].ToString();
                }
                reader.Dispose();
                mycmd.Dispose();

                string u_id = "";
                cmd = "select dbo.Users.F_NAME, dbo.Users.M_NAME, dbo.Users.L_NAME, Users.U_ID, Users.USERNAME, Administrator.A_RIGHTS from Users inner join Administrator on Administrator.U_ID = Users.U_ID where Administrator.A_RIGHTS = 0";
                mycmd = new SqlCommand(cmd, MyConnection);
                reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    if (reader["M_NAME"].ToString() == "" || reader["M_NAME"].ToString() == null)
                    {
                        comboBox1.Items.Add(reader["F_NAME"].ToString() + " " + reader["L_NAME"].ToString());
                    }
                    else
                    {
                        comboBox1.Items.Add(reader["F_NAME"].ToString() + " " + reader["M_NAME"].ToString() + " " + reader["L_NAME"].ToString());
                    }
                     comboBox3.Items.Add(reader["U_ID"].ToString());
                }
                reader.Dispose();
                mycmd.Dispose();

                cmd = "Select B_NAME from Storage_Panel";
                mycmd = new SqlCommand(cmd, MyConnection);
                reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["B_NAME"].ToString());
                }
                MyConnection.Close();
                comboBox3.Hide();
            }
            catch (Exception Labels)
            {
                MessageBox.Show(Labels.ToString());
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Course_Des_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select B_ID from dbo.Storage_Panel where B_NAME = '" + comboBox2.Text + "'";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                string B_ID = "";
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
                cmd = "INSERT INTO dbo.Issue_Master VALUES (" + Convert.ToInt32(comboBox3.Text) + ", " + B_ID + " , @issue_date , 'Reserved', null)";
                mycmd = new SqlCommand(cmd, MyConnection);
                mycmd.Parameters.AddWithValue("@issue_date", datenow);
                mycmd.ExecuteNonQuery();
                mycmd.Dispose();
                MessageBox.Show("Book Issued Successfully", "Successful", MessageBoxButtons.OK);
                
            }
            catch (Exception suppexcep)
            {
                if (comboBox1.Text == "" || comboBox2.Text == "")
                {
                    MessageBox.Show("Please Select Book First", "Error", MessageBoxButtons.OK);
                }
                MessageBox.Show(suppexcep.ToString());

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                comboBox3.SelectedIndex = comboBox1.SelectedIndex;

                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "Select Student.ROLL_NO, Student.BATCH ,Issue_Master.B_ID, Storage_Panel.B_NAME,"+
                    " Storage_Panel.CATEGORY, Issue_Master.ISSUE_DATE from Issue_Master inner "+
                    "join Storage_Panel on Issue_Master.U_ID = " + comboBox3.Text + 
                    " and Issue_Master.B_ID = Storage_Panel.B_ID inner join Student on "+
                    "Student.U_ID = " + comboBox3.Text + " Order by B_NAME ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();
                DT.Dispose();
            }
            catch (Exception Exp)
            {
                MessageBox.Show(Exp.ToString());
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
