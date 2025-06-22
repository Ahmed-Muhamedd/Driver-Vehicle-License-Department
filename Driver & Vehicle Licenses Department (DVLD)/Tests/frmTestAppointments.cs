using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application.Vision_Test;
using Driver___Vehicle_Licenses_Department__DVLD_.Properties;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application
{
    public partial class frmTestAppointments : Form
    {
        private DataTable _dtAllTestAppoitnemnts;
        private TestTypeB.enTestTypes _TestTypeID{ set; get; }
    
        private int _LocalDrivingLicenseID { get; set; }


      

        public event Action RefreshData;

        public frmTestAppointments(int LocalDrivingLicenseID, TestTypeB.enTestTypes TestTypeID)
        {
            InitializeComponent();
            ctrDrivingLicenseApplicationInfo1.LoadLocalLicenseInfo(LocalDrivingLicenseID);

            this._LocalDrivingLicenseID = LocalDrivingLicenseID;
            this._TestTypeID = TestTypeID;
        }
        


        private void _LoadAllTestAppointment()
        {
            _SetDefault();
            _dtAllTestAppoitnemnts = TestAppointmentB.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseID, _TestTypeID);
            ctrDrivingLicenseApplicationInfo1.LoadLocalLicenseInfo(_LocalDrivingLicenseID);
            dataGridView1.DataSource = _dtAllTestAppoitnemnts;

            lRecord.Text = dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 120;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 200;


                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 100;
            }
            

        }


        private void _SetDefault()
        {
            

            switch (_TestTypeID)
            {
                case TestTypeB.enTestTypes.VisionTest:
                    lHeader.Text = "Vision Test Appointments";
                    pbMain.Image = Resources.Vision_512;
                    this.Text = "Vision Test Appointment";
                    break;
                case TestTypeB.enTestTypes.StreetTest:
                    lHeader.Text = "Street Test Appointments";
                    pbMain.Image = Resources.Street_Test_32;
                    this.Text = "Street Test Appointment";
                    break;
                case TestTypeB.enTestTypes.WrittenTest:
                    lHeader.Text = "Written Test Appointments";
                    this.Text = "Written Test Appointment";
                    pbMain.Image = Resources.Written_Test_512;
                    break;

            }
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadAllTestAppointment();
        }

        private void _HandleScheduleTest()
        {
            LocalDrivingLicenseB LocalLicenseApplication = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(_LocalDrivingLicenseID);

            if (LocalLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("There is Already Active Appointnment For This Person", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TestB LastTest = LocalLicenseApplication.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                frmScheduleTest Frm = new frmScheduleTest(_LocalDrivingLicenseID, _TestTypeID);
                Frm.ShowDialog();
                _LoadAllTestAppointment();
                return;
            }

            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This Person Already Passed This Test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest Frm2 = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDID, _TestTypeID);
            Frm2.ShowDialog();
            _LoadAllTestAppointment();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _HandleScheduleTest();

        }

        private void frmVisionTestAppointments_Activated(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest Form = new frmScheduleTest(_LocalDrivingLicenseID, _TestTypeID, (int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            _LoadAllTestAppointment();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest Form = new frmTakeTest( (int)dataGridView1.CurrentRow.Cells[0].Value, _TestTypeID);
            Form.RefreshDate += _LoadAllTestAppointment;
            Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshData();
            this.Close();
        }

      
    }
}
