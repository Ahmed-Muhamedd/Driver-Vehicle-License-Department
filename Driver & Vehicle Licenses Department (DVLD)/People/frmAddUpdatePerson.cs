using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using Driver___Vehicle_Licenses_Department__DVLD_.Global_Classes;

namespace Driver___Vehicle_Licenses_Department__DVLD_.People
{
    public partial class frmAddUpdatePerson : Form
    {

        private int _PersonID {  get; set; }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            this._PersonID = PersonID;
            _Mode = _enMode.Update;

        }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = _enMode.AddNew;

        }

    
        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;


        public event Action  OnSaveButton;
        protected virtual void OnSaveButtonClick()
        {
            var Handler = OnSaveButton;
            if (Handler != null)
                Handler();
        }


        private enum _enGender { Male = 0 , Female = 1}

        private enum _enMode { AddNew , Update}

        private _enMode _Mode = _enMode.Update;

        private PeopleBusiness _Person;

        private void _FillCountriesInComboBox()
        {
            DataTable Countries = CountriesB.GetAllCountries();
            foreach(DataRow Rows in Countries.Rows)
            {
                cbCountry.Items.Add(Rows["CountryName"]);
            }
            cbCountry.SelectedItem = "Egypt";
        }

        private void _GetDataFromInputs()
        {
            if (!_HandleImageProcess())
                return;
            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.NationalNumber = tbNationalNum.Text.Trim();
            _Person.Address = tbAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Email = tbEmail.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.ImagePath = pbImage.ImageLocation;

            if (rbMale.Checked)
                _Person.Gender = (byte)_enGender.Male;
            else
                _Person.Gender = (byte)_enGender.Female;

            _Person.CountryID = CountriesB.FindCountry(cbCountry.Text).CountryID;

          
            if (_Person.Save())
            {
                lPersonID.Text = _Person.PersonID.ToString();
                lHeader.Text = "Update Person";
                _Mode = _enMode.Update;
                MessageBox.Show("Person Saved Successfully", "Accepted", MessageBoxButtons.OK);
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Person Not Saved Successfully", "Denied", MessageBoxButtons.OK);


        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();
            if(_Mode == _enMode.AddNew)
            {
                lHeader.Text = "Add New Person";
                _Person = new PeopleBusiness();

            }
            else
            {
                lHeader.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            llRemove.Visible = (pbImage.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountry.SelectedItem = "Egypt";
            //cbCountry.SelectedItem = cbCountry.FindString("Egypt");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNum.Text = "";
            tbAddress.Text = "";
            tbPhone.Text = "";
            tbEmail.Text = "";
            rbMale.Checked = true;

        }

        private void _LoadData()
        {    

            _Person = PeopleBusiness.FindPerson(_PersonID);
            if(_Person == null)
            {
                MessageBox.Show($"No Person With This ID = {_PersonID}", "Not Found!", MessageBoxButtons.OK , MessageBoxIcon.Error);
                this.Close();
                    return;
            }

            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNum.Text = _Person.NationalNumber;
            tbAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            if(_Person.ImagePath != "")
                pbImage.ImageLocation = _Person.ImagePath;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            cbCountry.SelectedItem = _Person.CountryInfo.CountryName;

            llRemove.Visible = (_Person.ImagePath != "");

        }

        private bool _HandleImageProcess()
        {
            if(_Person.ImagePath != pbImage.ImageLocation)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);

                    }catch(Exception Ex)
                    {

                    }
                }

                if(pbImage.ImageLocation != null)
                {
                    string SourceImageFile = pbImage.ImageLocation.ToString();
                    
                    if(Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK);
                        return false;
                    }
                }

            }

            return true;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

            _ResetDefaultValues();

            if (_Mode == _enMode.Update)
                _LoadData();    
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _GetDataFromInputs();
            OnSaveButtonClick();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectedFilePath = openFileDialog1.FileName;
                pbImage.Load(SelectedFilePath);
                llRemove.Visible = true;
            }

        }

        private void ValidateEmptyTextBox(object sender , CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;
            
            
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This Field Required");
            }
            else
            {
                errorProvider1.SetError(Temp, "");
            }
        }

        private void tbNationalNum_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbNationalNum.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNum, "This Field Cannot Be Empty");
                tbNationalNum.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNum, null);
            }


            if(tbNationalNum.Text.Trim() != _Person.NationalNumber && PeopleBusiness.IsPersonExists(tbNationalNum.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNum, "National Number Exist");
            }
            else
            {
                errorProvider1.SetError(tbNationalNum, null);
            }

           
        }

        private void tbEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (tbEmail.Text == "")
                return;

            if (!Validations.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid Email Address");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation == null)
                pbImage.Image = Resources.Female_512;
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            llRemove.Visible = false;
        }
    }
}
