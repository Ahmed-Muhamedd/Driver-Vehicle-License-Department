using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses
{
    public partial class ctrDriveLicenseInfo : UserControl
    {
        public ctrDriveLicenseInfo()
        {
         
            InitializeComponent();
        }

     
        private int _LicenseID;
        public int LicenseID
        {
            get
            {
                return _LicenseID;
            } 
        }

        private LicensesB _License;

        public LicensesB SelectedLicenseInfo { get { return _License; } }



        public void LoadLicenseInfo(int LicenseID)
        {
             _LicenseID = LicenseID;
             _License = LicensesB.FindLicenseByLicenseID(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("This License Not Found ID = " + LicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            
           

            lDateBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortTimeString();
            lClass.Text = _License.LicenseClassInfo.ClassName;
            lName.Text = _License.DriverInfo.PersonInfo.FullName();
            lNationaNumber.Text = _License.DriverInfo.PersonInfo.NationalNumber;
            lGender.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";

            //lIsDetained.Text = 

            lIssueDate.Text = _License.IssueDate.ToShortDateString();
            lExpireDate.Text = _License.ExpirataionDate.ToShortDateString();
            lIssueReason.Text = _License.IssueReasonText;
            lNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lIsActive.Text = _License.IsActive == true ? "Yes" : "No";
            lDriverID.Text = _License.DriverID.ToString();
            lLicenseID.Text = _License.LicenseID.ToString();
            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {

         

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                {
                    pbPicture.ImageLocation = ImagePath;
                    return;
                }

            if (_License.DriverInfo.PersonInfo.Gender == 0)
                pbPicture.Image = Resources.Male_512;
            else
                pbPicture.Image = Resources.Female_512;
        }



        private void ctrDriveLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void lGender_Click(object sender, EventArgs e)
        {

        }
    }
}
