using Final_Project.DataSet;
using Microsoft.Reporting.WinForms;
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
using System.Windows.Forms.VisualStyles;

namespace Final_Project.Report
{
    public partial class ReportList : Form
    {
        private SqlConnection SqlConnection;
        private SqlDataAdapter SqlDataAdapter;
        private string query;
        private string text;
        private string stringPath = @"....";
        public ReportList(string text)
        {
            InitializeComponent();
            this.text = text;
        }

        private void DoctorReport_Load(object sender, EventArgs e)
        {
            Check();

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void Check()
        {
            reportViewer1.Reset();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer1.LocalReport;
            
            DataSet.DataSet report = new DataSet.DataSet();
            if (text == "Doctor")
            {
                localReport.ReportPath = stringPath + "\\DoctorReport.rdlc";
                query = "SELECT DoctorId, DoctorName, Department, Address, ContactNumber FROM Doctor";
                GetReport(report,"DoctorsReport");
            }
            else if  (text == "Patient") {
                localReport.ReportPath = stringPath + "\\PatientReport.rdlc";
                query = "SELECT Pid, FirstName, LastName, Gender, Age, Address, DoctorId, Disease FROM  Patient";
                GetReport(report, "PatientsReport");
            }
            else if (text == "LabReport")
            {
                localReport.ReportPath = stringPath+"\\LabReport.rdlc";
                query = "SELECT LabNo, Pid, DoctoriID, Description, Date, Amount FROM LabReport";
                GetReport(report, "LabsReport");
            }
            else if (text == "InPatientBill")
            {
                localReport.ReportPath = stringPath + "\\InPatientBillReport.rdlc";
                query = "SELECT BillNo, Pid, RoomCharge, LabCharge, Status, Total, DateOfAdmission, DateOfDischarge FROM InPatientBill";
                GetReport(report, "InPatientBillsReport");
            }
            else
            {
                localReport.ReportPath = stringPath + "\\OutPatientBillReport.rdlc";
                query = "SELECT BillNo, Pid, LabCharge, Total, Date, Status FROM OutPatientBill";
                GetReport(report, "OutPatientBillsReport");
            }
        }
        private void GetReport(DataSet.DataSet report,string reportDsName)
        {
            try
            {
                SqlConnection = Class.Connection.SqlConnection();
                SqlDataAdapter = new SqlDataAdapter(query, SqlConnection);
                DataTable dt = new DataTable();
                SqlDataAdapter.Fill(dt);

                ReportDataSource DataSet = new ReportDataSource(reportDsName,dt);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(DataSet);
                this.reportViewer1.RefreshReport();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
