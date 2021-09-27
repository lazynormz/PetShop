using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> _petTypes;
        private static int _id;

        public PetTypeRepository()
        {
            _petTypes = new List<PetType>();
            _id = 0;
        }
        
        public bool CreatePetType(PetType type)
        {
            //TODO: Make sure no duplicates are available
            type.Name = type.Name.ToLower();
            _petTypes.Add(type);
            _id++;
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

        public bool DeletePetType(PetType type)
        {
            return _petTypes.Remove(type);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypes;
        }
    }
}