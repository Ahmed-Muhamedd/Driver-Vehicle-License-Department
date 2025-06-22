using DVLD_Business;
using System;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Users.User_Controller
{
    public partial class ctrUserInfo : UserControl
    {
        public ctrUserInfo()
        {
            InitializeComponent();
        }

        public int PeronID { get; set; }

        private UsersB _User;

        private int _UserID = -1;

        public int UserID { get { return _UserID; } }

        public void LoadUserInfo(int UserID)
        {

            _UserID = UserID;
            _User =  UsersB.FindUserByUserID(UserID);

            if(_User == null)
            {
                MessageBox.Show($"Not User With This ID = {UserID}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
                return;
            }

            _FillUserInfo();

        }

        private void _ResetDefaultData()
        {
            lUserID.Text = "???";
            lUsername.Text = "???";
            lIsActive.Text = "???";
        }
        private void _FillUserInfo()
        {
            lUsername.Text = _User.UserName;
            lUserID.Text = _User.UserID.ToString();
            lIsActive.Text = _User.IsActive ? "Yes" : "No";
            ctrPersonCard1.LoadPersonInfo(_User.PersonID);

        }
    }
}
 