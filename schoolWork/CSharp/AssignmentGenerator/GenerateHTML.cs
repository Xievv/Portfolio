using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

/// <summary>
/// Name: Shawn Giroux
/// Date: 11/19/2015
/// Summary: This class will contain a method that gets user input, converts it
/// into a line of HTML code, and outputs it to finalize our HTML document. It
/// will also return a boolean of 'true' to let the user know we have completed
/// the process.
/// </summary>

namespace AssignmentGenerator
{
    class GenerateHTML
    {

        public ArrayList html = new ArrayList();  // Arraylist will hold HTML template for manipulation

        public void CreateArray()
        {
            string path = @"E:\Programming\CSharp\programs\AssignmentGenerator\AssignmentGenerator\src\template.txt";  // Path to the template
            try
            {
                String[] htmlArray = File.ReadAllLines(path);   // Reads lines from the file into an array
                foreach(var item in htmlArray)                  // Throws the array into an arraylist so we can add elements later
                {
                    html.Add(item);
                }
            } catch(Exception e)
            {
                Console.WriteLine("An error has occured in 'CreateArray': " + e);  // Error catching
            }
        }
        public void linkFinalization()
        {
            Regex findURL = new Regex(@".\bhttp");            // Regular expression constructor for advanced keyword searches (http)

            for (int i = 0; i < html.Count; i++)              // For loop for searching through html
            {
                string checkHtml = html[i].ToString();        // String used for checking HTML
                if (findURL.IsMatch(checkHtml))               // If it finds a match to ReGex, do the following
                {
                    String[] splitHtml = Regex.Split(checkHtml, ("<td>|<br />|</td>"));  // Wipes the line of code of previous HTML coding and puts the leftover into an array
                    html[i] = "";                             // Clears the old line of code
                    foreach(var item in splitHtml)            // Goes through our new array to generate HTML links
                    {
                        if (item != "" && item.Contains(" ") != true)  // Avoids using the blanks slots in the array to get only what we need
                        {
                            String url = "          <a href=\"" + item + "\">" + item + "</a><br />";  // HTML link code
                            html.Insert(i, url);              // Inserts value into the location of our HTML arraylist
                            i += 1;                           // Allows our links to format in the way the user types them
                        }
                    }
                    break;                                    // Once we found our HTML code, we escape from the loop to avoid infinite looping
                }
            }
        }
        public void generateHTML()
        {
            string path = @"E:\Programming\CSharp\programs\AssignmentGenerator\AssignmentGenerator\src\assignment.html";  // Output file path
            string[] finalHTML = html.ToArray(typeof(string)) as string[];     // Convert out arraylist to a string array to allow us to use File.WriteAllLines
            try
            {
                File.WriteAllLines(path, finalHTML);                           // Prints into our output filepath
            }
            catch(Exception e)
            {
                Console.WriteLine("An error has occured in 'generateHTML': " + e); // Error catching
            }
        }
    }
}
