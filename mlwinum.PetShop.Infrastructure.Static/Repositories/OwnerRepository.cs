using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Infrastructure.Data.Entities;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetApplicationContext _ctx;

        public OwnerRepository(PetApplicationContext ctx) => (_ctx) = (ctx);
        public Owner CreateOwner(Owner owner)
        {
            try
            {
                OwnerEntity newEntity = _ctx.Owners.Add(new OwnerEntity
                    {
                        Name = owner.Name,
                        Address = owner.Address,
                        Phonenumber = owner.Phonenumber
                    }
                ).Entity;
                _ctx.SaveChanges();

                owner.ID = newEntity.ID;
                return owner;
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public Owner GetOwner(int id)
        {
            try
            { 
                return ConversionOfOwner().FirstOrDefault(owner => owner.ID == id);
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public IEnumerable<Owner> GetOwners()
        {
            try
            {
                return ConversionOfOwner().ToList();
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public Owner UpdateOwner(int id, Owner newOwner)
        {
            try
            {
                OwnerEntity newEntity = new OwnerEntity
                {
                    ID = id,
                    Name = newOwner.Name,
                    Address = newOwner.Address,
                    Phonenumber = newOwner.Phonenumber
                };
                _ctx.Owners.Update(newEntity);
                _ctx.SaveChanges();
                newOwner.ID = id;
                return newOwner;
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public bool DeleteOwner(int id)
        {
            _ctx.Owners.Remove(new OwnerEntity {ID = id});
            _ctx.SaveChanges();
            return true;
        }
        
        private IQueryable<Owner> ConversionOfOwner()
        {
            return _ctx.Owners
                .Select(ownerEntity => new Owner
                {
                    ID = ownerEntity.ID,
                    Name = ownerEntity.Name,
                    Address = ownerEntity.Address,
                    Phonenumber = ownerEntity.Phonenumber
                });
        }
    }
}