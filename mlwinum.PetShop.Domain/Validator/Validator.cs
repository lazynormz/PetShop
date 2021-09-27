using mlwinum.petshop.core.IValidator;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Validator
{
    public class Validator : IValidator
    {
        
        private readonly IPetRepository _petRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetTypeRepository _petTypeRepository;

        public Validator(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository)
            =>
        (_petRepository, _ownerRepository, _petTypeRepository) = (petRepository, ownerRepository, petTypeRepository);
        
        public bool ValidatePet(Pet pet)
        {
            return true;
            throw new System.NotImplementedException();
        }

        public bool ValidatePetType(PetType petType)
        {
            return true;
            throw new System.NotImplementedException();
        }

        public bool ValidateOwner(Owner owner)
        {
            return true;
            throw new System.NotImplementedException();
        }

        public bool PetExists(int id)
        {
            return true;
            throw new System.NotImplementedException();
        }

        public bool PetTypeExists(int id)
        {
            return true;
            throw new System.NotImplementedException();
        }

        public bool OwnerExists(int id)
        {
            return true;
            throw new System.NotImplementedException();
        }
    }
}