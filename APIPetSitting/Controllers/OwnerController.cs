using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLLPetSitting.Services;
using System.Linq;
using APIPetSitting.Mappers;
using System;
using Microsoft.AspNetCore.Authorization;
using APIPetSitting.Models.Concretes.Users;
using APIPetSitting.Models.Concretes.Dashboards;
using APIPetSitting.Filters;
using APIPetSitting.Extensions;

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
            return Ok(allOwnersData);
        }

        // GET api/<OwnerController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Owner> allOwnerData = _ownerService.GetById(id).Select(o=>o.ToApi());
            return Ok(allOwnerData);
        }
        [AllowAnonymous]
        [HttpGet("dashboard/{id}")]
        public IActionResult GetDashboard(int id)
        {
            DashboardOwner dashboard = _ownerService.GetDashboard(id).ToApi();

            return Ok(dashboard);
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
        [VerifyId]
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
        //[Authorize(Policy = "Granted")]
        [HttpDelete()]
        public IActionResult Delete()
        {
            if(_ownerService.Delete(User.GetId())!=0)
            {                
                int rowAffected = _ownerService.Delete(User.GetId());
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
