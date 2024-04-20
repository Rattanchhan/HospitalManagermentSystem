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

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class DoctorDetailFormUpdate : Form
    {
        //Connect to Sql server
        private string connectionString = "Data Source=DESKTOP-7ODK8A5\\SQLEXPRESS;Initial Catalog=HospitalVersion2;Integrated Security=SSPI;Connection Timeout=30";
        private SqlCommand sqlCommand;
        private Label LabelChange;
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private SqlCommandBuilder commandBuilder;
        public FormAdd.VisualForm visualForm;
        public DoctorInfo doctor;
        public List<DoctorInfo> doctors = new List<DoctorInfo>();
        public Form form;
        public DataGridView newDataGridView;
        private ResponsiveForm.MessageDeletePopUp messageDeletePopUp;/* = new MessageDeletePopUp();*/
        DataTable table;


        private int currentPage;
        private int recoardPerPage=10;
        private int totalPages;
        private int totalRecoard;

        //Create column in dataGridView
        DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
        DataGridViewImageColumn column7 = new DataGridViewImageColumn();
        DataGridViewImageColumn column8 = new DataGridViewImageColumn();
        DataGridViewImageColumn column9 = new DataGridViewImageColumn();
        DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();
        public DoctorDetailFormUpdate(Label label, Form form)
        {
            LabelChange = label;
            this.form = form;
            InitializeComponent();
        }

        private void DoctorDetailFormUpdate_Load(object sender, EventArgs e)
        {
            newDataGridView = dataGridView;
            SetMargin(panel10);
            /*dataGridView.Columns.Clear();
            CreateColumns();
            GetDataFromSql();*/

            GetTotalPages();
            UpdateNavigationLabel();
            dataGridView.Columns.Clear();
            CreateColumns();
            GetDataPerpage();
        }
        private void GetTotalPages()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Doctor", sqlConnection);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception eception)
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            totalRecoard = (Int32)command.ExecuteScalar();
            currentPage = 1;
            sqlConnection.Close();
        }
        private void UpdateNavigationLabel()
        {
            totalPages = (int)Math.Ceiling((double)totalRecoard / recoardPerPage);
            label8.Text = $"Page {currentPage} of {totalPages}";
        }
        private  void UpdatePaginationControl()
        {
            nextPictureBox.Enabled = nextLabel.Enabled= currentPage < totalPages;
            
            priviousPictureBox.Enabled=previousLabel.Enabled = currentPage > 1;
        }
        public void GetDataFromSql()
        {

            try
            {
                /*dataAdapter = new SqlDataAdapter("Select * From [dbo].[Doctor]", connectionString);*/
                /*  commandBuilder = new SqlCommandBuilder(dataAdapter);
                  table = new DataTable();
                  dataGridView.Columns[0].DataPropertyName = "DoctorID";
                  dataGridView.Columns[1].DataPropertyName = "DoctorName";
                  dataGridView.Columns[2].DataPropertyName = "Department";
                  dataGridView.Columns[3].DataPropertyName = "Address";
                  dataGridView.Columns[4].DataPropertyName = "ContactNumber";
                  dataAdapter.Fill(table);
                  dataGridView.DataSource = table;
                  dataGridView.AllowUserToAddRows = false;*/

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From [dbo].[Doctor] WHERE DoctorId IS NOT NULL", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void SetMargin(Panel panel)
        {
            int width = (int)(0.025 * tableLayoutPanel.Width);
            panel.Margin = new Padding(width, 3, width, 3);
        }
        public void CreateColumns()
        {
            column1.Name = "DoctorID";
            column2.Name = "DoctorName";
            column3.Name = "Department";
            column4.Name = "Address";
            column5.Name = "ContactNumber";

            column1.Width = column2.Width = column3.Width = column5.Width = (int)(0.14 * dataGridView.Width);
            column4.Width = (int)(0.16 * dataGridView.Width);
            column6.Width = column7.Width = column8.Width = column9.Width = column10.Width = (int)(0.20 * (dataGridView.Width * 0.28));

            column1.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SystemColors.Control,
                ForeColor = Color.Green,
                SelectionBackColor = SystemColors.Control,
                SelectionForeColor = Color.Green
            };

            column7.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = SystemColors.Control,
                ForeColor = Color.Green,
                SelectionBackColor = SystemColors.Control,
                SelectionForeColor = Color.Green
            };
            column6.DefaultCellStyle = column8.DefaultCellStyle = column9.DefaultCellStyle = column10.DefaultCellStyle = column7.DefaultCellStyle;
            column1.DefaultCellStyle = column2.DefaultCellStyle = column3.DefaultCellStyle = column4.DefaultCellStyle = column5.DefaultCellStyle;

            column7.Image = Properties.Resources.eye_regular_1_;
            column8.Image = Properties.Resources.pen_to_square_regular;
            column9.Image = Properties.Resources.trash_can_regular;

            
            dataGridView.Columns.Add(column1);
            dataGridView.Columns.Add(column2);
            dataGridView.Columns.Add(column3);
            dataGridView.Columns.Add(column4);
            dataGridView.Columns.Add(column5);
            dataGridView.Columns.Add(column6);
            dataGridView.Columns.Add(column7);
            dataGridView.Columns.Add(column8);
            dataGridView.Columns.Add(column9);
            dataGridView.Columns.Add(column10);

        }
        private void DataGridResponFormTest_Resize(object sender, EventArgs e)
        {
            dataGridView.Columns.Clear();
            CreateColumns();
            GetDataFromSql();
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==8)
            {

                /*visualForm = new FormAdd.VisualForm(new ResponsiveForm.MessageDeletePopUp(this));
                visualForm.Show();*/
                visualForm = new FormAdd.VisualForm(new Form());
                visualForm.Show();
                messageDeletePopUp = new MessageDeletePopUp(this, dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString());
                messageDeletePopUp.Show();
            }
            else if (e.ColumnIndex == 6)
            {
                ViewRecord();
            }
            else if (e.ColumnIndex == 7)
            {
                UpdateRecord();
            }
        }
        private void UpdateRecord()
        {
            GetObjectDoctorInfo();
            visualForm = new FormAdd.VisualForm(new FormAdd.Doctor(doctor, this));
            /*form.Hide();*/
            visualForm.Show();
        }
        private void GetObjectDoctorInfo()
        {
            doctor = new DoctorInfo(
                int.Parse(dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString()),
                dataGridView.CurrentRow.Cells["DoctorName"].Value.ToString(),
                dataGridView.CurrentRow.Cells["Department"].Value.ToString(),
                dataGridView.CurrentRow.Cells["Address"].Value.ToString(),
                dataGridView.CurrentRow.Cells["ContactNumber"].Value.ToString()
                );
        }
        private void ViewRecord()
        {
            GetObjectDoctorInfo();
            visualForm = new FormAdd.VisualForm(new ViewDetial.Doctor(doctor, this));
            /*form.Hide();*/
            visualForm.Show();
        }
        public void DeleteRecord()
        {
            string text = dataGridView.CurrentRow.Cells["DoctorID"].Value.ToString();
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("Delete From [dbo].[Doctor] Where DoctorID=@id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", text);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            GetTotal();
            dataGridView.Columns.Clear();
            CreateColumns();
            GetDataFromSql();
        }
        private void GetTotal()
        {
            sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Doctor", sqlConnection);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception eception)
            {
                if (sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            LabelChange.Text = "All Doctor (" + ((Int32)command.ExecuteScalar()).ToString() + ")";
            sqlConnection.Close();
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            currentPage++;
            label8.Text = $"Page {currentPage} of {totalPages}";
            currentPageLabel.Text = currentPage.ToString();
            dataGridView.Columns.Clear();
            CreateColumns();
            GetDataPerpage();
            UpdatePaginationControl();
            
        }
        private void GetDataPerpage()
        {
            try
            {

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand("Select * From [dbo].[Doctor] ORDER BY DoctorId OFFSET @current ROWS FETCH NEXT @recoardPerPage ROWS ONLY", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@current", (currentPage - 1) * recoardPerPage);
                sqlCommand.Parameters.AddWithValue("@recoardPerPage", currentPage* recoardPerPage);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void priviousPictureBox_Click(object sender, EventArgs e)
        {
            currentPage--;
            label8.Text = $"Page {currentPage} of {totalPages}";
            currentPageLabel.Text = currentPage.ToString();
            dataGridView.Columns.Clear();
            CreateColumns();
            GetDataPerpage();
            UpdatePaginationControl();
        }
    }
    public class DoctorInfo
    {
        private int doctorId;
        private string doctorName;
        private string department;
        private string address;
        private string contactNumber;

        public DoctorInfo() { }
        public DoctorInfo(int doctorId, string doctorName, string department, string address, string contactNumber)
        {
            this.doctorId = doctorId;
            this.doctorName = doctorName;
            this.department = department;
            this.address = address;
            this.contactNumber = contactNumber;
        }
        public string GetAddress()
        {
            return address;
        }
        public string GetContactNumber()
        {
            return contactNumber;
        }
        public string GetDeparemnt()
        {
            return department;
        }
        public int GetDoctorId()
        {
            return doctorId;
        }
        public string GetDoctorName()
        {
            return doctorName;
        }
    }

}
