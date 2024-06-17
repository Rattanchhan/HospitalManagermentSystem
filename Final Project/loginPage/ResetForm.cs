using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.loginPage
{
    public partial class ResetForm : Form
    {
        private Message.LoginMessage loginMessage;
        string textPath = @"....";
        public ResetForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            new loginPage.LoginForm().Show();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            Class.User user = new Class.User();
            user = getUser();

            if (textBoxOldPass.Text == user.Password)
            {
                if (textBoxNewPass.Text == textBoxConfirm.Text)
                {
                    user.Password = textBoxNewPass.Text;
                    UpdateUser(user);
                    Hide();
                    loginMessage = new Message.LoginMessage("reset");
                    loginMessage.Show();
                    invalidLabel.Visible = false;
                }
                else
                {
                    invalidLabel.Visible = true;
                    invalidLabel.Text = "Password not match";
                }
            }
            else
            {
                invalidLabel.Visible = true;
                invalidLabel.Text = "Invalid password";
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
        private void UpdateUser(Class.User user)
        {
            FileStream file = new FileStream(textPath, FileMode.Create);

            StreamWriter streamWriter = new StreamWriter(file);
            string jsonString = JsonSerializer.Serialize(user);
            streamWriter.Write(jsonString);
            
            streamWriter.Close();
            file.Close();
        }

        private void ResetForm_Load(object sender, EventArgs e)
        {
            invalidLabel.Visible = false;
        }
    }
}
