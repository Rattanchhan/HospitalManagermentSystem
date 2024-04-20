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

namespace FinalProject_Hospital_.FormLogin
{
    public partial class LoginForm : Form
    {
        private int width;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void UsernameTexboxMouseUp(object sender, MouseEventArgs e)
        {
            usernameTexbox.ForeColor = Color.Black;
            usernameTexbox.Text = string.Empty;
        }

        private void PasswordTexboxMouseUp(object sender, MouseEventArgs e)
        {
            passwordBox.ForeColor = Color.Black;
            passwordBox.Text = string.Empty;
            passwordBox.PasswordChar = '*';
        }

        private void LoginButtonMouseClick(object sender, MouseEventArgs e)
        {
            ResponsiveForm.MessageLoginPopUp mlp = new ResponsiveForm.MessageLoginPopUp(this)
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterParent
            };
            panel3.Visible = false;
            mlp.ShowDialog();
        }

        private void ResetMouseClick(object sender, MouseEventArgs e)
        {
            FormLogin.ResetPasswordForm resetPassword = new FormLogin.ResetPasswordForm();
            Hide();
            resetPassword.WindowState = FormWindowState.Maximized;
            resetPassword.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void CloseButtonMouseHover(object sender, EventArgs e) => closePanel.BackColor = Color.LightGray;
        private void MinimizeButtonMouseHover(object sender, EventArgs e) => minimizePanel.BackColor = Color.LightGray;
        private void CloseButtonMouseLeave(object sender, EventArgs e) => closePanel.BackColor = Color.Transparent;
        private void MinimizeButtonMouseLeave(object sender, EventArgs e) => minimizePanel.BackColor = Color.Transparent;
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
        private void ChangeSize(float percentage, int buttom)
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
