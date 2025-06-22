using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseInfo : Form
    {
        public frmLocalDrivingLicenseInfo(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            ctrDrivingLicenseApplicationInfo1.LoadLocalLicenseInfo(LocalDrivingLicenseID);
        }


        private void frmLocalDrivingLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
