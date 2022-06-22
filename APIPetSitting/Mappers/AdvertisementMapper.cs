using AdvertisementApi = APIPetSitting.Models.Concretes.Advertisement;
using AdvertisementBll = BLLPetSitting.Concretes.Advertisement;

namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Advertisement
    /// </summary>
    public static class AdvertisementMapper
    {
        /// <summary>
        /// Correspondance de l'Advertisement de la BLL vers l'advertisement dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static AdvertisementApi ToApi(this AdvertisementBll Bll)
        {
            return new AdvertisementApi 
            { 
                ID = Bll.Id,
                ID_Owner = Bll.Id_Owner,
                ID_Prestation = Bll.Id_Prestation,
                Title = Bll.Title,
                Description = Bll.Description,
                CreatedAt = Bll.CreateAt,
                Region = Bll.Region,
                City = Bll.City,
                DateStart = Bll.DateStart,
                DateEnd = Bll.DateEnd,
            };
        }
        /// <summary>
        /// Correspondance de l'Advertisement dans l'API de la BLL vers l'advertisement de la BLL
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static AdvertisementBll ToBll(this AdvertisementApi Api)
        {
            AdvertisementBll advertisement = new AdvertisementBll(Api.ID, Api.Title, Api.Description, Api.Region, Api.City, Api.DateStart, Api.DateEnd, Api.CreatedAt);
            advertisement.Id_Owner = Api.ID_Owner;
            advertisement.Id_Prestation = Api.ID_Prestation;

            return advertisement;
        }
    }
}
