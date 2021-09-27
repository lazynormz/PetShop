using System;
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
            owner.Id = _id;
            _owners.Add(owner);
            _id++;
            return owner;
        }

        public Owner GetOwner(int id)
        {
            return _owners.Find(owner => owner.Id == id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _owners;
        }

        public Owner UpdateOwner(Owner oldOwner, Owner newOwner)
        {
            Owner owner = GetOwner(oldOwner.Id);
            owner = newOwner;
            owner.Id = oldOwner.Id;
            _owners[owner.Id] = owner;
            return owner;
        }

        public bool DeleteOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}