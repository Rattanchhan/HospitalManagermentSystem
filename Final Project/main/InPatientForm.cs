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

namespace Final_Project.main
{
    public partial class InPatientForm : Form
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
        public InPatientForm()
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
            this.Height = 570;
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

        private void GetAllInPatient(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[3].ToString(), reader[2].ToString());
            }
        }
        private void CreateColumn()
        {
            column1.Name = "_PatientID";
            column2.Name = "_RoomNo";
            column3.Name = "_RegisterDate";
            column4.Name = "_Status";

            column1.HeaderText = "PatientID";
            column2.HeaderText = "RoomNo";
            column3.HeaderText = "RegisterDate";
            column4.HeaderText = "Status";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle =
            column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            comboxPatientID.Text = "Select";
            comboBoxRoomNo.Text = "Select";
            comboBoxStatus.Text = "Select";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[InPatient] values(@Pid,@RoomNo,@Status,@RegisterDate)";
            AddInPatient();
            Hide();
            SetRoomStatus(comboBoxRoomNo.Text);
            this._check.OpenForm(new Message.MessageAdd("inPatient"));

        }
        private void AddInPatient()
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
            command.Parameters.AddWithValue("@RoomNo", int.Parse(comboBoxRoomNo.Text));
            command.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
            command.Parameters.AddWithValue("@RegisterDate", RegisterDate.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }
        private void SetRoomStatus(string text)
        {
            try
            {
                connection = Class.Connection.SqlConnection();
                query = "update [dbo].[Room] set Status = @status Where RoomNo=@RoomNo";
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomNo", int.Parse(text));
                command.Parameters.AddWithValue("@status",string.Format("Unavailable"));
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
        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[InPatient] set RoomNo=@RoomNo" +
                ",Status=@Status,RegisterDate=@RegisterDate WHERE Pid=@Pid";
            InPatientUpdate();
        }

        private void InPatientUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("inPatient");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddInPatient();
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
                query = "SELECT* FROM [dbo].[InPatient] WHERE Pid=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[InPatient] WHERE Status LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[3].ToString(), reader[2].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            comboxPatientID.Text= dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString();
            comboBoxRoomNo.Text = dataGridView.CurrentRow.Cells["_RoomNo"].Value.ToString();
            comboBoxStatus.Text = dataGridView.CurrentRow.Cells["_Status"].Value.ToString();
            RegisterDate.Text = dataGridView.CurrentRow.Cells["_RegisterDate"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllInPatient("[dbo].[InPatient]");
        }

        private void InPatientForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void InPatientForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllID("Pid", "[dbo].[Patient]", comboxPatientID, true);
            GetAllID("RoomNo", "[dbo].[Room]", comboBoxRoomNo, false);
            GetAllInPatient("[dbo].[InPatient]");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("inPatient",
            int.Parse(dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString())));
        }
    }
}
