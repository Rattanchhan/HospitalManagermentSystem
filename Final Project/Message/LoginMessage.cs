using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Message
{
    public partial class LoginMessage : Form
    {
        private string text;
        public LoginMessage(string text)
        {
            this.text = text;
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Hide();
            if (text == "reset")
            {
                new loginPage.LoginForm().Show();
            }
            else
            {
                new Form1().Show();
            }
        }

        private void LoginMessage_Load(object sender, EventArgs e)
        {
            if (text == "reset")
            {
                viewLabel.Text = "Password Reset successfully";
            }
        }
    }
}
