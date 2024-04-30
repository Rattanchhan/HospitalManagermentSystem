using FinalProject_Hospital_.ResponsiveForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FinalProject_Hospital_.FormAdd
{

    public partial class Doctor : Form
    {
        private static string connectionString = "Data Source=DESKTOP-7ODK8A5\\SQLEXPRESS;Initial Catalog=HospitalVersion2;Integrated Security=SSPI;Connection Timeout=30";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        private static string query;
        private ResponsiveForm.MessagePopUp  addMessagePopUp;
        public Panel panel;
        private DoctorInfo doctorInfo;
        public Form form;
        public ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        public Doctor(DoctorInfo doctorInfo, Form form)
        {
            this.doctorInfo = doctorInfo;
            this.form = form;
            InitializeComponent();
        }
        public void PanelChange(string status)
        {
            panel = panel2;
            if (status == "ok")
            {
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
            
        }
        private void CloseButtonMouseClick(object sender, MouseEventArgs e) {
            OpenForm(sender,e);
           
        }
        private void OpenForm(object sender,MouseEventArgs e) 
        {
            dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);
            Close();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            CheckObjectDoctorInfo();
            StartPosition = FormStartPosition.CenterParent;
        }
        private void CheckObjectDoctorInfo() { 
            if(doctorInfo!=null)
            {
                DoctorIDTextBox.Text = doctorInfo.GetDoctorId().ToString();
                DoctorNameTextBox.Text= doctorInfo.GetDoctorName().ToString();
                DepartmentTextBox.Text = doctorInfo.GetDeparemnt().ToString();
                AddressTextBox.Text = doctorInfo.GetAddress().ToString();
                ContactNumberTextBox.Text = doctorInfo.GetContactNumber().ToString();

                ComponentChange();
                GenerateEvent();
            }
        }
        private void GenerateEvent()
        {
            AddButton.MouseClick -=AddClick;
            AddButton.MouseClick += SaveClick;
            ResetButton.MouseClick -= ResetClick;
            ResetButton.MouseClick += CancelClick;
        }

        private void CancelClick(object sender, MouseEventArgs e)
        {
            
        }

        private void SaveClick(object sender, MouseEventArgs e)
        {
            UpdateData();
            PanelChange(string.Empty);
            addMessagePopUp = new ResponsiveForm.MessagePopUp(form, "Edit Successfully");
            addMessagePopUp.Show();
        }
        private void UpdateData()
        {
            try
            {
                query = "UPDATE [dbo].[Doctor] SET DoctorName=@DoctorName,Department=@Department,Address=@Address,ContactNumber=@ContactNumber WHERE DoctorId=@DoctorID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                ExecutQuery(sqlCommand);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void ComponentChange()
        {
            DoctorIDTextBox.ReadOnly = true;
            DoctorNameTextBox.TabIndex = panel10.TabIndex = 20;
            DoctorIDTextBox.ForeColor = Color.Gray;
            panel10.BackColor = DoctorIDTextBox.BackColor = Color.LightGray;

            ResetButton.Text = "Cancel";
            AddButton.Text = "Save";
        }
        private void TextBoxReset()
        {
            DoctorIDTextBox.Text = string.Empty;
            DoctorNameTextBox.Text = string.Empty;
            DepartmentTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            ContactNumberTextBox.Text = string.Empty;
        }
        private void ResetClick(object sender, MouseEventArgs e)
        {
            TextBoxReset();
        }

        private void AddClick(object sender,MouseEventArgs e)
        {
            AddData();
            /*TextBoxReset();*/
            PanelChange(string.Empty);
            addMessagePopUp = new ResponsiveForm.MessagePopUp(form, "New Record Added Successfully");
            addMessagePopUp.Show();
        }
        private void ExecutQuery(SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@DoctorID", int.Parse(DoctorIDTextBox.Text.ToString()));
            sqlCommand.Parameters.AddWithValue("@DoctorName", DoctorNameTextBox.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@Department", DepartmentTextBox.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@Address", AddressTextBox.Text.ToString());
            sqlCommand.Parameters.AddWithValue("@ContactNumber", ContactNumberTextBox.Text.ToString());
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        private void AddData()
        {
            try
            {
                query = "Insert into [dbo].[Doctor] values(@DoctorID,@DoctorName,@Department,@Address,@ContactNumber)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                ExecutQuery(sqlCommand);
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
