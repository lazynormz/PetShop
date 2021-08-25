using System;

namespace mlwinum.PetShop.UI.Util
{
    public class Printer
    {
        public static void PrintError(string errorMessage)
        {
            Console.WriteLine("[ ERROR ]: " + errorMessage);
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}