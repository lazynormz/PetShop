using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Infrastructure.Data.Repositories;

namespace mlwinum.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly FakeDB _db;

        public PetsController()
        {
            _db = new FakeDB();
        }

        [HttpPost]
        public ActionResult<Pet> Create(Pet pet)
        {
            return _db.CreatePet(pet);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetPets()
        {
            return _db.GetAllPets().ToList();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> GetPet(long id)
        {
            return _db.GetPet(id);
        }
    }
}