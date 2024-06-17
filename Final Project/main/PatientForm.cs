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
using System.Windows.Input;

namespace Final_Project.main
{
    public partial class PatientForm : Form
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
        DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
        public PatientForm()
        {
            InitializeComponent();
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllDoctorID("[dbo].[Doctor]");
            GetAllPatient("[dbo].[Patient]");

        }
        private void GetAllDoctorID(string tableName)
        {
            query = "Select DoctorId From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                ComboBoxDoctorID.Items.Add(reader[0].ToString());
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

        private void GetAllPatient(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                     reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
            }
        }
        private void CreateColumn()
        {
            column1.Name = "PatientID";
            column2.Name = "FirstName";
            column3.Name = "LastName";
            column4.Name = "Gender";
            column5.Name = "Age";
            column6.Name = "Address";
            column7.Name = "DoctorID";
            column8.Name = "Disease";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle = column5.DefaultCellStyle =
            column6.DefaultCellStyle = column7.DefaultCellStyle = column8.DefaultCellStyle = column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.Columns.Add(column7);
            dataGridView.Columns.Add(column8);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            TextBoxPatientID.Text = string.Empty;
            TextBoxFirstName.Text = string.Empty;
            TextBoxLastName.Text = string.Empty;
            ComboBoxGender.Text = "Select";
            TextBoxAge.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            ComboBoxDoctorID.Text = "Select";
            TextBoxDisease.Text = string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[Patient] values(@Pid,@FirstName,@LastName,@Gender,@Age,@Address,@DoctorId,@Disease)";
            AddPatient();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("patient"));

        }
        private void AddPatient()
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
            command.Parameters.AddWithValue("@Pid", int.Parse(TextBoxPatientID.Text));
            command.Parameters.AddWithValue("@FirstName", TextBoxFirstName.Text);
            command.Parameters.AddWithValue("@LastName", TextBoxLastName.Text);
            command.Parameters.AddWithValue("@Gender", ComboBoxGender.Text);
            command.Parameters.AddWithValue("@Age", TextBoxAge.Text);
            command.Parameters.AddWithValue("@Address", TextBoxAddress.Text);
            command.Parameters.AddWithValue("@DoctorId",int.Parse(ComboBoxDoctorID.Text));
            command.Parameters.AddWithValue("@Disease", TextBoxDisease.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[Patient] set FirstName=@FirstName,LastName=@LastName,Gender=@Gender" +
                ",Age=@Age,Address=@Address,DoctorId=@DoctorId,Disease=@Disease WHERE Pid=@Pid";
            PatientUpdate();
        }

        private void PatientUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("patient");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddPatient();
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
                query = "SELECT* FROM [dbo].[Patient] WHERE Pid=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[Patient] WHERE FirstName LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                    reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            TextBoxPatientID.Text = dataGridView.CurrentRow.Cells["PatientID"].Value.ToString();
            TextBoxFirstName.Text = dataGridView.CurrentRow.Cells["FirstName"].Value.ToString();
            TextBoxLastName.Text = dataGridView.CurrentRow.Cells["LastName"].Value.ToString();
            ComboBoxGender.Text = dataGridView.CurrentRow.Cells["Gender"].Value.ToString();
            TextBoxAge.Text = dataGridView.CurrentRow.Cells["Age"].Value.ToString();
            TextBoxAddress.Text = dataGridView.CurrentRow.Cells["Address"].Value.ToString();
            ComboBoxDoctorID.Text = dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString();
            TextBoxDisease.Text = dataGridView.CurrentRow.Cells["Disease"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllPatient("[dbo].[Patient]");
        }

        private void PatientForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("patient",
            int.Parse(dataGridView.CurrentRow.Cells["PatientID"].Value.ToString())));
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            new Report.ReportList("Patient").Show();
        }
    }
}
