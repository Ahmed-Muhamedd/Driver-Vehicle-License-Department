using DVLD_Business;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.People.User_Controller
{
    public partial class ctrPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;

        public virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;
            if (Handler != null)
                Handler(PersonID);
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }

            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Enabled = _ShowAddPerson;
            }
        }

        private bool _FilteredEnabled = true;

        public bool FilteredEnabled
        {
            get
            {
                return _FilteredEnabled;
            }
            set
            {
                _FilteredEnabled = value;
                gbFilter.Enabled = _FilteredEnabled;
            }
        }

        public int PersonID
        {
            get { return ctrPersonCard1.PersonID; }
        }

        public PeopleBusiness PersonInfo
        {
            get { return ctrPersonCard1.PersonInfo; }
        }

        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 0;
            tbFilter.Text = PersonID.ToString();
            _SearchForPerson();
        }

        private void _SearchForPerson()
        {
            switch (cbFilter.SelectedItem)
            {
                case "Person ID":
                   
                    if (int.TryParse(tbFilter.Text, out int PersonID))
                        ctrPersonCard1.LoadPersonInfo(PersonID);
                    break;

                case "National Number":
                    if (tbFilter.Text != "")
                        ctrPersonCard1.LoadPersonInfo(tbFilter.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilteredEnabled)
                OnPersonSelected(ctrPersonCard1.PersonID);

        }

        public void FilterFocus()
        {
            tbFilter.Focus();
        }
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fields Are Not Valid", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SearchForPerson();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson Frm = new frmAddUpdatePerson();
            Frm.DataBack += DataBackEvent;
            Frm.ShowDialog();
        }

        private void DataBackEvent(object sender , int PersonID)
        {
            cbFilter.SelectedIndex = 0;
            tbFilter.Text = PersonID.ToString();
            ctrPersonCard1.LoadPersonInfo(PersonID);
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = "";
            tbFilter.Focus();
        }

        private void ctrPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            tbFilter.Focus();
        }

        private void tbFilter_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbFilter, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(tbFilter, null);
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindUser.PerformClick();

            if(cbFilter.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }
    }
}
