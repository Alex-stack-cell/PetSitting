using PrestationApi = APIPetSitting.Models.Concretes.Prestation;
using PrestationBll = BLLPetSitting.Concretes.Prestation;

namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Prestation
    /// </summary>
    public static class PrestationMapper
    {
        /// <summary>
        /// Correspondance de la prestation de la BLL vers la prestation dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PrestationApi ToApi(this PrestationBll Bll)
        {
            return new PrestationApi 
            { 
                ID = (int)Bll.Id,
                ID_PetSitter = (int)Bll.Id_PetSitter,
                DateStart = Bll.DateStart,
                DateEnd = Bll.DateEnd
            };
        }
        /// <summary>
        /// Correspondance de la prestation dans l'API de la BLL vers la prestation de la BLL
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PrestationBll ToBll(this PrestationApi Api)
        {
            return new PrestationBll(Api.ID,Api.ID_PetSitter, Api.DateStart, Api.DateEnd);
        }
    }
}
