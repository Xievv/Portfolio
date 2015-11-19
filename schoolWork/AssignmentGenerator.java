/*
 * Name: Shawn G
 * Date: 11/17/2015
 * Summary: This project will read into a text file that holds an HTML template.
 * It will get in user input and search out keywords in the template, and replace
 * them with HTML code.  It will then generate an HTML file that can either be
 * screen scraped or run on its own.
 *
 * Note: UserInterface is the child class of GenerateHTML, only one constructor
 * is needed to reach those processes.
 */

public class AssignmentGenerator {

    public static void main(String[] args) {
        
        String match = "        ObjectiveText";  // First string of text we're searching for in the document
        
        UserInterface test = new UserInterface();
        
        test.CreateArray();        
        boolean checkComplete = test.createHTML(match);          // Gets a boolean return from method createHTML
        if (checkComplete = true){
            System.out.println("HTML generation successful.");   // Lets user know the generation was successful
        }        
        test.linkFinalization();        
        test.generateHTML();
    }
    
}
