using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.Class
{
    public class Check
    {
        private Form form;
        public void OpenForm(Form form)
        {
            this.form = form;
            form.Show();
        }
        public int FormCheck(string text)
        {
            if (text == "doctor")
            {
                return 1;
            }
            else if(text=="room")
            {
                return 2;
            }
            else if(text=="patient")
            {
                return 3;
            }
            else if (text=="labReport"){
                return 4;
            }
            else if (text == "inPatient")
            {
                return 5;
            }
            else if (text == "outPatient")
            {
                return 6;
            }
            else if (text == "inPatientBill")
            {
                return 7;
            }
            else if (text == "outPatientBill")
            {
                return 8;
            }
            else
            {
                return -1;
            }
        }
    }
}
