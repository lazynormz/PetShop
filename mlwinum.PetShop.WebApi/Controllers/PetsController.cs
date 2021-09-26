using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;

namespace mlwinum.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost]
        public ActionResult<Pet> Create(Pet pet)
        {
            return _petService.CreatePet(pet);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetPets()
        {
            return _petService.GetAllPets().ToList();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> GetPet(long id)
        {
            return _petService.GetPet(id);
        }
    }
}