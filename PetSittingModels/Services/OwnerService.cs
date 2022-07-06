using System;
using System.Collections.Generic;
using System.Linq;
using OwnerDalService = DALPetSitting.Services.OwnerService;
using BLLPetSitting.Mappers;
using BLLPetSitting.Abstracts;
using BLLPetSitting.Concretes.Dashboards;
using BLLPetSitting.Concretes.Users.Updates;
using BLLPetSitting.Concretes.Users.UserAccount;
//using UpdateOwner = BLLPetSitting.Concretes.Users.Updates.UpdateOwnerInfo;
namespace BLLPetSitting.Services
{
    /// <summary>
    /// Représente l'ensemble des services pour la classe propriétaire.
    /// Classe communiquant avec la DAL par l'intermédiaire de mapper. 
    /// </summary>
    public class OwnerService
    {
        private readonly OwnerDalService _OwnerDalService;
        public OwnerService(OwnerDalService ownerDalService)
        {
            _OwnerDalService = ownerDalService;
        }
        /// <summary>
        /// Créations d'un nouveau propriétaire côté BLL
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public int Create(Owner owner)
        {
            return _OwnerDalService.Create(owner.ToDal());
        }
        /// <summary>
        /// Supression d'un propriétaire côté BLL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Delete(int id)
        {
            return _OwnerDalService.Delete(id);
        }
        /// <summary>
        /// Sélection de tout les propriétaires ainsi que leurs attributs côté BLL
        /// </summary>
        /// <returns>IEnumerable de propriétaire</returns>
        public IEnumerable<Owner> GetAll()
        {
            IEnumerable<Owner> owners = _OwnerDalService.GetAll().Select(o => o.ToBll());

            return owners;
        }
        /// <summary>
        /// Sélection les info. d'un propriétaitaire côté BLL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Owner> GetById(int id)
        {
            IEnumerable <Owner> owner = _OwnerDalService.GetById(id).Select(o=>o.ToBll());
            return owner;
        }
        public DashboardOwner GetDashboard(int id)
        {
            DashboardOwner dashboard = _OwnerDalService.GetDashboard(id).ToBll();
            return dashboard;
        }
        /// <summary>
        /// Met à jour les info d'un propriétaire sur base de son identifiant
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public int UpdatePassword(UpdatePassword updatePassword)
        {
            return _OwnerDalService.UpdatePassword(updatePassword.ToDal());
        }

        public int UpdateInfo(UpdateOwnerInfo owner)
        {
            return _OwnerDalService.UpdateOwnerInfo(owner.toDal());
        }
    }
}
