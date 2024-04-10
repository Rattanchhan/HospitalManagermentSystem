using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject_Hospital_.ResponsiveForm
{
    public partial class MessagePopUp : Form
    {
        private Form form;
        public string text;
        private ResponsiveForm.dashboard dashboard;
        public MessagePopUp(Form form,string text)
        {
            this.form = form;
            this.text = text;
            InitializeComponent();
        }

        private void OkButtonClick(object sender, MouseEventArgs e)
        {
            if(form is ResponsiveForm.dashboard)
            {
                dashboard = ((ResponsiveForm.dashboard)form);
                dashboard.visualForm.Hide();
                ReloadDoctorDetailForm(dashboard.doctorDetail);
            }
            else if(form is ResponsiveForm.DoctorDetailFormUpdate)
            {
                ((ResponsiveForm.DoctorDetailFormUpdate)form).visualForm.Hide();
                ReloadDoctorDetailForm(((ResponsiveForm.DoctorDetailFormUpdate)form));
                /*dashboard = new dashboard();*/

            }
            /*dashboard.WindowState = FormWindowState.Maximized;*/
            Hide();
            /*dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);*/
        }
        private void ReloadDoctorDetailForm(ResponsiveForm.DoctorDetailFormUpdate form)
        {
            form.newDataGridView.Columns.Clear();
            form.CreateColumns();
            form.GetDataFromSql();
        }

        private void AddMessagePopUp_Load(object sender, EventArgs e)
        {
            label1.Text = text;
        }
    }
}
