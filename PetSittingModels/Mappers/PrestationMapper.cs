using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestationBLL = BLLPetSitting.Concretes.Prestation;
using PrestationEntity = DALPetSitting.Entities.Prestation;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle Prestation
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static  class PrestationMapper
    {
        /// <summary>
        /// Correspondance de Prestation en DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static PrestationBLL ToBll(this PrestationEntity Entity)
        {
            return new PrestationBLL(Entity.ID, Entity.ID_PetSitter, Entity.DateStart, Entity.DateEnd);
        }
        /// <summary>
        /// Correspondance de la Prestation BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static PrestationEntity ToDal(this PrestationBLL Model)
        {
            return new PrestationEntity()
            {
                ID = (int)Model.Id,
                ID_PetSitter = (int)Model.Id_PetSitter,
                DateStart = Model.DateStart,
                DateEnd = Model.DateEnd,
            };
        }
    }
}
