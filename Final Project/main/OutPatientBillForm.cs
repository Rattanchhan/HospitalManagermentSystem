using Final_Project.Properties;
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
    public partial class OutPatientBillForm : Form
    {
        private Class.SearchInfo searchInfo = new Class.SearchInfo();
        private static SqlDataReader reader;
        private string query;
        private static SqlConnection connection;
        private static SqlCommand command;
        private Class.Check _check = new Class.Check();
        private double charge;
        private Class.Charge amount = new Class.Charge();
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
        DataGridViewImageColumn column7 = new DataGridViewImageColumn();
        public OutPatientBillForm()
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
            UpdateButton.Text = "Save";
            UpdateButton.MouseClick -= UpdateButton_Click;
            UpdateButton.MouseClick += SaveButton_Click;
        }

        private void GetAllOutPatientBill(string tableName)
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
            column1.Name = "BillNo";
            column2.Name = "PatientID";
            column3.Name = "LabCharge";
            column4.Name = "Total";
            column5.Name = "Date";
            column6.Name = "Status";
            column7.Name = "Print";

            column1.HeaderText = "BillNo";
            column2.HeaderText = "PatientID";
            column3.HeaderText = "LabCharge";
            column4.HeaderText = "Total";
            column5.HeaderText = "Date";
            column6.HeaderText = "Status";
            column7.HeaderText = "Print";

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.DarkSeaGreen,
                SelectionForeColor = SystemColors.ControlText
            };

            column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle =
            column4.DefaultCellStyle = column5.DefaultCellStyle = column6.DefaultCellStyle = 
            column1.DefaultCellStyle;

            column7.Image = Resources.print;
            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.Columns.Add(column7);

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
            textBoxLabCharge.Text = "0";
            textBoxTotal.Text = "0";
            comboBoxStatus.Text = "Select";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            query = "Insert into [dbo].[OutPatientBill] values(@BillNo,@Pid,@LabCharge" +
                ",@Total,@Date,@Status)";
            AddOutPatientBill();
            Hide();
            this._check.OpenForm(new Message.MessageAdd("outPatientBill"));

        }
        private void AddOutPatientBill()
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
            command.Parameters.AddWithValue("@LabCharge", double.Parse(textBoxLabCharge.Text));
            command.Parameters.AddWithValue("@Status", comboBoxStatus.Text);
            command.Parameters.AddWithValue("@Total", double.Parse(textBoxTotal.Text));
            command.Parameters.AddWithValue("@Date", dateOfRegister.Text);

            command.ExecuteNonQuery();
            connection.Close();
        }
        private void SaveButton_Click(object sender, MouseEventArgs e)
        {
            query = "Update [dbo].[OutPatientBill] set Pid=@Pid,LabCharge=@LabCharge" +
                ",Total=@Total,Date=@Date,Status=@Status WHERE BillNo=@BillNo";
            OutPatientBillUpdate();
        }

        private void OutPatientBillUpdate()
        {
            Message.MessageAdd messagePopUp = new Message.MessageAdd("outPatientBill");
            messagePopUp.ChangeLabelText("Edit Successfully");
            AddOutPatientBill();
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
                query = "SELECT* FROM [dbo].[OutPatientBill] WHERE Pid=@id";
                reader = searchInfo.DataReader(query, "int", id);
            }
            else
            {
                query = "SELECT* FROM [dbo].[OutPatientBill] WHERE Status LIKE @name";
                reader = searchInfo.DataReader(query, "string", TextBoxSearch.Text);
            }

            while (reader.Read())
            {
                dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()
                    , reader[4].ToString(), reader[5].ToString());
            }
            searchInfo.GetSqlConnection().Close();
        }
        private void SetTextBox()
        {
            textBoxBillNo.Text = dataGridView.CurrentRow.Cells["BillNo"].Value.ToString();
            comboBoxPatientID.Text = dataGridView.CurrentRow.Cells["PatientID"].Value.ToString();
            textBoxLabCharge.Text = dataGridView.CurrentRow.Cells["LabCharge"].Value.ToString();
            dateOfRegister.Text = dataGridView.CurrentRow.Cells["Date"].Value.ToString();
            textBoxTotal.Text = dataGridView.CurrentRow.Cells["Total"].Value.ToString();
            comboBoxStatus.Text = dataGridView.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumn();
            TextBoxSearch.Text = string.Empty;
            GetAllOutPatientBill("[dbo].[OutPatientBill]");
        }

        private void OutPatientBillForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this._check.OpenForm(new Form1());
        }

        private void OutPatientBillForm_Load(object sender, EventArgs e)
        {
            charge = amount.getAmount();
            UpdateButton.MouseClick += UpdateButton_Click;
            SetFormSize();
            dataGridView.Columns.Clear();
            CreateColumn();
            GetAllID("Pid", "[dbo].[OutPatient]", comboBoxPatientID, true);
            GetAllOutPatientBill("[dbo].[OutPatientBill]");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Hide();
            this._check.OpenForm(new Message.MessageDelete("outPatientBill",
            int.Parse(dataGridView.CurrentRow.Cells["PatientID"].Value.ToString())));
        }

        private void comboBoxPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLabCharge();
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
                textBoxTotal.Text =string.Format("{0:0.0000}",(double.Parse(textBoxLabCharge.Text) + charge ));
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                new main.Receipt(int.Parse(dataGridView.CurrentRow.Cells["BillNo"].Value.ToString()), "outPatientBill").Show();
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            new Report.ReportList("OutPatientBill").Show();
        }
    }
}
