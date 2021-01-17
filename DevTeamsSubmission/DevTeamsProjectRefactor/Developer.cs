using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Teams_Repo
{
    public class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double IndividualID { get; set; }
        public bool AccessPluralsight { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, double individualID, bool accessPluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            IndividualID = individualID;
            AccessPluralsight = accessPluralsight;
        }
    }
}
