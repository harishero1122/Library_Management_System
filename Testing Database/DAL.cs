using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;

namespace $safeprojectname$
{
    public static class DAL
    {

        public static SqlConnection CreateConnection()
        {
            string connstring = "Data Source=SAAD-PC\\SQLEXPRESS;Integrated Security=True;Pooling=False;Connect Timeout=10;Database=Library_mgmt";

            SqlConnection cnn = new SqlConnection(connstring); 

            return cnn;
        }
    
    }
}
