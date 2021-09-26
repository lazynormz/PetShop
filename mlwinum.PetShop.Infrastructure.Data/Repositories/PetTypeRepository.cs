using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public bool CreatePetType(PetType pet)
        {
            throw new System.NotImplementedException();
        }

        public PetType GetPetType(string name)
        {
            throw new System.NotImplementedException();
        }

        public PetType GetPetType(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType UpdatePetType(PetType oldPetType, PetType newPetType)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePetType(PetType pet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}