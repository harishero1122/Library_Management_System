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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Users");
            comboBox1.Items.Add("Administrator");
            comboBox1.Items.Add("Dept");
            comboBox1.Items.Add("Issue_Master");
            comboBox1.Items.Add("Member");
            comboBox1.Items.Add("Staff");
            comboBox1.Items.Add("Storage_Panel");
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Supplier");
            comboBox1.Items.Add("Teacher");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Register();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();

                string cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Users' ";

                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Users' ";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Administrator' ";
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Dept' ";
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Issue_Master' ";
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Member' ";
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Staff' ";
                }
                else if (comboBox1.SelectedIndex == 6)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Storage_Panel' ";
                }
                else if (comboBox1.SelectedIndex == 7)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Student' ";
                }
                else if (comboBox1.SelectedIndex == 8)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Supplier' ";
                }
                else if (comboBox1.SelectedIndex == 9)
                {
                    comboBox2.Items.Clear(); comboBox3.Items.Clear();
                    cmd = "SELECT column_name FROM information_schema.columns WHERE table_name = 'Teacher' ";
                }
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["column_name"].ToString());
                    comboBox3.Items.Add(reader["column_name"].ToString());
                }
                MyConnection.Close();

            }
            catch (SqlException Form3_excep)
            {
                MessageBox.Show(Form3_excep.ToString());
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Select Table Name", "Error");
                }
                else if (comboBox2.Text == "")
                {
                    MessageBox.Show("Select Column Name", "Error");
                }
                else if ( textBox1.Text== "")
                {
                    MessageBox.Show("Enter Values to Change", "Error");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Select Column", "Error");
                }
                else if (comboBox3.Text == "")
                {
                    MessageBox.Show("Enter Where Statement Value", "Error");
                }
                else
                {

                    SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                    MyConnection.Open();
                    string cmd = "UPDATE " + comboBox1.Text + " set " + comboBox2.Text + " = '" + textBox1.Text + "' where " + comboBox3.Text + " = '" + textBox2.Text + "'";
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();
                    MyConnection.Close();
                }
            }
            catch (Exception Form3excep)
            {
                MessageBox.Show(Form3excep.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "select Users.U_ID,Users.F_NAME,Users.EMAIL,Users.PASSWORD," +
                "Users.NIC,users.ADDRESS," +
                "Student.STD_ID, Student.ROLL_NO," +
                "Student.BATCH, Student.SECTION, Student.DISCIPLINE" +
                " from Users inner join Student on users.U_ID = Student.U_ID Order by U_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();

            }
            catch (Exception SelectUser)
            {
                MessageBox.Show(SelectUser.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "select Users.U_ID, Users.F_NAME, Users.EMAIL,"+
                " Users.PASSWORD, Users.NIC, Users.ADDRESS, Staff.DEPT_NO, "+
                "Staff.DESIGNATION, Dept.DEPT_NAME from Users inner join Staff "+
                "on Users.U_ID = Staff.U_ID inner join Dept on Staff.DEPT_NO = DEPT.DEPT_NO "+
                "Order by U_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();

            }
            catch (Exception SelectStaff)
            {
                MessageBox.Show(SelectStaff.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "select Users.U_ID, Users.F_NAME, Users.EMAIL, Users.PASSWORD,"+
                " Users.NIC, users.ADDRESS, Member.MEM_ID, Member.REG_DATE, Member.EXP_DATE,"+
                " Member.NO_BOOKS_ISSUED from Users inner join Member  on users.U_ID = "+
                "Member.U_ID Order by U_ID ASC";
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataAdapter DAdap = new SqlDataAdapter(mycmd);
                DataTable DT = new DataTable();
                DAdap.Fill(DT);
                dataGridView1.DataSource = DT;
                MyConnection.Close();
                DAdap.Dispose();

            }
            catch (Exception SelectStaff)
            {
                MessageBox.Show(SelectStaff.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var supplier = new Supplier();
            supplier.Closed += (s, args) => this.Close();
            supplier.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}

