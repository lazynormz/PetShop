using System.Collections.Generic;
using System.IO;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.IValidator;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        private readonly IValidator _validator;
        public PetService(IPetRepository repo, IValidator validator) => (_repo, _validator) = (repo, validator);
        public Pet CreatePet(Pet pet)
        {
            if (!_validator.ValidatePet(pet))
                throw new InvalidDataException("Invalid data while creating new pet");
            return _repo.AddPet(pet);
        }

        public Pet GetPet(int id)
        {
            if (!_validator.PetExists(id))
                throw new FileNotFoundException("Requested pet does not exist");
            return _repo.GetPet(id);
        }

        public Pet UpdatePet(int id, Pet newPet)
        {
            if (!_validator.PetExists(id))
                throw new FileNotFoundException("Requested pet does not exist");
            if (!_validator.ValidatePet(newPet))
                throw new InvalidDataException($"Invalid data while updating pet {id}");
            return _repo.UpdatePet(id, newPet);
        }

        public bool DeletePetID(int id)
        {
            if (!_validator.PetExists(id))
                throw new FileNotFoundException("Requested pet does not exist");
            return _repo.DeletePet(id);
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _repo.GetAllPets();
        }
    }
}