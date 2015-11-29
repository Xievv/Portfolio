/*
 * Name: Shawn G
 * Date: 11/17/2015
 * Summary: This class will contain a method for creating the array and reading
 * into an HTML template, along with generating an HTML file.
 */

import java.io.File;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.Scanner;

public class GenerateHTML {
    
    ArrayList<String> html = new ArrayList<>();
    
    public void CreateArray(){
        String path = "template.txt";  // Path to read the html template      
        try{
            Scanner read = new Scanner(new File(path));                                           // Scanner to read from the html file            
            
            while(read.hasNext() == true){                                                        // If there are still lines in the file, continue the loop
                html.add(read.nextLine());                                                        // Add line of text into html arraylist
            }
        } catch(Exception e){
            System.out.println("An error has occured in 'CreateArray': " + e);                    // Error catching
        }
    }
    public void linkFinalization(){
        ArrayList<String> htmlLink = new ArrayList<>();
        
        //System.out.println("Reached linkFinalization"); // Troubleshooting
        
        for(int i = 0; i < html.size(); i++){
            if(html.get(i).matches(".*?\\bhttp\\b.*?")){                        // Searches html arraylist for the words 'http'
                String[] splitHtml = html.get(i).split("<td>|<br />|</td>");    // Splits the table code out and puts the URL's into an array
                html.set(i, "");                                                // Clears out the old line of HTML code for replacement
                for(int r = 1; r < splitHtml.length; r++){
                    String url = "          <a href=\"" + splitHtml[r] + "\">" + splitHtml[r] + "</a><br />";  // Creates HTML code for links out of the URL string index
                    html.add(i, url);                                           // Inserts the url into the location of the code
                    //System.out.println(url); // Troubleshooting
                    i+= 1;                                                      // Keeps links in order of which they are put                    
                }
                break;                                                          // Break loop when we find and replace the code
            }
        }
    }
    public void generateHTML(){
        String outputPath = "assignments.html";  // File path for HTML document
        try{
            PrintWriter write = new PrintWriter(outputPath);                    // Used for writing into the HTML output file
            
            for(int i = 0; i < html.size(); i++){
                write.println(html.get(i));                                     // Creates and writes each line of text from html arraylist into the output file location
            }
            write.close();                                                      // Close document to save text
            System.out.println("HTML document generated at: " + outputPath);    // Message to let user know process completed
        } catch (Exception e){
            System.out.println("An error has occured in 'generateHTML': " + e); // Error catching
        }
    }
}
