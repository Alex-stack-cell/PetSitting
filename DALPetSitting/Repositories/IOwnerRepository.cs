using DALPetSitting.Repository;
using System.Collections.Generic;
using DALPetSitting.Entities.Users;
using DALPetSitting.Entities.Users.Updates;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité du propriétaire
    /// </summary>
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        public int UpdatePassword(UpdatePassword type);
    }
}
