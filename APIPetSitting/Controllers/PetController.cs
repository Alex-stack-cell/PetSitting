using APIPetSitting.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BLLPetSitting.Services;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using APIPetSitting.Models.Concretes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPetSitting.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;
        public PetController(PetService petService)
        {
            _petService = petService;
        }
        // GET: api/<PetController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Pet> pets = _petService.GetAll().Select(p=>p.ToApi());
            return Ok(pets);
        }

        // GET api/<PetController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Pet> pet = _petService.GetById(id).Select(p => p.ToApi());
            return Ok(pet);
        }

        // POST api/<PetController>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            int rowAffected;
            try
            {
                rowAffected = _petService.Create(pet.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422);
            }

            return Ok(rowAffected);
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pet pet)
        {
            if (_petService.Update(pet.ToBll())!=0)
            {
                int rowAffected = _petService.Update(pet.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_petService.Delete(id)!=0)
            {
                int rowAffected = _petService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
