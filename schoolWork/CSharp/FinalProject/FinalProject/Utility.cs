using System;
using System.IO;

/// <summary>
/// Name: Shawn Giroux
/// Class: CIS158M
/// Date: 11/4/2015
/// Summary: This class will be used to hold the tools that will
/// help us complete tasks that would otherwise need to be
/// repeated throughout the entire program.
/// </summary>

namespace FinalProject
{
    public class Utility
    {
        // This class was used to write some code for straight line programming
        public class WriteCode
        {
            private string localFilePath;                     // Variable of the submitted filepath to be used by other methods

            public void modify(string filePath)
            {
                string outputFilePath = @"E:\Programming\C#\programs\FinalProject\FinalProject\src\";  // This is the path for the new file

                localFilePath = filePath;                            // change this to filePath later so that all files can be modified without editing the code
                string[] fileNames = getFiles();                     // calls to the getFiles to find all file path names.  

                string[] outputNames = new string[fileNames.Length]; // This will hold the names of the output files
                for (int i = 0; i < outputNames.Length; i++)          // Build array of output file paths
                {
                    outputNames[i] = outputFilePath + "output" + i + ".txt";
                }

                int incrementOutput = 0;                             // Picks what element of outputNames to write into 

                // This foreach loop with a nested for loop will pull the text lines into an array
                // from each file path take from the getFiles() method.  It will then try to write
                // them all into a seperate location.  The original files are left unscathed.
                foreach (var item in fileNames)
                {
                    string[] modifyText = File.ReadAllLines(item);

                    for (int i = 0; i < modifyText.Length; i++)
                    {
                        string beginning = String.Format("scr.Line{0}=" + '"', i + 1);       // Used to modifying the beginning of the text
                        string end = String.Format('"' + ";");                             // Used to modify the end of the text
                        modifyText[i] = beginning + modifyText[i] + end;                   // Forms the output for the new file of the modified text
                    }
                    try
                    {
                        // Writes all lines into a file path, this will be changed into a loop afterwards
                        File.WriteAllLines(outputNames[incrementOutput], modifyText);
                    }
                    catch (Exception e)
                    {
                        // Displays the error, if there is one.
                        Console.WriteLine("An error has occured: " + e);
                    }
                    incrementOutput++;
                }
                Console.WriteLine("Process complete. Press any key to continue.");          
            }

            public string[] getFiles()
            {
                // This class will be used to gather all file path names
                // without the user having to change each string manually.
                // The user will only need to provide a file path and then
                // this method will take care of the rest.
                // Make sure only text files are in this folder.

                string[] fileNames = Directory.GetFiles(localFilePath);
                return fileNames;
            }
        }
        // This class will be used to gather our directories for our files.
        public class FindDirectories
        {
            // This method will get the file path to where we store our menus
            public string getMenuDir()
            {
                string currentDir = Directory.GetCurrentDirectory();                    // Gets directory of program.
                string upDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\"));   // Takes program directory and goes up 2 levels.
                string menuPath = upDir + @"src\menu\";                                 // Adds menu path.
                return menuPath;
            }
            // This method will get the file path to where we store our recipes
            public string getRecipeDir()
            {
                string currentDir = Directory.GetCurrentDirectory();                   // Gets directory of program.
                string upDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\"));  // Takes program directory and goes up 2 levels.
                string recipePath = upDir + @"src\recipes\";                           // Adds recipe path.
                return recipePath;
            }
            
        }
        // This class will be used to display our text files.
        public class PrintTxt
        {
            // This method will display text of a file from a passed file path
            public void displayText(string path)
            {
                try
                {
                    StreamReader read = new StreamReader(path);  // Create a streamreader for reading into files
                    string text;                                 // Will be used to store text from the streamreader
                    while((text = read.ReadLine()) != null)      // Uses string text to check if it is null, if not, the loop will be printing text from the streamreader.
                    {
                        Console.WriteLine(text);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("An error has occured in \"Utility.PrintTxt.displayText\": " + e);
                }
            }
        }
        // This class will be used to validate user input.
        public class ValidateInput
        {
            // This method returns boolean to let us know if user input was a number or not
            public Boolean checkInput(string userChoice, int maxRange)
            {
                int testInt;                                               // Int used to try and convert userChoice
                try
                {
                    testInt = Convert.ToInt32(userChoice);                 // Tries to convert string to integer
                }
                catch(Exception e)
                {
                    Console.WriteLine("\n                         This is not an integer!");
                    Console.Write("\n                        Press any key to continue...");
                    return false;
                }
                if (testInt <= maxRange && testInt > 0)                    // If convert is successful, checks number for boundaries specified in the text file
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("\n                       This number was not a choice.");
                    Console.Write("\n                           Press any key to continue...");
                    return false;
                }
            }
        }
    }
}
