﻿using OwnerBll = BLLPetSitting.Concretes.Owner;
using OwnerEntity = DALPetSitting.Entities.Owner;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle Owner
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static class OwnerMapper
    {
        /// <summary>
        /// Correspondance de l'Owner de la DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static OwnerBll ToBll(this OwnerEntity Entity)
        {
            return new OwnerBll(Entity.ID,Entity.LastName, Entity.FirstName, Entity.Email, Entity.BirthDate, Entity.Passwd, Entity.Score);            
        }
        /// <summary>
        /// Correspondance du Owner de la BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static OwnerEntity ToDal(this OwnerBll Model)
        {
            return new OwnerEntity()
            {
                ID = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                BirthDate = Model.BirthDate,
                Email = Model.Email,                
                Passwd = Model.Passwd,
                Score = Model.Score,
            };
        }
    }
}
