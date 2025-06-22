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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Detained_Licenses
{
    public partial class frmDetainedLicense : Form
    {
        public frmDetainedLicense()
        {
            InitializeComponent();
        }


        private int _DetainID { set; get; }

        private int _SelectedLicenseID { set; get; }

      

        private void frmDetainedLicense_Load(object sender, EventArgs e)
        {
            lDetainDate.Text = DateTime.Now.ToShortDateString();
            lCreatedBy.Text = GlobalUser.User.UserName;
        }

        private void _DetainedLicense()
        {
            _DetainID = ctrDriverLicenseInfoWithFilter1.SelectedLicense.Detain(Convert.ToDecimal(tbFineFees.Text.Trim()), GlobalUser.User.UserID);
            if(_DetainID == -1)
            {
                MessageBox.Show("Detained License Failed , Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("License Detainted Successfully", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lDetainID.Text = _DetainID.ToString();
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnDetain.Enabled = false;
            llShowLicense.Enabled = true;
            tbFineFees.Enabled = false;

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _DetainedLicense();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;
            lLicenseID.Text = _SelectedLicenseID.ToString();
            llHistory.Enabled = _SelectedLicenseID != -1;
            if (_SelectedLicenseID == -1)
                return;

            if (ctrDriverLicenseInfoWithFilter1.SelectedLicense.IsDetained)
            {
                MessageBox.Show("This License Already Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                return;
            }

            btnDetain.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
