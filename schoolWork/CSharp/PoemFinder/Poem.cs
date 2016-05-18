using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PoemFinder
{
    class Poem
    {
        public static void PoemName(string author, string poem)
        {
            /* This will send the message back to the Program class. */

            //Console.WriteLine("Passed author: " + author);
            //Console.WriteLine("Passed Poem: " + poem);

            /* Default test variables
            string authors = "Edgar Allan Poe Poems";
            string poems = "The Raven"; */

            PoemFind(author, poem);
            Console.ReadKey();
        }

        private static void PoemFind(string author, string poem)
        {
            /* This will find the poem and file.  Turn private when done testing. */
            string dir = @"E:\Programming\C#\programs\PoemFinder\poems";

            String[] testFile = Directory.GetFiles(dir);
            foreach(var item in testFile)
            {
                // Item is going to equal a file path.  The files paths in the array are in the order
                // in which they are in the directory (dir).
                //Console.WriteLine(item);  // Displays file paths.
                string line1 = File.ReadLines(item).First();

                if (line1 == author)
                {
                    string[] findPoem = File.ReadAllLines(item);
                    for (int line = 0; line < findPoem.Length; line++)
                    {
                        if (findPoem[line] == poem)
                        {
                            int linenum = line += 1;
                            Console.WriteLine(poem + " is located on line " + linenum + " of:\n'" + item + "'." );
                            break;
                        }
                    }
                    break;
                }
                /*else
                {
                    Console.WriteLine("We were unable to find that author.");
                }*/
            }
        }
    }
}
