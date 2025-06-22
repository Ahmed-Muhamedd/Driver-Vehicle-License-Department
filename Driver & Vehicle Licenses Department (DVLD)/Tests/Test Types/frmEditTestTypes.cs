using Driver___Vehicle_Licenses_Department__DVLD_.Global_Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private TestTypeB.enTestTypes _TestTypeID;

        private TestTypeB _Test;
        public frmEditTestTypes(TestTypeB.enTestTypes TestTypeID)
        {
            InitializeComponent();

            this._TestTypeID = TestTypeID;
        }



        public event Action OnSaveButton;

        protected virtual void OnSaveButtonClick()
        {
            var Handler = OnSaveButton;
            if (Handle != null)
                Handler();
        }

        private void _FindAndSetTestValues()
        {
            _Test = TestTypeB.FindTestType(_TestTypeID);
            if (_Test == null)
            {
                MessageBox.Show("This Test Type Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lTestID.Text = ((int)_Test.TestTypeID).ToString();
            tbTitle.Text = _Test.TestTypeTitle;
            tbDesc.Text = _Test.TestTypeDiscription;
            tbFees.Text = ((int)_Test.TestTypeFees).ToString();
        }
 
        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _FindAndSetTestValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _UpdateTestType()
        {
            if(_Test.TestTypeTitle == tbTitle.Text && _Test.TestTypeDiscription == tbDesc.Text && _Test.TestTypeFees == Convert.ToDecimal(tbFees.Text))
            {
                MessageBox.Show("This Data Already Saved ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Test.TestTypeTitle = tbTitle.Text;
            _Test.TestTypeDiscription = tbDesc.Text;
            _Test.TestTypeFees = Convert.ToDecimal(tbFees.Text);

            if (_Test.Save())
                MessageBox.Show("Data Saved Successfully", "Updated", MessageBoxButtons.OK , MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed To Save Data", "Error!", MessageBoxButtons.OK , MessageBoxIcon.Error);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Not Valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _UpdateTestType();
            OnSaveButton();
        }

        private void tbTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTitle, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbTitle, "");

            }
        }

        private void tbDesc_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(tbDesc.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbDesc, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbDesc, "");

            }
        }

        private void tbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFees, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFees, "");

            }

            if (!Validations.ValidIntegar(tbFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFees, "This Field Required Integars Only");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tbFees, "");

            }
        }
    }
}
