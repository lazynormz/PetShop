using System;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;

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
                Console.WriteLine($"Pet: {{{pet.ID} | {pet.Name} | {pet.Type.Name} | {pet.BirthDate} | {pet.Price}}}");
            }
        }

        public void PrintPet(string name)
        {
            Pet pet = _petService.GetPet(name);
            Console.WriteLine($"Pet: {{{pet.ID} | {pet.Name} | {pet.Type.Name} | {pet.BirthDate} | {pet.Price}}}");
        }
    }
}