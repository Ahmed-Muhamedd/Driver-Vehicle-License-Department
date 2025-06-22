using DVLD__DataAccess;
using System.Data;


namespace DVLD_Business
{
    public class ManageTestTypesB
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        private ManageTestTypesB(int ID, string Title, string Description, decimal Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            this.Description = Description;
        }

        public static ManageTestTypesB FindTest(int ID)
        {
            string Title = "" , Description = "";
            decimal Fees = 0;

            if (ManageTestTypesData.FindTest(ID , ref Title , ref Description , ref Fees))
                return new ManageTestTypesB(ID, Title, Description,Fees);
            else
                return null;
        }

        public static DataTable GetTestTypes()
        {
            return ManageTestTypesData.GetTestTypes();
        }

        private bool _Update()
        {
            return ManageTestTypesData.UpdateTestTypes(this.ID, this.Title, this.Description, this.Fees);
        }

        public bool Save()
        {
            if (_Update())
                return true;
            else
                return false;
        }
    }
}
