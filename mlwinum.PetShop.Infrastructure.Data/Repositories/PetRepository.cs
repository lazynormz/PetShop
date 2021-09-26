using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(string name)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPet(long id)
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