using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class FakeDB
    {
        private static List<Pet> _pets;
        private static List<PetType> _petTypes;

        private static IPetRepository _petRepo;
        private static IPetTypeRepository _petTypeRepo;
        
        private static int _petId;
        private static int _petTypeId;

        public FakeDB()
        {
            _petRepo = new PetRepository();
            _petTypeRepo = new PetTypeRepository();
            InitData();
        }

        public void InitData()
        {
            //Mock Owners
            //Mock PetTypes
            for (int i = 0; i < 15; i++)
            {
                PetType _ = new PetType();
                _.ID = i;
                _.Name = ((char) ('g' + i)).ToString();
                _petTypeRepo.CreatePetType(_);
            }
            //Mock Pets
            for (int i = 0; i < 10; i++)
            {
                Pet _ = new Pet();
                _.Name = ((char) ('a' + i)).ToString();
                _.Colour = "#654987";
                _.Price = Math.Pow(i, 10);
                _.Type = GetPetType(i);
                _.Owner = null;
                _petRepo.CreatePet(_);              //Pass through here because we make sure we have a PetType set in this method
            }
        }

        public Pet CreatePet(Pet pet)
        {
            Pet _p = pet;
            _p.Type = GetPetType(pet.Type.ID);
            return _petRepo.CreatePet(_p);
        }

        public Pet GetPet(string name)
        {
            return _petRepo.GetPet(name);
        }

        public Pet GetPet(long id)
        {
            return _petRepo.GetPet(id);
        }

        public Pet UpdatePet(Pet oldPet, Pet newPet)
        {
            return _petRepo.UpdatePet(oldPet, newPet);
        }

        public bool DeletePet(Pet pet)
        {
            return _petRepo.DeletePet(pet);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _petRepo.GetAllPets();
        }

        public bool CreatePetType(PetType type)
        {
            //TODO: Make sure no duplicates are available
            return _petTypeRepo.CreatePetType(type);
        }

        public PetType GetPetType(string name)
        {
            return _petTypeRepo.GetPetType(name);
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepo.GetPetType(id);
        }

        public PetType UpdatePetType(PetType oldPetType, PetType newPetType)
        {
            return _petTypeRepo.UpdatePetType(oldPetType, newPetType);
        }

        public bool DeletePetType(PetType type)
        {
            return _petTypeRepo.DeletePetType(type);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypeRepo.GetAllPetTypes();
        }

        public Owner CreateOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwner(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> GetOwners()
        {
            throw new NotImplementedException();
        }

        public Owner UpdateOwner()
        {
            throw new NotImplementedException();
        }

        public bool DeleteOwner()
        {
            throw new NotImplementedException();
        }
    }
}