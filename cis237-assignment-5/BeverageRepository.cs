//Skyler Dare
//CIS237
//11/23/21
using System;
using cis237_assignment_5.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cis237_assignment_5
{
    class BeverageRepository
    {
        BeverageContext beverageContext = new BeverageContext();
        
        public void PrintTheList()
        {
            Console.WriteLine("Printing the List of Beverages");

            foreach (Beverage bev in beverageContext.Beverages)
            {
                Console.WriteLine(BeverageToString(bev));
            }
        }

        // Add a new item to the collection
        public void AddNewItem(
            string id,
            string name,
            string pack,
            decimal price,
            bool active
        )
        {
            Beverage beverageToAdd = new Beverage();

            beverageToAdd.Id = id;
            beverageToAdd.Name = name;
            beverageToAdd.Pack = pack;
            beverageToAdd.Price = price;
            beverageToAdd.Active = active;

            try
            {
                beverageContext.Beverages.Add(beverageToAdd);
                beverageContext.SaveChanges();

            }
            catch (DbUpdateException e)
            {
                beverageContext.Beverages.Remove(beverageToAdd);
            }
        }

        // Find an item by it's Id and output
        public bool FindById(UserInterface ui, string id)
        {
            Beverage beverageToFind = beverageContext.Beverages.Find(id);
                
            if (beverageToFind != null)
            {
                ui.DisplayItemFound(BeverageToString(beverageToFind));
                return true;
            }
            else
            {
                ui.DisplayItemFoundError();
                return false;
            }
        }
        //Find by id but do not output the item
        public bool FindById(string id)
        {
            Beverage beverageToFind = beverageContext.Beverages.Find(id);

            if (beverageToFind != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// checks for the item in the database using the primary key, if it is found, remove the item from the database
        /// </summary>
        /// <param name="ui">user interface class to display to the user if the removal was successful or not</param>
        /// <param name="id">the primary key for searching the database</param>
        public void DeleteItem(UserInterface ui, string id)
        {
            Beverage beverageToDelete = beverageContext.Beverages.Find(id);

            if (beverageToDelete != null)
            {
                beverageContext.Beverages.Remove(beverageToDelete);
                beverageContext.SaveChanges();
                beverageToDelete = beverageContext.Beverages.Find(id);
                if (beverageToDelete == null)
                {
                    ui.DisplayDeleteSuccess();
                }
            }
            else
            {
                ui.DisplayDeleteError();
                return;
            }
        }
        /// <summary>
        /// allows the user to update an item, prompts for the ID and then if an item is found, allows the user to change everything about the item other than the ID
        /// </summary>
        /// <param name="name">name of the beverage</param>
        /// <param name="pack">pack size of the beverage</param>
        /// <param name="price">price of the beverage</param>
        /// <param name="active">whether or not the beverage is active</param>
        /// <param name="id">the primary key of the beverage</param>
        public void UpdateItem(    
            string name,
            string pack,
            decimal price,
            bool active,
            string id)
        {
            Beverage beverageToUpdate = beverageContext.Beverages.Find(id);
            
            beverageToUpdate.Name = name;
            beverageToUpdate.Pack = pack;
            beverageToUpdate.Price = price;
            beverageToUpdate.Active = active;

            beverageContext.SaveChanges();
        }

        /// <summary>
        /// puts the properties of a beverage into an output string
        /// </summary>
        /// <param name="bev">beverage to be output</param>
        /// <returns>string of the beverage to be output</returns>
        public string BeverageToString(Beverage bev)
        {
            return $"{bev.Id} {bev.Name} {bev.Pack} {bev.Price} {bev.Active}";
        }
    }
}
