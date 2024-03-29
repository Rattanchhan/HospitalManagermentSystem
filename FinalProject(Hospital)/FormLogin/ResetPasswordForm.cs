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
            ResponsiveForm.MessageLoginPopUp mlp = new ResponsiveForm.MessageLoginPopUp(this)
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent,
                reset="reset"
            };
            panel3.Visible = false;
            mlp.ShowDialog();
        }
        private void OpenLoginForm(Form form)
        {
            Close();
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ButtonBackClick(object sender, MouseEventArgs e)
        {
            OpenLoginForm(new FormLogin.LoginForm());
        }
        private void CloseButtonMouseClick(object sender, MouseEventArgs e) => Application.Exit();

        private void MinimizeButtonMouseClick(object sender, MouseEventArgs e) => WindowState = FormWindowState.Minimized;

        /*private void ResizeButtonMouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                panel3.Margin = new Padding(380, 30, 380, 260);
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                panel3.Margin = new Padding(300, 30, 300, 260);
            }
        }*/
    }
}
