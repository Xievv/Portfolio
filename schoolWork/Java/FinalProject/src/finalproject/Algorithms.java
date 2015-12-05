/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package finalproject;

import java.util.Scanner;

/**
 *
 * @author Shawn
 */
public class Algorithms {
    Utilities toolbox = new Utilities();
    Utilities.FilePaths getPath = toolbox.new FilePaths();       // This will get our menu paths to ensure the program can be used from any directory.
    Utilities.TxtFile readText = toolbox.new TxtFile();          // This constructor will display text files.
    Utilities.ValidateInput input = toolbox.new ValidateInput(); // This constructor is used for validating input
    
    MenuContainer menu = new MenuContainer();
    MenuContainer.AlgorithmMenu algorithmMenu = menu.new AlgorithmMenu();
    Scanner scan = new Scanner(System.in);
    
    public class Eratosthenes{
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
}
