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

        private void ResizeButtonMouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal) WindowState = FormWindowState.Maximized;
            panel3.Margin = new Padding(380, 30, 380, 260);
            
        }

        private void ResizeButtonMouseHover(object sender, EventArgs e)
        {

        }

        private void ResizeButtonMouseLeave(object sender, MouseEventArgs e)
        {

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
            ResponsiveForm.MessageLoginPopUp mlp = new ResponsiveForm.MessageLoginPopUp(this);
            mlp.FormBorderStyle = FormBorderStyle.None;
            mlp.StartPosition = FormStartPosition.CenterParent;
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
    }
}