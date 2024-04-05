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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void CloseButtonMouseClick(object sender, MouseEventArgs e) {
            ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
            {
                WindowState = FormWindowState.Maximized
            };
            dashboard.Show();
            dashboard.DoctorPanelClick(sender,e);
            Close();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterParent;
        }
    }
}
