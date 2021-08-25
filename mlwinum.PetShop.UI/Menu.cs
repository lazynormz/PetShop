using System;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using static mlwinum.PetShop.UI.Util.Printer;


namespace mlwinum.PetShop.UI
{
    public class Menu
    {
        private IPetService _petService;

        public Menu(IPetService petService) => (_petService) = (petService);

        public void PrintAllPets()
        {
            foreach (Pet pet in _petService.GetAllPets())
            {
                Print($"Pet: {{ Id: {pet.ID} | Name: \"{pet.Name}\" | Pet Type: \"{pet.Type.Name}\" | Date of birth: {pet.BirthDate} | Buy price: {pet.Price} }}");
            }
        }

        public void PrintPet(string name)
        {
            Pet pet = _petService.GetPet(name);
            Print($"Pet: {{{pet.ID} | {pet.Name} | {pet.Type.Name} | {pet.BirthDate} | {pet.Price}}}");
        }

        public void Start()
        {
            PrintAllPets();
        }
    }
}