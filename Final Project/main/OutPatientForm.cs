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

namespace Final_Project.main
{
    public partial class OutPatientForm : Form
    {
        private Class.SearchInfo searchInfo = new Class.SearchInfo();
        private static SqlDataReader reader;
        private string query;
        private static SqlConnection connection;
        private static SqlCommand command;
        private Class.Check _check = new Class.Check();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        public OutPatientForm()
        {
            InitializeComponent();
        }
        private void GetAllID(string columnName, string tableName, ComboBox comboBox, bool isTrue)
        {

            if (!isTrue)
            {
                query = "Select " + columnName + " From " + tableName + " Where Status = @name";
                reader = searchInfo.DataReader(query, null, "Available");
            }
            else
            {
                query = "Select " + columnName + " From " + tableName;
                reader = searchInfo.DataReader(query, null, "");
            }
            while (reader.Read())
            {
                comboBox.Items.Add(reader[0].ToString());
            }
        }
        private void SetFormSize()
        {
            this.Width = 925;
            this.Height = 520;
        }
        private void UpdateButton_Click(object sender, MouseEventArgs e)
        {
            SetTextBox();
            ResetButton.Enabled = false;
            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            UpdateButton.Text = "Save";
            UpdateButton.MouseClick -= UpdateButton_Click;
            UpdateButton.MouseClick += SaveButton_Click;
        }

        private void GetAllOutPatient(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
        }
        private void CreateColumn()
        {
            column1.Name = "_PatientID";
            column2.Name = "_RegisterDate";

            column1.HeaderText = "PatientID";
            column2.HeaderText = "RegisterDate";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle =
            column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            comboxPatientID.Text = "Select";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[OutPatient] values(@Pid,@RegisterDate)";
            AddOutPatient();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("outPatient"));

        }
        private void AddOutPatient()
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
            command.Parameters.AddWithValue("@Pid", int.Parse(comboxPatientID.Text));
            command.Parameters.AddWithValue("@RegisterDate", dateOfAdmission.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }
        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[OutPatient] set RegisterDate=@RegisterDate WHERE Pid=@Pid";
            OutPatientUpdate();
        }

        private void OutPatientUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("outPatient");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddOutPatient();
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
                query = "SELECT* FROM [dbo].[OutPatient] WHERE Pid=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[OutPatient] WHERE Status LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            comboxPatientID.Text = dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString();
            dateOfAdmission.Text = dataGridView.CurrentRow.Cells["_RegisterDate"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllOutPatient("[dbo].[OutPatient]");
        }

        private void OutPatientForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void OutPatientForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllID("Pid", "[dbo].[Patient]", comboxPatientID, true);
            GetAllOutPatient("[dbo].[OutPatient]");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("outPatient",
            int.Parse(dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString())));
        }
    }
}
