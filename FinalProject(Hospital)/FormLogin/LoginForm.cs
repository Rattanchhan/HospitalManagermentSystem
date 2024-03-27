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
            resetPassword.ResizePanel();
            resetPassword.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            panel3.Margin = new Padding(380, 30, 380, 260);
        }
        private void CloseButtonMouseHover(object sender, EventArgs e) => closePanel.BackColor = Color.LightGray;
        private void ResizeButtonMouseHover(object sender, EventArgs e) => resizePanel.BackColor = Color.LightGray;
        private void MinimizeButtonMouseHover(object sender, EventArgs e) => minimizePanel.BackColor = Color.LightGray;
        private void CloseButtonMouseLeave(object sender, EventArgs e) => closePanel.BackColor = Color.Transparent;
        private void MinimizeButtonMouseLeave(object sender, EventArgs e) => minimizePanel.BackColor = Color.Transparent;
        private void CloseButtonMouseClick(object sender, MouseEventArgs e) => Application.Exit();
        private void ResizeButtonMouseLeave(object sender, EventArgs e) => resizePanel.BackColor = Color.Transparent;

        private void MinimizeButtonMouseClick(object sender, MouseEventArgs e) => WindowState = FormWindowState.Minimized;

        private void ResizeButtonMouseClick(object sender, MouseEventArgs e)
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
        }
    }
}
