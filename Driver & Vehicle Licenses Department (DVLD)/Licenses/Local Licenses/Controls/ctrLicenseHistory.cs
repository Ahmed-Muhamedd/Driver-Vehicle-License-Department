using Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License;
using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses
{
    public partial class ctrLicenseHistory : UserControl
    {
        public ctrLicenseHistory()
        {
            InitializeComponent();

        }


   
        private int _DriverID { set; get; }
        private DriverB _Driver { set; get; }
        private DataTable _dtAllLocalLicenseHistory;
        private DataTable _dtAllInternationalHistory;

        private void _LoadLocalLicenses()
        {
            _dtAllLocalLicenseHistory = DriverB.GetLicenses(_DriverID);
            dataGridView1.DataSource = _dtAllLocalLicenseHistory;
            lRecordLocal.Text  =  dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Lic.ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "App.ID";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Class Name";
                dataGridView1.Columns[2].Width = 270;

                dataGridView1.Columns[3].HeaderText = "Issue Date";
                dataGridView1.Columns[3].Width = 170;

                dataGridView1.Columns[4].HeaderText = "Expiration Date";
                dataGridView1.Columns[4].Width = 170;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 110;
            }
        }


        private void _LoadInterNationalLicenses()
        {
            _dtAllInternationalHistory = DriverB.GetDriverInternationalLicenses(_DriverID);
            dataGridView2.DataSource = _dtAllInternationalHistory;
            lRecords.Text = dataGridView2.Rows.Count.ToString();

            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Columns[0].HeaderText = "International ID";
                dataGridView2.Columns[0].Width = 120;

                dataGridView2.Columns[1].HeaderText = "Application ID";
                dataGridView2.Columns[1].Width = 120;

                dataGridView2.Columns[2].HeaderText = "Local License ID";
                dataGridView2.Columns[2].Width = 150;

                dataGridView2.Columns[3].HeaderText = "Issue Date";
                dataGridView2.Columns[3].Width = 100;

                dataGridView2.Columns[4].HeaderText = "Expiration Date";
                dataGridView2.Columns[4].Width = 150;

                dataGridView2.Columns[5].HeaderText = "Is Active";
                dataGridView2.Columns[5].Width = 130;

            }
        }


        public void LoadInfoByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = DriverB.FindDriverByDriverID(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show("There Is No Driver With This Driver ID = " + DriverID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenses();
            _LoadInterNationalLicenses();
        }


        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = DriverB.FindDriver(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("There Is No Driver With This Person ID = " + PersonID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
             _DriverID = _Driver.DriverID;

            _LoadLocalLicenses();
           _LoadInterNationalLicenses();
        }


        public void Clear()
        {
            _dtAllInternationalHistory.Clear();
            _dtAllLocalLicenseHistory.Clear();
        }

        private void ctrLicenseHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo Frm = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo Frm = new frmInternationalLicenseInfo((int)dataGridView2.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
        }
    }
}
