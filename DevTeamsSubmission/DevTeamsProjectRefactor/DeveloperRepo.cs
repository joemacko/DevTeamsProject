using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Teams_Repo
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }

        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }

        //Developer Update
        public bool UpdateExistingDeveloper(double originalID, Developer newDeveloper)
        {
            // Find the developer
            Developer oldDeveloper = GetDeveloperByID(originalID);

            // Update the developer
            if (oldDeveloper != null)
            {
                oldDeveloper.FirstName = newDeveloper.FirstName;
                oldDeveloper.LastName = newDeveloper.LastName;
                oldDeveloper.IndividualID = newDeveloper.IndividualID;
                oldDeveloper.AccessPluralsight = newDeveloper.AccessPluralsight;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Delete
        public bool RemoveDeveloperFromList(double individualID)
        {
            Developer developer = GetDeveloperByID(individualID);

            if (developer == null)
            {
                return false;
            }

            int initialDevCount = _developerDirectory.Count;
            _developerDirectory.Remove(developer);

            if (initialDevCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)
        public Developer GetDeveloperByID(double individualID)
        {
            foreach (Developer developer in _developerDirectory)
            {
                if (developer.IndividualID == individualID)
                {
                    return developer;
                }
            }
            return null;
        }
    }
}
