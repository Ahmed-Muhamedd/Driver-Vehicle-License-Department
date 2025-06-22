using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.People;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Detained_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private DataTable _dtAllDetainedLicense;

        private void _LoadData()
        {
            cbFilter.SelectedIndex = 0;

            _dtAllDetainedLicense = DetainLicenseB.GetAllDetainLicense();

            dataGridView1.DataSource = _dtAllDetainedLicense;
            lCount.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "D.ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "L.ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "D.Date";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Is Released";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Fine Fees";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Release Date";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "N.No.";
                dataGridView1.Columns[6].Width = 90;

                dataGridView1.Columns[7].HeaderText = "Full Name";
                dataGridView1.Columns[7].Width = 150;

                dataGridView1.Columns[8].HeaderText = "Rlease App.ID";
                dataGridView1.Columns[8].Width = 100;

            }
        }

   

        private void _HandleFilterOnData()
        {
            string FilterColumn = "";

            switch (cbFilter.SelectedItem)
            {
                case "DetainID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    
                    FilterColumn = "IsReleased";
                    break;
                   

                case "National Number":
                    FilterColumn = "NationalNum";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release ApplicationID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (tbFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDetainedLicense.DefaultView.RowFilter = "";
                lCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtAllDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());
            else
                _dtAllDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilter.Text.Trim());

            lCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _LoadData();
        }


        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _HandleFilterOnData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem)
            {
                case "None":
                    _LoadData();
                    tbFilter.Visible = false;
                    cbIsReleased.Visible = false;
                    break;

                case "Is Released":
                    cbIsReleased.SelectedIndex = 0;
                    cbIsReleased.Visible = true;
                    tbFilter.Visible = false;
                    break;
                default:
                    cbIsReleased.Visible = false;
                    tbFilter.Visible = true;
                    break;

            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense Frm = new frmReleaseDetainedLicense();
            Frm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainedLicense Frm = new frmDetainedLicense();
            Frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails Frm = new frmPersonDetails(PeopleBusiness.FindPerson((string)dataGridView1.CurrentRow.Cells[6].Value).PersonID);
            Frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseInfo Frm = new frmLicenseInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            Frm.ShowDialog();
        }

    
        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory Frm = new frmLicenseHistory(PeopleBusiness.FindPerson((string)dataGridView1.CurrentRow.Cells[6].Value).PersonID);
            Frm.ShowDialog();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.SelectedItem == "Release ApplicationID" || cbFilter.SelectedItem == "DetainID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dataGridView1.CurrentRow.Cells[3].Value;
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";

            if(cbIsReleased.SelectedItem.ToString() == "Yes")
                _dtAllDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 1);
            else
                _dtAllDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 0);


        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense Frm = new frmReleaseDetainedLicense((int)dataGridView1.CurrentRow.Cells[1].Value);
            Frm.ShowDialog();
        }
    }
}

//private void _LoadData()
//{
//    DataTable DetainLicenses = DetainLicenseB.GetAllDetainLicense();
//    dataGridView1.Rows.Clear();

//    foreach (DataRow Row in DetainLicenses.Rows)
//    {
//        dataGridView1.Rows.Add(Row["DetainID"], Row["LicenseID"], Row["DetainDate"], Row["IsReleased"]
//            , Row["FineFees"], Row["ReleaseDate"], Row["NationalNum"], Row["FullName"], Row["ReleaseApplicationID"]);
//    }

//    lCount.Text = dataGridView1.Rows.Count.ToString();
//}

//private void _FilterData(string ColumnName)
//{
//    DataTable DetainLicenses = DetainLicenseB.GetAllDetainLicense();
//    dataGridView1.Rows.Clear();

//    DataRow[] Result = DetainLicenses.Select($"{ColumnName} = '{tbFilter.Text}'");

//    foreach (DataRow Row in Result)
//    {
//        dataGridView1.Rows.Add(Row["DetainID"], Row["LicenseID"], Row["DetainData"], Row["IsReleased"]
//            , Row["FineFees"], Row["ReleaseDate"], Row["NationalNum"], Row["FullName"], Row["ReleaseApplicationID"]);
//    }

//}


//private void _ChooseFilterColumn()
//{
//    switch (cbFilter.SelectedItem)
//    {
//        case "None":
//            _LoadData();
//            break;

//        case "DetainID":
//            _FilterData("DetainID");
//            break;

//        case "Is Released":
//            _FilterData("IsReleased");
//            break;


//        case "National Number":
//            _FilterData("NationalNum");
//            break;


//        case "Full Name":
//            _FilterData("FullName");
//            break;

//        case "Release ApplicationID":
//            _FilterData("ReleaseApplicationID");
//            break;
//    }
//}

