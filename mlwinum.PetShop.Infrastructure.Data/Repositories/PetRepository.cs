using System;
using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private List<Pet> _pets;
        private List<PetType> _petTypes;
        private static int _id;

        public PetRepository()
        {
            _pets = new List<Pet>();
            _petTypes = new List<PetType>();
            _id = 0;
            InitData();
        }

        public void InitData()
        {
            CreatePet(new Pet(_id,"a",null,DateTime.Now, DateTime.Now,"",123));
            CreatePet(new Pet(_id,"b",null,DateTime.Now, DateTime.Now,"",456));
            CreatePet(new Pet(_id,"c",null,DateTime.Now, DateTime.Now,"",789));
            CreatePet(new Pet(_id,"d",null,DateTime.Now, DateTime.Now,"",159));
            CreatePet(new Pet(_id,"e",null,DateTime.Now, DateTime.Now,"",753));
            CreatePet(new Pet(_id,"f",null,DateTime.Now, DateTime.Now,"",951));
            CreatePet(new Pet(_id,"g",null,DateTime.Now, DateTime.Now,"",753));
        }

        public bool CreatePet(Pet pet)
        {
            //TODO: Make sure there are no duplicates in the list
            _pets.Add(pet);
            _id++;
            return true;
        }

        public Pet GetPet(string name)
        {
            throw new System.NotImplementedException();
        }

        public Pet UpdatePet(Pet oldPet, Pet newPet)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePet(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _pets;
        }
    }
}