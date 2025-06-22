using Driver___Vehicle_Licenses_Department__DVLD_.User_Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.People
{
    public partial class frmPersonDetails : Form
    {
      
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            personDetailsController1.LoadPersonInfo(PersonID);
         
        }

        public frmPersonDetails(string NationalNumber)
        {
            InitializeComponent();
            personDetailsController1.LoadPersonInfo(NationalNumber);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
