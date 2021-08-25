using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        bool CreatePetType(PetType pet);
        PetType GetPetType(string name);
        PetType GetPetType(int id);
        PetType UpdatePetType(PetType oldPetType, PetType newPetType);
        bool DeletePetType(PetType pet);
        IEnumerable<PetType> GetAllPetTypes();
    }
}