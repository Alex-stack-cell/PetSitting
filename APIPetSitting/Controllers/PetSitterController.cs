using APIPetSitting.CredentialsHelpers;
using APIPetSitting.Filters;
using APIPetSitting.Mappers;
using APIPetSitting.Mappers.Users.DashBoard;
using APIPetSitting.Mappers.Users.Updates.Info;
using APIPetSitting.Mappers.Users.Updates.Password;
using APIPetSitting.Mappers.Users.UserAccount;
using APIPetSitting.Models.Concretes.Dashboards;
using APIPetSitting.Models.Concretes.Users.Updates;
using APIPetSitting.Models.Concretes.Users.UserAccount;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
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
        private readonly AccountService _accountService;
        public PetSitterController(PetSitterService petSitterService, AccountService accountService)
        {
            _petSitterService = petSitterService;
            _accountService = accountService;
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
            bool isAlreadyExist = false;
            try
            {
                string existingOwnerEmail = _accountService.GetEmailOwner(petSitter.Email);
                string existingPetSitterEmail = _accountService.GetEmailPetSitter(petSitter.Email);

                if (existingOwnerEmail == petSitter.Email)
                {
                    isAlreadyExist = true;

                }
                else if (existingPetSitterEmail == petSitter.Email)
                {
                    isAlreadyExist = true;
                }

                if (!isAlreadyExist)
                {
                    rowAffected = _petSitterService.Create(petSitter.ToBll());
                }
                else
                {
                    return BadRequest("Ce compte existe déjà");
                }
            }
            catch (Exception)
            {

                return new StatusCodeResult(422);
            }

            return (Ok(rowAffected));
        }
        //int rowAffected;
        //try
        //{
        //    rowAffected = _petSitterService.Create(petSitter.ToBll());
        //}
        //catch (Exception)
        //{

        //    return new StatusCodeResult(422);
        //}

        //return Ok(rowAffected);
    

        // PUT api/<PetSitterController>/5
        [VerifyId]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdatePassword updatePassword)
        {
            bool currentPasswordValid = _accountService.isPetSitterPasswordValid(updatePassword.currentPassword, updatePassword.id);

            if (currentPasswordValid)
            {
                int rowAffected = _petSitterService.UpdatePassword(updatePassword.toBll());
                if (rowAffected != 0)
                {
                
                    DashboardPetSitter petSitter = _petSitterService.GetDashboard(updatePassword.id).ToApi();
                    Email email = new Email()
                    {
                        FromSenderEmail = "alexandre.petsitting@gmail.com",
                        FromSenderName = "Gavriilidis",
                        ToRecipientEmail = petSitter.Email,
                        ToRecipientName = petSitter.LastName,
                        Subject = "Mis à jour de votre mot de passe",
                        PlainText = "Votre mot de passe a bien été modifié. Si vous n'êtes pas à l'origine de cette modification veuillez nous contacter au : +32 555 55 55 55",
                        HtmlText = "<strong>Votre mot de passe a bien été modifié.</strong> Si vous n'êtes pas à l'origine de cette mopdification veuillez contacter notre service helpdesk au : +32 555 55 55 55"
                    };
    
                    try
                    {
                        EmailConfirmation.sendEmail(email);
                    }
                    catch (SmtpException ex)
                    {

                        throw ex;
                    }
                    return Ok(rowAffected);
                }
            }
            return BadRequest();
        }
        [VerifyId]
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] UpdatePetSitterInfo petSitter)
        {
            int rowAffected = _petSitterService.UpdateInfo(petSitter.ToBll());
            if(rowAffected!=0)
            {
                
                Email email = new Email()
                {
                    FromSenderEmail = "alexandre.petsitting@gmail.com",
                    FromSenderName = "Gavriilidis",
                    ToRecipientEmail = petSitter.Email,
                    ToRecipientName = petSitter.LastName,
                    Subject = "Mis à jour de vos informations",
                    PlainText = "Vos données ont été modifié. Si vous n'êtes pas à l'origine de cette modification veuillez nous contacter au : +32 555 55 55 55",
                    HtmlText = "<strong>Vos données ont été modifié</strong> Si vous n'êtes pas à l'origine de cette modification veuillez contacter notre service helpdesk au : +32 555 55 55 55"
                };
                try
                {
                    EmailConfirmation.sendEmail(email);
                }
                catch (SmtpException ex)
                {

                    throw ex;
                }

                return Ok(petSitter);
            } 
            else
            {
                return BadRequest();
            }
            
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
