using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils
{
    public class FakeData
    {
       public static string FullName()
        {
            var firstName = new Bogus.DataSets.Name().FirstName().ToString();
            var lastName = new Bogus.DataSets.Name().LastName().ToString();
            return $"{firstName}  {lastName}";
        }
        public static string Description()
        {
            return new Bogus.DataSets.Name().Random.Words(5);
        }
        public static int RandomNumber(int number)
        {
            return new Bogus.Randomizer().Even(1, number);
        }
        public static string RandomAddress()
        {
            return new Bogus.DataSets.Address().FullAddress();
        }
        public static string RandomUserName()
        {
            return new Bogus.Person().UserName;
        }

        public static string RandomEmailId()
        {
            return new Bogus.Person().Email;
        }
        public static string RandomFullName()
        {
            return new Bogus.Person().FullName;
        }
        public static string RandomFirstName()
        {
            return new Bogus.Person().FirstName;
        }
    }
}
