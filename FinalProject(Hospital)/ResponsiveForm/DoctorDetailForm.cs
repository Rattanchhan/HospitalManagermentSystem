using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class DoctorDetailForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=HospitalVersion2;Integrated Security=SSPI;Connection Timeout=30";
        public FormAdd.VisualForm visualForm;
        private Label LabelChange;
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private SqlCommandBuilder commandBuilder;
        public  DoctorInfo doctor;
        public  List<DoctorInfo> doctors=new List<DoctorInfo>();
        public Form form;
        private ResponsiveForm.MessageDeletePopUp messageDeletePopUp;
        public DoctorDetailForm(Label label, Form form)
        {
            LabelChange = label;
            this.form = form;
            InitializeComponent();
            
        }

        private void DoctorDetailForm_Load(object sender, EventArgs e)
        {
            dataGrid.Columns.Clear();
            AddColumns();
            GetDataFromSql();
        }
        private void GetDataFromSql()
        {
            
            try
            {
                dataAdapter = new SqlDataAdapter("Select * From [dbo].[Doctor]", connectionString);
                commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                /* sqlConnection = new SqlConnection(connectionString);
                 sqlConnection.Open();
                 sqlCommand = new SqlCommand("Select * From [dbo].[Doctor]", sqlConnection);
                 SqlDataReader reader=sqlCommand.ExecuteReader();
                 while (reader.Read())
                 {
                     DoctorInfo doctor = new DoctorInfo(
                         int.Parse(reader[0].ToString()),
                         reader[1].ToString(),
                         reader[2].ToString(),
                         reader[3].ToString(),
                         reader[4].ToString()
                         );
                     doctors.Add( doctor );
                 }*/
                dataGrid.Columns[0].DataPropertyName = "DoctorId";
                dataGrid.Columns[1].DataPropertyName = "DoctorName";
                /*dataGrid.Columns[2].DataPropertyName = "Department";
                dataGrid.Columns[3].DataPropertyName = "Address";
                dataGrid.Columns[4].DataPropertyName = "ContactNumber";*/
                dataGrid.DataSource = doctors;
                dataAdapter.Fill(table);
                dataGrid.DataSource = table;
                dataGrid.AllowUserToAddRows = false;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }
        private void AddColumns()
        {
            DataGridViewTextBoxColumn DoctorID = new DataGridViewTextBoxColumn()
            {
                Name = "DoctorID"
            };
            DataGridViewTextBoxColumn DoctorName = new DataGridViewTextBoxColumn()
            {
                Name="DoctorName"
            };
            DataGridViewTextBoxColumn Department= new DataGridViewTextBoxColumn()
            {
                Name="Department"
            };
            DataGridViewTextBoxColumn Address = new DataGridViewTextBoxColumn()
            {
                Name="Address"
            };
            DataGridViewTextBoxColumn ContactNumber = new DataGridViewTextBoxColumn()
            {
                Name="ContactNumber"
            };
            DataGridViewTextBoxColumn VisualColumn1= new DataGridViewTextBoxColumn()
            {
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = SystemColors.Control,
                    ForeColor = Color.Green,
                    SelectionBackColor = SystemColors.Control,
                    SelectionForeColor = Color.Green
                    
                }
            };

            DataGridViewImageColumn View = new DataGridViewImageColumn()
            {
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = SystemColors.Control,
                    ForeColor = Color.Green,
                    SelectionBackColor = SystemColors.Control,
                    SelectionForeColor = Color.Green
                }
            };
            DataGridViewImageColumn Edit = new DataGridViewImageColumn();
            DataGridViewImageColumn Delete = new DataGridViewImageColumn();
            DataGridViewTextBoxColumn VisualColumn2 = new DataGridViewTextBoxColumn();

            VisualColumn1.Width =
            View.Width =
            Edit.Width =
            Delete.Width =
            VisualColumn2.Width = 80;


            VisualColumn2.DefaultCellStyle =
            Delete.DefaultCellStyle =
            Edit.DefaultCellStyle =
            View.DefaultCellStyle;

            View.Image = Properties.Resources.eye_regular_1_;
            Edit.Image = Properties.Resources.pen_to_square_regular;
            Delete.Image = Properties.Resources.trash_can_regular;



            DoctorID.Width =
            DoctorName.Width =
            Department.Width =
            ContactNumber.Width = 200;
            Address.Width = 259;
            dataGrid.Columns.Add(DoctorID);
            dataGrid.Columns.Add(DoctorName);
            dataGrid.Columns.Add(Department);
            /*dataGrid.Columns.Add(Address);
            dataGrid.Columns.Add(ContactNumber);
            dataGrid.Columns.Add(VisualColumn1);*/
            dataGrid.Columns.Add(View);
            dataGrid.Columns.Add(Edit);
            dataGrid.Columns.Add(Delete);
            dataGrid.Columns.Add(VisualColumn2);
        }
        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3) {

                /*visualForm = new FormAdd.VisualForm(new ResponsiveForm.MessageDeletePopUp(this));
                visualForm.Show();*/
                visualForm = new FormAdd.VisualForm(new Form());
                visualForm.Show();
                messageDeletePopUp=new MessageDeletePopUp(this, dataGrid.CurrentRow.Cells["DoctorID"].Value.ToString());
                messageDeletePopUp.ShowDialog();
            }
            else if(e.ColumnIndex==1)
            {
                EditRecord();
            }
            else if (e.ColumnIndex == 2)
            {
                UpdateRecord();
            }
        }

        private void UpdateRecord()
        {
            GetObjectDoctorInfo();
            /*visualForm = new FormAdd.VisualForm(new FormAdd.Doctor(doctor,this));*/
            form.Hide();
            visualForm.Show();
        }
        private  void GetObjectDoctorInfo()
        {
            doctor = new DoctorInfo(
                int.Parse(dataGrid.CurrentRow.Cells["DoctorID"].Value.ToString()),
                dataGrid.CurrentRow.Cells["DoctorName"].Value.ToString(),
                dataGrid.CurrentRow.Cells["Department"].Value.ToString(),
                dataGrid.CurrentRow.Cells["Address"].Value.ToString(),
                dataGrid.CurrentRow.Cells["ContactNumber"].Value.ToString()
                );
        }
        private void EditRecord()
        {
            GetObjectDoctorInfo();
            visualForm = new FormAdd.VisualForm(new ViewDetial.Doctor(doctor,this));
            form.Hide();
            visualForm.Show();
        }
        public void DeleteRecord()
        {
            string text = dataGrid.CurrentRow.Cells["DoctorID"].Value.ToString();
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("Delete From [dbo].[Doctor] Where DoctorID=@id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", text);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            GetTotal();
            dataGrid.Columns.Clear();
            AddColumns();
            GetDataFromSql();
        }
        private void GetTotal()
        {
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
        }
    }
   /* public class DoctorInfo
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
        public string GetAddress() {
            return address;
        }
        public string GetContactNumber()
        {
            return contactNumber;
        }
        public  string GetDeparemnt()
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
    }*/
}
