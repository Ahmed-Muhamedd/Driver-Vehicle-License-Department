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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses
{
    public partial class frmManageDrivers : Form
    {

        private DataTable _AllDrivers;

        public frmManageDrivers()
        {
            InitializeComponent();
        }


        private void _LoadData()
        {
            cbFilter.SelectedIndex = 0;
            _AllDrivers = DriverB.GetAllDrivers();
            dataGridView1.DataSource = _AllDrivers;
            lRecord.Text = dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width= 100;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "National Number";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 200;

                dataGridView1.Columns[4].HeaderText = "Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Active License";
                dataGridView1.Columns[5].Width = 100;

            }

        }



        private void _FilterBy()
        {
            string FilterColumn = "";

            switch (cbFilter.SelectedItem)
            {
                case "None":
                    FilterColumn = "None";
                    break;

                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "DriverID":
                    FilterColumn = "DriverID";

                    break;

                case "National Number":
                    FilterColumn = "NationalNum";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;
            }



            if (tbFilter.Text.Trim() == "" || FilterColumn == "None")
                _AllDrivers.DefaultView.RowFilter = "";

            if (FilterColumn == "PersonID" || FilterColumn == "DriverID")
                _AllDrivers.DefaultView.RowFilter = string.Format("{0} = '{1}'", FilterColumn, tbFilter.Text.Trim());
            else
                _AllDrivers.DefaultView.RowFilter = string.Format("{0} Like '{1}%'", FilterColumn, tbFilter.Text.Trim());


        }



        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            
            _LoadData();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterBy();

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = cbFilter.SelectedItem != "None";

        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem == "PersonID" || cbFilter.SelectedItem == "DriverID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails Frm = new frmPersonDetails((int)dataGridView1.CurrentRow.Cells[1].Value);
            Frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory Frm = new frmLicenseHistory((int)dataGridView1.CurrentRow.Cells[1].Value);
            Frm.ShowDialog();
        }

     
    }
}


//private void _LoadData()
//{
//    DataTable Drivers = Drivers_ViewB.GetAllDrivers();
//    dataGridView1.Rows.Clear();
//    foreach (DataRow Row in Drivers.Rows)
//    {
//        dataGridView1.Rows.Add(Row["DriverID"], Row["PersonID"], Row["NationalNum"], Row["FullName"], Row["CreatedDate"], Row["NumberOfActiveLicenses"]);

//    }

//    lRecord.Text = Drivers.Rows.Count.ToString();
//}

//private void _FilterDrivers(string ColumnName, string FilterBy)
//{
//    DataTable Drivers = Drivers_ViewB.GetAllDrivers();
//    dataGridView1.Rows.Clear();

//    DataRow[] Rows;
//    Rows = Drivers.Select($"{ColumnName} = '{FilterBy}'");

//    foreach (DataRow Row in Rows)
//    {
//        dataGridView1.Rows.Add(Row["DriverID"], Row["PersonID"], Row["NationalNum"], Row["FullName"], Row["CreatedDate"], Row["NumberOfActiveLicenses"]);

//    }


//}

//private void _FilterBy()
//{
//    switch (cbFilter.SelectedItem)
//    {
//        case "None":
//            _LoadData();
//            break;

//        case "PersonID":
//            if (int.TryParse(tbFilter.Text, out int PersonID))
//                _FilterDrivers("PersonID", PersonID.ToString());
//            break;

//        case "DriverID":
//            if (int.TryParse(tbFilter.Text, out int DriverID))
//                _FilterDrivers("DriverID", DriverID.ToString());

//            break;

//        case "National Number":
//            _FilterDrivers("NationalNum", tbFilter.Text);
//            break;

//        case "Full Name":
//            _FilterDrivers("FullName", tbFilter.Text);
//            break;
//    }
//}
