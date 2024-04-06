using FinalProject_Hospital_.ResponsiveForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.FormAdd
{
    public partial class VisualForm : Form
    {
        private static Form doctor;
        private ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        public VisualForm(Form doctorForm)
        {
            doctor= doctorForm;
            InitializeComponent();
        }
        
        private void VisualForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            doctor.FormBorderStyle = FormBorderStyle.None;
            doctor.Dock = DockStyle.Fill;
            doctor.TopLevel = false;
            panel2.Controls.Add(doctor);
            doctor.Show();
        }

        private void CloseButtonPanelClick(object sender, MouseEventArgs e)
        {
            doctor.Hide();
            Hide();
            dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);
        }

        private void CloseButtonPanelHover(object sender, EventArgs e)=>closePanel.BackColor = Color.LightGray;

        private void CloseButtonPanelLeave(object sender, EventArgs e)=>closePanel.BackColor = Color.Transparent;
    }
}
