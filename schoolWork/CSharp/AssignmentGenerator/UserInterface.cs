using System;
using System.Text.RegularExpressions;
using System.IO;

/// <summary>
/// Name: Shawn Giroux
/// Date: 11/19/2015
/// Summary: This class will contain a method that gets user input, convers it
/// into a line of HTML code, and outputs it to finalize our HTML document.  It
/// will also return a boolean of 'true' to let the user know we have completed
/// the process.
/// </summary>

namespace AssignmentGenerator
{
    class UserInterface: GenerateHTML             // Inherits from GenerateHTML to cut down on the amount of constructors we need and for our arrayList (html)
    {
        string changing = "Objective This Week";  // Initialize 'changing' as "Objective This Week'. Lets user know what part of the HTML code they are in 
        int recursion = 0;                        // Class variable used to keep track of amount of times to be recursive

        public Boolean createHTML(String match)   // **Note the passed parameter from Program.cs**
        {
            Boolean done = false;                 // boolean that will exit our while loop later                

            string begin = "        <td>";        // begin middle and end will be used to make HTML code
            string middle = "";                   // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            string end = "</td>";                 // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            string complete = null;               // Instansiate our complete variable, finalize it later

            Console.WriteLine("Enter in what you would like to be in the contents of: {0}", changing);  // user prompts
            Console.WriteLine("Type \"done\" when you are finished.");  // user prompts

            StreamReader read = new StreamReader(Console.OpenStandardInput());  // Console.ReadLine only accepts 254 characters, this allows us to bypass that amount

            for (int i = 0; i < html.Count; i++)              // Loop used for user input and inserting out HTML code
            {
                while(done != true)
                {
                    string userInput = read.ReadLine();       // Gets user input
                    if (userInput.Equals("done"))             // If done, exit while loop
                    {
                        done = true;
                    }
                    else
                    {
                        middle += userInput;                  // Code that will be turned into user input
                        middle += "<br />";                   // Adds a break html code incase user wants to start on a new line
                    }
                }

                complete = begin + middle + end;              // Finalizes string variable 'complete'
                Regex findWord = new Regex(@"\b" + match);    // Using Regular Expressions to find out keywords in the template
                if (findWord.IsMatch(html[i].ToString()))     // Checks to see if we found the keyword
                {
                    html[i] = complete;                       // Replaces keyword with out HTML code
                }
            }
            recursion++;                                      // Allows us to continue recursion or stop running the method depending on the value
            switch (recursion)                                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            {
                case 1: changing = "By This Time";            // Assigns value to our variables so user gets correct message prompts
                    createHTML("ByThisTimeText");             // Passes new parameter to our method to search for the correct keywords
                    break;
                case 2:
                    changing = "Labs This Week";
                    createHTML("LabsText");
                    break;
                case 3:
                    changing = "Programming Assignment This Week";
                    createHTML("AssignmentText");
                    break;
                case 4:
                    changing = "Readings For This Week";
                    createHTML("ReadingsText");
                    break;
            }

            return true;                                     // When recursive method is done, return true to let the user know we were successful
        }
    }
}
