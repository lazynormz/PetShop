using System.Collections.Generic;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository petTypeService) => (_petTypeRepository) = (petTypeService);

        public bool CreatePetType(PetType type)
        {
            return _petTypeRepository.CreatePetType(type);
        }

        public PetType GetPetType(string name)
        {
            return _petTypeRepository.GetPetType(name);
        }

        public PetType UpdatePetType(PetType oldPetType, PetType newPetType)
        {
            return _petTypeRepository.UpdatePetType(oldPetType, newPetType);
        }

        public bool RemovePetType(PetType type)
        {
            return _petTypeRepository.DeletePetType(type);
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.GetAllPetTypes();
        }
    }
}