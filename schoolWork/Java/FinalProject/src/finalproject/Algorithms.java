/*
 * Name: Shawn Giroux
 * Class: CIS148M
 * Date: 12/9/2015
 * Summary: This class will be used to handle our algorithm menus
 * and run the algorithms itself. The user will be given a brief
 * description of the algorithm and then get the results.
 */

package finalproject;

import java.io.*;
import java.util.Random;
import java.util.Scanner;

public class Algorithms {
    Utilities toolbox = new Utilities();
    Utilities.FilePaths getPath = toolbox.new FilePaths();       // This will get our menu paths to ensure the program can be used from any directory.
    Utilities.TxtFile readText = toolbox.new TxtFile();          // This constructor will display text files.
    Utilities.ValidateInput input = toolbox.new ValidateInput(); // This constructor is used for validating input
    
    // Allows us to return to the algorithm menu
    MenuContainer menu = new MenuContainer();
    MenuContainer.AlgorithmMenu algorithmMenu = menu.new AlgorithmMenu();
    
    Scanner scan = new Scanner(System.in); // Used to get user input throughout the program.
    
    // This class handles the algorithm for Sieve of Eratosthenes
    public class Eratosthenes{
        
        // Entry screen into the Eratosthenes program. User will interact here
        public void EntryScreen(){
            String entryText = getPath.menuFolder() + "/primeEntry.txt";
            readText.displayText(entryText);
            
            System.out.printf("%n           Please select a number under 1000 to generate primes to: ");
            
            String userInput = scan.nextLine();
            while(input.validateInteger(userInput, 1000) != true){
                userInput = scan.nextLine();
            }
            primeArray(Integer.parseInt(userInput));
            
            System.out.printf("%n%n%n                         Press any key to return%n");
            scan.nextLine();
            algorithmMenu.displayScreen();
        }
        // This will create our array of numbers and print out the prime number results
        private void primeArray(int userInput){
            int startNum = 2;
            int[] primes = new int[userInput - 1]; 
            
            for(int i = 0; i < primes.length; i++){
                primes[i] = startNum;
                startNum++;
            }
            
            sortPrimes(primes);
            
            System.out.printf("%n%n                       [Prime Numbers from 2 - %d]%n", userInput);
            for(int i = 0; i < primes.length; i++){
                if(primes[i] != 0){
                    System.out.printf("%d  ", primes[i]);
                }
            }
        }
        // This will sort out all non-primes and return the list back to primeArray
        private int[] sortPrimes(int[] primes){
            int nextPrime = 2;
            int checkForPrime = 1;
            
            while(true){
                for(int i = 0; i< primes.length; i++){
                    if(primes[i] != nextPrime){
                        if(primes[i] % nextPrime == 0){
                            primes[i] = 0;
                        }
                    }
                }
                while(true){
                    if(primes[checkForPrime] != 0 && checkForPrime != primes.length){
                        nextPrime = primes[checkForPrime];
                        checkForPrime++;
                        break;
                    }
                    else if (checkForPrime == primes.length - 1){ break; }
                    else { checkForPrime++; }
                }
                if (checkForPrime == primes.length - 1){ break; }
            }
            return primes;
        }
    }
    // This class handles the algorithm for a bubble sort
    public class BubbleSort{
        
        // These two strings will serve as the paths and displays for the input and output of our bubble sort numbers
        private final String inputPath = getPath.menuFolder() + "\\bubbleInput.txt";
        private final String outputPath = getPath.menuFolder() + "\\bubbleOutput.txt";
        
