using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class MessageDeletePopUp : Form
    {
        private Form form;
        private string id;
        private ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        public MessageDeletePopUp(Form form,string id)
        {
            this.form = form;
            this.id = id;
            InitializeComponent();
        }

        private void NoButtonClick(object sender, MouseEventArgs e)
        {
            Check(sender,e);
        }

        private void Check(object sender, MouseEventArgs e)
        {
            if(form is ResponsiveForm.DoctorDetailFormUpdate)
            {
                ((ResponsiveForm.DoctorDetailFormUpdate)form).visualForm.Hide();
                Hide();
               /* dashboard.Show(); 
                dashboard.DoctorPanelClick(sender, e);*/
                
            }
        }

        private void YesButtonClick(object sender, MouseEventArgs e)
        {
            if(form is ResponsiveForm.DoctorDetailFormUpdate)
            {
                ((ResponsiveForm.DoctorDetailFormUpdate)form).DeleteRecord();
                Check(sender,e);
            }
        }

        private void MessageDeletePopUpLoad(object sender, EventArgs e)
        {
            IdLabel.Text= "(ID:"+id+")";
        }
    }
}
