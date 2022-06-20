using PetSitterBLL = BLLPetSitting.Concretes.PetSitter;
using PetSitterApi = APIPetSitting.Models.PetSitter;

namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Owner
    /// </summary>
    public static class PetSitterMapper
    {
        /// <summary>
        /// Correspondance du pet-sitter de la BLL vers le pet-sitter dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PetSitterApi ToApi(this PetSitterBLL Bll)
        {
            return new PetSitterApi
            {
                ID = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                BirthDate = Bll.BirthDate,
                Email = Bll.Email,
                Passwd = Bll.Passwd,
                PetPreference = Bll.PetPreference
            };
        }
        /// <summary>
        /// Correspondance du pet-sitter de l'API vers le pet-sitter dans la BLL
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PetSitterBLL ToBll(this PetSitterApi Api)
        {
            PetSitterBLL petSitter = new PetSitterBLL(Api.ID, Api.LastName, Api.FirstName, Api.Email, Api.BirthDate,Api.Passwd);

            petSitter.PetPreference = (string)Api.PetPreference;

            return petSitter;
        }
    }
}
