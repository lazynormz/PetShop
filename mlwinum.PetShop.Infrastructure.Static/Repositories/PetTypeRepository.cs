using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Infrastructure.Data.Entities;

namespace mlwinum.PetShop.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        
        private readonly PetApplicationContext _ctx;

        public PetTypeRepository(PetApplicationContext ctx) => (_ctx) = (ctx);

        public PetType CreatePetType(PetType type)
        {
            PetTypeEntity e = _ctx.Add(new PetTypeEntity
            {
                ID = type.ID,
                Name = type.Name
            }).Entity;
            _ctx.SaveChanges();

            type.ID = e.ID;
            return type;
        }

        public PetType GetPetType(int id)
        {
            return _ctx.PetTypes.Select(type => new PetType
            {
                ID = type.ID,
                Name = type.Name
            }).FirstOrDefault(type => type.ID == id);
        }

        public PetType UpdatePetType(int id, PetType newPetType)
        {
            PetTypeEntity newEntity = new PetTypeEntity
            {
                ID = id,
                Name = newPetType.Name
            };
            _ctx.PetTypes.Update(newEntity);
            _ctx.SaveChanges();
            newPetType.ID = id;
            return newPetType;
        }

        public bool DeletePetType(int id)
        {
            _ctx.PetTypes.Remove(new PetTypeEntity {ID = id});
            _ctx.SaveChanges();
            return true;
        }

        public IEnumerable<PetType> GetAllPetTypes()
        {
            return _ctx.PetTypes.Select(type => new PetType
            {
                ID = type.ID,
                Name = type.Name
            }).ToList();
        }
    }
}