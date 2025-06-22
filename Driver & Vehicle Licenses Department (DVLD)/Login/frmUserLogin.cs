using DVLD_Business;
using System;
using System.Windows.Forms;
using System.IO;
namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void _SaveUserData(string UserName , string Password)
        {
            string Path = @"D:\Programming\Mohamed-Abu-Hadhud\Desktop Projects\DVLD\Driver & Vehicle Licenses Department (DVLD)\User.txt";
            
            StreamWriter Writer = new StreamWriter(Path);
            if (cbRemeber.Checked)
            {
            
                Writer.WriteLine(UserName);
                Writer.WriteLine(Password);
                Writer.Close();
            }
            else
            {
                Writer.Write("");
            }

            
        }
        //private void _ReadUserData()
        //{
        //    string Path = @"D:\Programming\Mohamed-Abu-Hadhud\Desktop Projects\DVLD\Driver & Vehicle Licenses Department (DVLD)\User.txt";

        //    StreamReader Reader = new StreamReader(Path);

        //    string[] UserLogin = new string[2];

        //    byte Counter = 0;
        //    string Line = "";
        //    while ((Line = Reader.ReadLine()) != null)
        //    {
        //        UserLogin[Counter] = Line;
        //        Counter++;
        //    }
        //    Reader.Close();

        //    tbUserName.Text = UserLogin[0];
        //    tbPassword.Text = UserLogin[1];

        //}
        private void _Login()
        {
            UsersB User = UsersB.FindUserByUserNameAndPassword(tbUserName.Text, tbPassword.Text);
            if (User == null)
            {
                MessageBox.Show("Invalid Username/Password.", "Wrong Credentials!", MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (!User.IsActive)
                {
                    MessageBox.Show("You Account Not Active, Contact Admin", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbRemeber.Checked)
                    GlobalUser._RememberUserNameAndPassword(tbUserName.Text.Trim(), tbPassword.Text.Trim());
                else
                    GlobalUser._RememberUserNameAndPassword( null , null);

                GlobalUser.User = User;
                this.Hide();
                Form frmMain = new Main(this);
                frmMain.ShowDialog();

            }


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void _HandleLoginCredential()
        {
            string UserName = "", Password = "";
            if(GlobalUser.GetStoredCredential(ref UserName , ref Password))
            {
                tbUserName.Text = UserName;
                tbPassword.Text = Password;
                cbRemeber.Checked = true;
            }
            else
            {
                tbUserName.Text = "";
                tbPassword.Text = "";
                cbRemeber.Checked = false;
            }
        }
        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            _HandleLoginCredential();
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRemeber_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
