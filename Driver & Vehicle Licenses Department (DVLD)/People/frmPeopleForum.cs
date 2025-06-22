using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Serialization;
namespace Driver___Vehicle_Licenses_Department__DVLD_.People
{
    public partial class frmPeopleForum : Form
    {
        private static DataTable _dtAllPeople = PeopleBusiness.LoadPeopleData();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNum",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "Nationality",
                                                       "Phone", "Email");

        public frmPeopleForum()
        {
            InitializeComponent();
        }

        private void _RefreshAllPeople()
        {
            _dtAllPeople = PeopleBusiness.LoadPeopleData();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNum",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "Nationality",
                                                       "Phone", "Email");
            dataGridView1.DataSource = _dtPeople;
            lCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void _HandleFilterPeople()
        {
            string FilterColumn = "";
            switch (cbFilter.SelectedItem)
            {

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "National Number":
                    FilterColumn = "NationalNum";
                    break;

                case "Nationality":
                    FilterColumn = "Nationality";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if(tbFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, tbFilter.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, tbFilter.Text.Trim());

            lCount.Text = dataGridView1.Rows.Count.ToString();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAdUpdateForum = new frmAddUpdatePerson();
            frmAdUpdateForum.OnSaveButton += _RefreshAllPeople;
            frmAdUpdateForum.ShowDialog();
        }


        private void _HandleDataToTable()
        {
            dataGridView1.DataSource = _dtPeople;
            cbFilter.SelectedIndex = 0;
            lCount.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 85;

                dataGridView1.Columns[1].HeaderText = "National Number";
                dataGridView1.Columns[1].Width = 120;


                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 100;


                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "Gender";
                dataGridView1.Columns[6].Width = 80;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 100;
   
                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 85;


                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 100;


                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 130;
            }
        }

        private void frmPeopleForum_Load(object sender, EventArgs e)
        {
            _HandleDataToTable();
        }

        private void personDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDetails = new frmPersonDetails((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmDetails.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAdUpdateForum = new frmAddUpdatePerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmAdUpdateForum.OnSaveButton += _RefreshAllPeople;
            frmAdUpdateForum.ShowDialog();

        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAdUpdateForum = new frmAddUpdatePerson();
            frmAdUpdateForum.OnSaveButton += _RefreshAllPeople;
            frmAdUpdateForum.ShowDialog();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are You Sure You Want To Delete This Person {dataGridView1.CurrentRow.Cells[0].Value}", "Confirm Delete",MessageBoxButtons.OKCancel, MessageBoxIcon.Information ) == DialogResult.OK)
            {
                if (PeopleBusiness.DeletePerson((int)dataGridView1.CurrentRow.Cells[0].Value)) 
                {
                    MessageBox.Show("Person Deleted Successfully", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllPeople();

                }
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Visible = (cbFilter.SelectedItem.ToString() != "None");

            if (tbFilter.Visible)
            {
                tbFilter.Text = "";
                tbFilter.Focus();
            }

        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            _HandleFilterPeople();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.Text.ToString() == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }



        //Another Solution Using DataTable Direct Without DataView 

        //private void _RefreshPeopleList()
        //{
        //    _dtAllPeople = PeopleBusiness.LoadPeopleData();

        //    _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNumber",
        //                          "FirstName", "SecondName", "ThirdName", "LastName",
        //                          "GendorCaption", "DateOfBirth", "Nationality",
        //                          "Phone", "Email");

        //    dataGridView1.DataSource = _dtPeople;
        //    lCount.Text = _dtPeople.Rows.Count.ToString();
        //}


        //private void _LoadData()
        //{
        //    switch (cbFilter.SelectedItem)
        //    {
        //        case "None":
        //            _LoadAllPeople();
        //            break;

        //        case "Person ID":
        //            if (int.TryParse(tbFilter.Text, out int PersonID))

        //            {
        //                _LoadFilteredPeople( "PersonID", PersonID.ToString());
        //            }
        //            break;

        //        case "First Name":
        //            _LoadFilteredPeople( "FirstName" , tbFilter.Text);
        //            break;

        //        case "Second Name":
        //            _LoadFilteredPeople( "SecondName", tbFilter.Text);
        //            break;

        //        case "Third Name":
        //            _LoadFilteredPeople( "ThirdName" ,tbFilter.Text);
        //            break;

        //        case "Last Name":
        //            _LoadFilteredPeople( "LastName" ,tbFilter.Text);
        //            break;

        //        case "National Number":
        //            _LoadFilteredPeople("NationalNum" , tbFilter.Text);
        //            break;

        //        case "Nationality":
        //            _LoadFilteredPeople("Nationality" ,tbFilter.Text);
        //            break;

        //        case "Gender":
        //            _LoadFilteredPeople("Gender" , tbFilter.Text);
        //            break;

        //        case "Phone":
        //            _LoadFilteredPeople("Phone" ,tbFilter.Text);
        //            break;

        //        case "Email":
        //            _LoadFilteredPeople("Email" , tbFilter.Text);
        //            break;
        //    }
        //}

        //private void _LoadFilteredPeople(string ColumnName, string Filter)
        //{
        //    DataTable People = PeopleBusiness.LoadPeopleData();
        //    dataGridView1.Rows.Clear();

        //    DataRow[] Records;
        //    Records = People.Select($"{ColumnName}= '{Filter}'");
        //    foreach (DataRow Row in Records)
        //    {
        //        dataGridView1.Rows.Add(Row["PersonID"], Row["NationalNum"], Row["FirstName"], Row["SecondName"], Row["ThirdName"], Row["LastName"],
        //            Row["Gender"], Row["DateOfBirth"], Row["Nationality"], Row["Phone"], Row["Email"]);
        //    }
        //}
        //private void _LoadAllPeople()
        //{
        //    DataTable People = PeopleBusiness.LoadPeopleData();


        //    dataGridView1.Rows.Clear();

        //    foreach (DataRow Row in People.Rows)
        //    {
        //        dataGridView1.Rows.Add(Row["PersonID"], Row["NationalNum"], Row["FirstName"], Row["SecondName"], Row["ThirdName"], Row["LastName"],
        //            Row["Gender"], Row["DateOfBirth"], Row["Nationality"], Row["Phone"], Row["Email"]);
        //    }

        //}
        //private string _CountPeople()
        //{

        //    DataTable People = PeopleBusiness.LoadPeopleData();

        //    return Convert.ToString(People.Rows.Count);
        //}
    }
}

