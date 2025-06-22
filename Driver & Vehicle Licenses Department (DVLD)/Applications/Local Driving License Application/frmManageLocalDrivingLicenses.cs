using Driver___Vehicle_Licenses_Department__DVLD_.Applications.IssueLicenseDriving;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Tests_Application;
using Driver___Vehicle_Licenses_Department__DVLD_.Local_Driving_License;
using DVLD_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenses : Form
    {
        private DataTable _dtAllLocalDrivingLicense;
        public frmManageLocalDrivingLicenses()
        {
            InitializeComponent();
        }

   
        private void _LoadFilteredData()
        {
            string FilterColumn = "";

            switch (cbFilter.SelectedItem)
            {
                case "None":
                    FilterColumn = "None";
                    break;

                case "LocalAppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National Number":
                    FilterColumn = "NationalNum";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

            }

            if (FilterColumn == "None" || tbFilter.Text == "")
            {
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = "";
                lCount.Text = _dtAllLocalDrivingLicense.Rows.Count.ToString();
                return;
            }
            else if (FilterColumn == "LocalDrivingLicenseApplicationID")
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());
            else
                _dtAllLocalDrivingLicense.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, tbFilter.Text.Trim());

            lCount.Text = dataGridView1.Rows.Count.ToString();

        }



        private void _LoadAllData()
        {
            _dtAllLocalDrivingLicense = LocalDrivingLicenseB.GetAllLocalDrivingLicenseApplications();
            dataGridView1.DataSource = _dtAllLocalDrivingLicense;
            cbFilter.SelectedItem = "None";

            lCount.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "LocalID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "Driving Class";
                dataGridView1.Columns[1].Width = 250;

                dataGridView1.Columns[2].HeaderText = "National Number";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 200;

                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Passed Tests";
                dataGridView1.Columns[5].Width = 95;

                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 100;
            }
        }

        private void frmManageLocalDrivingLicenses_Load(object sender, EventArgs e)
        {
            _LoadAllData();
          

        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _LoadFilteredData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.Text != "None");
            if (tbFilter.Visible)
            {
                tbFilter.Text = "";
                tbFilter.Focus();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frmNewLocalDrvingLicense = new frmAddUpdateLocalDrivingLicense();
            frmNewLocalDrvingLicense.ShowDialog();
        }

        private void seToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseInfo Frm = new frmLocalDrivingLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
            _LoadAllData();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel This Application", "Confrim", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (ApplicationB.CancelApplication((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("Application Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Question);
                _LoadAllData();
            }
            else
                MessageBox.Show("Application Not Cancelled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointments Form = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, TestTypeB.enTestTypes.VisionTest);
            Form.RefreshData += _LoadAllData;
            Form.ShowDialog();
        }


        private void _ContextMenuProccess()
        {

            LocalDrivingLicenseB LocalLicense = LocalDrivingLicenseB.FindLocalDrivingLicenseByID((int)dataGridView1.CurrentRow.Cells[0].Value);

            int TotalPassedTest = (int)dataGridView1.CurrentRow.Cells[5].Value;

            bool IsLicenseExists = LocalLicense.IsLicenseIssued();

            cmsNewDriving.Enabled = (TotalPassedTest == 3) && !IsLicenseExists;
            cmsShowLicense.Enabled = IsLicenseExists;
            cmsScheduleTests.Enabled = !IsLicenseExists;
            cmsEdit.Enabled = !IsLicenseExists && (LocalLicense.ApplicationStatus == ApplicationB.enApplicationStatus.New);

            cmsCancel.Enabled = LocalLicense.ApplicationStatus == ApplicationB.enApplicationStatus.New;

            cmsDelete.Enabled = LocalLicense.ApplicationStatus == ApplicationB.enApplicationStatus.New;


            bool PassedVisionTest = LocalLicense.DoesPassTestType(TestTypeB.enTestTypes.VisionTest);
            bool PassedWrittenTest = LocalLicense.DoesPassTestType(TestTypeB.enTestTypes.WrittenTest);
            bool PassedStreetTest = LocalLicense.DoesPassTestType(TestTypeB.enTestTypes.StreetTest);

            cmsScheduleTests.Enabled = (!PassedStreetTest || !PassedWrittenTest || !PassedStreetTest) && LocalLicense.ApplicationStatus == ApplicationB.enApplicationStatus.New;

            if (cmsScheduleTests.Enabled)
            {
                cmsVisionTest.Enabled = !PassedVisionTest;
                cmsWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;
                cmsStreetTest.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _ContextMenuProccess();
        }

        private void cmsWrittenTest_Click(object sender, EventArgs e)
        {
            frmTestAppointments Form = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, TestTypeB.enTestTypes.WrittenTest);
            Form.RefreshData += _LoadAllData;
            Form.ShowDialog();
        }

        private void cmsStreetTest_Click(object sender, EventArgs e)
        {
            frmTestAppointments Form = new frmTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, TestTypeB.enTestTypes.StreetTest);
            Form.RefreshData += _LoadAllData;
            Form.ShowDialog();
        }

        private void cmsNewDriving_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense Form = new frmIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void cmsShowLicense_Click(object sender, EventArgs e)
        {
            frmLicenseInfo Form = new frmLicenseInfo(LicensesB.FindLicenseByLocalLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value).LicenseID);
            Form.ShowDialog();
        }

        //repair
        private void cmsShowPersonLicense_Click(object sender, EventArgs e)
        {
            frmLicenseHistory Form = new frmLicenseHistory((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense Frm = new frmAddUpdateLocalDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
            _LoadAllData();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure You Want To Delete This Application" , "Confrim" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            LocalDrivingLicenseB License = LocalDrivingLicenseB.FindLocalDrivingLicenseByID(LocalLicenseID);

            if(License != null)
            {
                if (License.Delete())
                {
                    MessageBox.Show("License Application Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _LoadAllData();
                }
                else
                {
                    MessageBox.Show("Could Not Delete Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.Text == "LocalAppID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}

//private void _LoadDataTable()
//{
//    DataTable Local = LocalDrivingLicenseViewB.GetLocalViews();
//    dataGridView1.Rows.Clear();

//    foreach (DataRow Row in Local.Rows)
//    {
//        dataGridView1.Rows.Add(Row["LocalDrivingLicenseApplicationID"], Row["ClassName"], Row["NationalNum"], Row["FullName"], Row["ApplicationDate"],
//                               Row["PassedTestCount"], Row["Status"]);
//    }
//    lCount.Text = Local.Rows.Count.ToString();
//}
//private void _LoadFilteredLocal(string ColumnName, string Filter)
//{
//    DataTable Local = LocalDrivingLicenseViewB.GetLocalViews();
//    dataGridView1.Rows.Clear();

//    DataRow[] Records;
//    Records = Local.Select($"{ColumnName}= '{Filter}'");
//    foreach (DataRow Row in Records)
//    {
//        dataGridView1.Rows.Add(Row["LocalDrivingLicenseApplicationID"], Row["ClassName"], Row["NationalNum"], Row["FullName"], Row["ApplicationDate"],
//                               Row["PassedTestCount"], Row["Status"]);
//    }
//}
//if(dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Cancelled")
//    cmsScheduleTests.Enabled = false;
//else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Completed")
//{
//    cmsScheduleTests.Enabled = false;
//    cmsEdit.Enabled = false;
//    cmsCancel.Enabled = false;
//    cmsDelete.Enabled = false;
//    cmsShowLicense.Enabled = true;
//    cmsShowPersonLicense.Enabled = true;

//}
//else
//{
//    cmsScheduleTests.Enabled = true;

//}

//switch (dataGridView1.CurrentRow.Cells[5].Value.ToString())
//{
//    case "0":
//        cmsVisionTest.Enabled = true;
//        cmsStreetTest.Enabled = false;
//        cmsWrittenTest.Enabled = false;
//        break;
//    case "1":
//        cmsVisionTest.Enabled = false;
//        cmsWrittenTest.Enabled = true;
//        cmsStreetTest.Enabled = false;
//        break;

//    case "2":
//        cmsVisionTest.Enabled = false;
//        cmsWrittenTest.Enabled = false;
//        cmsStreetTest.Enabled = true;
//        break;

//    case "3":
//        cmsScheduleTests.Enabled = false;
//        cmsNewDriving.Enabled = true;
//        cmsShowPersonLicense.Enabled = true;
//        if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Completed")
//            cmsNewDriving.Enabled = false;
//        break;
//}