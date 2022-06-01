using DALPetSitting.Entities;
using DALPetSitting.Repository;
using System.Collections.Generic;
namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité Advertisement
    /// </summary>
    public interface IAdvertisementRepository : IGenericRepository<Advertisement>
    {       
        public IEnumerable<Advertisement> GetByRegion(string region);
        public IEnumerable<Advertisement> GetByCity(string region);
        public IEnumerable<Advertisement> GetByOwner(int id); 

    }
}
