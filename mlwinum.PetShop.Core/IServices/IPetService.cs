using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IServices
{
    public interface IPetService
    {
        bool CreatePet(Pet pet);
        Pet GetPet(string name);
        Pet UpdatePet(Pet oldPet, Pet newPet);
        bool RemovePet(Pet pet);
        IEnumerable<Pet> GetAllPets();
    }
}