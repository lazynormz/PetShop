using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepositories
    {
        bool CreatePetType(PetType pet);
        PetType GetPetType(string name);
        PetType UpdatePetType(PetType oldPetType, PetType newPetType);
        bool DeletePetType(PetType pet);
        IEnumerable<PetType> GetAllPetTypes();
    }
}