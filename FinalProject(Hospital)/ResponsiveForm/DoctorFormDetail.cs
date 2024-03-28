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
    public partial class DoctorFormDetail : Form
    {
        public DoctorFormDetail()
        {
            InitializeComponent();
        }

        private void DoctorFormDetail_Load(object sender, EventArgs e)
        {
            string connectingString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;";
            SqlConnection connect = new SqlConnection(connectingString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select DoctorID,DoctorFirstName,DoctorLastName From [dbo].[Doctor]", connect);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView2.Columns[0].DataPropertyName = "DoctorID";
            dataGridView2.Columns[1].DataPropertyName = "DoctorFirstName";
            dataGridView2.Columns[2].DataPropertyName = "DoctorLastName";
            dataGridView2.DataSource = dt;
            dataGridView2.AllowUserToAddRows = false;
        }
    }
}
