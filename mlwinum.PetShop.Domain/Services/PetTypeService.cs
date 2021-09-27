using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.IValidator;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly IPetTypeRepository _repo;
        private readonly IValidator _validator;
        public PetTypeService(IPetTypeRepository repo, IValidator validator) => (_repo, _validator) = (repo, validator);

        public PetType CreatePetType(PetType type)
        {
            if (!_validator.ValidatePetType(type))
                throw new InvalidDataException("Invalid data while creating new pettype");
            
            return _repo.CreatePetType(type);
        }

        public PetType GetByID(int id)
        {
            if (!_validator.PetTypeExists(id))
                throw new FileNotFoundException("Pet Type ID does not exist!");
            
            return _repo.GetPetType(id);
        }

        public PetType UpdatePetType(int id, PetType newPetType)
        {
            if (!_validator.PetTypeExists(id))
                throw new FileNotFoundException("Pet Type ID does not exist!");
            
            if (!_validator.ValidatePetType(newPetType))
                throw new InvalidDataException($"Invalid data while updating PetType {id}");
            return _repo.UpdatePetType(id, newPetType);
        }

        public bool RemovePetType(int id)
        {
            if (!_validator.PetTypeExists(id))
                throw new FileNotFoundException("Pet Type ID does not exist!");
            return _repo.DeletePetType(id);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _repo.GetAllPetTypes();
        }
    }
}