using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.FormLogin
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }
        public void ResizePanel()
        {
            panel3.Margin = new Padding(380, 30, 380, 260);
        }
        private void TextBoxChange(TextBox textBox)
        {
            textBox.ForeColor = Color.Black;
            textBox.Text = string.Empty;
            textBox.PasswordChar = '*';
        }
        private void ConfirmPasswordTextBoxMouseUp(object sender, MouseEventArgs e)
        {
            TextBoxChange(confirmPasswordTextBox);
        }

        private void NewPasswordBoxMouseUp(object sender, MouseEventArgs e)
        {
            TextBoxChange(newPasswordBox);
        }

        private void OldPasswordTexboxMouseUp(object sender, MouseEventArgs e)
        {
            TextBoxChange(oldPasswordTexbox);
        }

        private void ResizePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;
            panel3.Margin = new Padding(380, 30, 380, 260);
        }

        private void ChangePasswordButtonClick(object sender, MouseEventArgs e)
        {
            FormLogin.LoginForm login = new FormLogin.LoginForm();
            Close();
            login.WindowState = FormWindowState.Maximized;
            login.Show();
        }
    }
}
