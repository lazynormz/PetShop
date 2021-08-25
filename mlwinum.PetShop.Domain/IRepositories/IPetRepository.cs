using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        bool CreatePet(Pet pet);
        Pet GetPet(string name);
        Pet UpdatePet(Pet oldPet, Pet newPet);
        bool DeletePet(Pet pet);
        IEnumerable<Pet> GetAllPets();
    }
}