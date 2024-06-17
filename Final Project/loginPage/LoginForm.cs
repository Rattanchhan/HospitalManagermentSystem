using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.loginPage
{
    public partial class LoginForm : Form
    {
        private string textPath = @".....";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ResetLink_Click(object sender, EventArgs e)
        {
            Hide();
            new loginPage.ResetForm().Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Class.User user = new Class.User();
            user = getUser();

            if (textBoxUserName.Text == user.Name && textBoxPassword.Text == user.Password)
            {
                Hide();
                new Message.LoginMessage("").Show();
            }
            else
            {
                invalidLabel.Visible = true;
            }
        }
        private Class.User getUser()
        {
            FileStream file = new FileStream(textPath, FileMode.Open);

            StreamReader streamReader = new StreamReader(file);
            string getString = streamReader.ReadLine();
            Class.User jsonString = JsonSerializer.Deserialize<Class.User>(getString);
            file.Close();
            streamReader.Close();
            return jsonString;

        }
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            invalidLabel.Visible = false;
        }
    }
}
