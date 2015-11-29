using System;

/// <summary>
/// Name: Shawn Giroux
/// Date: 10/31/2015
/// Summary: This class will hold all menus for both the menu, recipe and algorithm section.
/// It will display the recipes and the algorithms along with the menu to get to them.
/// </summary>

namespace FinalProject
{
    class MenuContainer
    {
        public Utility.FindDirectories FindDir = new Utility.FindDirectories();  // Constructor for our premade tools
        Utility.PrintTxt Display = new Utility.PrintTxt();                       // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        Utility.ValidateInput Validate = new Utility.ValidateInput();            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        // Displays and lets the user interact with the main menu
        public class MainMenu
        {
            MenuContainer Tools = new MenuContainer();

            public void displayScreen()
            {
                string menuPath = Tools.FindDir.getMenuDir() + "mainScreen.txt";  // Menu screen path
                Tools.Display.displayText(menuPath);                              // Displays menu screen

                int maxRange = 3;                                                 // Max range of menu choices in the txt file
                string userInput = Console.ReadLine();

                while (Tools.Validate.checkInput(userInput, maxRange) != true)    // Calls boolean method to validate input and checks if true or false
                {
                    userInput = Console.ReadLine();
                }
                jumpTree(Convert.ToInt32(userInput));                             // Converts user input for switch case statement
            }
            public void jumpTree(int userChoice)
            {
                string recipePath = Tools.FindDir.getMenuDir() + "recipeScreen.txt";  // Recipe menu screen
                RecipeMenu Recipe = new RecipeMenu();                                 // Allows us to move to the RecipeMenu class
                switch (userChoice)
                {
                    case 1:
                        Recipe.displayScreen();
                        break;
                    case 2: 
                        // Display algorithms menu
                        break;
                    case 3:
                        Environment.Exit(0);                                      // Closes program is user selects exit
                        break;
                    default:
                        Console.WriteLine("Something went wrong in the jumpTree");
                        break;
                }
            }
        }
        // Displays and lets the user interact with the recipe menu
        public class RecipeMenu
        {
            MenuContainer Tools = new MenuContainer();

            public void displayScreen()
            {
                string recipePath = Tools.FindDir.getMenuDir() + "recipeScreen.txt";  // Recipe menu screen path
                Tools.Display.displayText(recipePath);                                // Displays the recipe menu screen text
                
                int maxRange = 7;                                                     // Max amount of options in the text file
                string userInput = Console.ReadLine();

                while(Tools.Validate.checkInput(userInput, maxRange) != true)         // Passes user input to our validation method and checks until it returns true
                {
                    userInput = Console.ReadLine();
                }
                jumpTree(Convert.ToInt32(userInput));                                 // Convert to int to pass to a switch case
            }
            public void jumpTree(int userChoice)
            {
                MainMenu Return = new MainMenu();                                     // Allows us to return to the main menu
                string recipePath = Tools.FindDir.getRecipeDir();                     // Grabs path to recipes directory

                // Case 1 - 6 will display the recipes, case 7 will return us to the menu screen
                switch (userChoice)
                {
                    case 1:
                        Tools.Display.displayText(recipePath + "bakedChickenPotatoFinal.txt");
                        break;
                    case 2:
                        Tools.Display.displayText(recipePath + "beefstewFinal.txt");
                        break;
                    case 3:
                        Tools.Display.displayText(recipePath + "chickenCacciatoreFinal.txt");
                        break;
                    case 4:
                        Tools.Display.displayText(recipePath + "chickenStewFinal.txt");
                        break;
                    case 5:
                        Tools.Display.displayText(recipePath + "sweetSourChickenFinal.txt");
                        break;
                    case 6:
                        Tools.Display.displayText(recipePath + "tomatoRiceSoupFinal.txt");
                        break;
                    case 7:
                        Return.displayScreen();
                        break;
                    default:
                        Console.WriteLine("Something went wrong in the jumpTree");
                        break;
                }

                // The user is prompted to press any key to continue, ReadKey handles that and then we go back to the recipe menu
                Console.ReadKey();
                displayScreen();
            }
        }
    }
}