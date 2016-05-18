using System;

/// <summary>
/// Name: Shawn Giroux
/// Class: CIS158M
/// Date: 10/29/2015
/// Summary: This class is just the entry into the program.
/// It will immediately send the program off to the menu 
/// container class.
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
