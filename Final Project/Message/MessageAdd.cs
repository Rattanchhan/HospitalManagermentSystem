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
    public partial class MessageAdd : Form
    {
        private string text;
        private Class.Check check = new Class.Check();
        public MessageAdd(string text)
        {
            this.text = text;
            InitializeComponent();
        }
        public void ChangeLabelText(string labelText)
        {
            LabelMessage.Text = labelText;
        }
        private void MessageAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            RepeatForm();
        }
        private void OpenFormDialog(Form form)
        {
            this.Hide();
            this.check.OpenForm(form);
        }
        private void RepeatForm()
        {
            if (check.FormCheck(text)==1)
            {
                OpenFormDialog(new main.DoctorMainForm());
            }
            else if(check.FormCheck(text)==2)
            {
                OpenFormDialog(new main.RoomForm());
            }
            else if (check.FormCheck(text) == 3)
            {
                OpenFormDialog(new main.PatientForm());
            }
            else if(check.FormCheck(text) == 4)
            {
                OpenFormDialog(new main.LabReportForm());
            }
            else if(check.FormCheck(text)==5)
            {
                OpenFormDialog(new main.InPatientForm());
            }
            else if (check.FormCheck(text) == 6)
            {
                OpenFormDialog(new main.OutPatientForm());
            }
            else if (check.FormCheck(text) == 7)
            {
                OpenFormDialog(new main.InPatientBillForm());
            }
            else if (check.FormCheck(text) == 8)
            {
                OpenFormDialog(new main.OutPatientBillForm());
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            RepeatForm();
        }
    }
}
