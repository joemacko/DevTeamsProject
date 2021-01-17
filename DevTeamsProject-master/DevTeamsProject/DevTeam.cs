using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Teams_Repo
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public double TeamID { get; set; }
        public List<Developer> DeveloperList {get; set; }

        public DevTeam() { }

        public DevTeam(string teamName, double teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }
    }
}
