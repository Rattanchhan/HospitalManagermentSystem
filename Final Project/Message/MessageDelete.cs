using Final_Project.Class;
using System;
using System.Collections;
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

namespace Final_Project.Message
{
    public partial class MessageDelete : Form
    {
        private string table;
        private int id;
        private Class.Check check=new Class.Check();
        private SqlConnection connection;
        private string query;
        private SqlCommand command;

        public MessageDelete(string table,int id)
        {
            this.table= table;
            this.id = id;
            InitializeComponent();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            if (table == "inPatient")
            {
                query = "Delete from [dbo].[InPatient] Where Pid=@id";
                deleteRecord();
                RepeateForm();
            }
            else if (table == "outPatient")
            {
                query = "Delete from [dbo].[OutPatient] Where Pid=@id";
                deleteRecord();
                RepeateForm();
            }
            else if (table == "doctor")
            {
                query = "Delete from [dbo].[Doctor] Where DoctorId=@id";
                deleteRecord();
                RepeateForm();
            }
            else if(table == "patient")
            {
                query = "Delete from [dbo].[Patient] Where Pid=@id";
                deleteRecord();
                RepeateForm();
            }
        }

        private void MessageDelete_Load(object sender, EventArgs e)
        {
            IdLabel.Text="(ID: "+id.ToString()+").";
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            RepeateForm();
        }
        private void RepeateForm()
        {
            if (table == "inPatient")
            {
                Hide();
                check.OpenForm(new main.InPatientForm());
            }
            else if (table == "outPatient")
            {
                Hide();
                check.OpenForm(new main.OutPatientForm());
            }
            else if (table == "doctor")
            {
                Hide();
                check.OpenForm(new main.DoctorMainForm());
            }
            else if (table == "patient")
            {
                Hide();
                check.OpenForm(new main.PatientForm());
            }
        }
        private void deleteRecord()
        {
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
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
