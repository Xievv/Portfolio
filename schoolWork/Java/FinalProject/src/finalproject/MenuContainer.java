/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class will be used to display the recipes that the
 * user would like to view with a switch statement.
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
        AlgorithmMenu algorithm = new AlgorithmMenu();
        
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
        private void jumpTree(int userChoice){
            switch(userChoice){
                case 1:  
                    recipe.displayScreen();
                    break;
                case 2:  
                    algorithm.displayScreen();
                    break;
                case 3:
                    System.exit(0);
                    break;
                default: System.out.println("There was an error in \"MainMenu.jumptree\"");
            }
        }
    }
    // This class will hold all methods correlating to the recipe menu
    private class RecipeMenu{
        public void displayScreen(){
            String recipePath = getPath.menuFolder() + "/recipeScreen.txt"; // Uses our toolbox constructor to pull the directory for menu folder.
            readText.displayText(recipePath);                               // Displays our text file from the directory we pulled.
            
            int maxRange = 7;                                            // Highest number option user can choose.
            String userInput = scan.nextLine();
            
            while(input.validateInteger(userInput, maxRange) != true){   // Checks for a "true" value from method validate to see if the input is a number.
                userInput = scan.nextLine();
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
            String algorithmPath = getPath.menuFolder() + "/algorithmScreen.txt";
            readText.displayText(algorithmPath);
            
            int maxRange = 4;
            String userInput = scan.nextLine();
            
            while(input.validateInteger(userInput,maxRange) != true){
                userInput = scan.nextLine();
            }
            jumpTree(Integer.parseInt(userInput));
        }
        private void jumpTree(int userChoice){
            Algorithms algorithms = new Algorithms();
            Algorithms.Eratosthenes eratosthenes = algorithms.new Eratosthenes();
            Algorithms.BubbleSort bubbleSort = algorithms.new BubbleSort();
            Scanner scan = new Scanner(System.in);
            // case 1 - 3 will run algorithms, case 4 will return to the menu.
            switch(userChoice){
                case 1: 
                    bubbleSort.entryScreen();
                    break;
                case 2: 
                    // Euclidean Algorithm
                    break;
                case 3: 
                    eratosthenes.EntryScreen();
                    break;
                case 4: 
                    MainMenu menu = new MainMenu();
                    menu.displayScreen();
                    break;
                default: 
                    System.out.println("An error has occured in \"MenuContainer.RecipeMenu.jumpTree\"");
                    break;
            }
        }
    }
}
