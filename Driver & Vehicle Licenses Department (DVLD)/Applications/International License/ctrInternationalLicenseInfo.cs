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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License
{
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private int _InternationalID { set; get; }

        public int InternationalID { get { return _InternationalID; } }

        private InternationalLicenseB _InternationalLicense;

        public InternationalLicenseB SelectedInternationalLicenseInfo { get { return _InternationalLicense; } }


        private void _HandlePersonImage()
        {
            string ImagePath = _InternationalLicense.DriveInfo.PersonInfo.ImagePath;

            if(ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPicture.ImageLocation = ImagePath;

            if (_InternationalLicense.DriveInfo.PersonInfo.Gender == 0)
                pbPicture.Image = Resources.Male_512;
            else
                pbPicture.Image = Resources.Female_512;
        }

        public void  LoadLicenseDate(int InternationalLicenseID)
        {
               _InternationalLicense = InternationalLicenseB.FindInternationalLicense(InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("International License Not Found", "Not Found", MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }

            _InternationalID = InternationalLicenseID;


            lNationaNumber.Text = _InternationalLicense.DriveInfo.PersonInfo.NationalNumber;
            lGender.Text = _InternationalLicense.DriveInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lDateBirth.Text = _InternationalLicense.DriveInfo.PersonInfo.DateOfBirth.ToShortDateString();



            lName.Text = _InternationalLicense.ApplicantFullName;
            lIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lDriverID.Text = _InternationalLicense.DriverID.ToString();
            lExpireDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lIsActive.Text = _InternationalLicense.IsActive == true ? "Yes" : "No";

            _HandlePersonImage();


        }
        private void ctrInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
