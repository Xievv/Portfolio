using System;
using System.IO;

/// <summary>
/// Name: Shawn Giroux
/// Class: CIS158M
/// Date: 12/11/2015
/// Summary: This class will be used to handle our algorithm menus
/// and run the algorithms itself. The user will be given a brief
/// description of the algorithm and then get the results.
/// </summary>

namespace FinalProject
{
    class Algorithms
    {
        MenuContainer.AlgorithmMenu backToMenu = new MenuContainer.AlgorithmMenu();

        Utility.FindDirectories FindDir = new Utility.FindDirectories();         // Constructor for our premade tools
        Utility.PrintTxt Display = new Utility.PrintTxt();                       // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        Utility.ValidateInput Validate = new Utility.ValidateInput();            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        // This class will be used to create files for the bubble sort algorithm
        public class BubbleSort
        {
            Algorithms Tools = new Algorithms();

            private string inputPath;   // Input file path
            private string outputPath;  // Output file path

            public void entryScreen()
            {
                Console.Clear();

                string initInputPath = Tools.FindDir.getMenuDir() + "bubbleInput.txt";        // Input file path
                string initOutputPath = Tools.FindDir.getMenuDir() + "bubbleOutput.txt";       // Output file 

                inputPath = initInputPath;
                outputPath = initOutputPath;

                string entryScreen = Tools.FindDir.getMenuDir() + "bubbleEntry.txt";
                Tools.Display.displayText(entryScreen);

                generate();

                Console.WriteLine("\n\n\n\n   " + inputPath);
                Console.WriteLine("\n   " + outputPath);

                Console.Write("\n\n                   Press any key to continue...");
                Console.ReadKey();
                Tools.backToMenu.displayScreen();
            }
            // Create file with numbers 1,000 - 10,000
            private void generate()
            {
                Random random = new Random();                                               // This will create our random numbers

                int increment = 0;                                                          // Lets the while loop fill the input.txt 100 times
                int min = 1000;                                                             // Our minimum value for the random numbers
                int max = 10000;                                                            // Our maximum value for the random numbers

                try
                {
                    using (StreamWriter writeFile = new StreamWriter(inputPath))    // Constructor to write into another file (input.txt)
                    {
                        while (increment < 100)
                        {
                            writeFile.WriteLine(random.Next(min, max) + 1);                 // Writes random numbers between min and max (+1 to offset the 0)
                            increment++;
                        }
                        writeFile.Close();                                                  // Close file to save text
                        createArray();                                                      // Go to our createArray method for the beginning of the algorithm to sort
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured in 'generate': " + e);          // Error catching
                }

            }
            // Read file into array
            private void createArray()
            {
                try
                {
                    int[] numbers = Array.ConvertAll(File.ReadAllLines(inputPath), int.Parse);    // Creates an array full of the input.txt values and converts them to an integer
                    sortArray(numbers);                                                                   // Pass array (numbers) to sortArray method
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured in 'createArray': " + e);                     // Error catching
                }
            }
            // Pass array from createArray and sort it
            private void sortArray(int[] numbers)
            {
                Boolean check = false;                                // Set out check to false for the while loop
                int swap;                                             // Variable for swapping elements in the array
                try
                {
                    while (check == false)
                    {
                        check = true;                                 // Sets to true to end the while loop; if this continues through the loop, algorithm is done
                        for (int i = 0; i < numbers.Length - 1; i++)
                        {
                            if (numbers[i] > numbers[i + 1])           // Checks if previous element is larger than the latter
                            {
                                swap = numbers[i];                    // Swaps variables
                                numbers[i] = numbers[i + 1];          // ^^^^^^^^^^^^^^^
                                numbers[i + 1] = swap;                // ^^^^^^^^^^^^^^^
                                check = false;                        // Continues while loop if it hits this if statement
                            }
                        }
                    }
                    printOutput(numbers);                             // Pass array (numbers) to printOutput method
                }
                catch (Exception e)                                    // Error catching
                {
                    Console.WriteLine("An error has occured in 'sortArray': " + e);
                }
            }
            // Pass array from sortArray and output into a .txt file
            private void printOutput(int[] numbers)
            {
                try
                {
                    using (StreamWriter writeFile = new StreamWriter(outputPath))  // Constructor to write text into output.txt
                    {
                        foreach (var item in numbers)
                        {
                            writeFile.WriteLine(item);                                     // Foreach loop that writes each array element into output.txt
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured in 'printOutput': " + e);      // Error catching
                }
            }
        }
        public class Euclid
        {
            Algorithms Tools = new Algorithms();

            public void entryScreen()
            {
                Console.Clear();

                string entryPath = Tools.FindDir.getMenuDir() + "euclidEntry.txt";
                Tools.Display.displayText(entryPath);
                
                Console.Write("  Enter a non-negative integer under 1,000,000 for the first number: ");
                string firstNum = Console.ReadLine();

                // Validation for the input of first number up to 1,000,000
                if (Tools.Validate.checkInput(firstNum, 1000000) != true)
                {
                    Console.ReadKey();
                    entryScreen();
                }

                Console.Write("\n  Enter a non-negative integer under 1,000,000 for the first number: ");
                string secondNum = Console.ReadLine();

                // Validation for the input of first number up to 1,000,000
                if (Tools.Validate.checkInput(secondNum, 1000000) != true)
                {
                    Console.ReadKey();
                    entryScreen();
                }

                euclideanAlgorithm(Convert.ToInt32(firstNum), Convert.ToInt32(secondNum));

                Console.Write("\n\n\n                       Press any key to continue...");
                Console.ReadKey();
                Tools.backToMenu.displayScreen();
            }
            // This method will run euclids algorithm
            private void euclideanAlgorithm(int firstNum, int secondNum)
            {
                int remainder;

                // Swapping numbers if the first one is smaller than the second so that algorithm works properly
                if (secondNum > firstNum)
                {
                    remainder = firstNum;
                    firstNum = secondNum;
                    secondNum = remainder;
                }

                while (true)
                {
                    remainder = firstNum % secondNum;
                    firstNum = secondNum;
                    secondNum = remainder;
                    if (remainder == 0) { Console.WriteLine("\n                  The GCD between these two numbers is {0}", firstNum); break; }
                    if (remainder == 1) { Console.WriteLine("\n                   There is either a prime number or no GCD"); break; }
                }                
            }
        }
        // This class will be used to show off our prime number generator
        public class Eratosthenes
        {
            Algorithms Tools = new Algorithms();                                 // Lets us use our tools

            // This is the entry screen; the user will interact with the program here.
            public void entryScreen()
            {
                Console.Clear();                                                     // Clear console for aesthetics

                string entryText = Tools.FindDir.getMenuDir() + "primeEntry.txt";    // Get path to our entry screen text file
                Tools.Display.displayText(entryText);                                // Use display utility to print text to console

                Console.Write("\n         Please select a number up to 1000 to generate primes to: ");

                string userInput = Console.ReadLine();                               // Grabbing user input
                if (Tools.Validate.checkInput(userInput, 1000) != true)            // Validating input through the validation utility
                {
                    Console.ReadKey();
                    entryScreen();
                }
                primeArray(Convert.ToInt32(userInput));                              // Pass user input to our algorithm

                Console.WriteLine("\n\n\n                         Press any key to return");
                Console.ReadKey();
                Tools.backToMenu.displayScreen();
            }
            // This method will create our array full of primes and print out our prime numbers.
            private void primeArray(int userInput)
            {
                int startNum = 2;                        // This will be used to populate our primes array
                int[] primes = new int[userInput - 1];   // Creates an array to the size that the user selected

                for (int i = 0; i < primes.Length; i++)  // Fill our array with numbers 1 through the users selection
                {
                    primes[i] = startNum;
                    startNum++;
                }

                sortPrimes(primes);                      // Passes array to our prime finding algorithm

                Console.WriteLine("\n\n                       [Prime Numbers from 2 - {0}]\n", userInput);
                for(int i = 0; i < primes.Length; i++)   // This loop will display our prime numbers
                {
                    if(primes[i] != 0) // If the number is marked as a '0', it is not a prime number
                    {
                        Console.Write("{0}  ", primes[i]);
                    }
                }
            }
            // This method handles the algorithm for returning the prime numbers from our array.
            private int[] sortPrimes(int[] primes)
            {
                int nextPrime = 2;                      // This will be used to determine what our next prime is
                int checkForPrime = 1;                  // This will be used to check the index of array 'primes' for the next prime number

                // This loop will find all numbers in our array and mark the composite numbers as 0
                while (true)
                {
                    // This nested loop will search through our list with our current prime-checking number
                    for (int i = 0; i < primes.Length; i++)
                    {
                        if (primes[i] != nextPrime)
                        {
                            if (primes[i] % nextPrime == 0)  // If we get a 0, the number is composite
                            {
                                primes[i] = 0;               // Mark composite number as 0
                            }
                        }
                    }
                    // This nested loop will find our next number to divide by
                    while (true)
                    {
                        // If the element in primes isn't 0 or the end of our array, then it's our next number
                        if (primes[checkForPrime] != 0 && checkForPrime != primes.Length - 1)  
                        {
                            nextPrime = primes[checkForPrime];
                            checkForPrime++;
                            break;
                        }
                        // If the element is the last in the array, we can break this
                        else if (checkForPrime == primes.Length - 1) { break; }
                        // Increase our checking number to move through our array index
                        else { checkForPrime++; }
                    }
                    // If our prime checker is equal to the end of the array, we are done because all numbers are checked
                    if (checkForPrime == primes.Length - 1) { break; }
                }
                return primes;
            }
        }       
    }
}
