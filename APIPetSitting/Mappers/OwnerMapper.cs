using OwnerBLL = BLLPetSitting.Concretes.Users.Owner;
using OwnerApi = APIPetSitting.Models.Concretes.Users.Owner;

namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Owner
    /// </summary>
    public static class OwnerMapper
    {
        /// <summary>
        /// Correspondance du propriétaire de la BLL vers le propriétaire dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static OwnerApi ToApi (this OwnerBLL Bll)
        {
            return new OwnerApi
            {
                ID = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                Email = Bll.Email,
                BirthDate = Bll.BirthDate,
                Passwd = Bll.Passwd,                
            };
        }
        /// <summary>
        /// Correspondance du propriétaire dans l'API vers le propriétaire dans la BLL 
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static OwnerBLL ToBll(this OwnerApi Model)
        {
            OwnerBLL owner =  new OwnerBLL(Model.ID,Model.LastName,Model.FirstName,Model.Email,Model.BirthDate,Model.Passwd);

            return owner;
        }
    }
}
