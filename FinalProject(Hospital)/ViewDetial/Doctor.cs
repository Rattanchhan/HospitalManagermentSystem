using FinalProject_Hospital_.FormAdd;
using FinalProject_Hospital_.ResponsiveForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Hospital_.ViewDetial
{
    public partial class Doctor : Form
    {
        private DoctorInfo doctorInfo;
        /*private ResponsiveForm.DoctorDetailForm doctorDetail;*/
        private Form doctorDetailUpdate;
        private ResponsiveForm.dashboard dashboard = new ResponsiveForm.dashboard()
        {
            WindowState = FormWindowState.Maximized
        };
        public Doctor(DoctorInfo doctorInfo, Form form)
        {
            this.doctorInfo = doctorInfo;
            this.doctorDetailUpdate = form;
            InitializeComponent();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            SetInfo();
        }
        private void SetInfo()
        {
            doctorIdLabel.Text = doctorInfo.GetDoctorId().ToString();
            doctorNameLabel.Text=doctorInfo.GetDoctorName();
            departmentLabel.Text=doctorInfo.GetDeparemnt();
            addressLabel.Text=doctorInfo.GetAddress();
            contacNumberLabel.Text=doctorInfo.GetContactNumber();

        }
        private void OkButtonClick(object sender, MouseEventArgs e)
        {
            Hide();
            ((ResponsiveForm.DoctorDetailFormUpdate)doctorDetailUpdate).visualForm.Hide();
            /*dashboard.Show();
            dashboard.DoctorPanelClick(sender, e);*/
        }
    }
}
