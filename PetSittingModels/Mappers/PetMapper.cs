using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetBll = BLLPetSitting.Concretes.Pet;
using PetEntity = DALPetSitting.Entities.Pet;

namespace BLLPetSitting.Mappers
{
    /// <summary>
    /// Data mapper pour l'entité/Modèle Pet
    /// L'entité = DB
    /// Modèle = BLL
    /// </summary>
    public static class PetMapper
    {
        /// <summary>
        /// Correspondance de Pet de la DAL vers la BLL
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public static PetBll ToBll(this PetEntity Entity)
        {
            PetBll Pet = new PetBll(Entity.ID, Entity.NickName, Entity.Type, Entity.Breed, Entity.BirthDate);

            Pet.ID_Owner = Entity.ID_Owner;

            return Pet;
        }

        /// <summary>
        /// Correspondance de Pet de la BLL vers la DAL
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static PetEntity ToDal(this PetBll Model)
        {
            PetEntity Pet = new PetEntity()
            {
                ID = Model.Id,
                ID_Owner = Model.IdOwner,
                NickName = Model.NickName,
                Type = Model.Type,
                Breed = Model.Breed,
                BirthDate = Model.BirthDate,
            };

            return Pet;
        }
    }
}
