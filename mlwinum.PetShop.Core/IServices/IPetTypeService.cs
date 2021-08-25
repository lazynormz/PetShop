using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IServices
{
    public interface IPetTypeService
    {
        bool CreatePetType(PetType pet);
        PetType GetPetType(string name);
        PetType UpdatePetType(PetType oldPetType, PetType newPetType);
        bool RemovePetType(PetType pet);
        IEnumerable<PetType> GetAllPetTypes();
    }
}