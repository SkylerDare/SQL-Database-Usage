using System;
using System.IO;

namespace cis237_assignment_5
{
    class CSVProcessor
    {
        // Declare a variable to flag whether the CSV has been imported
        bool hasBeenImported;

        // Constructor
        public CSVProcessor()
        {
            this.hasBeenImported = false;
        }

        /*
        |----------------------------------------------------------------------
        | Public Methods
        |----------------------------------------------------------------------
        */

        // Public method to Import the CSV
        public bool ImportCSV(BeverageCollection beverages, string pathToCSVFile)
        {
            // Declare the streamreader
            StreamReader streamReader = null;

            // If it has already been imported
            if (hasBeenImported)
            {
                return false;
            }

            // Has not been imported yet, so do the import.
            try
            {
                // Declare a string for the line
                string line;

                // Instantiate a new StreamReader class instance
                streamReader = new StreamReader(pathToCSVFile);

                // While still reading a line from the file
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Process the line
                    this.processLine(line, beverages);
                }

                // Set hasBeenImported to true now that it is imported
                hasBeenImported = true;

                // Return true to represent success
                return true;
            }
            catch (Exception e)
            {
                // Output the Error that occured.
                // This is the only output that is NOT
                // being done in the UI class
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);

                // Return false to signify that it failed
                return false;
            }
            finally
            {
                // If the stream reader was instanciated,
                // make sure it is closed before exiting.
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }

        /*
        |----------------------------------------------------------------------
        | Private Methods
        |----------------------------------------------------------------------
        */

        private void processLine(string line, BeverageCollection beverageCollection)
        {
            // Declare array of parts that will contain the
            // results of splitting the read in string.
            string[] parts = line.Split(',');

            // Assign each part to a variable
            string id = parts[0];
            string name = parts[1];
            string pack = parts[2];
            decimal price = decimal.Parse(parts[3]);
            bool active = (parts[4] == "True");

            // Add a new beverage into the collection with the properties
            // of what was read in.
            beverageCollection.AddNewItem(id, name, pack, price, active);
        }
    }
}
