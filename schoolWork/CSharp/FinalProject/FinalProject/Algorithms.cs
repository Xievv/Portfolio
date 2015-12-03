using System;

namespace FinalProject
{
    class Algorithms
    {
        Utility.FindDirectories FindDir = new Utility.FindDirectories();         // Constructor for our premade tools
        Utility.PrintTxt Display = new Utility.PrintTxt();                       // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        Utility.ValidateInput Validate = new Utility.ValidateInput();            // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        // This class will be used to show off our prime number generator
        public class Eratosthenes
        {
            Algorithms Tools = new Algorithms();                                 // Lets us use our tools

            // This is the entry screen; the user will interact with the program here.
            public void EntryScreen()
            {
                Console.Clear();                                                     // Clear console for aesthetics
                string entryText = Tools.FindDir.getMenuDir() + "primeEntry.txt";    // Get path to our entry screen text file
                Tools.Display.displayText(entryText);                                // Use display utility to print text to console

                Console.Write("\n           Please select a number under 1000 to generate primes to: ");

                string userInput = Console.ReadLine();                               // Grabbing user input
                while(Tools.Validate.checkInput(userInput, 1000) != true)            // Validating input through the validation utility
                {
                    userInput = Console.ReadLine();
                }
                primeArray(Convert.ToInt32(userInput));                              // Pass user input to our algorithm

                Console.WriteLine("\n\n\n                         Press any key to return");
                Console.ReadKey();
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
                        Console.Write("{0}  ", primes[i]);  // puts ',' between numbers
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
