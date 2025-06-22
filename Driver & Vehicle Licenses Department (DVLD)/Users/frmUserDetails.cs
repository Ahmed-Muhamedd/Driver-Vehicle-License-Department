using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            ctrUserInfo1.LoadUserInfo(UserID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
