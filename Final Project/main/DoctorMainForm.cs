using Final_Project.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Final_Project.main
{
    public partial class DoctorMainForm : Form
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static string query;
        private static SqlDataReader reader;
        private Class.SearchInfo searchInfo=new Class.SearchInfo();
        private Class.Check _check = new Class.Check();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();

        public DoctorMainForm()
        {
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllDoctor("[dbo].[Doctor]");
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

        private void GetAllDoctor(string tableName)
        {
            query = "Select * From "+tableName;
            reader = searchInfo.DataReader(query,null,"");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }
        }

        private void SetFormSize()
        {
            this.Width = 925;
            this.Height = 570;
        }
        private void CreateColumn()
        {
            column1.Name = "DoctorID";
            column2.Name = "DoctorName";
            column3.Name = "Department";
            column4.Name = "Address";
            column5.Name = "ContactNumber";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle = column5.DefaultCellStyle = column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            TextBoxDoctorID.Text = string.Empty;
            TextBoxDoctorName.Text = string.Empty;
            TextBoxDepartment.Text = string.Empty;
            TextBoxAddress.Text = string.Empty;
            TextBoxContactNumber.Text = string.Empty;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[Doctor] values(@DoctorId,@DoctorName,@Department,@Address,@ContactNumber)";
            AddDoctor();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("doctor"));

        }
        private void AddDoctor()
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
            command.Parameters.AddWithValue("@DoctorId", int.Parse(TextBoxDoctorID.Text));
            command.Parameters.AddWithValue("@DoctorName", TextBoxDoctorName.Text);
            command.Parameters.AddWithValue("@Department",TextBoxDepartment.Text);
            command.Parameters.AddWithValue("@Address", TextBoxAddress.Text);
            command.Parameters.AddWithValue("@ContactNumber",TextBoxContactNumber.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[Doctor] set DoctorName=@DoctorName,Department=@Department,Address=@Address,ContactNumber=@ContactNumber WHERE DoctorId=@DoctorId";
            DoctorUpdate();
        }

        private void DoctorUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("doctor");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddDoctor();
            Hide();
            this._check.OpenForm(messagePopUp);
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            int id;
            dataGridView.Columns.Clear();
            CreateColumn();
            if(int.TryParse(TextBoxSearch.Text, out id))
            {
                query = "SELECT* FROM [dbo].[Doctor] WHERE DoctorId=@id";
                reader = searchInfo.DataReader(query,"int",id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[Doctor] WHERE DoctorName LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }
            
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            TextBoxDoctorID.Text = dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString();
            TextBoxDoctorName.Text = dataGridView.CurrentRow.Cells["DoctorName"].Value.ToString();
            TextBoxDepartment.Text = dataGridView.CurrentRow.Cells["Department"].Value.ToString();
            TextBoxAddress.Text = dataGridView.CurrentRow.Cells["Address"].Value.ToString();
            TextBoxContactNumber.Text = dataGridView.CurrentRow.Cells["ContactNumber"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllDoctor("[dbo].[Doctor]");
        }

        private void DoctorForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("doctor",
            int.Parse(dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString())));
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            new Report.ReportList("Doctor").Show();
        }
    }
}
