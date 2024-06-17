using Final_Project.Class;
using Final_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

namespace Final_Project.main
{
    public partial class InPatientBillForm : Form
    {
        private Class.SearchInfo searchInfo = new Class.SearchInfo();
        private static SqlDataReader reader;
        private string query;
        private static SqlConnection connection;
        private static SqlCommand command;
        private Class.Check _check = new Class.Check();
        private double roomCharge;
        private string roomType="Normal";
        private double charge;
        private Class.Charge amount = new Class.Charge();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
        DataGridViewImageColumn   column9 = new DataGridViewImageColumn();
        public InPatientBillForm()
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
            this.Height = 620;
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

        private void GetAllInPatientBill(string tableName)
        {
            query = "Select * From " + tableName;
            reader = searchInfo.DataReader(query, null, "");
            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[6].ToString(), reader[7].ToString(),
                reader[2].ToString(), reader[3].ToString(), reader[5].ToString(), reader[4].ToString());
            }
        }
        private void CreateColumn()
        {
            column1.Name = "_BillNo";
            column2.Name = "_PatientID";
            column3.Name = "_DateOfAdmission";
            column4.Name = "_DateOfDescharge";
            column5.Name = "_RoomCharge";
            column6.Name = "_LabCharge";
            column7.Name = "_Total";
            column8.Name = "_Status";
            column9.Name = "_Print";

            column1.HeaderText = "BillNo";
            column2.HeaderText = "PatientID";
            column3.HeaderText = "DateOfAdmission";
            column4.HeaderText = "DateOfDescharge";
            column5.HeaderText = "RoomCharge";
            column6.HeaderText = "LabCharge";
            column7.HeaderText = "Total";
            column8.HeaderText= "Status";
            column9.HeaderText = "Print";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle =
            column4.DefaultCellStyle= column5.DefaultCellStyle = column6.DefaultCellStyle =
            column7.DefaultCellStyle = column8.DefaultCellStyle=
            column1.DefaultCellStyle;

            column9.Image= Resources.print;

            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.Columns.Add(column7);
            dataGridView.Columns.Add(column8);
            dataGridView.Columns.Add(column9);
            dataGridView.AllowUserToAddRows = false;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
             ClearTextBox();
        }
        private void ClearTextBox()
        {
            textBoxBillNo.Text = string.Empty;
            comboBoxPatientID.Text = "Select";
            textBoxRoomCharge.Text = "0";
            textBoxLabCharge.Text = "0";
            textBoxTotal.Text = "0";
            comboBoxStatus.Text = "Select";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[InPatientBill] values(@BillNo,@Pid,@RoomCharge,@LabCharge" +
                ",@Status,@Total,@DateOfAdmission,@DateOfDischarge)";
            AddInPatientBill();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("inPatientBill"));

        }
        private void AddInPatientBill()
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
            command.Parameters.AddWithValue("@BillNo", int.Parse(textBoxBillNo.Text));
            command.Parameters.AddWithValue("@Pid", int.Parse(comboBoxPatientID.Text));
            command.Parameters.AddWithValue("@RoomCharge",double.Parse(textBoxRoomCharge.Text));
            command.Parameters.AddWithValue("@LabCharge", double.Parse(textBoxLabCharge.Text));
            command.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
            command.Parameters.AddWithValue("@Total", double.Parse(textBoxTotal.Text));
            command.Parameters.AddWithValue("@DateOfAdmission",dateOfAdmission.Text);
            command.Parameters.AddWithValue("@DateOfDischarge",dateOfDescharge.Text);

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
                command.Parameters.AddWithValue("@status", string.Format("Available"));
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
            query = "Update [dbo].[InPatientBill] set BillNo=@BillNo,Pid=@Pid,RoomCharge=@RoomCharge,LabCharge=@LabCharge" +
                ",Status=@Status,Total=@Total,DateOfAdmission=@DateOfAdmission,DateOfDischarge=@DateOfDischarge WHERE BillNo=@BillNo";
            InPatientBillUpdate();
            if (getStatus(comboBoxPatientID.Text) == "Paid"){
                UpdateStatus();
                UpdateInPatient(comboBoxPatientID.Text);
            }
            
        }

        private string getStatus(string text)
        {
            query = "select Status from [dbo].[InPatientBill] where Pid = @Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", int.Parse(text));
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return  reader[0].ToString();
                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            return "Sent";
        }

        private void UpdateInPatient(string text)
        {
            try
            {
                connection = Class.Connection.SqlConnection();
                query = "Update [dbo].[InPatient] set Status = @status Where Pid=@Pid";
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", int.Parse(text));
                command.Parameters.AddWithValue("@status",string.Format("Out"));
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

        private void UpdateStatus()
        {
            string roomNo;
            query = "select RoomNo from InPatient where Pid =@Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", int.Parse(comboBoxPatientID.Text));
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roomNo = reader[0].ToString();
                    SetRoomStatus(roomNo);  
                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void InPatientBillUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("inPatientBill");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddInPatientBill();
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
                query = "SELECT* FROM [dbo].[InPatientBill] WHERE Pid=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[InPatientBill] WHERE Status LIKE @name";
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
            textBoxBillNo.Text = dataGridView.CurrentRow.Cells["_BillNo"].Value.ToString();
            comboBoxPatientID.Text = dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString();
            dateOfAdmission.Text = dataGridView.CurrentRow.Cells["_DateOfAdmission"].Value.ToString();
            dateOfDescharge.Text = dataGridView.CurrentRow.Cells["_DateOfDescharge"].Value.ToString();
            textBoxRoomCharge.Text = dataGridView.CurrentRow.Cells["_RoomCharge"].Value.ToString();
            textBoxLabCharge.Text = dataGridView.CurrentRow.Cells["_LabCharge"].Value.ToString();
            textBoxTotal.Text = dataGridView.CurrentRow.Cells["_Total"].Value.ToString();
            comboBoxStatus.Text = dataGridView.CurrentRow.Cells["_Status"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllInPatientBill("[dbo].[InPatientBill]");
        }

        private void InPatientBillForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void InPatientBillForm_Load(object sender, EventArgs e)
        {
            charge = amount.getAmount();
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllID("Pid", "[dbo].[InPatient]", comboBoxPatientID, true);
            GetAllInPatientBill("[dbo].[InPatientBill]");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("inPatientBill",
            int.Parse(dataGridView.CurrentRow.Cells["_PatientID"].Value.ToString())));
        }

        private void comboBoxPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select RoomType from InPatient ip inner join Room r on ip.RoomNo = r.RoomNo where Pid =@Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", int.Parse(comboBoxPatientID.Text));
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    roomType = reader[0].ToString();
                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            GetLabCharge();
            GetTotal();
        }

        private void GetTotal()
        {
            double total;
            try
            {
                if (textBoxRoomCharge.Text=="0")
                {
                    total = double.Parse(textBoxLabCharge.Text) + charge;
                }
                else
                {
                    total = double.Parse(textBoxLabCharge.Text) + charge + double.Parse(textBoxRoomCharge.Text);
                }

                textBoxTotal.Text = string.Format("{0:0.0000}",total);
            }
            catch (Exception exception)
            {
                MessageBox.Show("TryParse faild...");
            }
            
        }

        private void GetLabCharge()
        {
            query = "select SUM(Amount) As Total from dbo.LabReport where Pid=@Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", int.Parse(comboBoxPatientID.Text));
                textBoxLabCharge.Text = command.ExecuteScalar().ToString();
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private double Calculate(string roomType)
        {
            double price;
            if(roomType == "VIP")
            {
                price = 120;
            }
            else if (roomType == "Normal")
            {
                price = 60;
            }
            else
            {
                price = 30;
            }
            return price*CalculateDay();
        }
        private int CalculateDay()
        {
            int days;
            DateTime start = DateTime.Parse(dateOfAdmission.Text);
            DateTime end = DateTime.Parse(dateOfDescharge.Text);

            days = (end- start).Days;

            if(days > 0)
            {
                return days;
            }
            return 0;
        }

        private void dateOfAdmission_ValueChanged(object sender, EventArgs e)
        {
            roomCharge = Calculate(roomType);
            textBoxRoomCharge.Text = string.Format("{0:0.0000}",roomCharge);
            GetTotal();
        }

        private void dateOfDescharge_ValueChanged(object sender, EventArgs e)
        {
            roomCharge = Calculate(roomType);
            textBoxRoomCharge.Text = string.Format("{0:0.0000}", roomCharge);
            GetTotal();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                new main.Receipt(int.Parse(dataGridView.CurrentRow.Cells["_BillNo"].Value.ToString()),"inPatientBill").Show();
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            new Report.ReportList("InPatientBill").Show();
        }
    }
}
