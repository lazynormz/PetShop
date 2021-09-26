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
            //TODO: override Pet.ToString instead of using this method
            Pet pet = _petService.GetPet(name);
            if (pet != null)
            {
                Print($"Pet: {{ {pet.ID} | {pet.Name} | {pet.Type.Name} | {pet.BirthDate} | {pet.Price} }}\n");
                return;
            }
            Error(ErrorType.FAILED_GETTING_PET);
        }

        private void UpdatePet(string petName)
        {
            Pet oPet = _petService.GetPet(petName);
            Pet pet = oPet;
            if (pet == null)
            {
                Error(ErrorType.FAILED_GETTING_PET);
                return;
            }
            Print("If pre-existing data is correct, leave field empty...\n");
            Print($"Enter new name of pet ({pet.Name})");
            string name, colour;
            double price;
            DateTime soldDate;
            if ((name = ReadLine()) != String.Empty)
                pet.Name = name;
            Print($"Enter new colour of pet ({pet.Colour})");
            if ((colour = ReadLine()) != String.Empty)
                pet.Colour = colour;
            Print($"Enter new price of pet ({pet.Price})");
            if ((price = ReadDouble()) != -99d)
                pet.Price = price;
            _petService.UpdatePet(oPet, pet);
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

        private void DeletePet(string petName)
        {
            if(!_petService.RemovePet(_petService.GetPet(petName)))
                Error(ErrorType.FAILED_DELETING_PET);
        }

        private void DeletePetType(string typeName)
        {
            if(!_petTypeService.RemovePetType(_petTypeService.GetPetType(typeName)))
                Error(ErrorType.FAILED_DELETING_PETTYPE);
        }

        public void Start()
        {
            PrintMenu();
            int val;
            while ((val = ReadInt()) != 99)
            {
                switch (val)
                {
                    case 1:             //Create pet
                        CreatePet();
                        PrintMenu();
                        break;
                    case 2:             //Create a new pet-type
                        break;
                    case 3:             //Print list of all pets
                        PrintAllPets();
                        PrintMenu();
                        break;
                    case 4:             //Print specific pet
                        Print("Enter the desired name of pet!");
                        PrintPet(ReadLine());
                        Print("\n");
                        Pause();
                        PrintMenu();
                        break;
                    case 5:             //Delete a pet
                        Print("Enter the name of pet to delete...");
                        DeletePet(ReadLine());
                        PrintMenu();
                        break;
                    case 6:             //Delete a pet-type
                        Print("Enter the name of the pet-type to be deleted");
                        DeletePetType(ReadLine());
                        PrintMenu();
                        break;
                    case 7:             //Update a pet from the registry; search for pet -> update values -> upload
                        Print("Enter the name of pet you wish to update...");
                        UpdatePet(ReadLine());
                        PrintMenu();
                        break;
                    default:            //Error; command not found
                        Error(ErrorType.COMMAND_NOT_RECOGNIZED);
                        PrintMenu();
                        break;
                }
            }
        }
    }
}