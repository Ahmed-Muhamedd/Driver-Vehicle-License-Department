using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.CompilerServices;
using DVLD__DataAccess;

namespace DVLD_Business
{
    public class PeopleBusiness
    {
        public int PersonID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }

        public CountriesB CountryInfo;
        private enum _enMode { AddNew , Update};
        private _enMode _Mode = _enMode.Update;

        public PeopleBusiness()
        {
            this.PersonID = -1;
            this.NationalNumber = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryID = -1;
            this.ImagePath = "";
            _Mode = _enMode.AddNew;
        }

        private PeopleBusiness(int PersonID,string NationalNum, string FirstName, string SecondName
          , string ThirdName, string LastName, DateTime DateOfBirth, byte Gender, string Address, string Phone
          , string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNumber = NationalNum;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = CountriesB.FindCountryByID(NationalityCountryID);
            _Mode = _enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = People.AddNewPerson(this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return People.UpdatePerson(this.PersonID, this.NationalNumber, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }

        public string FullName()
        {
            return this.FirstName + " " + this.SecondName + " " + this.ThirdName + " " + this.LastName;
        }
        public static PeopleBusiness FindPerson(int PersonID)
        {
            string NationalNumber = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int ID = PersonID, CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;

            if (People.FindPeoplePersonID(ID, ref NationalNumber, ref FirstName, ref SecondName, ref ThirdName, ref LastName
                , ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))

                return new PeopleBusiness(ID, NationalNumber, FirstName, SecondName, ThirdName, LastName
                    , DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
            else

                return null;
        }

        public static PeopleBusiness FindPerson(string  NationalNumber)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int PersonID = -1 , CountryID = 0;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;

            if (People.FindPeopleNationalNumber(ref PersonID,  NationalNumber, ref FirstName, ref SecondName, ref ThirdName, ref LastName
                , ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))

                return new PeopleBusiness(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName
                    , DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
            else

                return null;
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case _enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        _Mode = _enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case _enMode.Update:

                    return _UpdatePerson();

                default:
                    return false;
            }

        }

        public static bool IsPersonExists(int PersonID)
        {
            return People.IsPersonExist(PersonID);
        }

        public static bool IsPersonExists(string NationalNumber)
        {
            return People.IsPersonExist(NationalNumber);

        }

        private static bool DeleteImagePath(int PersonID)
        {
            string ImagePath = PeopleBusiness.FindPerson(PersonID).ImagePath;
            if (File.Exists(ImagePath))
            {
                File.Delete(ImagePath);
                return true;
            }
            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            if (DeleteImagePath(PersonID))
            {
                People.DeletePerson(PersonID);
                return true;
            }
            return false;
        }

        public static DataTable LoadPeopleData()
        {
            return People.GetAllPeople();
        }


        // Will Deleted Usless

        public static int GetPersonID(string NationalNumber)
        {
            return People.GetPersonID(NationalNumber);
        }
    }
}
