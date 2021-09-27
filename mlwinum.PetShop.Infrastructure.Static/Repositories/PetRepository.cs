using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Infrastructure.Data.Entities;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetApplicationContext _ctx;

        public PetRepository(PetApplicationContext ctx) => (_ctx) = (ctx);
        
        public Pet AddPet(Pet pet)
        {
            try
            {
                PetEntity e = _ctx.Pets.Add(new PetEntity
                {
                    ID = pet.ID,
                    Name = pet.Name,
                    Colour = pet.Colour,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Price = pet.Price,
                    TypeId = (int) pet.Type.ID,
                    OwnerId = pet.Owner.ID
                }).Entity;
                _ctx.SaveChanges();

                return GetPet(e.ID);
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }
        
        public Pet GetPet(int? id)
        {
            try
            {
                return ConversionOfPet().FirstOrDefault(pet => pet.ID == id);
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public Pet UpdatePet(int id, Pet newPet)
        {
            try
            {
                var newEntity = new PetEntity
                {
                    ID = id,
                    Name = newPet.Name,
                    Colour = newPet.Colour,
                    BirthDate = newPet.BirthDate,
                    SoldDate = newPet.SoldDate,
                    Price = newPet.Price,
                    TypeId = (int) newPet.Type.ID
                };
                _ctx.Pets.Update(newEntity);
                _ctx.SaveChanges();
                newPet.ID = id;
                return newPet;
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public bool DeletePet(int id)
        {
            try
            {
                _ctx.Pets.Remove(new PetEntity {ID = id});
                _ctx.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }

        public IEnumerable<Pet> GetAllPets()
        {
            try
            {
                return ConversionOfPet().ToList();
            }
            catch (DbUpdateException)
            {
                throw new SystemException("An internal error occured. Please contact the system provider.");
            }
        }
        
        private IQueryable<Pet> ConversionOfPet()
        {
            return _ctx.Pets
                .Include(petEntity => petEntity.Type)
                .Include(petEntity => petEntity.Owner)
                .Select(petEntity => new Pet
                {
                    ID = petEntity.ID,
                    Name = petEntity.Name,
                    BirthDate = petEntity.BirthDate,
                    SoldDate = petEntity.SoldDate,
                    Colour = petEntity.Colour,
                    Price = petEntity.Price,
                    Type = new PetType {ID = petEntity.Type.ID, Name = petEntity.Type.Name},
                    Owner = new Owner
                    {
                        ID = petEntity.Owner.ID,
                        Name = petEntity.Owner.Name,
                        Address = petEntity.Owner.Address,
                    }
                });
        }
    }
}