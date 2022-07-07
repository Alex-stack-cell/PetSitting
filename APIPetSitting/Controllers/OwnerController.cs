using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BLLPetSitting.Services;
using System.Linq;
using APIPetSitting.Mappers;
using System;
using Microsoft.AspNetCore.Authorization;
using APIPetSitting.Models.Concretes.Dashboards;
using APIPetSitting.Filters;
using APIPetSitting.Extensions;
using APIPetSitting.Models.Concretes.Users.Updates;
using APIPetSitting.Mappers.Users.DashBoard;
using APIPetSitting.Mappers.Users.UserAccount;
using APIPetSitting.Mappers.Users.Updates.Info;
using APIPetSitting.Models.Concretes.Users.UserAccount;
using APIPetSitting.CredentialsHelpers;
using APIPetSitting.Mappers.Users.Updates.Password;
using System.Net.Mail;

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
        private readonly AccountService _accountService;

        public OwnerController(OwnerService ownerService, AccountService accountService)
        {
            _ownerService = ownerService;
            _accountService = accountService;
        }

        // GET: api/<OwnerController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Owner> allOwnersData = _ownerService.GetAll().Select(o => o.ToApi());
            IEnumerable<object> essentialData = allOwnersData.
                Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email });
            return Ok(essentialData);
        }

        // GET api/<OwnerController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Owner> allOwnerData = _ownerService.GetById(id).Select(o=>o.ToApi());
            IEnumerable<object> essentialData = allOwnerData.
                Select(o => new { o.ID, o.LastName, o.FirstName, o.BirthDate, o.Email });
            return Ok(essentialData);
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
        public IActionResult Put([FromBody] UpdatePassword updatePassword)
        {
            bool currentPasswdValid = _accountService.isOwnerPasswordValid(updatePassword.currentPassword, updatePassword.id);

            DashboardOwner dashboard = _ownerService.GetDashboard(updatePassword.id).ToApi();
            

            if (currentPasswdValid)
            {
                if (_ownerService.UpdatePassword(updatePassword.toBll()) != 0)
                {
                    int rowAffected = _ownerService.UpdatePassword(updatePassword.toBll());
                  
                    Email email = new Email()
                    {
                        
                        FromSenderEmail = "alexandre.petsitting@gmail.com",
                        FromSenderName = "Gavriilidis",
                        ToRecipientEmail = dashboard.Email,
                        ToRecipientName = dashboard.LastName,
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
        public IActionResult Put([FromBody] UpdateOwnerInfo owner)
        {
            
            if (_ownerService.UpdateInfo(owner.ToBll()) != 0)
            {
                int rowAffected = _ownerService.UpdateInfo(owner.ToBll());

                Email email = new Email()
                {

                    FromSenderEmail = "alexandre.petsitting@gmail.com",
                    FromSenderName = "Gavriilidis",
                    ToRecipientEmail = owner.Email,
                    ToRecipientName = owner.LastName,
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
