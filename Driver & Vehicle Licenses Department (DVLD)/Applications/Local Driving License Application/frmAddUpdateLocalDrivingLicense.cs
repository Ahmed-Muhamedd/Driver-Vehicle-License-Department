using Driver___Vehicle_Licenses_Department__DVLD_.People;
using Driver___Vehicle_Licenses_Department__DVLD_.People.User_Controller;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicense : Form
    {
        private enum _enMode { AddNew , Update}

        private _enMode _Mode;
        private int _LocalDrivingLicenseID = -1;
        private int _SelectedPerson = -1;
        private LocalDrivingLicenseB _LocalDrivingLicense;
        public frmAddUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = _enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLicense(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _Mode = _enMode.Update;
            this._LocalDrivingLicenseID = LocalDrivingLicenseID;
        }


        public event Action RefreshData;

        public virtual void RefreshTableData()
        {
            var Handler = RefreshData;
            if (Handler != null)
                Handler();
        }
    

        private void _LoadLicenseClassNames()
        {
            DataTable Tb = LicenseClassesB.GetAllLicenseClass();

            foreach (DataRow Row in Tb.Rows)
            {
                cbClassName.Items.Add(Row["ClassName"]);
            }

        }

        private void _SetDefualtValues()
        {
            _LoadLicenseClassNames();
            
            if(_Mode == _enMode.AddNew)
            {
                lTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicense = new LocalDrivingLicenseB();
                tbApplicationInfo.Enabled = false;
                cbClassName.SelectedIndex = 2;
                lAppFees.Text = ApplicationTypesB.FindApplicationType((int)ApplicationB.enApplicationType.NewDrivingLicense).Fees.ToString();
                lAppData.Text = DateTime.Now.ToShortDateString();
                lCreatedBy.Text = GlobalUser.User.UserName;
            }
            else
            {
                lTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tbApplicationInfo.Enabled = true;
                btnSave.Enabled = true;

            }
        }


        private void _LoadData()
        {
            ctrPersonCardWithFilter1.FilteredEnabled = false;
            _LocalDrivingLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(_LocalDrivingLicenseID);
            if(_LocalDrivingLicense == null)
            {
                MessageBox.Show("No Local License ID = " + _LocalDrivingLicenseID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicense.PersonID);
            lAppData.Text = _LocalDrivingLicense.ApplicationDate.ToShortDateString();
            lAppID.Text = _LocalDrivingLicense.ApplicationID.ToString();
            cbClassName.SelectedItem = _LocalDrivingLicense.LicenseClassInfo.ClassName;
            lAppFees.Text = _LocalDrivingLicense.PaidFees.ToString();
            lCreatedBy.Text = UsersB.FindUserByUserID(_LocalDrivingLicense.CreatedByUser).UserName;


        }

        private void frmNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _SetDefualtValues();

            if (_Mode == _enMode.Update)
                _LoadData();

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == _enMode.Update)
            {
                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tbPersonalInfo.SelectedTab = tbApplicationInfo;
                return;
            }


            //incase of add new mode.
            if (ctrPersonCardWithFilter1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tbApplicationInfo.Enabled = true;
                tbPersonalInfo.SelectedTab = tbApplicationInfo;

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFilter1.FilterFocus();
            }
        }

        private void _HandleSaveProcess()
        {
       
            int LicenseClassID = LicenseClassesB.FindLicenseClass(cbClassName.Text).LicenseClassID;

            int ApplicationID = ApplicationB.GetActiveApplicationIDForLicenseClass(_SelectedPerson, ApplicationB.enApplicationType.NewDrivingLicense, LicenseClassID);

        
            if(ApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" 
                    + ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if(LicensesB.IsLicenseExistByPersonID(ctrPersonCardWithFilter1.PersonID , LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicense.PersonID = ctrPersonCardWithFilter1.PersonID;
            _LocalDrivingLicense.ApplicationDate = Convert.ToDateTime(lAppData.Text);
            _LocalDrivingLicense.LastStatusDate = Convert.ToDateTime(lAppData.Text).AddDays(3);
            _LocalDrivingLicense.ApplicationTypeID = (int)ApplicationB.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicense.ApplicationStatus = ApplicationB.enApplicationStatus.New;
            _LocalDrivingLicense.PaidFees = Convert.ToDecimal(lAppFees.Text);
            _LocalDrivingLicense.CreatedByUser = GlobalUser.User.UserID;
            _LocalDrivingLicense.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicense.Save())
            {
                lAppID.Text = _LocalDrivingLicense.LocalDrivingLicenseID.ToString();
                _Mode = _enMode.Update;
                lTitle.Text = "Update Local Driving License Application";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

       

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _HandleSaveProcess();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPerson = obj;
        }




        //private void _TakeDataFromInputs()
        //{
        //    Application.PersonID = Person.PersonID;
        //    Application.ApplicationDate = Convert.ToDateTime(lAppData.Text);
        //    Application.ApplicationTypeID = 1;
        //    Application.ApplicationStatus = ApplicationB.enApplicationStatus.New;
        //    Application.LastStatusDate = Convert.ToDateTime(lAppData.Text) + TimeSpan.FromDays(5);
        //    Application.PaidFees = Convert.ToDecimal(lAppFees.Text) + 18;
        //    Application.CreatedByUser = GlobalUser.User.UserID;

        //    if (Application.Save())
        //    {
        //        LocalDrivingLicenseB Local = new LocalDrivingLicenseB();
        //        Local.LicenseClassID = LicenseClassesB.ReturnLicenseClassID(cbClassName.SelectedItem.ToString());
        //        Local.ApplicationID = Application.ApplicationID;
        //        Local.Save();

        //        MessageBox.Show("Added", "Saved", MessageBoxButtons.OK);
        //    }
        //    else
        //        MessageBox.Show("Canceled", "Failed", MessageBoxButtons.OK);
        //}
    }
}
