using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLLPetSitting.Services;
using APIPetSitting.Models;
using System.Linq;
using APIPetSitting.Mappers;
using System;
using Microsoft.AspNetCore.Authorization;

namespace APIPetSitting.Controllers
{
    /// <summary>
    /// Classe controller pour l'api
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _ownerService;


        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/<OwnerController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Owner> allOwnersData = _ownerService.GetAll().Select(o => o.ToApi());
            IEnumerable<object> essentialOwnersData = allOwnersData.Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email, o.Score }) ;

            return Ok(essentialOwnersData);
        }

        // GET api/<OwnerController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Owner> allOwnerData = _ownerService.GetById(id).Select(o=>o.ToApi());
            object essentialOwnerInfo = allOwnerData.Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email, o.Score });

            return Ok(essentialOwnerInfo);
        }

        // POST api/<OwnerController>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] Owner owner)
        {
            int rowAffected;
            try
            {
                rowAffected = _ownerService.Create(owner.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422);
            }

            return (Ok(rowAffected));
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Owner owner)
        {
            if (_ownerService.Update(owner.ToBll())!=0)
            {
                int rowAffected = _ownerService.Update(owner.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_ownerService.Delete(id)!=0)
            {
                int rowAffected = _ownerService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
