using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Licenses.Local_Licenses.Controls
{
    public partial class ctrDriverLicenseInfoWithFilter : UserControl
    {

        public event Action<int> OnLicenseSelected;

        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> Handler = OnLicenseSelected;
            if (Handler != null)
                Handler(LicenseID);
        }

        private int _LicenseID { set; get; }

        public int License { get { return ctrDriveLicenseInfo1.LicenseID; } }

        public LicensesB SelectedLicense { get { return ctrDriveLicenseInfo1.SelectedLicenseInfo; } }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public ctrDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            tbFilter.Text = LicenseID.ToString();
            ctrDriveLicenseInfo1.LoadLicenseInfo(LicenseID);
            _LicenseID = ctrDriveLicenseInfo1.LicenseID;

            if (OnLicenseSelected != null && FilterEnabled)
                OnLicenseSelected(_LicenseID);
        }

        private void DriverLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There Is Field Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(tbFilter.Text.Trim(), out int ID))
                _LicenseID = ID;

            LoadLicenseInfo(_LicenseID);

        }

        public void InputFocus()
        {
            tbFilter.Focus();
        }



        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)
                btnSearch.PerformClick();
        }

        private void tbFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFilter, "This Field Cannot Be An Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFilter, null);
            }
        }
    }
}
 