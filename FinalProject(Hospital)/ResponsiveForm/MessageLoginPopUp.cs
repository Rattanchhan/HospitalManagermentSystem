using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class MessageLoginPopUp : Form
    {
        Form get;
        public MessageLoginPopUp(Form _get)
        {
            InitializeComponent();
            get = _get;
        }

        private void CloseButtonMouseClick(object sender, MouseEventArgs e)
        {
            get.Hide();
            ResponsiveForm.dashboard dasboard = new ResponsiveForm.dashboard();
            Close();
            dasboard.WindowState = FormWindowState.Maximized;
            dasboard.Show();
        }
    }
}
