using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Teams_Repo
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();

        //DevTeam Create
        public void AddDeveloperTeam(DevTeam devTeam)
        {
            _devTeamDirectory.Add(devTeam);
        }

        //DevTeam Read
        public List<DevTeam> GetDeveloperTeamList()
        {
            return _devTeamDirectory;
        }

        //DevTeam Update
        public bool UpdateExistingDeveloperTeam(double originalTeamID, DevTeam newDeveloperTeam)
        {
            // Find the developer team
            DevTeam oldDeveloperTeam = GetDeveloperTeamByID(originalTeamID);

            // Update the developer
            if (oldDeveloperTeam != null)
            {
                oldDeveloperTeam.TeamName = newDeveloperTeam.TeamName;
                oldDeveloperTeam.TeamID = newDeveloperTeam.TeamID;

                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Delete
        public bool RemoveDeveloperTeamFromList(double teamID)
        {
            DevTeam developerTeam = GetDeveloperTeamByID(teamID);

            if (developerTeam == null)
            {
                return false;
            }

            int initialDevTeamsCount = _devTeamDirectory.Count;
            _devTeamDirectory.Remove(developerTeam);

            if (initialDevTeamsCount > _devTeamDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDeveloperTeamByID(double teamID)
        {
            foreach (DevTeam devTeam in _devTeamDirectory)
            {
                if (devTeam.TeamID == teamID)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}
