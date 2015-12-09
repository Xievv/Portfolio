/*
 * Name: Shawn Giroux
 * Date: 11/6/2015
 * Summary: This class will be used to hold the tools that will
 * help us complete tasks that would otherwise need to be
 * repeated throughout the entire program.
 */

package finalproject;

import java.util.ArrayList;
import java.util.Scanner;
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;


public class Utilities {
    class TextCounter{
        // This class will hold the classes and methods needed to count lines and the character amounts.
        class Tool{
            private final String outputPath = "E:\\Programming\\Java\\programs\\FinalProject\\src\\Output.txt";    

            private ArrayList fileStorage = new ArrayList(); // This array will be used to hold the contents of each file for both classes.
            private String path;                             // Holds the path name that was passed to getFileContents.

            // This method will fill fileStorage with the contents of a text file.
            public void getFileContents(String filePath){
                ArrayList storage = new ArrayList();                  // Creating an ArrayList that will hold the contents of a text file.
                path = filePath;                                      // Sets the instance variable path to equal the string passed through the parameter.
                try{
                    Scanner read = new Scanner(new File(filePath));   // Creating a scanner to take in the text files contents.
                    while(read.hasNextLine()){                        // This will continue the loop until we have reached the end of the text files contents.
                        storage.add(read.nextLine());                 // Adds the file contents to the storage array.
                    }
                }catch(Exception e){
                    System.out.println("An error has occured in getFileContents: " + e); // Catching any errors that may occur while reading and storing information.
                }
                fileStorage = storage;                                // Passes all information to the instance variable array list for further use in the next classes.        
            }

            // This class will print and count the amount of lines in a file
            class LineCount{
                public void printLine(){            
                    try{    
                        PrintWriter output = new PrintWriter(outputPath);               // To be used for writing in the file.
                        int lineTotal = fileStorage.size();                             // Finds the line total by counting the amount of elements in the arraylist.
                        File fileName = new File(path);                                 // This will be used to grab the exact name of the text file.
                        output.printf("Reading from: %s%n%n", fileName.getName());      // Prints out the name of the text file using fileName.
                        for(int i = 0; i < fileStorage.size();i++){                     // This for loop will print the text file.
                            output.println(fileStorage.get(i));
                        }                
                        output.printf("There are a total of %d lines in this file.%n%n", lineTotal); 
                        output.close();                                                 // Close file to save the input.
                    } catch (Exception e){
                        System.out.println("An error has occured in LineCount: " + e);  // Catch any errors that may occur with pathing and such.
                        System.out.println("Path equals: " + path);
                    }
                }            
            }
            // This class will count the amount of characters in a line
            class LineSize{
                public void printChars(){
                    try{
                        PrintWriter output = new PrintWriter(new FileWriter(outputPath, true));
                        File fileName = new File(path);                                                       // This will be used to grab the exact name of the text file.
                        output.printf("Counting the amount characters from %s%n%n", fileName.getName());      // Prints out name of the file using fileName.
                        for(int i = 0; i < fileStorage.size(); i++){
                            String charCount = fileStorage.get(i).toString();                                 // Makes a string from an element of fileStorage to use while counting characters.
                            output.printf("There are %s characters in line %d%n", charCount.length(), i+1);   // Finds the length of charCount which is the amount of characters in the fileStorage element.
                        }
                        output.close();                                                                       // Close file to save input.
                    } catch (Exception e){
                        System.out.println("An error has occured in LineSize: " + e);                         // Catch any errors that may occur with pathing and such.
                        System.out.println("Path equals: " + path);
                    }
                }
            }
        }
        // This class is where the user provide the screens for the user to interact with the tool class.
        class UserInterface{

            private final Scanner input = new Scanner(System.in);                                      // To be used for user input.

            private final String menuPathString = "E:\\Programming\\Java\\menu\\";                     // String path for menus.
            private final String recipePathString = "E:\\Programming\\Java\\recipes\\";                // String path for recipes.        
            private final File menuPath = new File(menuPathString);                                    // This will help us get the file names later.
            private final File recipePath = new File(recipePathString);                                // ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            private final File[] menuFileNames = menuPath.listFiles();                                 // Creates a file array for file names.
            private final File[] recipeFileNames = recipePath.listFiles();                             // Creates a file array for file names.

