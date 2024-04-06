﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class dashboard : Form
    {
        private Form activeForm = new Form();
        private string day=DateTime.Now.Day.ToString();
        private string month=DateTime.Now.Month.ToString();
        private readonly string year=DateTime.Now.Year.ToString();
        private static readonly FormLogin.LoginForm login = new FormLogin.LoginForm();
        private static readonly FormAdd.Doctor doctor = new FormAdd.Doctor()
        {
            FormBorderStyle = FormBorderStyle.None
        };
        private static readonly FormAdd.VisualForm visualForm = new FormAdd.VisualForm(doctor);
        public dashboard()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private String ValidateDateTime()
        {
            if (DateTime.Now.Day < 10)
            {
                if (DateTime.Now.Month < 10)
                {
                    day = "-0" + DateTime.Now.Day.ToString();
                    month = "-0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    day = "-0" + DateTime.Now.Day.ToString();
                }
            }
            else
            {
                if (DateTime.Now.Month < 10)
                {
                    month = "-0" + DateTime.Now.Month.ToString();
                }
            }
            return year + month + day;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            label3.Text=ValidateDateTime();
            SetPanel(panel20, label4);
            PanelChange(panel21, panel22, panel28, panel29, panel46, panel73, panel74,
                        label11, label10, label13, label14, label15, label27, label28);
            label9.Visible = false;
            panel27.Visible = false;
            OpenForm(new ResponsiveForm.dashboardPage(), panel18);

        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void DisablePanel(Panel panel, Label label)
        {
            label.ForeColor = Color.Black;
            panel.Visible = false;
        }
        private void SetPanel(Panel panel, Label label)
        {
            label.ForeColor = Color.Green;
            panel.BackColor = Color.Green;
            panel.Visible = true;
        }
        private void OpenForm(Form childForm, Panel panel)
        {
            activeForm?.Close();
            activeForm = childForm;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.TopLevel = false;
            panel.Controls.Add(childForm);
            childForm.Show();
        }
        private void PanelChange(Panel panel1, Panel panel2, Panel panel3, Panel panel4, Panel panel5, Panel panel6,
            Panel panel7, Label label1, Label label2, Label label3, Label label4, Label label5, Label label6, Label label7)
        {
            DisablePanel(panel1, label1);
            DisablePanel(panel2, label2);
            DisablePanel(panel3, label3);
            DisablePanel(panel4, label4);
            DisablePanel(panel5, label5);
            DisablePanel(panel6, label6);
            DisablePanel(panel7, label7);
        }
        private void DashboardPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel20, label4);
            PanelChange(panel21, panel22, panel28, panel29, panel46, panel73, panel74,
                        label11, label10, label13, label14, label15, label27, label28);
            label9.Visible = false;
            label8.Text = "Status";
            panel27.Visible = false;
            panel18.Visible = true;
            OpenForm(new ResponsiveForm.dashboardPage(), panel18);
        }

        public void DoctorPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel21, label11);
            PanelChange(panel20, panel22, panel28, panel29, panel46, panel73, panel74,
                        label4, label10, label13, label14, label15, label27, label28);
            label9.Visible = true;
            label8.Text = "Add New Doctor";
            panel27.Visible = true;
            panel18.Visible = true;
            GetStatus();
            OpenForm(new ResponsiveForm.DoctorDetailForm(), panel18);
        }
        private void GetStatus()
        {
            string connectionString = "Data Source=DESKTOP-DS0DC6P\\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=SSPI;Connection Timeout=30";
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Doctor", connect);
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
            }
            catch (Exception eception)
            {
                if (connect.State != ConnectionState.Closed)
                    connect.Close();
            }
            label9.Text = "All Doctor (" + ((Int32)command.ExecuteScalar()).ToString()+")";
            OpenForm(new ResponsiveForm.dashboardPage(), panel18);
        }
        private void PatientPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel22, label10);
            PanelChange(panel20, panel21, panel28, panel29, panel46, panel73, panel74,
                        label4, label11, label13, label14, label15, label27, label28);
        }

        private void DepartementPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel28, label13);
            PanelChange(panel20, panel22, panel21, panel29, panel46, panel73, panel74,
                        label4, label10, label11, label14, label15, label27, label28);
        }

        private void RoomPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel29, label14);
            PanelChange(panel20, panel22, panel21, panel28, panel46, panel73, panel74,
                        label4, label10, label11, label13, label15, label27, label28);
        }

        private void StaffPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel46, label15);
            PanelChange(panel20, panel22, panel21, panel29, panel28, panel73, panel74,
                        label4, label10, label11, label14, label13, label27, label28);
        }

        private void PharmacyPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel73, label27);
            PanelChange(panel20, panel22, panel21, panel29, panel46, panel28, panel74,
                        label4, label10, label11, label14, label15, label13, label28);
        }

        private void AppointmentPanelClick(object sender, MouseEventArgs e)
        {
            SetPanel(panel74, label28);
            PanelChange(panel20, panel22, panel21, panel29, panel46, panel28, panel73,
                        label4, label10, label11, label14, label15, label13, label27);
        }

        private void CloseButtonMouseHover(object sender, EventArgs e)=>closePanel.BackColor = Color.LightGray;
        private void MinimizeButtonMouseHover(object sender, EventArgs e) => minimizePanel.BackColor = Color.LightGray;
        private void CloseButtonMouseLeave(object sender, EventArgs e) => closePanel.BackColor = Color.Transparent;
        private void MinimizeButtonMouseLeave(object sender, EventArgs e) => minimizePanel.BackColor = Color.Transparent;
        private void CloseButtonMouseClick(object sender, MouseEventArgs e) => Application.Exit();

        private void MinimizeButtonMouseClick(object sender, MouseEventArgs e) => WindowState = FormWindowState.Minimized;
        /*private void ResizeButtonMouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                
            }
            else WindowState = FormWindowState.Normal;

        }*/

        private void ButtonLogOutMouseClick(object sender, MouseEventArgs e)
        {
            Hide();
            login.WindowState = FormWindowState.Maximized;
            login.Show();
        }

        private void AddNewDoctor(object sender, MouseEventArgs e)
        {
            Hide();
            visualForm.Show();
            /*doctor.PanelChange("ok");*/
            doctor.Show();
        }
    }
}
