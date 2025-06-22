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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications
{
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;


        }

        private int _LicenseID { set; get; }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrDriveLicenseInfo1.LoadLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
