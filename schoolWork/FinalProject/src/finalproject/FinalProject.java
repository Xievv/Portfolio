/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class is currently being used to select which
 * menu the user would like to go to.
 */
package finalproject;

import java.util.Scanner;

public class FinalProject {

    public static void main(String[] args) {
        MenuContainer menu = new MenuContainer();
        MenuContainer.MainMenu startProgram = menu.new MainMenu();
        startProgram.displayScreen();
        
        
        /*Utilities tools = new Utilities();
        Utilities.FilePaths filePaths = tools.new FilePaths();
        Utilities.TxtFile display = tools.new TxtFile();
        Utilities.ValidateInput input = tools.new ValidateInput();
        Scanner scan = new Scanner(System.in);
        
        String menuDir = filePaths.menuFolder();
        String recipeDir = filePaths.recipeFolder();
        int rangeMax = 3;
        
        display.displayText(menuDir + "/recipeScreen.txt");
        
        String userInput = scan.nextLine();

        while(input.validateInteger(userInput, rangeMax) != true){
            userInput = scan.nextLine();
        }
        switch(Integer.parseInt(userInput)){
            case 1: display.displayText(recipeDir + "/bakedChickenPotatoFinal.txt");
                if (scan.nextLine() != null){ main(null); }
                break;
        }*/
        
    }
}