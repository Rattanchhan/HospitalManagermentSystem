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
        private readonly Form childForm;
        private ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        public VisualForm(Form form)
        {
            childForm = form;
            InitializeComponent();
        }
        private void VisualForm_Load(object sender, EventArgs e)
        {
            OpenForm(childForm);
        }
        private void OpenForm(Form childForm)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.TopLevel = false;
            panel2.Controls.Add(childForm);
            childForm.Show();
        }

        private void CloseButtonPanelClick(object sender, MouseEventArgs e)
        {
            childForm.Hide();
            Hide();
            /*dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);*/
        }

        private void CloseButtonPanelHover(object sender, EventArgs e)=>closePanel.BackColor = Color.LightGray;

        private void CloseButtonPanelLeave(object sender, EventArgs e)=>closePanel.BackColor = Color.Transparent;
    }
}
