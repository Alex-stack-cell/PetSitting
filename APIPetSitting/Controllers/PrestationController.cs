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
    public class PrestationController : ControllerBase
    {
        private readonly PrestationService _prestationService;
        public PrestationController(PrestationService prestationService)
        {
            _prestationService = prestationService;
        }

        // GET: api/<PrestationController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Prestation> prestations = _prestationService.GetAll().Select(p=>p.ToApi());
            return Ok(prestations);
        }

        // GET api/<PrestationController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Prestation> prestation = _prestationService.GetById(id).Select(p=>p.ToApi());
            return Ok(prestation);
        }

        // POST api/<PrestationController>
        [HttpPost]
        public IActionResult Post([FromBody] Prestation prestation)
        {
            int affectedRow;
            try
            {
                affectedRow = _prestationService.Create(prestation.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422); ;
            }
            return Ok(affectedRow);
        }

        // PUT api/<PrestationController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Prestation prestation)
        {
            if (_prestationService.Update(prestation.ToBll()) != 0)
            {
                int rowAffected = _prestationService.Update(prestation.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<PrestationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_prestationService.Delete(id) != 0)
            {
                int rowAffected = _prestationService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
