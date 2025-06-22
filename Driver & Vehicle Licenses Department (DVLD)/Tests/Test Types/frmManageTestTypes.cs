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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }


        private void _LoadData()
        {
            _dtAllTestTypes = TestTypeB.GetAllTestTypes();
            dataGridView1.DataSource = _dtAllTestTypes;
            lCount.Text = dataGridView1.Rows.Count.ToString();

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "TestType ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 130;

                dataGridView1.Columns[2].HeaderText = "Description";
                dataGridView1.Columns[2].Width= 450;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 80;



            }
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestTypes frm = new frmEditTestTypes((TestTypeB.enTestTypes)dataGridView1.CurrentRow.Cells[0].Value);
            frm.OnSaveButton += _LoadData;
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // Using Datatable Direct Without Default View
        //private void _LoadData()
        //{
        //    DataTable Table = ManageTestTypesB.GetTestTypes();
        //    dataGridView1.Rows.Clear();

        //    foreach (DataRow Row in Table.Rows)
        //    {
        //        dataGridView1.Rows.Add(Row["TestTypeID"], Row["TestTypeTitle"], Row["TestTypeDescription"], Row["TestTypeFees"]);
        //    }

        //    lCount.Text = Table.Rows.Count.ToString();
        //}

    }
}
