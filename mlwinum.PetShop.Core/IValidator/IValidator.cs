using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IValidator
{
    public interface IValidator
    {
        public bool ValidatePet(Pet pet);

        public bool ValidatePetType(PetType petType);

        public bool ValidateOwner(Owner owner);

        public bool PetExists(int id);

        public bool PetTypeExists(int id);

        public bool OwnerExists(int id);
    }
}