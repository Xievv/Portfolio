﻿using System;

/// <summary>
/// Name: Shawn Giroux
/// Class: CIS158M
/// Date: 10/31/2015
/// Summary: This class will hold all menus for both the menu, recipe and algorithm section.
/// It will display the recipes and the algorithms along with the menu to get to them.
/// ASCII used in the exit screen was generated from patorjk.com/software/taag/
/// </summary>

namespace FinalProject
{
    class MenuContainer
    {
        Utility.FindDirectories FindDir = new Utility.FindDirectories();         // Constructor for our premade tools
        Utility.PrintTxt Display = new Utility.PrintTxt();                       // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        Utility.ValidateInput Validate = new Utility.ValidateInput();            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        // Displays and lets the user interact with the main menu
        public class MainMenu
        {
            MenuContainer Tools = new MenuContainer();

            // This Method will display the screen we made in a text file
            public void displayScreen()
            {
                Console.Clear();                                                  // Clear console for aesthetics
                string menuPath = Tools.FindDir.getMenuDir() + "mainScreen.txt";  // Menu screen path
                Tools.Display.displayText(menuPath);                              // Displays menu screen

                int maxRange = 3;                                                 // Max range of menu choices in the txt file

                Console.Write("                       Please select an option: ");
                string userInput = Console.ReadLine();

                if (Tools.Validate.checkInput(userInput, maxRange) != true)    // Calls boolean method to validate input and checks if true or false
                {
                    Console.ReadKey();
                    displayScreen();
                }
                jumpTree(Convert.ToInt32(userInput));                             // Converts user input for switch case statement
            }
            // This Method will use a jump tree allows the user to select from optioned provided in the text file.
            private void jumpTree(int userChoice)
            {
                RecipeMenu Recipe = new RecipeMenu();                                 // Allows us to move to the RecipeMenu class
                AlgorithmMenu Algorithm = new AlgorithmMenu();                        // Allows us to move to the AlgorithmMenu class
                ExitScreen Exit = new ExitScreen();                                   // Allows us to move to the Exit class
                switch (userChoice)
                {
                    case 1:
                        Recipe.displayScreen();
                        break;
                    case 2:
                        Algorithm.displayScreen();
                        break;
                    case 3:
                        Exit.exitScreen();
                        break;
                    default:
                        Console.WriteLine("Something went wrong in the jumpTree");
                        break;
                }
            }
        }
        // Displays and lets the user interact with the recipe menu
        private class RecipeMenu
        {
            MenuContainer Tools = new MenuContainer();

            // This Method will display the screen we made in a text file
            public void displayScreen()
            {
                Console.Clear();                                                      // Clear console for aesthetics
                string recipePath = Tools.FindDir.getMenuDir() + "recipeScreen.txt";  // Recipe menu screen path
                Tools.Display.displayText(recipePath);                                // Displays the recipe menu screen text
                
                int maxRange = 7;                                                     // Max amount of options in the text file

                Console.Write("                       Please select an option: ");
                string userInput = Console.ReadLine();

                if (Tools.Validate.checkInput(userInput, maxRange) != true)    // Calls boolean method to validate input and checks if true or false
                {
                    Console.ReadKey();
                    displayScreen();
                }
                Console.Clear();
                jumpTree(Convert.ToInt32(userInput));                                 // Convert to int to pass to a switch case
            }
            // This Method will use a jump tree allows the user to select from optioned provided in the text file.
            private void jumpTree(int userChoice)
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
        // Display and lets the user interact with the algorithm menu
        public class AlgorithmMenu
        {
            MenuContainer Tools = new MenuContainer();

            // This Method will display the screen we made in a text file
            public void displayScreen()
            {
                Console.Clear();                                                            // Clear console for aesthetics
                string algorithmPath = Tools.FindDir.getMenuDir() + "algorithmScreen.txt";  // Algorithm menu screen path
                Tools.Display.displayText(algorithmPath);                                   // Displays the algorithm menu screen text

                int maxRange = 4;                                                           // Max amount of options in the text file

                Console.Write("                       Please select an option: ");
                string userInput = Console.ReadLine();

                if (Tools.Validate.checkInput(userInput, maxRange) != true)    // Calls boolean method to validate input and checks if true or false
                {
                    Console.ReadKey();
                    displayScreen();
                }
                Console.Clear();
                jumpTree(Convert.ToInt32(userInput));                                       // Convert to int to pass to a switch case
            }
            // This Method will use a jump tree allows the user to select from optioned provided in the text file.
            private void jumpTree(int userChoice)
            {
                MainMenu Return = new MainMenu();                                           // Allows us to return to the main menu

                Algorithms algorithms = new Algorithms();
                Algorithms.Eratosthenes primes = new Algorithms.Eratosthenes();
                Algorithms.BubbleSort bubblesort = new Algorithms.BubbleSort();
                Algorithms.Euclid euclid = new Algorithms.Euclid();

                switch (userChoice)
                {
                    case 1:
                        bubblesort.entryScreen();
                        break;
                    case 2:
                        euclid.entryScreen();
                        break;
                    case 3:
                        primes.entryScreen();                        
                        break;
                    case 4:
                        Return.displayScreen();
                        break;
                    default:
                        Console.WriteLine("Something went wrong in the jumpTree");
                        break;
                }
                displayScreen();
            }
        }
        // Displays the exit screen when the user is quitting
        private class ExitScreen
        {            
            MenuContainer Tools = new MenuContainer();

            public void exitScreen()
            {
                Console.Clear();

                string exitPath = Tools.FindDir.getMenuDir() + "exitScreen.txt";
                Tools.Display.displayText(exitPath);

                Console.Write("                          Press any key to quit...");
                Console.ReadKey();
                Environment.Exit(0);                 // Closes program is user selects exit
            }
        }
    }
}