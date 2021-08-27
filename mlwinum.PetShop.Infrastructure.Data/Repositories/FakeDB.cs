using System;
using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class FakeDB : IPetRepository, IPetTypeRepository
    {
        private List<Pet> _pets;
        private List<PetType> _petTypes;
        
        private static int _petId;
        private static int _petTypeId;

        public FakeDB()
        {
            _pets = new List<Pet>();
            _petTypes = new List<PetType>();
            _petId = 0;
            _petTypeId = 0;
            InitData();
        }

        public void InitData()
        {
            //Random petTypes
            CreatePetType(new PetType(_petTypeId, "Cat"));
            CreatePetType(new PetType(_petTypeId, "Dog"));
            CreatePetType(new PetType(_petTypeId, "Fish"));
            CreatePetType(new PetType(_petTypeId, "Goat"));
            CreatePetType(new PetType(_petTypeId, "Cow"));
            CreatePetType(new PetType(_petTypeId, "Pig"));
            CreatePetType(new PetType(_petTypeId, "Chicken"));
            //Random pets
            CreatePet(new Pet("a",GetPetType(0),DateTime.Now, DateTime.Now,"",123));
            CreatePet(new Pet("b",GetPetType(1),DateTime.Now, DateTime.Now,"",456));
            CreatePet(new Pet("c",GetPetType(2),DateTime.Now, DateTime.Now,"",789));
            CreatePet(new Pet("d",GetPetType(3),DateTime.Now, DateTime.Now,"",159));
            CreatePet(new Pet("e",GetPetType(4),DateTime.Now, DateTime.Now,"",753));
            CreatePet(new Pet("f",GetPetType(5),DateTime.Now, DateTime.Now,"",951));
            CreatePet(new Pet("g",GetPetType(6),DateTime.Now, DateTime.Now,"",753));
        }

        public bool CreatePet(Pet pet)
        {
            //TODO: Make sure there are no duplicates in the list
            pet.ID = _petId;
            _pets.Add(pet);
            ++_petId;
            return true;
        }

        public Pet GetPet(string name)
        {
            return _pets.Find(pet => pet.Name.ToLower() == name.ToLower());
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

        public bool CreatePetType(PetType type)
        {
            //TODO: Make sure no duplicates are available
            type.Name = type.Name.ToLower();
            _petTypes.Add(type);
            _petTypeId++;
            return true;
        }

        public PetType GetPetType(string name)
        {
            return _petTypes.Find(type => type.Name.ToLower() == name.ToLower());
        }

        public PetType GetPetType(int id)
        {
            return _petTypes.Find(type => type.ID == id);
        }

        public PetType UpdatePetType(PetType oldPetType, PetType newPetType)
        {
            throw new NotImplementedException();
        }

        public bool DeletePetType(PetType pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypes;
        }
    }
}