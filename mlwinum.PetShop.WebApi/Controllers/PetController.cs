using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.Infrastructure.Data.Repositories;
using mlwinum.PetShop.WebApi.DTO;

namespace mlwinum.PetShop.WebApi.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _service;

        public PetController(IPetService service) => (_service) = (service);

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> GetAllPets()
        {
            try
            {
                return Ok(_service.GetAllPets());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("id")]
        public ActionResult<Pet> GetPetID(int id)
        {
            try
            {
                return Ok(_service.GetPet(id));
            }
            catch (FileNotFoundException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Pet> createPet([FromBody] PetDTO p)
        {
            try
            {
                return Ok(_service.CreatePet(new Pet
                {
                    Name = p.Name,
                    Colour = p.Colour,
                    BirthDate = p.Birthdate,
                    SoldDate = p.SoldDate,
                    Price = p.Price,
                    Type = new PetType {ID = p.PetTypeId},
                    Owner = new Owner {ID = p.OwnerId}
                }));
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (SystemException e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPut("{id}")]
        public ActionResult<Pet> updatePet(int id, [FromBody] PetDTO pet)
        {
            try
            {
                return Ok(_service.UpdatePet(id, new Pet
                {
                    Name = pet.Name,
                    Colour = pet.Colour,
                    BirthDate = pet.Birthdate,
                    SoldDate = pet.SoldDate,
                    Price = pet.Price,
                    Type = new PetType {ID = pet.PetTypeId}
                }));
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (SystemException e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult<bool> deletePet(int id)
        {
            try
            {
                return Ok(_service.DeletePetID(id));
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (SystemException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}