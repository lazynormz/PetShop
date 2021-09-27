using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType pet);
        PetType GetByID(int id);
        PetType UpdatePetType(int id, PetType newPetType);
        bool RemovePetType(int id);
        IEnumerable<PetType> GetAllPetTypes();
    }
}