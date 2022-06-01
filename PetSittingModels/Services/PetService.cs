using BLLPetSitting.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeteDalServic = DALPetSitting.Services.PetService;
using BLLPetSitting.Mappers;

namespace BLLPetSitting.Services
{
    /// <summary>
    /// Représente l'ensemble des services pour la classe pet.
    /// Classe communiquant avec la DAL par l'intermédiaire de mapper. 
    /// </summary>
    public class PetService
    {
        private readonly PeteDalServic _petDalService;
        public PetService(PeteDalServic petDalService)
        {
            _petDalService = petDalService;
        }
        public int Create(Pet pet)
        {
            return _petDalService.Create(pet.ToDal());            
        }
        public int Delete(int id)
        {
            return _petDalService.Delete(id);
        }
        public IEnumerable<Pet> GetAll()
        {
            return _petDalService.GetAll().Select(p => p.ToBll());
        }
        public IEnumerable<Pet>GetByOwner(int id)
        {
            return _petDalService.GetByOwner(id).Select(p => p.ToBll());
        }
        public IEnumerable<Pet>GetById(int id)
        {
            return  _petDalService.GetById(id).Select(p=>p.ToBll());
        }
        public int Update(Pet pet)
        {
            return _petDalService.Update(pet.ToDal());
        }
    }
}
