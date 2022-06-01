using BLLPetSitting.Concretes;
using BLLPetSitting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementDalService = DALPetSitting.Services.AdvertisementService;
namespace BLLPetSitting.Services
{
    public class AdvertisementService
    {
        private readonly AdvertisementDalService _advertisementService;
        public AdvertisementService(AdvertisementDalService advertisementDalService)
        {
            _advertisementService = advertisementDalService;
        }

        public int Create(Advertisement advertisement)
        {
            return _advertisementService.Create(advertisement.ToDal());
        }
        public int Delete(int id)
        {
            return _advertisementService.Delete(id);
        }
        public IEnumerable<Advertisement> GetAll()
        {
            return _advertisementService.GetAll().Select(a=>a.ToBll());
        }
        public IEnumerable<Advertisement> GetByCity(string city)
        {
            return _advertisementService.GetByCity(city).Select(a => a.ToBll());
        }
        public IEnumerable<Advertisement>GetById(int id)
        {
            return _advertisementService.GetById(id).Select(a=>a.ToBll());
        }
        public IEnumerable<Advertisement>GetByOwner(int id)
        {
            return _advertisementService.GetByOwner(id).Select(a => a.ToBll());
        }
        public IEnumerable<Advertisement>GetByRegion(string region)
        {
            return _advertisementService.GetByRegion(region).Select(a => a.ToBll());
        }
        public int Update(Advertisement advertisement)
        {
            return _advertisementService.Update(advertisement.ToDal());
        }
    }
}
