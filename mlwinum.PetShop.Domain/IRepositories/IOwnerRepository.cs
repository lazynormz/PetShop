using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);
        Owner GetOwner(int id);
        IEnumerable<Owner> GetOwners();
        Owner UpdateOwner();
        bool DeleteOwner();
    }
}