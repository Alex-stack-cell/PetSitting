﻿using DALPetSitting.Repository;
using System.Collections.Generic;
using DALPetSitting.Entities;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité du propriétaire
    /// </summary>
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        
    }
}