using Driver___Vehicle_Licenses_Department__DVLD_.People;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Controls
{
    public partial class ctrApplicationInfo : UserControl
    {
        private ApplicationB _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }
        public ctrApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = ApplicationB.FindApplication(ApplicationID);
            if(_Application == null)
            {
                MessageBox.Show("No Application With This Application ID = " + ApplicationID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lAppID.Text = _Application.ApplicationID.ToString();
            lStatus.Text = _Application.StatusText;
            lFees.Text = _Application.PaidFees.ToString();

            lType.Text = _Application.ApplicationTypeInfo.Title;
            lApplicant.Text = _Application.PersonInfo.FullName();
            lDate.Text = _Application.ApplicationDate.ToShortDateString();
            lStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lCreatedBy.Text = _Application.CreatedByUserInfo.UserName;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_Application.PersonID);
            frm.ShowDialog();

            LoadApplicationInfo(_ApplicationID);
        }
    }
}
