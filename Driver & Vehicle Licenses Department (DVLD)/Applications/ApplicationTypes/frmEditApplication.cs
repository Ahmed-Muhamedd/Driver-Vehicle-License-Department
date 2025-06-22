using Driver___Vehicle_Licenses_Department__DVLD_.Global_Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications
{
    public partial class frmEditApplication : Form
    {
        public frmEditApplication(int ID)
        {
            InitializeComponent();
            this._ID = ID;
        }
        private int _ID { get; }

        private ApplicationTypesB App;

        public event Action OnSaveButton;


        private void _SetData()
        {
             App = ApplicationTypesB.FindApplicationType(_ID);
            if (App == null)
                return;

            lUserID.Text = App.ID.ToString();
            lTitle.Text = App.Title;
            lFees.Text = App.Fees.ToString();

        }
        private void frmEditApplication_Load(object sender, EventArgs e)
        {
            _SetData();
        }

        private void _LoadData()
        {
            App.Title = lTitle.Text;
            App.Fees = Convert.ToDecimal(lFees.Text);

            if (App.Save())
                MessageBox.Show("Updates", "Comfirm!", MessageBoxButtons.OK);
            else
                MessageBox.Show("Failed", "Comfirm!", MessageBoxButtons.OK);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are some fields not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadData();
            OnSaveButton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(lTitle, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(lTitle, "");
            }
        }

        private void lFees_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void lFees_KeyPress(object sender, KeyPressEventArgs e)
        {
           
           // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void lFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(lFees, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(lFees, "");
            }

            if (!Validations.ValidIntegar(lFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(lFees, "This Field Cannot Be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(lFees, "");
            }
        }
    }
}
