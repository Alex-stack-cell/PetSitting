using DALPetSitting.Entities;
using DALPetSitting.Repository;
using System.Collections.Generic;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité Pet
    /// </summary>
    public interface IPetRepository : IGenericRepository<Pet>
    {
        /// <summary>
        /// Sélectionne tous les animaux appartenant à un propriétaire
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Pet> GetByOwner(int id);
    }
}
