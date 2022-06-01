using BLLPetSitting.Concretes;
using BLLPetSitting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrestationDalService = DALPetSitting.Services.PrestationService;
namespace BLLPetSitting.Services
{
    public class PrestationService
    {
        private readonly PrestationDalService _prestationDalService;
        public PrestationService(PrestationDalService prestationDalService)
        {
            _prestationDalService = prestationDalService;
        }
        public int Create (Prestation prestation)
        {
            return _prestationDalService.Create(prestation.ToDal());
        }
        public int Delete(int id)
        {
            return _prestationDalService.Delete(id);
        }
        public IEnumerable<Prestation> GetAll()
        {
            IEnumerable<Prestation> prestations = _prestationDalService.GetAll().Select(p=>p.ToBll());
            return prestations;
        }
        public IEnumerable<Prestation> GetById(int id)
        {
            IEnumerable<Prestation> prestation = _prestationDalService.GetById(id).Select(p => p.ToBll());
            return prestation;
        }
        public int Update(Prestation prestation)
        {
            return _prestationDalService.Update(prestation.ToDal());
        }

    }
}
