﻿
using UI;

namespace Driver
{
    class Driver
    {
        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager();
            while (true)
            {
                try
                {
                    menuManager.ShowMenu();
                    int choice = menuManager.GetChoice();
                    menuManager.RunOperation(choice);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}