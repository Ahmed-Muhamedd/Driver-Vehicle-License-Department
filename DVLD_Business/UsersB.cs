using DVLD__DataAccess;
using Microsoft.Win32;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;




namespace DVLD_Business
{
    public class UsersB
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public PeopleBusiness PersonInfo;
        private enum _enMode { Addnew , Update};

        private _enMode Mode = _enMode.Update;
        public UsersB()
        {
            this.PersonID = -1;
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            Mode = _enMode.Addnew;
        }

        private UsersB(int UserID , int PersonID , string UserName , string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = PeopleBusiness.FindPerson(PersonID);
            Mode = _enMode.Update;
        }

        public static UsersB FindUserByPersonID(int PersonID)
        {
            int UserID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (UsersData.FindUserByPersonID(PersonID, ref UserID, ref UserName, ref Password, ref IsActive))
                return new UsersB(UserID, PersonID, UserName, Password, IsActive);
            else
                return null; 

        }

        public static UsersB FindUserByUserID(int UserID)
        {
            int PID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            if (UsersData.FindUserByUserID(ref PID,  UserID, ref UserName, ref Password, ref IsActive))
                return new UsersB(UserID, PID, UserName, Password, IsActive);
            else
                return null;

        }

        public static UsersB FindUserByUserNameAndPassword(string UserName , string UserPassword)
        {
            int PersonID = 0, UserID = 0;
            bool IsActive = false;
            string HashedPassword = HashPassword(UserPassword);
            if (UsersData.FindUserByUserNameAndPassword(ref PersonID,  ref UserID,  UserName, HashedPassword, ref IsActive))
                return new UsersB(UserID, PersonID, UserName, HashedPassword, IsActive);
            else
                return null;

        }

        public static bool IsPersonIsUser(int PersonID)
        {
            return UsersData.IsPersonIsUser(PersonID);
        }

        public static bool IsUserExists(int UserID)
        {
            return UsersData.IsUserExists(UserID);
        }

        public static bool IsUserExists(string UserName)
        {
            return UsersData.IsUserExists(UserName);
        }
        private bool _AddNewUser()
        {
            string HashedPassword = HashPassword();
            this.UserID = UsersData.AddNewUser(this.PersonID, this.UserName, HashedPassword, this.IsActive);
            return this.UserID != -1;
        }

        private string HashPassword()
        {
            using(SHA256 Sha = SHA256.Create())
            {
                byte[] Hashing = Sha.ComputeHash(Encoding.UTF8.GetBytes(this.Password));

                return BitConverter.ToString(Hashing).Replace("-", "").ToLower();
            }
        }
        private static string HashPassword(string Password)
        {
            using (SHA256 Sha = SHA256.Create())
            {
                byte[] Hashing = Sha.ComputeHash(Encoding.UTF8.GetBytes(Password));

                return BitConverter.ToString(Hashing).Replace("-", "").ToLower();
            }
        }

        private bool UpdateUser() 
        {

            string HashedPassword = HashPassword();
            return UsersData.UpdateUser(this.UserID, this.UserName, HashedPassword, this.IsActive);
        
        }

        public bool Save()
        {
            switch (Mode)
            {
                case _enMode.Addnew:
                    _AddNewUser();
                    Mode = _enMode.Update;
                    return true;

                case _enMode.Update:
                    UpdateUser();
                    return true;

                default:
                    return false;

            }
        }

        public static DataTable GetAllUsers()
        {
            return UsersData.GetAllUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return UsersData.DeleteUser(UserID);
        }

        public  bool ChangePassword(string Password)
        {
            return UsersData.ChangePassword(this.UserID, Password);
        }
    }
}
