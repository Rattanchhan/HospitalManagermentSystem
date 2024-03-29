using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;";
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Doctor", connect);
            connect.Open();
            label6.Text =((Int32)command.ExecuteScalar()).ToString();
        }
    }
}
