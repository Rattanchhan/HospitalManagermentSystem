using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Class
{
    public class SearchInfo
    {
        private static SqlConnection sqlConnection;
        private static SqlCommand sqlCommand;
        private static SqlDataReader dataReader;
        public SqlConnection GetSqlConnection()
        {
             return sqlConnection;
        }
        public SqlDataReader DataReader<T> (string query,string type,T key)
        {
            try
            {
                sqlConnection = Class.Connection.SqlConnection();
                sqlCommand = new SqlCommand(query, sqlConnection);
                    if (type=="int")
                    {
                        sqlCommand.Parameters.AddWithValue("@id",key);
                    }
                    else if (type=="string")
                    {
                        sqlCommand.Parameters.AddWithValue("@name",string.Format("%"+key+"%"));
                    }
                    else {
                        if (key.ToString()!="")
                        {
                        sqlCommand.Parameters.AddWithValue("@name", string.Format(key.ToString()));
                        }
                    }

                sqlConnection.Open();
                dataReader = sqlCommand.ExecuteReader();
                return dataReader;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            return dataReader;
        }
    }
}
