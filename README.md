# Assignment 5 - Update the Assignment 1 with Beverages to use a database instead of a CSV

## Author



## Description

Either modify what I have in my Asignment1 key, which is included here, or bring in your files and use that to do the work. You may need to change the namespace in your files if you do not want to use my files.

You are going to take the Assignment 1 we did with the Beverage List .CSV and update it to work with a database in place of the CSV. In addition, the UI must be updated to accommodate some new features that were not in assignment 1.

The program should continually run until the user decides to exit (entering a certain character on the keyboard).

The program should allow the following functionality:

1. Loads the information about the Beverages from the database. This is achieved by making the connection to the database. You don't really have to 'code' anything, but you do need to setup the connection correctly.
2. Allow the user to print the entire list of beverages.
3. Allow the user to search for an beverage by the beverage id, and print out the beverage if found. Error message if not. This can be done with either Find, or Where.
4. Allow the user to add a new beverage to the list. It should show a nice error message if the user tries to add a beverage with a primary id that is already in the DB.
5. (NEW) Allow the user to update an existing beverage. (You should not allow the user to update the ID / ItemID since that is the Primary Key of the database record)
6. (NEW) Allow the user to delete an existing beverage. It should show a nice error if the delete can not complete. (Deleting by ID is good enough. If you would like to offer other searches for deletion you can, but are not required to.)

Replace the class called Beverage with an Entity Framework Model based on the data in the database. We will do an example of this in class.

You should transform the BeverageCollection class into a Repository API. Although not required, you may want to rename the class.
Entity Framework allows you to add a Collection called BeverageContext.Beverages, so you will no longer need the BeverageCollection class to function as it currently does. Instead, you should make the BeverageCollection become a class that sits between the code in Program / UI and the newly created EntityFramework classes. This will be discussed in class and in the video about this assignment. If you are confused about it, ask.

Update the class called User Interface to include any new methods that are required to facilitate the above functionality. You can also remove the option to load the CSV file since it will no longer be needed.

CSVProcessor should be removed. It will not be used.
The datafiles directory can be removed as well since it will not be used anymore.


To connect to the database you will use the following information.

Sever address / name: barnesbrothers.ddns.net,443 //Remember that the comma denotes that the port number follows.

Sql Server Authentication (Not Windows Auth):

Username: FirstInial + LastName (All lowercase) (ie. John Smith would be jsmith)
It should be just like your valley username but without the ending numbers.

Password: password (If you would like me to change your password to something else for you, I can)

DatabaseName: Beverage + FirstInital + LastName

********************************************************************************************
*NOTE: There is a database for each person. Use the one that is for you. Don't be a troll. If I hear about you trolling on someone else's database, you will get a zero for the assignment!
********************************************************************************************

Solution Requirements:

* 4 classes (Main, Beverage (EF Version), BeverageContext (EF Version), BeverageCollection (Though you may rename), and UserInterface. The names can differ, and might due to database names and EF setup. If you aren't sure, ask.
* EntityFramework Model and Collection
* Repurposed BeverageCollection
* Read functionality
* Insert functionality
* Update functionality
* Delete functionality
* UI Class to handle I/O

### Notes



## Grading
| Feature                                 | Points |
|-----------------------------------------|--------|
| EF Models                               | 10     |
| Insert Functionality                    | 10     |
| Update Functionality                    | 10     |
| Delete Functionality                    | 10     |
| List All                                | 10     |
| Search                                  | 10     |
| Repurpose BeverageCollection as API     | 10     |
| UI is updated correctly                 | 10     |
| Handle Errors                           | 5      |
| DB Connection                           | 5      |
| Documentation                           | 5      |
| README                                  | 5      |
| **Total**                               | **100**|

## Outside Resources Used



## Known Problems, Issues, And/Or Errors in the Program


