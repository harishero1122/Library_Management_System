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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Member");
            if (Form1.Reg_But != 1)
            {
                comboBox1.Items.Add("Teacher");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Register reg = new Register();
            if (comboBox1.SelectedIndex == 0)
            {
                label9.Show(); textBox9.Show();
                label10.Show(); textBox10.Show();
                label11.Show(); textBox11.Show();
                label12.Show(); textBox12.Show();
                label9.Text = "Roll No";
                label10.Text = "Batch";
                label11.Text = "Section";
                label12.Text = "Discipline";

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label9.Hide(); textBox9.Hide();
                label10.Hide(); textBox10.Hide();
                label11.Hide(); textBox11.Hide();
                label12.Hide(); textBox12.Hide();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label9.Show(); textBox9.Show();
                label10.Show(); textBox10.Show();
                label11.Show(); textBox11.Show();
                label9.Text = "Dept No";
                label10.Text = "Designation";
                label11.Text = "Course Details";
                label12.Hide(); textBox12.Hide();
            }
        }
        public static int U_ID;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                if (comboBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Enter First Name", "Error");
                    }
                    else if (textBox2.Text == "")
                    {
                        MessageBox.Show("Enter Middle Name", "Error");
                    }
                    else if (textBox3.Text == "")
                    {
                        MessageBox.Show("Enter Last Name", "Error");
                    }
                    else if (textBox4.Text == "")
                    {
                        MessageBox.Show("Enter Email Address", "Error");
                    }
                    else if (textBox5.Text == "")
                    {
                        MessageBox.Show("Enter Username", "Error");
                    }
                    else if (textBox6.Text == "")
                    {
                        MessageBox.Show("Enter Password", "Error");
                    }
                    else if (textBox7.Text == "")
                    {
                        MessageBox.Show("Enter Address", "Error");
                    }
                    else if (textBox8.Text == "")
                    {
                        MessageBox.Show("Enter NIC Identity", "Error");
                    }
                    else if (textBox9.Text == "")
                    {
                        MessageBox.Show("Enter Roll", "Error");
                    }
                    else if (textBox10.Text == "")
                    {
                        MessageBox.Show("Enter Batch", "Error");
                    }
                    else if (textBox11.Text == "")
                    {
                        MessageBox.Show("Enter Section", "Error");
                    }
                    else if (textBox12.Text == "")
                    {
                        MessageBox.Show("Enter Discipline", "Error");
                    }
                    else
                    {
                        MyConnection.Open();
                        // Insertion Query to Users table// Main
                        SqlParameter F_NAME = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
                        SqlParameter M_NAME = new SqlParameter("@middlename", SqlDbType.VarChar, 50);
                        SqlParameter L_NAME = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
                        SqlParameter EMAIL = new SqlParameter("@email", SqlDbType.VarChar, 50);
                        SqlParameter USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                        SqlParameter PASSWORD = new SqlParameter("@password", SqlDbType.VarChar, 50);
                        SqlParameter ADDRESS = new SqlParameter("@address", SqlDbType.VarChar, 250);
                        SqlParameter NIC = new SqlParameter("@nic", SqlDbType.VarChar, 13);
                        F_NAME.Value = textBox1.Text;
                        M_NAME.Value = textBox2.Text;
                        L_NAME.Value = textBox3.Text;
                        EMAIL.Value = textBox4.Text;
                        USERNAME.Value = textBox5.Text;
                        PASSWORD.Value = textBox6.Text;
                        ADDRESS.Value = textBox7.Text;
                        NIC.Value = textBox8.Text;

                        string cmd = "INSERT INTO dbo.Users VALUES ( @firstname, @middlename, @lastname, @email, @username, @password, @address , @nic )";
                        SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                        mycmd.Parameters.Add(F_NAME);
                        mycmd.Parameters.Add(M_NAME);
                        mycmd.Parameters.Add(L_NAME);
                        mycmd.Parameters.Add(EMAIL);
                        mycmd.Parameters.Add(USERNAME);
                        mycmd.Parameters.Add(PASSWORD);
                        mycmd.Parameters.Add(ADDRESS);
                        mycmd.Parameters.Add(NIC);

                        mycmd.ExecuteNonQuery();
                        mycmd.Dispose();



                        // Selection Query of U_ID From USers table
                        USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                        USERNAME.Value = textBox5.Text;
                        cmd = "Select U_ID from dbo.Users where USERNAME = @username";
                        mycmd = new SqlCommand(cmd, MyConnection);
                        mycmd.Parameters.Add(USERNAME);
                        SqlDataReader reader = null;
                        reader = mycmd.ExecuteReader();
                        while (reader.Read())
                        {
                            U_ID = Convert.ToInt32(reader["U_ID"]);
                        }
                        reader.Dispose();
                        mycmd.Dispose();




                        // Insertion Query for Student table Using U_ID
                        SqlParameter u_id = new SqlParameter("@u_id", SqlDbType.Int);
                        SqlParameter ROLLNO = new SqlParameter("@rollno", SqlDbType.Int);
                        SqlParameter BATCH = new SqlParameter("@batch", SqlDbType.Int);
                        SqlParameter SECTION = new SqlParameter("@section", SqlDbType.VarChar, 2);
                        SqlParameter DISCIPLINE = new SqlParameter("@discipline", SqlDbType.VarChar, 50);
                        ROLLNO.Value = Convert.ToInt32(textBox9.Text);
                        BATCH.Value = Convert.ToInt32(textBox10.Text);
                        SECTION.Value = textBox11.Text;
                        DISCIPLINE.Value = textBox12.Text;
                        u_id.Value = Convert.ToInt32(U_ID);
                        cmd = "INSERT INTO dbo.Student VALUES ( @u_id, @rollno, @batch, @section, @discipline )";
                        mycmd = new SqlCommand(cmd, MyConnection);
                        mycmd.Parameters.Add(u_id);
                        mycmd.Parameters.Add(ROLLNO);
                        mycmd.Parameters.Add(BATCH);
                        mycmd.Parameters.Add(SECTION);
                        mycmd.Parameters.Add(DISCIPLINE);

                        mycmd.ExecuteNonQuery();
                        mycmd.Dispose();


                        // Insertion Query to Administrator table Giving Access Rights to U_ID
                        SqlParameter A_RIGHTS = new SqlParameter("@a_rights", SqlDbType.Int);
                        A_RIGHTS.Value = Convert.ToInt32("0");
                        u_id = new SqlParameter("@u_id", SqlDbType.Int);
                        u_id.Value = Convert.ToInt32(U_ID);

                        cmd = "INSERT INTO dbo.Administrator VALUES ( @u_id, @a_rights )";
                        mycmd = new SqlCommand(cmd, MyConnection);
                        mycmd.Parameters.Add(u_id);
                        mycmd.Parameters.Add(A_RIGHTS);

                        mycmd.ExecuteNonQuery();
                        mycmd.Dispose();
                        MyConnection.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                        textBox12.Clear();
                        MessageBox.Show("Registration Successful", "Successful", MessageBoxButtons.OK);
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    MyConnection.Open();
                    // Insertion Query to Users table// Main
                    SqlParameter F_NAME = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
                    SqlParameter M_NAME = new SqlParameter("@middlename", SqlDbType.VarChar, 50);
                    SqlParameter L_NAME = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
                    SqlParameter EMAIL = new SqlParameter("@email", SqlDbType.VarChar, 50);
                    SqlParameter USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    SqlParameter PASSWORD = new SqlParameter("@password", SqlDbType.VarChar, 50);
                    SqlParameter ADDRESS = new SqlParameter("@address", SqlDbType.VarChar, 250);
                    SqlParameter NIC = new SqlParameter("@nic", SqlDbType.VarChar, 13);
                    F_NAME.Value = textBox1.Text;
                    M_NAME.Value = textBox2.Text;
                    L_NAME.Value = textBox3.Text;
                    EMAIL.Value = textBox4.Text;
                    USERNAME.Value = textBox5.Text;
                    PASSWORD.Value = textBox6.Text;
                    ADDRESS.Value = textBox7.Text;
                    NIC.Value = textBox8.Text;

                    string cmd = "INSERT INTO dbo.Users VALUES ( @firstname, @middlename, @lastname, @email, @username, @password, @address , @nic )";
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(F_NAME);
                    mycmd.Parameters.Add(M_NAME);
                    mycmd.Parameters.Add(L_NAME);
                    mycmd.Parameters.Add(EMAIL);
                    mycmd.Parameters.Add(USERNAME);
                    mycmd.Parameters.Add(PASSWORD);
                    mycmd.Parameters.Add(ADDRESS);
                    mycmd.Parameters.Add(NIC);

                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();



                    // Selection Query of U_ID From USers Table
                    USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    USERNAME.Value = textBox5.Text;
                    cmd = "Select U_ID from dbo.Users where USERNAME = @username";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(USERNAME);
                    SqlDataReader reader = null;
                    reader = mycmd.ExecuteReader();
                    while (reader.Read())
                    {
                        U_ID = Convert.ToInt32(reader["U_ID"]);
                    }
                    reader.Dispose();
                    mycmd.Dispose();



                    // Insertion Query for Member Table Using U_ID
                    SqlParameter u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    DateTime datenow = DateTime.Now;
                   
                    u_id.Value = Convert.ToInt32(U_ID);
                    cmd = "INSERT INTO Member (U_ID,REG_DATE,EXP_DATE,NO_BOOKS_ISSUED) VALUES (@u_id, @reg_date, @exp_date, @no_books_issued)";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(u_id);
                    mycmd.Parameters.AddWithValue("@reg_date", datenow);
                    mycmd.Parameters.AddWithValue("@exp_date", datenow.AddYears(2));
                    mycmd.Parameters.AddWithValue("@no_books_issued", 0);
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();



                    // Insertion Query to Administrator table Giving Access Rights to U_ID
                    SqlParameter A_RIGHTS = new SqlParameter("@a_rights", SqlDbType.Int);
                    A_RIGHTS.Value = Convert.ToInt32("0");
                    u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    u_id.Value = Convert.ToInt32(U_ID);

                    cmd = "INSERT INTO dbo.Administrator VALUES ( @u_id, @a_rights )";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(u_id);
                    mycmd.Parameters.Add(A_RIGHTS);

                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();
                    MyConnection.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    MessageBox.Show("Registration Successful", "Successful", MessageBoxButtons.OK);

                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    MyConnection.Open();
                    // Insertion Query to Users table// Main
                    SqlParameter F_NAME = new SqlParameter("@firstname", SqlDbType.VarChar, 50);
                    SqlParameter M_NAME = new SqlParameter("@middlename", SqlDbType.VarChar, 50);
                    SqlParameter L_NAME = new SqlParameter("@lastname", SqlDbType.VarChar, 50);
                    SqlParameter EMAIL = new SqlParameter("@email", SqlDbType.VarChar, 50);
                    SqlParameter USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    SqlParameter PASSWORD = new SqlParameter("@password", SqlDbType.VarChar, 50);
                    SqlParameter ADDRESS = new SqlParameter("@address", SqlDbType.VarChar, 250);
                    SqlParameter NIC = new SqlParameter("@nic", SqlDbType.VarChar, 13);
                    F_NAME.Value = textBox1.Text;
                    M_NAME.Value = textBox2.Text;
                    L_NAME.Value = textBox3.Text;
                    EMAIL.Value = textBox4.Text;
                    USERNAME.Value = textBox5.Text;
                    PASSWORD.Value = textBox6.Text;
                    ADDRESS.Value = textBox7.Text;
                    NIC.Value = textBox8.Text;

                    string cmd = "INSERT INTO dbo.Users VALUES ( @firstname, @middlename, @lastname, @email, @username, @password, @address , @nic )";
                    SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(F_NAME);
                    mycmd.Parameters.Add(M_NAME);
                    mycmd.Parameters.Add(L_NAME);
                    mycmd.Parameters.Add(EMAIL);
                    mycmd.Parameters.Add(USERNAME);
                    mycmd.Parameters.Add(PASSWORD);
                    mycmd.Parameters.Add(ADDRESS);
                    mycmd.Parameters.Add(NIC);

                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();



                    // Selection Query of U_ID From USers Table
                    USERNAME = new SqlParameter("@username", SqlDbType.VarChar, 50);
                    USERNAME.Value = textBox5.Text;
                    cmd = "Select U_ID from dbo.Users where USERNAME = @username";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(USERNAME);
                    SqlDataReader reader = null;
                    reader = mycmd.ExecuteReader();
                    while (reader.Read())
                    {
                        U_ID = Convert.ToInt32(reader["U_ID"]);
                    }
                    reader.Dispose();
                    mycmd.Dispose();



                    // Insertion Query for Staff Table Using U_ID
                    SqlParameter u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    

                    u_id.Value = Convert.ToInt32(U_ID);
                    cmd = "INSERT INTO Staff (U_ID ,DEPT_NO, DESIGNATION) VALUES ( @u_id , "+textBox9.Text+" , '"+textBox10.Text+"' )";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(u_id);
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();



                    // Insertion Query to Administrator table Giving Access Rights to U_ID
                    SqlParameter A_RIGHTS = new SqlParameter("@a_rights", SqlDbType.Int);
                    A_RIGHTS.Value = Convert.ToInt32("2");
                    u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    u_id.Value = Convert.ToInt32(U_ID);

                    cmd = "INSERT INTO dbo.Administrator VALUES ( @u_id, @a_rights )";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(u_id);
                    mycmd.Parameters.Add(A_RIGHTS);

                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();


                    u_id = new SqlParameter("@u_id", SqlDbType.Int);
                    u_id.Value = Convert.ToInt32(U_ID);

                    cmd = "insert into Teacher (teacher.U_ID, teacher.COURSE_DES) values(@u_id, '"+textBox11.Text+"' )";
                    mycmd = new SqlCommand(cmd, MyConnection);
                    mycmd.Parameters.Add(u_id);
                    
                    mycmd.ExecuteNonQuery();
                    mycmd.Dispose();



                    MyConnection.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    MessageBox.Show("Registration Successful", "Successful", MessageBoxButtons.OK);

                }
            }
            catch (Exception Register_Excep)
            {
                {
                    MessageBox.Show(Register_Excep.ToString());
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form5 = new Form3();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
        }
    }
}

