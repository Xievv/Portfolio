/*
 * Name: Shawn G
 * Date: 11/17/2015
 * Summary: This class will contain a method that gets user input, converts it
 * into a line of HTML code, and outputs it to finalize our HTML document.  It
 * will also return a boolean of 'true' to let the user know we have completed
 * the process.
 * 
 * Note: Need to make HTML links finalize themselves in the generateHTML class. [Complete]
 * Added functionality for HTML links under GenerateHTML.
 */

import java.util.Scanner;

public class UserInterface extends GenerateHTML{
    Scanner input = new Scanner(System.in);                  // Used to get user input
    String changing = "Objective This Week";                 // Lets the user know it starts in Objective This Week first
    int recursion = 0;                                       // Used to limit recursion
    
    public boolean createHTML(String match){                 // Passing argument 'match' to find correct keyword in HTML template
        
        boolean done = false;                                //  Ends user input while loop
        
        String begin = "        <td>";                       // Beginning of HTML code for tables
        String middle = "";                                  // This will be filled with the user input
        String end = "</td>";                                // End of HTML code for tables        
        
        String complete = null;                              // Instansiate complete for use later
               
        System.out.printf("%nEnter in what you would like to be in the contents of: %s%n", changing);
        System.out.println("Type \"done\" when you are finished.");

        for(int i = 0; i < html.size(); i++){                // This for loop will be used for seaching through the HTML arraylist
            while(done != true){                             // This while loop will take in user input to convert into HTML later                
                String userInput = input.nextLine();         // Using the 'input' Scanner to get the users input
                if (userInput.equals("done")){               // If user types 'done', the while loop stops
                    done = true;
                } else {
                    middle += userInput;                 // Adds users input into the string variable 'middle'
                    middle += "<br />";                  // Adds a break line to the user input
                }
            }            
            
            complete = begin + middle + end;             // Finalizes the HTML code by adding the variables begin, middle and end                 
            if(html.get(i).equals(match)){
                html.set(i, complete);                       // Searches for the passed argument of 'match'
            }
        }
        
        recursion++;                                         // Increments to limit amount of recursion
        switch(recursion){                                   // This switch tree will start recursion for 4 addition runs of the method
            case 1: changing = "By This Time";               // Variables changed in each case will manipulate the string and search variables
                createHTML("        ByThisTimeText");                
                break;
            case 2: changing = "Labs This Week";
                createHTML("        LabsText");
                break;
            case 3: changing = "Programming Assignment This Week";
                createHTML("        AssignmentText");                
                break;
            case 4: changing = "Readings For This Week";
                createHTML("          ReadingsText");                
                break;
        }
        return true;                                          // Returns true to let us know we are done
    }    
}
