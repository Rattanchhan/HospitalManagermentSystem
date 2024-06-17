using Final_Project.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.main
{
    public partial class Receipt : Form
    {
        private Panel panelPrint;
        private Bitmap memroying;
        private int id;
        private string text;
        private static SqlDataReader reader;
        private string query;
        private static SqlConnection connection;
        private static SqlCommand command;
        private int pid;
        public Receipt(int id,string text)
        {
            this.id = id;
            this.text = text;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Print(panel);
        }
        private void Print(Panel panel)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            panelPrint = panel;
            getPrintArea(panel);
            printPreviewDialog1.Document = printDocument1;
            printDocument1.PrintPage += PrintDocument1_PrintPage;
            printPreviewDialog1.ShowDialog();

        }

        private void getPrintArea(Panel panel)
        {
           memroying= new Bitmap(panel.Width,panel.Height);
            panel.DrawToBitmap(memroying,new Rectangle(0,0,panel.Width,panel.Height));
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pageArea = e.PageBounds;
            e.Graphics.DrawImage(memroying,(pageArea.Width/2)-(this.panelPrint.Width/2),this.panelPrint.Location.Y);
        }

        private void Reciept_Load(object sender, EventArgs e)
        {
            if (text == "inPatientBill")
            {
                SetInpatientBillValue();
            }
            else
            {
                SetOutPatientBillValue();
            }
            
        }

        private void SetOutPatientBillValue()
        {
            query = "select * from [dbo].[OutPatientBill] Where BillNo = @BillNo ";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillNo", id);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pid = int.Parse(reader[1].ToString());
                    LabChargeLabel.Text = reader[2].ToString();
                    amountLabel.Text = reader[3].ToString();
                    total.Text = "$" + reader[3].ToString();
                    admissionLabel.Text = reader[4].ToString();
                    dischargeLabel.Text = reader[4].ToString();
                    roomChargeLabel.Text ="0.0000";
                    roomNoLabel.Text = "";
                    dateLabel.Text = reader[4].ToString();
                    endDateLabel.Text = reader[4].ToString();

                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            GetPatientInfo();
        }

        private void SetInpatientBillValue()
        {
            query = "select * from [dbo].[InPatientBill] Where BillNo = @BillNo ";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BillNo", id);
                reader = command.ExecuteReader();
                while (reader.Read())
                { 
                    pid = int.Parse(reader[1].ToString());
                    LabChargeLabel.Text = reader[3].ToString();
                    amountLabel.Text = reader[5].ToString();
                    total.Text ="$"+reader[5].ToString();
                    admissionLabel.Text = reader[6].ToString();
                    dischargeLabel.Text = reader[7].ToString();
                    roomChargeLabel.Text = reader[2].ToString();
                    dateLabel.Text = reader[7].ToString();
                    endDateLabel.Text = reader[7].ToString();
                       
                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            GetPatientInfo();
        }
        private void GetPatientInfo()
        {
            query = "select * from [dbo].[Patient] Where Pid = @Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", pid);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    nameLabel.Text = reader[1].ToString()+" " + reader[2].ToString();
                    ageLabel.Text = reader[4].ToString();
                    addressLabel.Text = reader[5].ToString();
                    GenderLabel.Text = reader[3].ToString();
                }
                connection.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
            if (text == "inPatientBill")
            {
                GetRoomNO();
            }
            
        }

        private void GetRoomNO()
        {
            query = "select RoomNo from [dbo].[InPatient] Where Pid = @Pid";
            try
            {
                connection = Class.Connection.SqlConnection();
                connection.Open();
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Pid", pid);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    roomNoLabel.Text = reader[0].ToString();
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
    }
}
