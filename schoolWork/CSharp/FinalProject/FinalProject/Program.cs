using System;

/// <summary>
/// Name: Shawn Giroux
/// Date: 10/29/2015
/// Summary: This class is the entry screen into the program
/// </summary>

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuContainer.MainMenu MainMenu = new MenuContainer.MainMenu();
            MainMenu.displayScreen();
            Console.ReadLine();
        }
    }
}
