using System.Collections.Generic;
using mlwinum.petshop.core.Models;

namespace mlwinum.petshop.core.IServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        Owner GetOwner(int id);
        IEnumerable<Owner> GetOwners();
        Owner UpdateOwner(int id, Owner newOwner);
        bool DeleteOwner(int id);
    }
}