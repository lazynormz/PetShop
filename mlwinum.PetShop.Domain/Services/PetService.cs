using System.Collections.Generic;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository petRepository) => (_petRepository) = (petRepository);
        public bool CreatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(string name)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet oldPet, Pet newPet)
        {
            throw new System.NotImplementedException();
        }

        public bool RemovePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
        }
    }
}