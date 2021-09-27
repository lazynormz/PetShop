using System.Collections.Generic;
using System.IO;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.IValidator;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repo;
        private readonly IValidator _validator;

        public OwnerService(IOwnerRepository repo, IValidator validator) => (_repo, _validator) = (repo, validator);
        
        public Owner CreateOwner(Owner owner)
        {
            //if not validator.validateOwner throw InvalidDataException
            if (!_validator.ValidateOwner(owner))
                throw new InvalidDataException("Owner not valid when attempting to create");
            
            return _repo.CreateOwner(owner);
        }

        public Owner GetOwner(int id)
        {
            if(!_validator.OwnerExists(id)) throw new FileNotFoundException("Requested owner doesn't exist");
            
            return _repo.GetOwner(id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _repo.GetOwners();
        }

        public Owner UpdateOwner(int id, Owner newOwner)
        {
            if (!_validator.OwnerExists(id)) throw new FileNotFoundException("Requested owner doesn't exist");
            if (!_validator.ValidateOwner(newOwner)) throw new InvalidDataException($"Invalid input when updating owner with id {id}");
            return _repo.UpdateOwner(id, newOwner);
        }

        public bool DeleteOwner(int id)
        {
            if (!_validator.OwnerExists(id))
                throw new FileNotFoundException("Requested owner doesn't exist");
            return _repo.DeleteOwner(id);
        }
    }
}