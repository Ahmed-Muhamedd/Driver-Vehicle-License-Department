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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            DataTable AllApplicationTypes = ApplicationTypesB.GetApplicationTypes();
            dataGridView1.DataSource = AllApplicationTypes;
            lCount.Text = dataGridView1.Rows.Count.ToString();
            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 230;

                dataGridView1.Columns[2].HeaderText = "Fees";
                dataGridView1.Columns[2].Width = 80;
            }
           
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplication frm = new frmEditApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.OnSaveButton += _LoadData;
            frm.ShowDialog();
        }


        //Another Solution Using Datatable Direct :)
        //private void _LoadData()
        //{
        //    DataTable Table = ApplicationTypesB.GetApplicationTypes();
        //    dataGridView1.Rows.Clear();

        //    foreach (DataRow Row in Table.Rows)
        //    {
        //        dataGridView1.Rows.Add(Row["ApplicationTypeID"], Row["ApplicationTypeTitle"], Row["ApplicationFees"]);
        //    }
        //    lCount.Text = Table.Rows.Count.ToString();
        //}

    }
}
