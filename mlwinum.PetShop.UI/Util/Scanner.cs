using System;

namespace mlwinum.PetShop.UI.Util
{
    public class Scanner
    {
        public static void Pause()
        {
            Console.WriteLine("<Press enter to resume>");
            Console.ReadLine();
            Console.WriteLine("\n");
        }
        public static int ReadInt()
        {
            int val;
            if(int.TryParse(Console.ReadLine().Split(" ")[0], out val))
            {
                Console.WriteLine("\n");
                return val;
            }
            return -99;
        }

        public static double ReadDouble()
        {
            double val;
            if (double.TryParse(Console.ReadLine().Split(" ")[0], out val))
            {
                Console.WriteLine("\n");
                return val;
            }
            return -99d;
        }

        public static string ReadLine()
        {
            string val = Console.ReadLine();
            Console.WriteLine("\n");
            return val;
        }
    }
}