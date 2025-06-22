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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.IssueLicenseDriving
{
    public partial class frmIssueDrivingLicense : Form
    {
        public frmIssueDrivingLicense(int LocalDrivingLicenseID )
        {
            InitializeComponent();
            this._LocalDrivingLicenseID = LocalDrivingLicenseID;
           
        }

        private int _LocalDrivingLicenseID { set; get; }
  
        private LocalDrivingLicenseB _LocalDrivingLicense;


    
        private void _FillObject()
        {
            _LocalDrivingLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(_LocalDrivingLicenseID);
            if(_LocalDrivingLicense == null)
            {
                MessageBox.Show("This Local License Application Not Available", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicense.PassedAllTests())
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicense.GetActiveLicenseID();

            if(LicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }
            ctrDrivingLicenseApplicationInfo1.LoadLocalLicenseInfo(_LocalDrivingLicenseID);

        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillObject();
        }


        private void _HandleSaveData()
        {
            int LicenseID = _LocalDrivingLicense.IssueLicenseForTheFirtTime(tbNotes.Text.Trim(), GlobalUser.User.UserID);

            if(LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully With License ID = " + LicenseID, "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }else
                MessageBox.Show("License Not Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }
        private void button1_Click(object sender, EventArgs e)
        {
            _HandleSaveData();
        }
    }
}
