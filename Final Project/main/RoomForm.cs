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

namespace Final_Project.main
{
    public partial class RoomForm : Form
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static string query;
        private static SqlDataReader reader;
        private Class.SearchInfo searchInfo = new Class.SearchInfo();
        private Class.Check _check = new Class.Check();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();

        public RoomForm()
        {
            InitializeComponent();
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllRoom("[dbo].[Room]");
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

        private void GetAllRoom(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
        }

        private void SetFormSize()
        {
            this.Width = 925;
            this.Height = 570;
        }
        private void CreateColumn()
        {
            column1.Name = "RoomNo";
            column2.Name = "RoomType";
            column3.Name = "Status";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle= column1.DefaultCellStyle;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
        private void ClearTextBox()
        {
            TextBoxRoomNo.Text = string.Empty;
            ComboBoxRoomType.Text = "Select";
            ComboBoxStatus.Text = "Select";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[Room] values(@RoomNo,@RoomType,@Status)";
            AddRoom();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("room"));

        }
        private void AddRoom()
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
            command.Parameters.AddWithValue("@RoomNo", int.Parse(TextBoxRoomNo.Text));
            command.Parameters.AddWithValue("@RoomType", ComboBoxRoomType.Text);
            command.Parameters.AddWithValue("@Status", ComboBoxStatus.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }

        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[Room] set RoomType=@RoomType,Status=@Status WHERE RoomNo=@RoomNo";
            RoomUpdate();
        }

        private void RoomUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("room");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddRoom();
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
                query = "SELECT* FROM [dbo].[Room] WHERE RoomNo=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[Room] WHERE RoomType LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            TextBoxRoomNo.Text = dataGridView.CurrentRow.Cells["RoomNo"].Value.ToString();
            ComboBoxRoomType.Text = dataGridView.CurrentRow.Cells["RoomType"].Value.ToString();
            ComboBoxStatus.Text = dataGridView.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllRoom("[dbo].[Room]");
        }

        private void RoomForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }
    }
}
