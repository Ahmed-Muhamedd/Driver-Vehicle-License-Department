
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public partial class frmAddUpdateUser : Form
    {
        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = _enMode.Addnew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
            Mode = _enMode.Update;
        }

        private int _UserID { get; }
        private enum _enMode { Addnew , Update};

        private _enMode Mode = _enMode.Update;

        private UsersB _User;

        private void _GetDataFromInputs()
        {
            _User.PersonID = ctrPersonCardWithFilter1.PersonID;
            _User.UserName = tbUserName.Text;
            _User.Password = tbPassword.Text;
            _User.IsActive = cbIsActive.Checked;

            if (_User.Save())
            {
                lUserID.Text = _User.UserID.ToString();
                lHeader.Text = "Update User";
                this.Text = "Update User";
                Mode = _enMode.Update;
                MessageBox.Show("User Saved Successfully", "Confirm" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("User Failed To Save", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _GetDataFromInputs();
          
        }

        private void tbUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(tbUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUserName, "Can't Be Empty");
               
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbUserName, "");

            }

            if(Mode == _enMode.Update)
            {
                if(_User.UserName != tbUserName.Text.Trim())
                {

                    if (UsersB.IsUserExists(tbUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(tbUserName, "This User Name Is Aleardy Exists");
                    }
                    else
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(tbUserName, "");
                    }
                }
            }
            
        }

        private void tbConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(tbPassword.Text.Trim() != tbConfirmPassword.Text.Trim())
            {
              
                errorProvider1.SetError(tbConfirmPassword, "Can't Be Empty");
               
            }
            else
            {
              
                errorProvider1.SetError(tbConfirmPassword, "");

            }
        }

        private void _LoadUserData()
        {
            _User = UsersB.FindUserByUserID(_UserID);
            ctrPersonCardWithFilter1.FilteredEnabled = false;
           
            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            lUserID.Text = _User.UserID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            tbPassword.Text = _User.Password;
            tbConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            ctrPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            
        }

        private void _ResetDefaultValues()
        {
            if(Mode == _enMode.Addnew)
            {
                lHeader.Text = "Add New User";
                this.Text = "Add New User";
                _User = new UsersB();
                tbLoginInfo.Enabled = false; 
            }

            if(Mode == _enMode.Update)
            {
                lHeader.Text = "Update User";
                this.Text = "Update User";
                tbLoginInfo.Enabled = true;
                btnNext.Enabled = true;
            }

            tbUserName.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text= "";
            cbIsActive.Checked = true;


        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (Mode == _enMode.Update)
                _LoadUserData();
        }
 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(Mode == _enMode.Update)
            {
                btnSave.Enabled = true;
                tbLoginInfo.Enabled = true;
                tbUserInfo.SelectedTab = tbLoginInfo;
                return;
            }

            if(Mode == _enMode.Addnew)
            {
                if(ctrPersonCardWithFilter1.PersonID != -1)
                {
                    if (UsersB.IsPersonIsUser(ctrPersonCardWithFilter1.PersonID))
                        MessageBox.Show("Selected Person Is Already A User", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        btnSave.Enabled = true;
                        tbLoginInfo.Enabled = true;
                        tbUserInfo.SelectedTab = tbLoginInfo;

                    }

                }
                else
                {
                    MessageBox.Show("Please Select A Person", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void tbPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Password Can't Be Empty");
            }
            else
            {
                errorProvider1.SetError(tbPassword, "");
                e.Cancel = false;
            }
        }
    }
}
