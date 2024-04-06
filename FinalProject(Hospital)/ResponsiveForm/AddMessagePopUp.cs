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
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class AddMessagePopUp : Form
    {
        private string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;Connection Timeout=30";
        private FormAdd.Doctor doctor;
        public AddMessagePopUp(FormAdd.Doctor form)
        {
            doctor = form;
            InitializeComponent();
        }

        private void OkButtonClick(object sender, MouseEventArgs e)
        {
            AddData();
            doctor.PanelChange("ok");
            Hide();
        }
        private void AddData()
        {
            try
            {   

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlcommand = new SqlCommand("Insert into [dbo].[Doctor] values(@DoctorID,@DoctorFirstName,@DoctorLastName,@DoctorPhoneNumber", sqlConnection);
                /*sqlCommand.Parameters.AddWithValue("@DoctorID", );
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();*/
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
