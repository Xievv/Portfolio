using System;

/// <summary>
/// Name: Shawn Giroux
/// Date: 11/19/2015
/// Summary: This project will read into a text file that holds an HTML template.
/// It will get in user input and search out keywords in the template, and replace
/// them with HTML code.  It will then generate an HTML file that can either be
/// screen scraped or run on its own.
/// </summary>

namespace AssignmentGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string parm = "ObjectiveText";                          // This string will be passed as a parameter for createHTML to search the HTML template

            UserInterface makeHtml = new UserInterface();               // Constructor to UserInterface, everything below calls to methods
            makeHtml.CreateArray();
            Boolean checkComplete = makeHtml.createHTML(parm);          // Checks boolean return values to see if process was complete
            if (checkComplete == true)
            {
                Console.WriteLine("HTML generation successful.");
            }
            makeHtml.linkFinalization();
            makeHtml.generateHTML();

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
