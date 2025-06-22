using Driver___Vehicle_Licenses_Department__DVLD_.People;
using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.User_Controllers
{
    public partial class ctrPersonCard : UserControl
    {
        public ctrPersonCard()
        {
            InitializeComponent();
         
        }



        private PeopleBusiness _Person;

        private int _PersonID = -1 ;

        public int PersonID
        {
            get { return _PersonID; }
            set { _PersonID = value; }
        }


        public PeopleBusiness PersonInfo
        {
            get{ return _Person; }
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = PeopleBusiness.FindPerson(PersonID);
            if(_Person == null)
            {
                MessageBox.Show("No Person With This ID = " + PersonID.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillController();
        }
        public void LoadPersonInfo(string NationalNumber)
        {
            _Person = PeopleBusiness.FindPerson(NationalNumber);
            if (_Person == null)
            {
                MessageBox.Show("No Person With This Nationa Number = " + NationalNumber.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillController();
        }

        private void _FillController()
        {
            _PersonID = _Person.PersonID;
            lPersonID.Text = _Person.PersonID.ToString();
            lName.Text = _Person.FullName();
            lNationalNumber.Text = _Person.NationalNumber;
            lGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lEmail.Text = _Person.Email;
            lAddress.Text = _Person.Address;
            lDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lPhone.Text = _Person.Phone;
            lCountry.Text = CountriesB.FindCountryByID(_Person.CountryID).CountryName;
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could Not Find This Image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);
        }

        private void ctrPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
