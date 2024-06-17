using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.main
{
    public partial class LabReportForm : Form
    {
        private Class.SearchInfo searchInfo = new Class.SearchInfo();
        private static SqlDataReader reader;
        private string query;
        private static SqlConnection connection;
        private static SqlCommand command;
        private Class.Check _check = new Class.Check();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
        public LabReportForm()
        {
            InitializeComponent();
        }

        private void LabReportForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllID("DoctorId","[dbo].[Doctor]", ComboBoxDoctorID);
            GetAllID("Pid", "[dbo].[Patient]", ComboBoxPatientID);
            GetAllLabReport("[dbo].[LabReport]");

        }
        private void GetAllID(string columnName,string tableName,ComboBox comboBox)
        {
            query = "Select "+ columnName+" From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                comboBox.Items.Add(reader[0].ToString());
            }
        }
        private void SetFormSize()
        {
            this.Width = 925;
            this.Height = 680;
        }
        private void UpdateButton_Click(object sender, MouseEventArgs e)
        {
            SetTextBox();
            ResetButton.Enabled = false;
            AddButton.Enabled = false;
            UpdateButton.Text = "Save";
            UpdateButton.MouseClick -= UpdateButton_Click;
            UpdateButton.MouseClick += SaveButton_Click;
        }

        private void GetAllLabReport(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                     reader[4].ToString(), reader[5].ToString());
            }
        }
        private void CreateColumn()
        {
            column1.Name = "LabNo";
            column2.Name = "PatientID";
            column3.Name = "DoctorID";
            column4.Name = "Description";
            column5.Name = "Date";
            column6.Name = "Amount";


            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle = column5.DefaultCellStyle =
            column6.DefaultCellStyle  = column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            TextBoxLabNo.Text = string.Empty;
            ComboBoxPatientID.Text = "Select";
            ComboBoxDoctorID.Text = "Select";
            TextBoxDescription.Text = string.Empty;
            TextBoxAmount.Text = string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[LabReport] values(@LabNo,@Pid,@DoctoriID,@Description,@Date,@Amount)";
            AddLabReport();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("labReport"));

        }
        private void AddLabReport()
        {
            try
            {
                connection = Class.Connection.SqlConnection();
                ExecutQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void ExecutQuery()
        {
            connection.Open();
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LabNo", int.Parse(TextBoxLabNo.Text));
            command.Parameters.AddWithValue("@Pid", int.Parse(ComboBoxPatientID.Text));
            command.Parameters.AddWithValue("@DoctoriID", int.Parse(ComboBoxDoctorID.Text));
            command.Parameters.AddWithValue("@Description", TextBoxDescription.Text);
            command.Parameters.AddWithValue("@Date", dateTimePicker.Text);
            command.Parameters.AddWithValue("@Amount", int.Parse(TextBoxAmount.Text));

            command.ExecuteNonQuery();
            connection.Close();
        }

        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[LabReport] set Pid=@Pid,DoctoriId=@DoctoriId" +
                ",Description=@Description,Date=@Date,Amount=@Amount WHERE LabNo=@LabNo";
            LabReportUpdate();
        }

        private void LabReportUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("labReport");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddLabReport();
            Hide();
            this._check.OpenForm(messagePopUp);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int id;
            dataGridView.Columns.Clear();
            CreateColumn();
            if (int.TryParse(TextBoxSearch.Text, out id))
            {
                query = "SELECT* FROM [dbo].[LabReport] WHERE LabNo=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[LabReport] WHERE Category LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    reader[4].ToString(), reader[5].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            TextBoxLabNo.Text = dataGridView.CurrentRow.Cells["LabNo"].Value.ToString();
            ComboBoxPatientID.Text = dataGridView.CurrentRow.Cells["PatientID"].Value.ToString();
            ComboBoxDoctorID.Text = dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString();
            TextBoxDescription.Text = dataGridView.CurrentRow.Cells["Description"].Value.ToString();
            dateTimePicker.Text = dataGridView.CurrentRow.Cells["Date"].Value.ToString();
            TextBoxAmount.Text = double.Parse(dataGridView.CurrentRow.Cells["Amount"].Value.ToString()).ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllLabReport("[dbo].[LabReport]");
        }

        private void LabReportForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            new Report.ReportList("LabReport").Show();
        }
    }
}
