using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using Driver___Vehicle_Licenses_Department__DVLD_.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application.Vision_Test
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID { set; get; }


        private TestB _Test;

        private TestTypeB.enTestTypes _TestTypeID { set; get; }

        public frmTakeTest(int TestAppointmentID , TestTypeB.enTestTypes TestTypeID)
        {
            InitializeComponent();
            this._TestAppointmentID = TestAppointmentID;
            this._TestTypeID = TestTypeID;
        }

  

        public event Action RefreshDate;

    
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrScheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID);
            ctrScheduledTest1.TestTypeID = _TestTypeID;

            if (ctrScheduledTest1.TestAppointmentID == -1)
                button1.Enabled = false;
            else
                button1.Enabled = true;

            int TestID = ctrScheduledTest1.TestID;

            if(TestID != -1)
            {
                _Test = TestB.FindTest(TestID);
                tbNotes.Text = _Test.Notes;
                if (_Test.TestResult)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = false;

                rbFail.Enabled = false;
                rbPass.Enabled = false;
                label1.Enabled = true;
                label1.Text = "You Cannot Change The Results";

            }else
                _Test = new TestB();

        }


        private void _GetDataFromInputs()
        {

            if(MessageBox.Show("Are You Sure You Want To Save ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointmentID;

            _Test.TestResult = rbPass.Checked;
            _Test.Notes = tbNotes.Text;
            _Test.UserID = GlobalUser.User.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Saved", "Saved", MessageBoxButtons.OK , MessageBoxIcon.Information);
                button1.Enabled = false;
            }
            else
                MessageBox.Show("Failed", "Failed", MessageBoxButtons.OK , MessageBoxIcon.Error);

        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            _GetDataFromInputs();
            RefreshDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
