using APIPetSitting.Filters;
using APIPetSitting.Mappers;
using APIPetSitting.Models.Concretes.Dashboards;
using APIPetSitting.Models.Concretes.Users;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPetSitting.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetSitterController : ControllerBase
    {
        private readonly PetSitterService _petSitterService;
        public PetSitterController(PetSitterService petSitterService)
        {
            _petSitterService = petSitterService;
            //_config = config;
        }

        // GET: api/<PetSitterController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PetSitter> allSittersData = _petSitterService.GetAll().Select(p=>p.ToApi());
            IEnumerable<object> essentialSittersData = allSittersData.Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email, o.PetPreference });

            return Ok(essentialSittersData);
        }

        // GET api/<PetSitterController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<PetSitter> sitterData = _petSitterService.GetById(id).Select(p => p.ToApi());
            IEnumerable<object> essentialSitterData = sitterData.Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email, o.PetPreference });

            return Ok(essentialSitterData);
        }
        [AllowAnonymous]
        [HttpGet("dashboard/{id}")]
        public IActionResult GetDashboard(int id)
        {
            DashboardPetSitter dashboard = _petSitterService.GetDashboard(id).ToApi();

            return Ok(dashboard);
        }


        // POST api/<PetSitterController>
        [AllowAnonymous]
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
        [VerifyId]
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
        [VerifyId]
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
