using APIPetSitting.Mappers;
using APIPetSitting.Models;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPetSitting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetSitterController : ControllerBase
    {
        private readonly PetSitterService _petSitterService;
        public PetSitterController(PetSitterService petSitterService)
        {
            _petSitterService = petSitterService;
        }
        // GET: api/<PetSitterController>
        [HttpGet]
        public IActionResult Get()
        {
             IEnumerable<PetSitter> petSitters = _petSitterService.GetAll().Select(p=>p.ToApi());
            return Ok(petSitters);
        }

        // GET api/<PetSitterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<PetSitter> petSitter = _petSitterService.GetById(id).Select(p => p.ToApi());
            return Ok(petSitter);
        }

        // POST api/<PetSitterController>
        [HttpPost]
        public IActionResult Post([FromBody] PetSitter petSitter)
        {
            int rowAffected;
            try
            {
                rowAffected = _petSitterService.Create(petSitter.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422);
            }
                        
            return Ok(rowAffected);
        }

        // PUT api/<PetSitterController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] PetSitter petSitter)
        {
            if (_petSitterService.Update(petSitter.ToBll()) != 0)
            {
                int rowAffected = _petSitterService.Update(petSitter.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<PetSitterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_petSitterService.Delete(id) != 0)
            {
                int rowAffected = _petSitterService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
