/*
 * Name: Shawn Giroux
 * Date: 10/28/2015
 * Summary: This class is currently being used to select which
 * menu the user would like to go to.
 */
package finalproject;

public class FinalProject {

    public static void main(String[] args) {
        Utilities utility = new Utilities();
        Utilities.txtFile help = utility.new txtFile();
        help.displayText("E:\\Programming\\Java\\menu\\mainScreen.txt");
    }
}