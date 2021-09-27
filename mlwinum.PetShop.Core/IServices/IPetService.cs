using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IServices
{
    public interface IPetService
    {
        Pet CreatePet(Pet pet);
        Pet GetPet(int id);
        Pet UpdatePet(int id, Pet newPet);
        bool DeletePetID(int id);
        IEnumerable<Pet> GetAllPets();
    }
}