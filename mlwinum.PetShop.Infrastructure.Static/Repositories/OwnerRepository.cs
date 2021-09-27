using System.Collections.Generic;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> _owners;
        private static int _id;
        public OwnerRepository()
        {
            _owners = new List<Owner>();
            _id = 0;
        }
        public Owner CreateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public Owner GetOwner(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Owner> GetOwners()
        {
            throw new System.NotImplementedException();
        }

        public Owner UpdateOwner()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteOwner()
        {
            throw new System.NotImplementedException();
        }
    }
}