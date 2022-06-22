using PetBll = BLLPetSitting.Concretes.Pet;
using PetApi = APIPetSitting.Models.Concretes.Pet;


namespace APIPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'API/BLL Pet
    /// </summary>
    public static class PetMapper
    {
        /// <summary>
        /// Correspondance du pet de la BLL vers le pet dans l'API
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PetApi ToApi(this PetBll Bll)
        {
            return new PetApi 
            { 
                ID = Bll.Id,
                ID_Owner = Bll.IdOwner,
                NickName = Bll.NickName,
                Type = Bll.Type,
                Breed = Bll.Breed,
                BirthDate = Bll.BirthDate
            };
        }
        /// <summary>
        /// Correspondance du pet de l'API vers le pet dans la BLL
        /// </summary>
        /// <param name="Bll"></param>
        /// <returns></returns>
        public static PetBll ToBll(this PetApi Api)
        {
            PetBll pet = new PetBll(Api.ID, Api.NickName, Api.Type, Api.Breed, Api.BirthDate);
            pet.ID_Owner = Api.ID_Owner;

            return pet;
        }
    }
}
