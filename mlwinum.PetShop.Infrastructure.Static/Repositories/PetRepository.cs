using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static List<Pet> _pets;
        private static int _id;
        
        public PetRepository()
        {
            _pets = new List<Pet>();
            _id = 0;
        }
        
        public Pet CreatePet(Pet pet)
        {
            //TODO: Make sure there are no duplicates in the list
            pet.ID = _id;
            _pets.Add(pet);
            ++_id;
            return pet;
        }

        public Pet GetPet(string name)
        {
            return _pets.Find(pet => pet.Name.ToLower() == name.ToLower());
        }

        public Pet GetPet(long id)
        {
            return _pets.Find(pet => pet.ID == id);
        }

        public Pet UpdatePet(Pet oldPet, Pet newPet)
        {
            //TODO: Check if pet is actually in list
            Pet p = _pets.Find(pet => pet.Equals(oldPet));
            p.Name = newPet.Name;
            p.Colour = newPet.Colour;
            p.Price = newPet.Price;
            p.Type = newPet.Type;
            p.SoldDate = newPet.SoldDate;
            _pets[_pets.IndexOf(oldPet)] = p;
            return p;
        }

        public bool DeletePet(Pet pet)
        {
            return _pets.Remove(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _pets;
        }
    }
}