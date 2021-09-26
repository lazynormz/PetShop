using System;
using System.Transactions;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.UI.Util;
using static mlwinum.PetShop.UI.Util.Printer;
using static mlwinum.PetShop.UI.Util.Scanner;
using static mlwinum.PetShop.UI.Util.ErrorHandle;


namespace mlwinum.PetShop.UI
{
    public class Menu
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;
        public Menu(IPetService petService, IPetTypeService petTypeService) => (_petService, _petTypeService) = (petService, petTypeService);

        public void PrintMenu()
        {
            Print("1) Create a new pet!");
            Print("2) Create a new pet type!");
            Print("3) Print a list of all registered pets!");
            Print("4) Print a specific pet based on its name!");
            Print("5) Delete a pet from registry");
            Print("6) Delete a pet type from the registry");
            Print("7) Update an existing pet in the registry!");
            Print("");
            Print("99) Exit program!");
        }

        public void PrintAllPets()
        {
            foreach (Pet pet in _petService.GetAllPets())
            {
                Print($"Pet: {{ Id: {pet.ID} | Name: \"{pet.Name}\" | Pet Type: \"{pet.Type.Name}\" | Date of birth: {pet.BirthDate} | Buy price: {pet.Price} }}");
            }
            Print("\n");
        }

        public void PrintPet(string name)
        {
            Pet pet = _petService.GetPet(name);
            Print($"Pet: {{ {pet.ID} | {pet.Name} | {pet.Type.Name} | {pet.BirthDate} | {pet.Price} }}\n");
        }

        private void CreatePet()
        {
            Pet pet = new Pet();
            Print("Enter a name for the new pet...");
            pet.Name = ReadLine();
            Print("What colour is the pet?");
            pet.Colour = ReadLine();
            Print("What is the price of the new pet?");
            pet.Price = ReadDouble();
            Print("What type of animal is the new pet? (not case-sensitive)");
            PetType pt = _petTypeService.GetPetType(ReadLine());
            if (pt != null)
            {
                pet.Type = pt;
                pet.BirthDate = DateTime.Now;
                pet.SoldDate = DateTime.Now;
                if (_petService.CreatePet(pet) != null)
                {
                    Print("Pet created successfully!");
                    Console.WriteLine("\n");
                }
                else
                {
                    Error(ErrorType.FAILED_CREATING_PET);
                }
            }
            else
            {
                Error(ErrorType.FAILED_GETTNG_PET_TYPE);
            }
        }

        public void Start()
        {
            PrintMenu();
            int val;
            while ((val = ReadInt()) != 99)
            {
                switch (val)
                {
                    case 1:
                        CreatePet();
                        PrintMenu();
                        break;
                    case 2:
                        break;
                    case 3:
                        PrintAllPets();
                        PrintMenu();
                        break;
                    case 4:
                        Print("Enter the desired name of pet!");
                        PrintPet(ReadLine());
                        Print("\n");
                        Pause();
                        PrintMenu();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        Error(ErrorType.COMMAND_NOT_RECOGNIZED);
                        PrintMenu();
                        break;
                }
            }
        }
    }
}