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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Dept_Name_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
                MyConnection.Open();
                string cmd = "select dbo.Users.F_NAME, dbo.users.M_NAME, dbo.Users.L_NAME, " +
                    "dbo.Users.EMAIL, dbo.users.NIC, dbo.Member.REG_DATE, dbo.Member.EXP_DATE, " +
                    "dbo.Member.NO_BOOKS_ISSUED from Users inner join Member on users.U_ID = " +
                    "Member.U_ID where users.U_ID = " + Form1.U_ID;
                SqlCommand mycmd = new SqlCommand(cmd, MyConnection);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["M_NAME"].ToString() == "" || reader["M_NAME"].ToString() == null)
                    {
                        Member_Name.Text = reader["F_NAME"].ToString() + " " + reader["L_NAME"].ToString();
                    }
                    else
                    {
                        Member_Name.Text = reader["F_NAME"].ToString() + " " + reader["M_NAME"].ToString() + " " + reader["L_NAME"].ToString();
                    }
                    Email.Text = reader["EMAIL"].ToString();
                    NIC.Text = reader["NIC"].ToString();
                    Registration_date.Text = reader["REG_DATE"].ToString();
                    EXP_date.Text = reader["EXP_DATE"].ToString();
                    Book_Issued.Text = reader["NO_BOOKS_ISSUED"].ToString();
                }
                reader.Dispose();
                mycmd.Dispose();
                MyConnection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString(), "ERROR");
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}
