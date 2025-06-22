using DVLD_Business;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
namespace Driver___Vehicle_Licenses_Department__DVLD_.Users
{
    public class GlobalUser
    {

        public static UsersB User;

        public static bool _RememberUserNameAndPassword(string UserName , string Password)
        {
            const string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            const string ValueNameOfUserName = "UserName";
            const string ValueNameOfPassword = "Password";
            try
            {
                if(UserName == null && Password == null)
                {
                    Registry.SetValue(keyPath, ValueNameOfUserName, "");
                    Registry.SetValue(keyPath, ValueNameOfPassword, "");
                }
                else
                {
                     Registry.SetValue(keyPath, ValueNameOfUserName, UserName);
                    Registry.SetValue(keyPath, ValueNameOfPassword, Password);

                }

                return true;

            }catch(Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }

            //try
            //{

            //    string CurrentDirectory = Directory.GetCurrentDirectory();

            //    string FilePath = Path.Combine(CurrentDirectory, "User.txt");

            //    using (StreamWriter Writer = new StreamWriter(FilePath))
            //    {
            //        if (UserName == "" || UserName == null)
            //            Writer.Write(string.Empty);
            //        else
            //        {
            //            string DataToSave = UserName + "#//#" + Password;
            //            Writer.WriteLine(DataToSave);
            //        }
                   
            //        return true;
            //    }


            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show($"An Error In Remember User {Ex.Message}", "Error");
            //    return false;
            //}

        }

        public static bool GetStoredCredential(ref string UserName , ref string Password)
        {


            const string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            const string ValueNameOfUserName = "UserName";
            const string ValueNameOfPassword = "Password";
            try
            {

                UserName = (string)Registry.GetValue(keyPath, ValueNameOfUserName, null);
                Password = (string)Registry.GetValue(keyPath, ValueNameOfPassword, null);

                if (UserName != null && Password != null)
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                return false;
            }

            //try
            //{

            //    string CurrentDirectory = Directory.GetCurrentDirectory();

            //    string FilePath = Path.Combine(CurrentDirectory, "User.txt");


            //    if (File.Exists(FilePath))
            //    {
            //        using (StreamReader Reader = new StreamReader(FilePath))
            //        {
            //            string Data;

            //            if((Data = Reader.ReadLine()) != null)
            //            {
            //                string[] Result = Data.Split(new string[] { "#//#" }, StringSplitOptions.None);
            //                UserName = Result[0];
            //                Password = Result[1];
            //                return true;

            //            }

            //            return false;

            //        }
            //    }
            //    else
            //        return false;

            //}catch(Exception Ex)
            //{
            //    return false;
            //}


        }

    }
}
