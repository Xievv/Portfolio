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
    
    // This class will hold all methods correlating to the main menu
    public class MainMenu{
        
        RecipeMenu recipe = new RecipeMenu(); // Constructor to go to recipe menu
        
        public void displayScreen(){
            String menuDir = getPath.menuFolder() + "/mainScreen.txt";   // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(menuDir);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 3;                                            // Highest number option user can choose.
            String userInput = scan.nextLine();
            
            while(input.validateInteger(userInput, maxRange) != true){   // Checks for a "true" value from method validate to see if the input is a number.
                userInput = scan.nextLine();
            }
            jumpTree(Integer.parseInt(userInput));
        }
        public void jumpTree(int userChoice){
            switch(userChoice){
                case 1:  recipe.displayScreen();
                    break;
                case 2:  // To algorithsm
                    break;
                default: System.out.println("There was an error in \"MainMenu.jumptree\"");
            }
        }
    }
    // This class will hold all methods correlating to the recipe menu
    public class RecipeMenu{
        public void displayScreen(){
            String menuDir = getPath.menuFolder() + "/recipeScreen.txt"; // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(menuDir);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 7;                                            // Highest number option user can choose.
            String userInput = scan.nextLine();
            
            while(input.validateInteger(userInput, maxRange) != true){   // Checks for a "true" value from method validate to see if the input is a number.
                userInput = scan.nextLine();
            }
            jumpTree(Integer.parseInt(userInput));
        }
        public void jumpTree(int userChoice){
            String recipeDir = getPath.recipeFolder();
            switch(userChoice){
                case 1: readText.displayText(recipeDir + "/bakedChickenPotatoFinal.txt");
                    break;
                case 2: readText.displayText(recipeDir + "/beefstewFinal.txt");
                    break;
                case 3: readText.displayText(recipeDir + "/chickenCacciatore.txt");
                    break;
                case 4: readText.displayText(recipeDir + "/chickenStewFinal.txt");
                    break;
                case 5: readText.displayText(recipeDir + "/sweetSourChickenFinal.txt");
                    break;
                case 6: readText.displayText(recipeDir + "/sweetSourChicken.txt");
                    break;
                case 7: // Return to main menu
                    break;
                default: System.out.println("An error has occured in \"MenuContainer.RecipeMenu.jumpTree\"");
                    break;
            }
        }
    }
    // This class will hold all methods correlating to the algorithm menu
    public class AlgorithmMenu{
        
    }
}
