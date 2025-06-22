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

namespace Driver___Vehicle_Licenses_Department__DVLD_.Applications.Licenses
{
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        public frmLicenseHistory()
        {
            InitializeComponent();
        }

        private int _PersonID = -1;


        private void _HandleForumProcess()
        {
            if(_PersonID != -1)
            {
              ctrPersonCardWithFilter1.LoadPersonInfo(_PersonID);
              ctrPersonCardWithFilter1.FilteredEnabled = false;
              ctrLicenseHistory1.LoadInfoByPersonID(_PersonID);

            }
            else
            {
                ctrPersonCardWithFilter1.FilteredEnabled = true;
                ctrPersonCardWithFilter1.FilterFocus();
            }


        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _HandleForumProcess();
        }

        //private void ctrPersonCardWithFilter1_OnPersonSelected(int obj)
        //{
        //    _PersonID = obj;

        //    if (_PersonID == -1)
        //        ctrLicenseHistory1.Clear();
        //    else
        //        ctrPersonCardWithFilter1.LoadPersonInfo(_PersonID);
        //}
    }
}
