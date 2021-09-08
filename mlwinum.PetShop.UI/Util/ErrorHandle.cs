using System;
using static mlwinum.PetShop.UI.Util.Printer;

namespace mlwinum.PetShop.UI.Util
{
    public class ErrorHandle
    {
        public static void Error(ErrorType error)
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
                case ErrorType.COMMAND_NOT_RECOGNIZED:
                    PrintError("Command was not recognized, try again");
                    break;
                case ErrorType.FAILED_GETTNG_PET_TYPE:
                    PrintError("Type of pet not found in the database");
                    break;
                case ErrorType.FAILED_GETTING_PET:
                    PrintError("Pet with specified name was not found in the database");
                    break;
                default:        //Case we manage to input something that doesn't exist; shouldn't really be a case
                    Console.WriteLine();
                    break;
            }
        }
    }
}