using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        public Pet AddPet(Pet pet);
        public Pet GetPet(int? id);
        public Pet UpdatePet(int id, Pet newPet);
        public bool DeletePet(int id);
        public IEnumerable<Pet> GetAllPets();
    }
}