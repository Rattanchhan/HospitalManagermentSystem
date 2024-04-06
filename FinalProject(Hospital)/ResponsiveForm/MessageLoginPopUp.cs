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
        public Form get;
        public string reset;
        public MessageLoginPopUp(Form _get)
        {
            InitializeComponent();
            get = _get;
        }

        private void CloseButtonMouseClick(object sender, MouseEventArgs e)
        {
            if (reset == "reset")
            {
                get.Close();
                OpenLoginForm(new FormLogin.LoginForm());
            }
            else
            {
                get.Hide();
                OpenLoginForm(new ResponsiveForm.dashboard());
            }
        }
        private void OpenLoginForm(Form form)
        {
            Hide();
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void MessageLoginPopUp_Load(object sender, EventArgs e)
        {
            if(reset== "reset")
            {
                label1.Text = "Password changed successfully!";
                label1.Location = new Point(210, 200);
                label2.Text = "Please login to your account again";
                label2.Location = new Point(245, 237);
                button1.Text = "Login";
            }
        }
    }
}
