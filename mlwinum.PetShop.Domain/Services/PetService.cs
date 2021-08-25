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
            return _petRepository.CreatePet(pet);
        }

        public Pet GetPet(string name)
        {
            return _petRepository.GetPet(name);
        }

        public Pet UpdatePet(Pet oldPet, Pet newPet)
        {
            return _petRepository.UpdatePet(oldPet, newPet);
        }

        public bool RemovePet(Pet pet)
        {
            return _petRepository.DeletePet(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }
    }
}