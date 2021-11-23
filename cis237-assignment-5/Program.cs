using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cis237_assignment_5.Models;

namespace cis237_assignment_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set Console Window Size
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.WindowHeight = 40;
            Console.WindowWidth = 150;

            // Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            // Create an instance of the BeverageCollection class
            BeverageRepository beverageRepository = new BeverageRepository();

            // Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            // Display the Menu and get the response. Store the response in the choice integer
            // This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            // While the choice is not exit program
            while (choice != 6)
            {
                switch (choice)
                {
                    case 1:
                        // Print Entire List Of Items
                        beverageRepository.PrintTheList();
                        break;

                    case 2:
                        string id;
                        id = userInterface.GetSearchQuery();
                        beverageRepository.FindById(userInterface, id);
                        break;

                    case 3:
                        //Add a new item
                        bool o = false;
                        string[] newItemInformation = userInterface.GetNewItemInformation(o);
                        if (beverageRepository.FindById(newItemInformation[0]) == false)
                        {
                            beverageRepository.AddNewItem(newItemInformation[0],
                                newItemInformation[1],
                                newItemInformation[2],
                                decimal.Parse(newItemInformation[3]),
                                (newItemInformation[4] == "True"));
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }
                        break;

                    case 4:
                        //Update an item
                        bool found;
                        string idToUpdate = userInterface.GetId();
                        found = beverageRepository.FindById(idToUpdate);
                        if (found == true)
                        {
                            string[] updatedItemInformation = userInterface.GetNewItemInformation(found);

                            beverageRepository.UpdateItem(updatedItemInformation[0],
                                updatedItemInformation[1],
                                decimal.Parse(updatedItemInformation[2]),
                                updatedItemInformation[3] == "True", idToUpdate);
                        }
                        break;

                    case 5:
                        //Delete an item
                        string anItem = userInterface.DeletePrompt();
                        beverageRepository.DeleteItem(userInterface, anItem);
                        break;
                }

                // Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }
        }
    }
}
