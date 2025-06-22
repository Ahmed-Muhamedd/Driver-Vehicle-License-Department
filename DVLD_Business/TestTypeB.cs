using DVLD__DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class TestTypeB
    {
        public enum enTestTypes { VisionTest = 1 , WrittenTest = 2 , StreetTest = 3}
        public enTestTypes TestTypeID { set; get; }
        public string TestTypeTitle { set; get; }
        public string TestTypeDiscription { set; get; }
        public decimal TestTypeFees { set; get; }

        private TestTypeB(enTestTypes TestID , string TestTitle , string TestDesc , decimal TestFees)
        {
            this.TestTypeID = TestID;
            this.TestTypeTitle = TestTitle;
            this.TestTypeFees = TestFees;
            this.TestTypeDiscription = TestDesc;

        }

        public static TestTypeB FindTestType(enTestTypes TestTypeID)
        {

            string TestTitle = "", TestDesc = "";
            decimal TestFees = 0;

            if (TestTypesData.FindTestType(ref TestTitle, (int)TestTypeID, ref TestDesc, ref TestFees))
                return new TestTypeB(TestTypeID, TestTitle, TestDesc, TestFees);
            else
                return null; 

        }


        public static DataTable GetAllTestTypes()
        {
            return TestTypesData.GetTestTypes();
        }

        public bool UpdateTestType()
        {
            return TestTypesData.UpdateTestTypes((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDiscription, this.TestTypeFees);
        }

        public bool Save()
        {

            return UpdateTestType() ? true : false;
        }
        public static byte ReturnTestTypeID(string TestTypeTitle)
        {
            return TestTypesData.ReturnTestTypeID(TestTypeTitle);
        }



    }
}
