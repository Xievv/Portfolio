/*
 * Name: Shawn Giroux
 * Date: 10/15/2015
 * Summary: This class will hold all menus for both the menu, recipe and algorithm section.
 * It will display the recipes and the algorithms along with the menu to get them.
 * ASCII used in the exit screen was generated from patorjk.com/software/taag/
 */

package finalproject;

import java.util.Scanner;

public class MenuContainer {
    Utilities toolbox = new Utilities();
    Utilities.FilePaths getPath = toolbox.new FilePaths();       // This will get our menu paths to ensure the program can be used from any directory.
    Utilities.TxtFile readText = toolbox.new TxtFile();          // This constructor will display text files.
    Utilities.ValidateInput input = toolbox.new ValidateInput(); // This constructor is used for validating input
    Scanner scan = new Scanner(System.in);
    
    // This class will hold all methods correlating to the main menu
    public class MainMenu{
        
        RecipeMenu recipe = new RecipeMenu();                            // Constructor to go to recipe menu
        AlgorithmMenu algorithm = new AlgorithmMenu();                   // Constructor to go to algorithm menu
        ExitScreen exit = new ExitScreen();                              // Constructor to go to exit screen
        
        public void displayScreen(){
            
            String menuDir = getPath.menuFolder() + "/mainScreen.txt";   // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(menuDir);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 3;                                            // Highest number option user can choose.

            System.out.print("                       Please select an option: ");
            String userInput = scan.nextLine();
            
            if(input.validateInteger(userInput, maxRange) != true){   // Checks for a "true" value from method validate to see if the input is a number.
                scan.nextLine();
                displayScreen();
            }
            jumpTree(Integer.parseInt(userInput));
        }
        private void jumpTree(int userChoice){
            // case 1 and 2 will bring us to our other menus. Case 3 will end our program
            switch(userChoice){
                case 1:  
                    recipe.displayScreen();
                    break;
                case 2:  
                    algorithm.displayScreen();
                    break;
                case 3:
                    exit.exitScreen();
                    break;
                default: System.out.println("There was an error in \"MenuContainer.MainMenu.jumptree\"");
            }
        }
    }
    // This class will hold all methods correlating to the recipe menu
    private class RecipeMenu{
        public void displayScreen(){
            String recipePath = getPath.menuFolder() + "/recipeScreen.txt"; // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(recipePath);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 7;      // Highest number option user can choose.
            
            System.out.print("                       Please select an option: ");
            String userInput = scan.nextLine();
            
            if(input.validateInteger(userInput, maxRange) != true){      // Checks for a "true" value from method validate to see if the input is a number.
                scan.nextLine();
                displayScreen();
            }
            jumpTree(Integer.parseInt(userInput));
        }
        private void jumpTree(int userChoice){
            String recipeDir = getPath.recipeFolder();  // This constructor gets us the path where the recipe files are held.
            Scanner scan = new Scanner(System.in);
            
            // case 1 - 6 will display recipes, case 7 will return to the menu.
            switch(userChoice){
                case 1: 
                    readText.displayText(recipeDir + "/bakedChickenPotatoFinal.txt");
                    break;
                case 2: 
                    readText.displayText(recipeDir + "/beefstewFinal.txt");
                    break;
                case 3: 
                    readText.displayText(recipeDir + "/chickenCacciatoreFinal.txt");
                    break;
                case 4: 
                    readText.displayText(recipeDir + "/chickenStewFinal.txt");
                    break;
                case 5: 
                    readText.displayText(recipeDir + "/sweetSourChickenFinal.txt");
                    break;
                case 6: 
                    readText.displayText(recipeDir + "/tomatoRiceSoupFinal.txt");
                    break;
                case 7: 
                    MainMenu menu = new MainMenu();
                    menu.displayScreen();
                    break;
                default: 
                    System.out.println("An error has occured in \"MenuContainer.RecipeMenu.jumpTree\"");
                    break;
            }
            scan.hasNextLine();
            displayScreen();
        }
    }
    // This class will hold all methods correlating to the algorithm menu
    public class AlgorithmMenu{
        public void displayScreen(){
            String algorithmPath = getPath.menuFolder() + "/algorithmScreen.txt";  // Gets path to the menu folder directory
            readText.displayText(algorithmPath); // Displays the text file on screen
            
            int maxRange = 4;                    // This is the max number a user can select up to
            
            System.out.print("                       Please select an option: ");
            String userInput = scan.nextLine();
                        
            if(input.validateInteger(userInput,maxRange) != true){ // Input validation for integers
                scan.nextLine();
                displayScreen();
            }
            jumpTree(Integer.parseInt(userInput));                    // Move to our jump tree with the user's selection
        }
        private void jumpTree(int userChoice){
            
            // The algorithm constructors are used to jump to our algorithm sections of our Algorithms class
            Algorithms algorithms = new Algorithms();
            Algorithms.Eratosthenes eratosthenes = algorithms.new Eratosthenes();
            Algorithms.BubbleSort bubbleSort = algorithms.new BubbleSort();
            Algorithms.Euclid euclid = algorithms.new Euclid();
            
            Scanner scan = new Scanner(System.in);    // Used to gather input
            
            // case 1 - 3 will run algorithms, case 4 will return to the menu.
            switch(userChoice){
                case 1: 
                    bubbleSort.entryScreen();
                    break;
                case 2: 
                    euclid.entryScreen();
                    break;
                case 3: 
                    eratosthenes.entryScreen();
                    break;
                case 4: 
                    MainMenu menu = new MainMenu(); // Takes us back to the main menu
                    menu.displayScreen();
                    break;
                default: 
                    System.out.println("An error has occured in \"MenuContainer.AlgorithmMenu.jumpTree\"");
                    break;
            }
        }
    }
    // Displays the exit screen when the user is quitting
    private class ExitScreen{
        
        public void exitScreen(){
            String exitPath = getPath.menuFolder() + "/exitScreen.txt";
            readText.displayText(exitPath);
            
            System.out.print("                          Press any key to quit...");
            scan.nextLine();
            System.exit(0);     // Ends the program
        }
    }
}
