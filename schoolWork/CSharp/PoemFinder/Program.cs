using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PoemFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Make program that searching through poems folder for edgar allen poe's 'raven'.
             * Check if authors name is in the top of the file, if not then skip the file and move on.
             * Then return the name of the file and place where the line exists. */
            entryScreen();
        }
        public static void entryScreen()
        {
            /* Let user select what author and poem they would like to read from the txt files */
            string author = null;
            string aPoem = null;
               
            Console.WriteLine("Welcome to my poem finder application");
            Console.WriteLine("Select who you would like to find poems from: ");
            Console.WriteLine("1) Edgar Allan Poe");
            Console.WriteLine("2) Walt Whitman");
            while (true)
            {
                int checkNum;

                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out checkNum) && Convert.ToInt32(userInput) <= 2 && Convert.ToInt32(userInput) > 0)
                {
                    switch (Convert.ToInt32(userInput))
                    {
                        case 1:
                            Console.WriteLine("\nYou selected Edgar Allan Poe.\n");
                            author = "Edgar Allan Poe Poems";
                            aPoem = EdgarPoems();
                            break;
                        case 2:
                            Console.WriteLine("\nYou selected Walt Whitman\n");
                            author = "Walt Whitman Poems";
                            aPoem = WhitmanPoems();
                            break;
                        default:
                            Console.WriteLine("This wasn't an option.");
                            Console.Clear();
                            break;                      
                    }
                    break;                
                }
                else
                {
                    Console.WriteLine("This is not an option!");
                }                
            }
            Poem.PoemName(author, aPoem);
        }
        private static string EdgarPoems()
        {
            //List of poems linked to switch case
            string result = null;

            Console.WriteLine("Which Edgar Allan Poe poem would you like to find?");
            Console.WriteLine("1) Annabel Lee");
            Console.WriteLine("2) A Dream Within A Dream");
            Console.WriteLine("3) The Raven");
            Console.WriteLine("4) Eldorado");
            while (true)
            {
                int checkNum;

                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out checkNum) && Convert.ToInt32(userInput) <= 4 && Convert.ToInt32(userInput) > 0)
                {
                    switch (Convert.ToInt32(userInput))
                    {
                        case 1:
                            Console.WriteLine("\nYou selected 'Annabel Lee'\n");
                            result = "Annabel Lee";
                            break;
                        case 2:
                            Console.WriteLine("\nYou selected 'A Dream Within A Dream'\n");
                            result = "A Dream Within A Dream";
                            break;
                        case 3:
                            Console.WriteLine("\nYou selected 'The Raven'\n");
                            result = "The Raven";
                            break;                            
                        case 4:
                            Console.WriteLine("\nYou selected 'Eldorado\n");
                            result = "Eldorado";
                            break;
                        default:
                            Console.WriteLine("This wasn't an option.");
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("This is not an option!");
                }
            }
            return result;

        }
        private static string WhitmanPoems()
        {
            //List of poems linked to switch case

            string result = null;

            Console.WriteLine("Which Walt Whitman poem would you like to find?");
            Console.WriteLine("1) O Captain! My Captain!");
            Console.WriteLine("2) A Clear Midnight");
            Console.WriteLine("3) A Farm-Picture");
            Console.WriteLine("4) A Glimpse");
            while (true)
            {
                int checkNum;

                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out checkNum) && Convert.ToInt32(userInput) <= 4 && Convert.ToInt32(userInput) > 0)
                {
                    switch (Convert.ToInt32(userInput))
                    {
                        case 1:
                            Console.WriteLine("\nYou selected 'O Captain! My Captain!'\n");
                            result = "O Captain! My Captain!";
                            break;
                        case 2:
                            Console.WriteLine("\nYou selected 'A Clear Midnight'\n");
                            result = "A Clear Midnight";
                            break;
                        case 3:
                            Console.WriteLine("\nYou selected 'A Farm-Picture'\n");
                            result = "A Farm-Picture";
                            break;
                        case 4:
                            Console.WriteLine("\nYou selected 'A Glimpse\n");
                            result = "A Glimpse";
                            break;
                        default:
                            Console.WriteLine("This wasn't an option.");
                            break;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("This is not an option!");
                }
            }
            return result;
        }
    }
}