        // Entry screen into the Bubble sort program. User will interact here
        public void entryScreen(){
            
            String entryText = getPath.menuFolder() + "/bubbleEntry.txt";     // Gets path to the menu screen for the bubble sort
            readText.displayText(entryText);     // Displays our text from the .txt file
            
            System.out.printf("%n%nInput Path: %s", inputPath);    // Shows user where to view the files
            System.out.printf("%nOutput Path: %s%n", outputPath);  // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            
            generate();  // runs the process for bubble sort and creates the files at the input and output locations
            
            System.out.printf("%n%n%n                         Press any key to return%n");
            
            scan.nextLine();
            algorithmMenu.displayScreen();
        }
        // Create file with numbers 1,000 - 10,000 
        private void generate(){                                   
            File file = new File(inputPath);                                    // This will be used to create a file at inputPath location
            Random random = new Random();                                       // This will be used to create our random numbers
            
            int increment = 0;                                                  // Ensures the while loop goes 100 times as we add to it
            int min = 1000;                                                     // Lowest out random number can be
            int max = 10000;                                                    // Highest our random number can be
            
            try{
                file.createNewFile();                                           // Creates file at inputPath location
                PrintWriter write = new PrintWriter(inputPath);                 // Constructor for our file output   
                
                while(increment < 100){
                    write.println(random.nextInt(max - min + 1) + min);         // writes out random number, +1 offsets the 0 it starts at
                    increment++;
                }
                write.close();                                                  // Closes file to save text input
            } catch(Exception e){
                System.out.println("An error has occured in 'generate': " + e); // Error catching
            }
            createArray();
        }
        // Read file into array
        private void createArray(){
            int numbers[] = new int[100];                                          // Creates an array with 100 elements (0 - 99)
            int increment = 0;                                                     // Incrementing variables used for while loop to 100
            try{
                Scanner write = new Scanner(new FileReader(inputPath));            // This will read our input from input.txt                
                while(increment < 100){
                    numbers[increment] = write.nextInt();                          // Changes each element in numbers array to the text file numbers
                    increment++;
                }                
            }catch(Exception e){
                System.out.println("An error has occured in 'createArray': " + e); // Error catching
            }
            sortArray(numbers);                                                    // Pass our array along        
        }
        // Pass array from createArray and sort
        private void sortArray(int numbers[]){
            boolean check = false;                                                // Will be used to continue our while loop
            int swap;                                                             // This will be used for swapping numbers through the array
            try{
                while(check == false){
                    check = true;                                                 // Sets to true for the loop to end
                    for(int i = 0; i < numbers.length-1; i++){
                        if(numbers[i] > numbers[i+1]){                            // Swap numbers if the lower element is greater than the higher element
                            swap = numbers[i];                                    // Trade numbers off and swap
                            numbers[i] = numbers[i+1];                            // ^^^^^^^^^^^^^^^^^^^^^^^^^^
                            numbers[i+1] = swap;                                  // ^^^^^^^^^^^^^^^^^^^^^^^^^^
                            check = false;                                        // Keeps loop going until all numbers have been shifted down into position
                        }
                    }
                }
            }catch(Exception e){
                System.out.println("An error has occured in 'sortArray': " + e);  // Error catching
            }
            printOutput(numbers);                                                 // Pass our array along
        }
        // Pass array from sortArray and output into a .txt file
        private void printOutput(int numbers[]){
            File file = new File(outputPath);                                   // Used for creating output file
            try{                
                file.createNewFile();                                           // Tries to create output.txt
                PrintWriter write = new PrintWriter(outputPath);                // Used for writing into our output.txt file
                for(int i = 0; i < numbers.length;i++){
                    write.println(numbers[i]);                                  // Writing the elements into the file
                }
                write.close();                                                  // Close file to save the .txt file
                System.out.println("Process complete.");
            }catch(Exception e){
                System.out.println("An error has occured in 'printOutput': " + e); 
            }
        }
    }
    // This class handles the algorithm for the Euclidean Algorithm
    public class Euclid{
        
        // Entry screen into the Euclid program. User will interact here
        public void entryScreen(){            
            
            String entryText = getPath.menuFolder() + "\\euclidEntry.txt";    // Path for the Euclid menu screen
            readText.displayText(entryText);  // Prints out the text from a text file
                        
            System.out.print("  Enter in a non-negative integer under 1,000,000 for first number: ");
            String firstNum = scan.nextLine();   
            
            // This while loop will use our validate integer utility to check for a number under 1,000,000
            while(input.validateInteger(firstNum, 1000000) != true){
                firstNum = scan.nextLine();
            }
            
            System.out.print("\n  Enter in a non-negative integer under 1,000,000 for the second number: ");
            String secondNum = scan.nextLine();
            
            // This while loop will use our validate integer utility to check for a number under 1,000,000
            while(input.validateInteger(secondNum, 1000000) != true){
                secondNum = scan.nextLine();
            }
            euclideanAlgorithm(Integer.parseInt(firstNum),Integer.parseInt(secondNum));  // We must convert out strings to integers before passing the parameters
            
            System.out.println("\n                         Press any key to return");
            
            scan.nextLine();
            algorithmMenu.displayScreen();
        }
        // This method will do the process for the Euclidean Algorithm
        private void euclideanAlgorithm(int firstNum, int secondNum){
            int remainder = 0;

            if (firstNum < secondNum){ // Swap if firstNum is less than secondNum
                remainder = firstNum;
                firstNum = secondNum;
                secondNum = remainder;
            }

            while(true){  // Runs loops to find if there is a GCD between two numbers given by user
                remainder = firstNum - secondNum;
                firstNum = remainder;
                if (firstNum < secondNum){
                    firstNum = secondNum;
                    secondNum = remainder;
                }
                if (remainder == 0){
                    System.out.println("\n                    The GCD between these two numbers is: " + firstNum);
                    break;
                }
                if (remainder == 1){
                    System.out.println("\n                One of these numbers is prime or there is no GCD.");
                    break;
                }
            }
        }
    }
}
~