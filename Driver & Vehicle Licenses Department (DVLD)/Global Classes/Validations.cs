
using System.Text.RegularExpressions;
namespace Driver___Vehicle_Licenses_Department__DVLD_.Global_Classes
{
    public static class Validations
    {
        public static bool ValidateEmail(string Email)
        {
            var Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            var Regax = new Regex(Pattern);

            return Regax.IsMatch(Email);

        }

        public static bool ValidIntegar(string Number)
        {
            var Pattern = @"^[0-9]*$";

            var Regax = new Regex(Pattern);

            return Regax.IsMatch(Number);
        }
     

    }
}
