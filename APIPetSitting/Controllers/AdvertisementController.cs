using Microsoft.AspNetCore.Mvc;
using BLLPetSitting.Services;
using APIPetSitting.Models;
using System.Collections.Generic;
using System.Linq;
using APIPetSitting.Mappers;
using System;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPetSitting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly AdvertisementService _advertisementService;
        public AdvertisementController(AdvertisementService advertisementService)
        {
            this._advertisementService = advertisementService;
        }
        // GET: api/<AdvertisementController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetAll().Select(a => a.ToApi());
            return Ok(advertisements);
        }

        // GET: api/<AdvertisementController>/Bruxelles/city
        [HttpGet("city/{city}")]
        public IActionResult GetByCity(string city)
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetByCity(city).Select(a => a.ToApi());
            return Ok(advertisements);
        }

        // GET api/<AdvertisementController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetById(id).Select(a => a.ToApi());
            return Ok(advertisements);
        }

        //// GET api/<AdvertisementController>/5/owner
        [HttpGet("owner/{idOwner}")]
        public IActionResult GetByOwner(int idOwner)
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetByOwner(idOwner).Select(a => a.ToApi());
            return Ok(advertisements);
        }
        // GET api/<AdvertisementController>/Wallonie/region
        [HttpGet("region/{region}")]
        public IActionResult GetByRegion(string region)
        {
            IEnumerable<Advertisement> advertisements = _advertisementService.GetByRegion(region).Select(a => a.ToApi());
            return Ok(advertisements);
        }

        // POST api/<AdvertisementController>
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Advertisement advertisement)
        {
            int rowsAffected;

            try
            {
                rowsAffected = _advertisementService.Create(advertisement.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422); //syntaxe correcte mais le serveur n'a pas réussi à traiter les info. contenues dans la requête
            }
            return Ok(advertisement);
        }

        // PUT api/<AdvertisementController>/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Advertisement advertisement)
        {
            if (_advertisementService.Update(advertisement.ToBll()) != 0)
            {
                int rowAffected = _advertisementService.Update(advertisement.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<AdvertisementController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(_advertisementService.Delete(id)!=0)
            {
                int rowAffected = _advertisementService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
