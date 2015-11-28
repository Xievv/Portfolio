/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class is currently being used to select which
 * menu the user would like to go to.
 */
package finalproject;

public class FinalProject {

    public static void main(String[] args) {
        MenuContainer menu = new MenuContainer();
        MenuContainer.MainMenu startProgram = menu.new MainMenu();
        startProgram.displayScreen();
    }
}