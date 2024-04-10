﻿using System;
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
            if (WindowState == FormWindowState.Normal)
            {
                int width = (int)(0.12 * tableLayoutPanel3.Width);
                panel3.Margin = new Padding(width, 30, width, 200);
            }
            else
            {
                int width = (int)(0.20 * tableLayoutPanel3.Width);
                panel3.Margin = new Padding(width, 30, width, 260);
            }
            
        }
    }
}
