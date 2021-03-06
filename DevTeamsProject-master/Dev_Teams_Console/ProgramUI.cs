﻿using Dev_Teams_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_Teams_Console
{
    class ProgramUI
    {
        private readonly DeveloperRepo _developerRepository = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepository = new DevTeamRepo();

        // Run application method
        public void Run()
        {
            SeedDeveloperList();
            SeedDeveloperTeamsList();
            Menu();
        }

        // Menu method
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display options
                Console.WriteLine("Main Menu - please select an option below:\n" +
                    "1. View/edit individual developer(s)\n" +
                    "2. View/edit developer team(s)\n" +
                    "3. Exit");

                // Get user input
                string inputOne = Console.ReadLine();

                // Evaluate & act on user input
                switch (inputOne)
                {
                    case "1":
                        // View/edit individual developer(s) menu
                        Console.Clear();
                        Console.WriteLine("Developer Menu - please select an option below:\n" +
                            "1. Add a developer\n" +
                            "2. View all developers\n" +
                            "3. View a developer\n" +
                            "4. Update a developer\n" +
                            "5. Remove a developer\n" +
                            "6. Exit");

                        // Get user input again
                        string inputTwoA = Console.ReadLine();

                        // Evaluate & act on user input again
                        switch (inputTwoA)
                        {
                            case "1":
                                // Add a developer
                                AddNewDeveloper();
                                break;
                            case "2":
                                // View all developers
                                ViewAllDevelopers();
                                break;
                            case "3":
                                // View a developer by ID
                                ViewDeveloperByID();
                                break;
                            case "4":
                                // Update a developer by ID
                                UpdateExistingDeveloper();
                                break;
                            case "5":
                                // Remove a developer by ID
                                RemoveExistingDeveloper();
                                break;
                            case "6":
                                // Exit
                                keepRunning = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a number 1-6");
                                break;
                        }
                        break;
                    case "2":
                        //View/edit developer team(s)
                        Console.Clear();
                        Console.WriteLine("Developer Teams Menu - please select an option below:\n" +
                            "1. Add a developer team\n" +
                            "2. Add an individual developer to a team\n" +
                            "3. Add multiple developers to a team\n" +
                            "4. Remove a developer team\n" +
                            "5. Remove individual developer from a team\n" +
                            "6. Remove multiple developers from a team\n" +
                            "7. Exit");

                        // Get user input again
                        string inputTwoB = Console.ReadLine();

                        // Evaluate & act on user input again
                        switch (inputTwoB)
                        {
                            case "1":
                                // Add a developer team
                                AddDeveloperTeam();
                                break;
                            case "2":
                                // Add individual developers to a team
                                AddDeveloperToTeam();
                                break;
                            case "3":
                                // Add multiple developers to a team
                                AddMultipleDevelopersToTeam();
                                break;
                            case "4":
                                // Remove developer team
                                RemoveDeveloperTeam();
                                break;
                            case "5":
                                // Remove individual developer from a team
                                RemoveDeveloperFromTeam();
                                break;
                            case "6":
                                // Remove multiple developers from a team
                                RemoveMultipleDevelopersFromTeam();
                                break;
                            case "7":
                                // Exit
                                keepRunning = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a number 1-6");
                                break;
                        }
                        break;
                    case "3":
                        // Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-3");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Add a developer
        private void AddNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // First Name
            Console.WriteLine("Please enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Please enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();

            // Individual ID
            Console.WriteLine("Please enter the developer's ID number:");
            string IDAsString = Console.ReadLine();
            newDeveloper.IndividualID = double.Parse(IDAsString);

            // Access to Pluralsight?
            Console.WriteLine("Does the developer have access to Pluralsight? (Y/N):");
            string PluralsightString = Console.ReadLine().ToLower();

            if (PluralsightString == "Y")
            {
                newDeveloper.AccessPluralsight = true;
            }
            else
            {
                newDeveloper.AccessPluralsight = false;
            }

            _developerRepository.AddDeveloperToList(newDeveloper);
        }

        // View all developers
        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepository.GetDeveloperList();

            foreach(Developer developer in listOfDevelopers)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Individual ID: {developer.IndividualID}");
            }
        }

        // View a developer by ID
        private void ViewDeveloperByID()
        {
            Console.Clear();
            // Prompt user to give ID
            Console.WriteLine("Please enter the ID number of the developer:");

            // Get user input
            string IDAsString = Console.ReadLine();
            double IDAsDouble = double.Parse(IDAsString);

            // Find developer by ID
            Developer developer = _developerRepository.GetDeveloperByID(IDAsDouble);

            // Display developer if not null
            if (developer != null)
            {
                Console.WriteLine($"First Name: {developer.FirstName}\n" +
                    $"Last Name: {developer.LastName}\n" +
                    $"Individual ID: {developer.IndividualID}\n" +
                    $"Access to Pluralsight: {developer.AccessPluralsight}");
            }
            else
            {
                Console.WriteLine("No developer by that ID");
            }
        }

        // Update a developer by ID
        private void UpdateExistingDeveloper()
        {
            // View all developers
            ViewAllDevelopers();

            // Prompt user for ID
            Console.WriteLine("Please enter the ID of the developer you'd like to update:");
            string oldIDAsString = Console.ReadLine();
            double oldIDAsDouble = double.Parse(oldIDAsString);

            // Build new object
            Developer newDeveloper = new Developer();

            // First Name
            Console.WriteLine("Please enter the developer's first name:");
            newDeveloper.FirstName = Console.ReadLine();

            // Last Name
            Console.WriteLine("Please enter the developer's last name:");
            newDeveloper.LastName = Console.ReadLine();

            // Individual ID
            Console.WriteLine("Please enter the developer's ID number:");
            string IDAsString = Console.ReadLine();
            newDeveloper.IndividualID = double.Parse(IDAsString);

            // Access to Pluralsight?
            Console.WriteLine("Does the developer have access to Pluralsight? (Y/N):");
            string PluralsightString = Console.ReadLine().ToLower();

            if (PluralsightString == "Y")
            {
                newDeveloper.AccessPluralsight = true;
            }
            else
            {
                newDeveloper.AccessPluralsight = false;
            }

            // Verify the update worked
            bool developerUpdated = _developerRepository.UpdateExistingDeveloper(oldIDAsDouble, newDeveloper);

            if (developerUpdated)
            {
                Console.WriteLine("Developer successfully upated");
            }
            else
            {
                Console.WriteLine("Developer could not be updated");
            }
        }

        // Remove a developer by ID
        private void RemoveExistingDeveloper()
        {
            // View all developers
            ViewAllDevelopers();

            // Prompt user for ID
            Console.WriteLine("\nPlease enter the ID of the developer you'd like to remove:");
            string IDAsString = Console.ReadLine();
            double IDAsDouble = double.Parse(IDAsString);

            // Call the remove method
            bool developerDeleted = _developerRepository.RemoveDeveloperFromList(IDAsDouble);

            // If the developer was deleted, say so
            if (developerDeleted)
            {
                Console.WriteLine("Developer successfully deleted");
            }
            // Otherwise, state the developer couldn't be deleted
            else
            {
                Console.WriteLine("No developer was deleted");
            }
        }

        // Add a developer team
        private void AddDeveloperTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            // Team Name
            Console.WriteLine("Please enter the new team's name:");
            newDevTeam.TeamName = Console.ReadLine();

            // Team ID
            Console.WriteLine("Please enter the new team's number:");
            string TeamIDAsString = Console.ReadLine();
            newDevTeam.TeamID = double.Parse(TeamIDAsString);

            _devTeamRepository.AddDeveloperTeam(newDevTeam);
        }

        // Add an individual developer to a team
        private void AddDeveloperToTeam()
        {

        }

        // Add multiple developers to a team
        private void AddMultipleDevelopersToTeam()
        {

        }

        // Remove a developer team
        private void RemoveDeveloperTeam()
        {

        }

        // Remove individual developer from a team
        private void RemoveDeveloperFromTeam()
        {

        }

        // Remove multiple developers from a team
        private void RemoveMultipleDevelopersFromTeam()
        {

        }

        // Seed developers method
        private void SeedDeveloperList()
        {
            Developer DeveloperOne = new Developer("James", "McIntyre", 111111, true);
            Developer DeveloperTwo = new Developer("Jessica", "Knight", 222222, true);
            Developer DeveloperThree = new Developer("Larry", "Smith", 333333, false);
            Developer DeveloperFour = new Developer("Amanda", "Gentry", 444444, true);
            Developer DeveloperFive = new Developer("George", "Allister", 555555, false);
            Developer DeveloperSix = new Developer("Stephanie", "Diaz", 666666, false);
            Developer DeveloperSeven = new Developer("Brian", "Reynolds", 777777, false);
            Developer DeveloperEight = new Developer("Lauren", "White", 888888, true);
            Developer DeveloperNine = new Developer("Rick", "Fairfield", 999999, false);

            _developerRepository.AddDeveloperToList(DeveloperOne);
            _developerRepository.AddDeveloperToList(DeveloperTwo);
            _developerRepository.AddDeveloperToList(DeveloperThree);
            _developerRepository.AddDeveloperToList(DeveloperFour);
            _developerRepository.AddDeveloperToList(DeveloperFive);
            _developerRepository.AddDeveloperToList(DeveloperSix);
            _developerRepository.AddDeveloperToList(DeveloperSeven);
            _developerRepository.AddDeveloperToList(DeveloperEight);
            _developerRepository.AddDeveloperToList(DeveloperNine);
        }

        // Seed developer teams method
        private void SeedDeveloperTeamsList()
        {
            DevTeam DevTeamOne = new DevTeam("Team 1", 1);
        }
    }
}
