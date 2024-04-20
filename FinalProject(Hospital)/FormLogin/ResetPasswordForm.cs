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
        private int width;
        public ResetPasswordForm()
        {
            InitializeComponent();
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

        private void ResizeForm(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                width = tableLayoutPanel3.Width;
            }
            if (width <= 1300)
            {
                ScreenSize1();
            }
            else
            {
                ScreenSize2();
            }
        }
        private void ScreenSize1()
        {
            if (WindowState == FormWindowState.Normal)
            {
                ChangeSize(0.12F, 100);
            }
            else
            {
                ChangeSize(0.20F, 160);
            }
        }
        private void ChangeSize(float percentage,int buttom)
        {
            int width = (int)(percentage * tableLayoutPanel3.Width);
            panel3.Margin = new Padding(width, 30, width, buttom);
        }
        private void ScreenSize2()
        {
            if (WindowState == FormWindowState.Normal)
            {
                ChangeSize(0.12F, 200);
            }
            else
            {
                ChangeSize(0.20F, 260);
            }
        }
    }
}
