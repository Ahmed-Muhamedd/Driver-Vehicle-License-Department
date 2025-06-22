
using System.Configuration;

namespace DVLD__DataAccess
{
    static internal class Connection
    {
        public static string ConnectionDB = ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString;
    }
}
