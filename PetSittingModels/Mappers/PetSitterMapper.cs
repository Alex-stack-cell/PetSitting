using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetSitterBll = BLLPetSitting.Concretes.PetSitter;
using PetSitterEntity = DALPetSitting.Entities.PetSitter;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle PetSitter
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static class PetSitterMapper
    {
        /// <summary>
        /// Correspondance de PetSitter de la DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static PetSitterBll ToBll(this PetSitterEntity Entity)
        {
            PetSitterBll PetSitter = new PetSitterBll(Entity.ID, Entity.LastName, Entity.FirstName, Entity.Email, Entity.BirthDate, Entity.Passwd);

            PetSitter.PetPreference = Entity.PetPreference;
            return PetSitter;
        }

        /// <summary>
        /// Correspondance du PetSitter de la BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static PetSitterEntity ToDal(this PetSitterBll Model)
        {
            PetSitterEntity PetSitter = new PetSitterEntity()
            {
                ID = Model.Id,
                LastName = Model.LastName,
                FirstName = Model.FirstName,
                Email = Model.Email,
                BirthDate = Model.BirthDate,
                Passwd = Model.Passwd,
                PetPreference = Model.PetPreference,
            };
            return PetSitter;
        }
    }
}
