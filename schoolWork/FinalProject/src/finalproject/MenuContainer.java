/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class will be used to display the recipes that the
 * user would like to view with a switch statement.
 */

package finalproject;

import java.util.Scanner;

/**
 *
 * @author CISPupil
 */
public class MenuContainer {
    Utilities toolbox = new Utilities();
    Utilities.FilePaths getPath = toolbox.new FilePaths();       // This will get our menu paths to ensure the program can be used from any directory.
    Utilities.TxtFile readText = toolbox.new TxtFile();          // This constructor will display text files.
    Utilities.ValidateInput input = toolbox.new ValidateInput(); // This constructor is used for validating input
    Scanner scan = new Scanner(System.in);
    
    public class mainMenu{
        
        public void displayScreen(){
            String menuDir = getPath.menuFolder() + "\\mainScreen.txt";  // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(menuDir);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 3;                                            // Highest number option user can choose.
            String userInput = scan.nextLine();
            
            while(input.validateInteger(userInput, maxRange) != true){
                userInput = scan.nextLine();
            }
        }
    }
}