            public void jumpTree(){

            System.out.println("Which path would you like to read from?");
            System.out.println("1) " + menuPath);
            System.out.println("2) " + recipePath);

            String userInput = input.nextLine();                                                // String for user input.

            switch(Integer.parseInt(userInput)){                                                // Convert to int for selecting an item.
                case 1: System.out.println("Here are the files in " + menuPathString);
                    for(int i = 0; i < menuFileNames.length;i++){
                        System.out.printf("%d) %s%n", i+1, menuFileNames[i].getName());         // Displays the file names is a nice and neat manner.
                    }
                    System.out.println("Select a file.");
                    menuScreenCont();
                    break;
                case 2: System.out.println("Here are all the files in " + recipePathString);
                    for(int i = 0; i < recipeFileNames.length;i++){
                        System.out.printf("%d) %s%n", i+1, recipeFileNames[i].getName());       // Displays the file names is a nice and neat manner.
                    }
                    System.out.println("Select a file.");
                    recipeScreenCont();
                    break;
                default: System.out.println("This wasn't an option.");
                    break;

                }        
            }
            private void menuScreenCont(){          
                ArrayList check = new ArrayList();                              // This arraylist is used to validate users input.

                Utilities.TextCounter.Tool tool = new Utilities.TextCounter.Tool();                         // Constructor for Tool Utility.
                Utilities.TextCounter.Tool.LineCount count = tool.new LineCount();            // Constructor for LineCount class in Utility.
                Utilities.TextCounter.Tool.LineSize size = tool.new LineSize();               // Constructor for LineSize class in Utility.

                String userInput = input.nextLine();
                int choice = Integer.parseInt(userInput);                       // Get the integer value of users input to use as an index selector in the file array.
                for(int i = 0; i < menuFileNames.length;i++){
                    check.add(i);
                }
                if(check.contains(choice-1)){
                    tool.getFileContents(menuFileNames[choice-1].toString());   // Calls and passes the parameters of getFileContents with the file selected.
                    count.printLine();
                    size.printChars();
                    System.out.printf("Process complete. Output is at '%s'%n", tool.outputPath);
                } 
                else{
                    System.out.println(check);
                    System.out.println("Invalid input.");
                }
            }
            private void recipeScreenCont(){          
                ArrayList check = new ArrayList();                              // This arraylist is used to validate users input.

                Utilities.TextCounter.Tool tool = new Utilities.TextCounter.Tool();                         // Constructor for Tool Utility.
                Utilities.TextCounter.Tool.LineCount count = tool.new LineCount();            // Constructor for LineCount class in Utility.
                Utilities.TextCounter.Tool.LineSize size = tool.new LineSize();               // Constructor for LineSize class in Utility.

                String userInput = input.nextLine();
                int choice = Integer.parseInt(userInput);                       // Get the integer value of users input to use as an index selector in the file array.
                for(int i = 0; i < recipeFileNames.length;i++){
                    check.add(i);
                }
                if(check.contains(choice-1)){
                    tool.getFileContents(recipeFileNames[choice-1].toString()); // Calls and passes the parameters of getFileContents with the file selected.
                    count.printLine();
                    size.printChars();
                    System.out.printf("Process complete. Output is at '%s'%n", tool.outputPath);
                } 
                else{
                    System.out.println(check);
                    System.out.println("Invalid input.");
                }
            }
        }  
    }
    // This class will write our txt files throughout the program for the user.
    class TxtFile{
        public void displayText(String path){
            try{
                Scanner read = new Scanner(new File(path));     // Using scanner to read from the file.                
                while(read.hasNextLine() != false){             // While loop runs as long as more text in txt file remains.
                    System.out.println(read.nextLine());        // Prints out our text from the text file.
                }
            } catch (Exception e){
                System.out.println("An error has occured in \"Utilities.Txt.File.displayText\": " + e);
            }
        }
    }
    // This class will pull the directory paths we need to ensure the program will work regardless to where it is on someones computer.
    class FilePaths{
        // This method will get the menu folder directory.
        public String menuFolder(){
            File file;                                          // Used for manipulation of file paths
            String startDir = System.getProperty("user.dir");   // Grabs directory that the program resides in
            file = new File(startDir + "/src/menu");            // Prepares the path for the menu directory
            String returnPath = null;                           // Initializes returnPath for the method's return
            try{
                returnPath = file.getCanonicalPath();           // Finalizes the menu directory path
            } catch(Exception e) {
                System.out.println("An error has occured in \"Utilities.FilePaths.menuFolder\": " + e);        
            }
            return returnPath;
        }
        // this method will get the recipe folder director.
        public String recipeFolder(){
            File file;                                           // Used for manipulation of file paths
            String startDir = System.getProperty("user.dir");    // Grabs directory that the program resides in
            file = new File(startDir + "/src/recipes");          // Prepares the path for the recipe directory
            String returnPath = null;                            // Intializes returnPath for the method's return
            try{
                returnPath = file.getCanonicalPath();            // Finalizes the menu directory path
            } catch(Exception e) {
                System.out.println("An error has occured in \"Utilities.FilePaths.menuFolder\": " + e);        
            }
            return returnPath;
        }
    }
    // This class will be used to validate input from user
    class ValidateInput{
        // This method is going to validate integer input
        public boolean validateInteger(String userInput, int rangeMax){
            int testInt;                                       // Int for attempting to convert user input
            try{                
                testInt = Integer.parseInt(userInput);         // Tries to convert user input to an integer
                //System.out.println("Validation success!");           // Troubleshooting.
            } catch (Exception e){
                System.out.println("This is not an integer!"); // If conversion fails, send message to user and return false
                return false;
            }
            if(testInt <= rangeMax && testInt > 0){            // This if statement checks if we're within the specified boundaries of the text file
                return true;
            } else {
                System.out.println("This number was not a choice."); 
                return false;
            }           
        }
    }
}
