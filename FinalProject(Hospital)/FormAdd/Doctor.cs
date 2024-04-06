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
    public partial class Doctor : Form
    {
        private ResponsiveForm.AddMessagePopUp addMessagePopUp;
        public Panel panel;
        private static readonly ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        private static readonly FormAdd.VisualForm visualForm = new FormAdd.VisualForm(new Form());
        public Doctor()
        {
            addMessagePopUp = new ResponsiveForm.AddMessagePopUp(this);
            InitializeComponent();
        }
        public void PanelChange(string status)
        {
            panel = panel2;
            if (status == "ok")
            {
                panel.Visible = true;
            }
            else
            {
                panel.Visible = false;
            }
            
        }
        private void CloseButtonMouseClick(object sender, MouseEventArgs e) {
            OpenForm(sender,e);
           
        }
        private void OpenForm(object sender,MouseEventArgs e) 
        {
            dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);
            Close();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
        }
        private void TextBoxReset()
        {
            DoctorIDTextBox.Text = string.Empty;
            DoctorNameTextBox.Text = string.Empty;
            DepartmentTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            ContactNumberTextBox.Text = string.Empty;
        }
        private void ResetClick(object sender, MouseEventArgs e)
        {
            TextBoxReset();
        }

        private void AddClick(object sender, MouseEventArgs e)
        {
            PanelChange(string.Empty);
            addMessagePopUp.Show();
        }
    }
}
