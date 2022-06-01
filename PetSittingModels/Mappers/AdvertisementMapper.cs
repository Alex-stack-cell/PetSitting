using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementBll = BLLPetSitting.Concretes.Advertisement;
using AdvertisementEntity = DALPetSitting.Entities.Advertisement;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle Advertisement
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static class AdvertisementMapper
    {
        /// <summary>
        /// Correspondance de Advertisement de la DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static AdvertisementBll ToBll(this AdvertisementEntity Entity)
        {
            AdvertisementBll Advertisement = new AdvertisementBll(Entity.ID, Entity.Title, Entity.Description, Entity.Region, Entity.City, Entity.DateStart, Entity.DateEnd, Entity.CreatedAt);

            Advertisement.Id_Owner = Entity.ID_Owner;
            Advertisement.Id_Prestation = Entity.ID_Prestation;

            return Advertisement;
        }
        /// <summary>
        /// Correspondance de Advertisement de la BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static AdvertisementEntity ToDal(this AdvertisementBll Model)
        {
            AdvertisementEntity Advertisement = new AdvertisementEntity()
            {
                ID = (int)Model.Id,
                ID_Owner = (int)Model.Id_Owner,
                ID_Prestation = (int)Model.Id_Prestation,
                Title = Model.Title,
                Description = Model.Description,
                Region = Model.Region,
                City = Model.City,
                DateStart = Model.DateStart,
                DateEnd = Model.DateEnd,
                CreatedAt = Model.CreateAt
            };

            return Advertisement;
        }
    }
}
