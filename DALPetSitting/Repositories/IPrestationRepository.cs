using DALPetSitting.Entities;
using DALPetSitting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité Prestation
    /// </summary>
    public interface IPrestationRepository : IGenericRepository<Prestation>
    {    
    }
}
