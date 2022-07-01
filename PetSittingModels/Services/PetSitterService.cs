using BLLPetSitting.Concretes.Dashboards;
using BLLPetSitting.Concretes.Users.Updates;
using BLLPetSitting.Concretes.Users.UserAccount;
using BLLPetSitting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetSitterDalService = DALPetSitting.Services.PetSitterService;

namespace BLLPetSitting.Services
{
    /// <summary>
    /// Représente l'ensemble des services pour la classe propriétaire.
    /// Classe communiquant avec la DAL par l'intermédiaire de mapper. 
    /// </summary>
    public class PetSitterService
    {
        private readonly PetSitterDalService _petSitterDalService;
        public PetSitterService(PetSitterDalService petSitterDalService)
        {
            _petSitterDalService = petSitterDalService;
        }
        public int Create(PetSitter petSitter)
        {
            return _petSitterDalService.Create(petSitter.ToDal());
        }
        public int Delete(int id)
        {
            return _petSitterDalService.Delete(id);
        }
        public IEnumerable<PetSitter> GetAll()
        {
            return _petSitterDalService.GetAll().Select(p=>p.ToBll());
        }
        public IEnumerable<PetSitter> GetById(int id)
        {
            return _petSitterDalService.GetById(id).Select(p => p.ToBll());
        }
        public IEnumerable<PetSitter> GetByPreference(string preference)
        {
            return _petSitterDalService.GetByPreference(preference).Select(p => p.ToBll());
        }
        public DashboardPetSitter GetDashboard(int petSitterId)
        {
            return _petSitterDalService.GetDashboard(petSitterId).ToBll();
        }
        public int Update(PetSitter petSitter)
        {
            return _petSitterDalService.Update(petSitter.ToDal());
        }

        public int UpdateInfo(UpdatePetSitterInfo petSitter)
        {
            return _petSitterDalService.UpdateInfo(petSitter.toDal());
        }
    }
}
