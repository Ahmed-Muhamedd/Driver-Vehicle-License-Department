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
using System.Xml.Serialization;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public partial class frmManageUsers : Form
    {
        private DataTable _dtAllUsers;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUserData()
        {
            _dtAllUsers = UsersB.GetAllUsers();
            dataGridView1.DataSource = _dtAllUsers;
            lCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
        }



        private void _DataFilterByColumn()
        {
            string FilterColumn = "";
            switch (comboBox1.SelectedItem)
            {
                case "None":
                    FilterColumn = "None";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;            
            }

            if(tbFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lCount.Text = dataGridView1.Rows.Count.ToString();
            }

            if(FilterColumn != "FullName" && FilterColumn != "UserName")
               _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}" , FilterColumn , tbFilter.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, tbFilter.Text.Trim());

            lCount.Text = dataGridView1.Rows.Count.ToString();

        }

        private void _HandleTableStructure()
        {
            _dtAllUsers = UsersB.GetAllUsers();
            dataGridView1.DataSource = _dtAllUsers;
            comboBox1.SelectedIndex = 0;
            lCount.Text = dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 80;

                dataGridView1.Columns[2].HeaderText = "Full Name";
                dataGridView1.Columns[2].Width = 230;

                dataGridView1.Columns[3].HeaderText = "UserName";
                dataGridView1.Columns[3].Width = 95;

                dataGridView1.Columns[4].HeaderText = "Is Active";
                dataGridView1.Columns[4].Width = 100;
            }
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _HandleTableStructure(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Is Active")
            {
                tbFilter.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else 
            {
                tbFilter.Visible = (comboBox1.SelectedItem.ToString() != "None");
                cbIsActive.Visible = false;
                tbFilter.Text = "";
            }
          
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _DataFilterByColumn();
        }

        private void _HandleIsActiveComboBox() 
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;

                default:
                    FilterValue = "All";
                    break;

            }

            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}" , FilterColumn , FilterValue);

            lCount.Text = dataGridView1.Rows.Count.ToString();

        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HandleIsActiveComboBox();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UsersB.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Deleted", "Confirm!", MessageBoxButtons.OK);
                _RefreshUserData();
            }
            else
                MessageBox.Show("User Not Deleted", "Confirm!", MessageBoxButtons.OK);
            
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnSaveButton += _RefreshUserData;
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Method Will Added Soon", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Method Will Added Soon", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void tbFilter_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Person ID" || comboBox1.SelectedItem.ToString() == "User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }




        //Another Solution Using DataTable Direct Without Default View :)
        //private void _LoadUsersData()
        //{

        //    DataTable UsersTable = UsersB.GetAllUsers();
        //    dataGridView1.Rows.Clear();

        //    foreach (DataRow Row in UsersTable.Rows)
        //    {
        //        dataGridView1.Rows.Add(Row["UserID"], Row["PersonID"], Row["FullName"], Row["UserName"], Row["IsActive"]);

        //    }
        //}

        //private string _UsersCount()
        //{
        //    DataTable UsersTable = UsersB.GetAllUsers();
        //    return UsersTable.Rows.Count.ToString();
        //}

        //private void _LoadUserDataWithFilter(string ColumnName, string FilterBy)
        //{

        //    DataTable UsersTable = UsersB.GetAllUsers();
        //    dataGridView1.Rows.Clear();

        //    DataRow[] FilteredRows;

        //    FilteredRows = UsersTable.Select($"{ColumnName} = '{FilterBy}'");

        //    foreach (DataRow Row in FilteredRows)
        //    {
        //        dataGridView1.Rows.Add(Row["UserID"], Row["PersonID"], Row["FullName"], Row["UserName"], Row["IsActive"]);

        //    }

        //}

        //private void _FilterBy()
        //{
        //    switch (comboBox1.SelectedItem)
        //    {
        //        case "None":
        //            _LoadUsersData();
        //            break;

        //        case "User ID":
        //            if (int.TryParse(tbFilter.Text, out int PersonID))
        //                _LoadUserDataWithFilter("UserID", PersonID.ToString());
        //            break;

        //        case "Person ID":
        //            _LoadUserDataWithFilter("PersonID", tbFilter.Text);
        //            break;

        //        case "UserName":
        //            _LoadUserDataWithFilter("UserName", tbFilter.Text);
        //            break;

        //        case "Full Name":
        //            _LoadUserDataWithFilter("FullName", tbFilter.Text);

        //            break;
        //    }
        //}

    }
}
