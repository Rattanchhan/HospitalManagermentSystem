using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Class
{
    public class Connection
    {
        private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=database name;Integrated Security=SSPI;Connection Timeout=30";
        private static SqlConnection connection;

        public static SqlConnection SqlConnection()
        {
            connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
