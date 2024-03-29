using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class DoctorDetailForm : Form
    {
        public DoctorDetailForm()
        {
            InitializeComponent();
        }

        private void DoctorDetailForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;";
            SqlDataAdapter dataAdapter;
                try
                {
                    dataAdapter = new SqlDataAdapter("Select DoctorID,DoctorFirstName,DoctorLastName,DoctorPhoneNumber From [dbo].[Doctor]",connectionString);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    dataGrid.Columns[0].DataPropertyName = "DoctorID";
                    dataGrid.Columns[1].DataPropertyName = "DoctorFirstName";
                    dataGrid.Columns[2].DataPropertyName = "DoctorLastName";
                    dataGrid.Columns[3].DataPropertyName = "DoctorPhoneNumber";
                    dataGrid.DataSource = table;
                    dataGrid.AllowUserToAddRows = false;
                }
                catch (SqlException)
                {
                    MessageBox.Show("To run this example, replace the value of the " +
                        "connectionString variable with a connection string that is " +
                        "valid for your system.");
                }

        }
    }
}
