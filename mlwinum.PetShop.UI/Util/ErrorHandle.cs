using System;
using static mlwinum.PetShop.UI.Util.Printer;

namespace mlwinum.PetShop.UI.Util
{
    public class ErrorHandle
    {
        public void Error(ErrorType error)
        {
            switch (error)
            {
                case ErrorType.FAILED_CREATING_PET:
                    PrintError("Failed creating Pet instance");
                    break;
                case ErrorType.FAILED_CREATING_PETTYPE:
                    PrintError("Failed creating PetType instance");
                    break;
                case ErrorType.FAILED_DELETING_PET:
                    PrintError("Failed deleting pet from database");
                    break;
                case ErrorType.FAILED_DELETING_PETTYPE:
                    PrintError("Failed deleting pet type from database");
                    break;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }
}