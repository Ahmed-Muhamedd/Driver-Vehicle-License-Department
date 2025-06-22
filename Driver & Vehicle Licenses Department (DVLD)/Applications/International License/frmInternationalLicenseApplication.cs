using Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses;
using Driver___Vehicle_Licenses_Department__DVLD_.People;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.International_License
{
    public partial class frmInternationalLicenseApplication : Form
    {
        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private DataTable _dtAllInternationalLicense;

        private void _LoadAllInternationalLicenses()
        {
            _dtAllInternationalLicense = InternationalLicenseB.GetAllInternationalLicenses();
            dataGridView1.DataSource = _dtAllInternationalLicense;
            lCount.Text = dataGridView1.Rows.Count.ToString();
            cbFilter.SelectedIndex = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Int.License ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "Driver ID";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "L.License ID";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Issue Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Expiration Date";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Is Active";
                dataGridView1.Columns[6].Width = 80;

            }

        }
        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadAllInternationalLicenses();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense Form = new frmNewInternationalLicense();
            Form.ShowDialog();
        }

        private void showPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails Frm = new frmPersonDetails(DriverB.FindDriverByDriverID((int)dataGridView1.CurrentRow.Cells[2].Value).PersonID);
            Frm.ShowDialog();
        }

  
        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory Frm = new frmLicenseHistory(DriverB.FindDriverByDriverID((int)dataGridView1.CurrentRow.Cells[2].Value).PersonID);
            Frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo Frm = new frmInternationalLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            Frm.ShowDialog();
        }

        private void _FilterData()
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }
  


            if (tbFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllInternationalLicense.DefaultView.RowFilter = "";
                lCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }



            _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());

            lCount.Text = _dtAllInternationalLicense.Rows.Count.ToString();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilter.SelectedItem)
            {
                case "None":
                    tbFilter.Visible = false;
                    cbIsActive.Visible = false;
                    break;
                case "Is Active":
                    cbIsActive.SelectedIndex = 0;
                    tbFilter.Visible = false;
                    cbIsActive.Visible = true;
                    break;

                default:
                    tbFilter.Visible = true;
                    cbIsActive.Visible = false;
                    break;
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";

            if(cbIsActive.SelectedItem == "Yes")
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 1);
            else
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, 0);


        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
