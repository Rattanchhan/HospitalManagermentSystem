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

namespace Final_Project
{
    public partial class Form1 : Form
    {
        private string day = DateTime.Now.Day.ToString();
        private string month = DateTime.Now.Month.ToString();
        private readonly string year = DateTime.Now.Year.ToString();
        private static SqlConnection connection;
        private static SqlCommand command;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = ValidateDateTime();
            DashBoardView(LabelDoctor,"SELECT COUNT(*) FROM [dbo].[Doctor]");
            DashBoardView(LabelRoom, "SELECT COUNT(*) FROM [dbo].[Room]");
            DashBoardView(LabelPatient, "SELECT COUNT(*) FROM [dbo].[Patient]");
            DashBoardView(LabelLabReport, "SELECT COUNT(*) FROM [dbo].[LabReport]");
            DashBoardView(LabelInPatient, "SELECT COUNT(*) FROM [dbo].[InPatient]");
            DashBoardView(LabelOutPatient, "SELECT COUNT(*) FROM [dbo].[OutPatient]");
            DashBoardView(LabelInPatientBill, "SELECT COUNT(*) FROM [dbo].[InPatientBill]");
            DashBoardView(LabelOutPatientBill, "SELECT COUNT(*) FROM [dbo].[OutPatientBill]");
            ValidateDateTime();
        }

        private void DashBoardView(Label label,string query)
        {
            connection = Class.Connection.SqlConnection();
            connection.Open();
            command = new SqlCommand(query, connection);
            label.Text = command.ExecuteScalar().ToString();
        }

        private string ValidateDateTime()
        {
            if (DateTime.Now.Day < 10)
            {
                if (DateTime.Now.Month < 10)
                {
                    day = "-0" + DateTime.Now.Day.ToString();
                    month = "-0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    day = "-0" + DateTime.Now.Day.ToString();
                    month = "-" + DateTime.Now.Month.ToString();
                }
            }
            else
            {
                if (DateTime.Now.Month < 10)
                {
                    month = "-0" + DateTime.Now.Month.ToString() + "-";
                }
            }
            return year + month + day;
        }

        private void DoctorMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.DoctorMainForm().Show();
        }

        private void PatientMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.PatientForm().Show();
        }

        private void LapReportMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.LabReportForm().Show();
        }

        private void RoomMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.RoomForm().Show();
        }

        private void OutPatientMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.OutPatientForm().Show();
        }

        private void InPatientMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.InPatientForm().Show();
        }

        private void InPatientBillMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.InPatientBillForm().Show();
        }

        private void OutPatientBillMainForm_Click(object sender, EventArgs e)
        {
            Hide();
            new main.OutPatientBillForm().Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            new loginPage.LoginForm().Show();
        }
    }
}
