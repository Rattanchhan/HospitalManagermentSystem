using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class dashboardPage : Form
    {
        public dashboardPage()
        {
            InitializeComponent();
        }

        private void dashboardPage_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;Connection Timeout=30";
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Doctor", connect);
            try {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
            }
            catch (SqlException sql)
            {
                if (connect.State != ConnectionState.Closed)
                    connect.Close();
                else
                {
                    connect.Open();
                }
            }
            label6.Text =((Int32)command.ExecuteScalar()).ToString();
        }
    }
}
