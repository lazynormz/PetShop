using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using mlwinum.petshop.core.IServices;
using mlwinum.petshop.core.Models;
using mlwinum.PetShop.WebApi.DTO;

namespace mlwinum.PetShop.WebApi.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public ActionResult<List<Owner>> GetAllOwners()
        {
            try
            {
                return Ok(_ownerService.GetOwners());
            }
            catch (SystemException e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetOwnerById(int id)
        {
            try
            {
                return Ok(_ownerService.GetOwner(id));
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

        [HttpPost]
        public ActionResult<Owner> CreateOwner([FromBody] OwnerDTO owner)
        {
            try
            {
                return Ok(_ownerService.CreateOwner(new Owner
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    Phonenumber = owner.Phonenumber
                }));
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (SystemException e)
            {
                return StatusCode(500, e.Message + "asdfasdf");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> UpdateOwner(int id, [FromBody] OwnerDTO owner)
        {
            try
            {
                return Ok(_ownerService.UpdateOwner(id, new Owner
                {
                    Name = owner.Name,
                    Address = owner.Address,
                    Phonenumber = owner.Phonenumber
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
        public ActionResult<bool> DeleteOwner(int id)
        {
            try
            {
                return Ok(_ownerService.DeleteOwner(id));
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