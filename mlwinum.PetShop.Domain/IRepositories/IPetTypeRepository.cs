using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType CreatePetType(PetType pet);
        PetType GetPetType(int id);
        PetType UpdatePetType(int id, PetType newPetType);
        bool DeletePetType(int id);
        IEnumerable<PetType> GetAllPetTypes();
    }
}