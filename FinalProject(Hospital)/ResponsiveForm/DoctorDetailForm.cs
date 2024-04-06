using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class DoctorDetailForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;Connection Timeout=30";
        public DoctorDetailForm()
        {
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
            SqlDataAdapter dataAdapter;
            try
            {
                dataAdapter = new SqlDataAdapter("Select DoctorID,DoctorFirstName,DoctorLastName,DoctorPhoneNumber From [dbo].[Doctor]", connectionString);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable();
                dataGrid.Columns[0].DataPropertyName = "DoctorID";
                dataGrid.Columns[1].DataPropertyName = "DoctorFirstName";
                dataGrid.Columns[2].DataPropertyName = "DoctorLastName";
                dataGrid.Columns[3].DataPropertyName = "DoctorPhoneNumber";
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
            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.Name = "column1";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn()
            {
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = SystemColors.Control,
                    ForeColor = Color.Green,
                    SelectionBackColor = SystemColors.Control,
                    SelectionForeColor = Color.Green
                }
            };

            DataGridViewImageColumn column7 = new DataGridViewImageColumn();
            DataGridViewImageColumn column8 = new DataGridViewImageColumn();
            DataGridViewImageColumn column9 = new DataGridViewImageColumn();
            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();

            column6.Width =
            column7.Width =
            column8.Width =
            column9.Width =
            column10.Width = 93;


            column10.DefaultCellStyle=
            column9.DefaultCellStyle=
            column8.DefaultCellStyle=
            column7.DefaultCellStyle=column6.DefaultCellStyle;

            column7.Image = Properties.Resources.eye_regular_1_;
            column8.Image = Properties.Resources.pen_to_square_regular;
            column9.Image = Properties.Resources.trash_can_regular;

            
            column1.Width =
            column2.Width =
            column3.Width =
            column4.Width = 200;
            column5.Width = 259;
            dataGrid.Columns.Add(column1);
            dataGrid.Columns.Add(column2);
            dataGrid.Columns.Add(column3);
            dataGrid.Columns.Add(column4);
            dataGrid.Columns.Add(column5);
            dataGrid.Columns.Add(column6);
            dataGrid.Columns.Add(column7);
            dataGrid.Columns.Add(column8);
            dataGrid.Columns.Add(column9);
            dataGrid.Columns.Add(column10);
        }
        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) {
                string text = dataGrid.CurrentRow.Cells["column1"].Value.ToString();
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("Delete From [dbo].[Doctor] Where DoctorID=@id",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", text);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                dataGrid.Columns.Clear();
                AddColumns();
                GetDataFromSql();
            }
        }
    }
}
