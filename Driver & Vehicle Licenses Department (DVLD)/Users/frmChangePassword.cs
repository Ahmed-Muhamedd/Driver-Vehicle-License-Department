using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(int _UserID)
        {
            InitializeComponent();
            this._UserID = _UserID;
        }

        private int _UserID { get; set; }

        private UsersB _User;

        private void _ResetDefualtValues()
        {
            tbCurrentPassword.Text = "";
            tbNewPassword.Text = "";
            tbConfirmPassword.Text = "";
            tbCurrentPassword.Focus();
        }
        private void _LoadUserData()
        {
            _ResetDefualtValues();
            _User = UsersB.FindUserByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"Could Not Found This User ID = {_UserID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrUserInfo1.LoadUserInfo(_UserID);
        }
   

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadUserData();
        }

        private static string HashPassword(string Password)
        {
            using (SHA256 Sha = SHA256.Create())
            {
                byte[] Hashing = Sha.ComputeHash(Encoding.UTF8.GetBytes(Password));

                return BitConverter.ToString(Hashing).Replace("-", "").ToLower();
            }
        }
        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "This Field Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, "");
            }

            if (_User.Password != HashPassword(tbCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Wrong Password!");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbCurrentPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There Is Some Fields Are Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = tbNewPassword.Text.Trim();

            if (_User.Save())
            {
                MessageBox.Show("Password Changed", "Confirm!", MessageBoxButtons.OK);
                tbNewPassword.Text = "";
                tbCurrentPassword.Text = "";
                tbConfirmPassword.Text = "";
            }
            else
                MessageBox.Show("Failed To Change Password", "Confirm!", MessageBoxButtons.OK);

            //Another Solution Using the ChangePassword Function
            //if (_User.ChangePassword(tbNewPassword.Text))
            //{
            //    MessageBox.Show("Password Changed", "Confirm!", MessageBoxButtons.OK);
            //    tbNewPassword.Text = "";
            //    tbCurrentPassword.Text = "";
            //    tbConfirmPassword.Text = "";
            //}
            //else
            //    MessageBox.Show("Failed To Change Password", "Confirm!", MessageBoxButtons.OK);

        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "This Field Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfirmPassword, "");
            }


            if (tbNewPassword.Text != tbConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "The Password Not Match!");
             

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNewPassword, "This Field Can't Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNewPassword, "");
            }
        }
    }
}
