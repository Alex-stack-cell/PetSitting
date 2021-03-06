using DALPetSitting.Entities.Users;
using DALPetSitting.Entities.Users.Updates;
using DALPetSitting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité du pet-sitter
    /// </summary>
    public interface IPetSitterRepository : IGenericRepository<PetSitter>
    {
        public IEnumerable<PetSitter> GetByPreference(string petPreference);
        public int UpdateInfo(UpdatePetSitterInfo updatePetSitterInfo);
        public int UpdatePassword(UpdatePassword updatePassword);
    }
}
