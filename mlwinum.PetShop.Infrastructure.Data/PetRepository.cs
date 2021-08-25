using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
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

        public bool DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            throw new System.NotImplementedException();
        }
    }
}