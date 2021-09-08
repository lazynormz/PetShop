using System;
using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class FakeDB : IPetRepository, IPetTypeRepository
    {
        private static List<Pet> _pets;
        private static List<PetType> _petTypes;
        
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
            CreatePet(new Pet("a",GetPetType(0),DateTime.Now, DateTime.Now,"black",123));
            CreatePet(new Pet("b",GetPetType(1),DateTime.Now, DateTime.Now,"brown",456));
            CreatePet(new Pet("c",GetPetType(2),DateTime.Now, DateTime.Now,"blue",789));
            CreatePet(new Pet("d",GetPetType(3),DateTime.Now, DateTime.Now,"orange",159));
            CreatePet(new Pet("e",GetPetType(4),DateTime.Now, DateTime.Now,"spotted",753));
            CreatePet(new Pet("f",GetPetType(5),DateTime.Now, DateTime.Now,"somwhat like a cow",951));
            CreatePet(new Pet("g",GetPetType(6),DateTime.Now, DateTime.Now,"red",753));
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
            PetType p = _petTypes.Find(pet => pet.Equals(oldPetType));
            p.Name = newPetType.Name;
            _petTypes[_petTypes.IndexOf(oldPetType)] = p;
            return p;
        }

        public bool DeletePetType(PetType pet)
        {
            return _petTypes.Remove(pet);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypes;
        }
    }
}