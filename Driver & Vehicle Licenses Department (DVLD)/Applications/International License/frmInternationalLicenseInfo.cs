using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        public frmInternationalLicenseInfo(int InterID)
        {
            InitializeComponent();
            ctrInternationalLicenseInfo1.LoadLicenseDate(InterID);
            
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
