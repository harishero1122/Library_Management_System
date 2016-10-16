using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public partial class Form1 : Form
    {
        public static string Conn_String = "Data Source=SAAD-PC\\SQLEXPRESS;Integrated Security=True;Pooling=False;Connect Timeout=10;Database=Library_mgmt";
        public Form1()
        {
            InitializeComponent();
        }
        public static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
        public static int U_ID; //For Further User Tracking
        public static int Reg_But = 0; //For Further Registration Form Tracking
        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection(Form1.Conn_String);
            try
            {
                MyConnection.Open();
                SqlParameter Username = new SqlParameter("@Username", SqlDbType.VarChar, 20);                
                SqlParameter Pass = new SqlParameter("@Pass", SqlDbType.VarChar, 50);
                Username.Value = textBox1.Text;
                Pass.Value = textBox2.Text;
                string cmd = "select Users.F_NAME, Users.U_ID, Users.USERNAME, Administrator.A_RIGHTS"+
                    " from Users inner join Administrator on Administrator.U_ID = Users.U_ID "+
                    "where USERNAME = @Username and PASSWORD = @Pass";                
                SqlCommand mycmd = new SqlCommand(cmd,MyConnection);
                mycmd.Parameters.Add(Username);
                mycmd.Parameters.Add(Pass);
                SqlDataReader reader = null;
                reader = mycmd.ExecuteReader();
                string User = "";
                int Admin_Rights = 0;
                while(reader.Read())
                {
                    User = reader["F_NAME"].ToString();
                    Admin_Rights = Convert.ToInt32(reader["A_RIGHTS"].ToString());
                    U_ID = Convert.ToInt32(reader["U_ID"]);

                }
                if (reader.HasRows)
                {

                    label3.Text = "Please Wait";
                    MyConnection.Close();
                    reader.Dispose();
                    mycmd.Dispose();
                    DialogResult res = MessageBox.Show("Welcome "+User,"Welcome",MessageBoxButtons.OK);
                    if (res == DialogResult.OK)
                    {
                       switch(Admin_Rights)
                       {
                           case 0:
                               {
                                   this.Hide();
                                    var form2 = new Form2();
                                    form2.Closed += (s, args) => this.Close();
                                    form2.Show();
                                   break;
                               }
                            case 1:
                               {
                                   this.Hide();
                                    var form3 = new Form3();
                                    form3.Closed += (s, args) => this.Close();
                                    form3.Show();
                                   break;
                               }
                            case 2:
                               {
                                   this.Hide();
                                    var form4 = new Form4();
                                    form4.Closed += (s, args) => this.Close();
                                    form4.Show();
                                   break;
                               }
                            case 3:
                               {
                                   this.Hide();
                                    var form5 = new Form5();
                                    form5.Closed += (s, args) => this.Close();
                                    form5.Show();
                                   break;
                               }
                       }
                    }

                }
                else
                {
                    label3.Text = "No User Found";
                    MyConnection.Close();
                    reader.Dispose();
                    mycmd.Dispose();
                }
            }
            catch(Exception a)
            {
                MessageBox.Show(a.ToString());

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form4();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reg_But = 1;
            this.Hide();
            var register = new Register();
            register.Closed += (s, args) => this.Close();
            register.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
