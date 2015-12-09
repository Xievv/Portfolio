/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class is just the entry into the program.
 * It will immediately send the program off to the menu container
 * class.
 */

package finalproject;

public class FinalProject {

    public static void main(String[] args) {
        // Starts us in our main menu
        MenuContainer menu = new MenuContainer();
        MenuContainer.MainMenu startProgram = menu.new MainMenu();
        startProgram.displayScreen();
    }
}