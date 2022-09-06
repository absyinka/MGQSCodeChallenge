using System;

namespace BasicApp
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("==================Simple Employee App===============");
                Menu menu = new Menu();
                menu.MainMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}