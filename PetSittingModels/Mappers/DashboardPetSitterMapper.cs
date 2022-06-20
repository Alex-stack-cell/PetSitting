using DashboardPetSitterBll = BLLPetSitting.Concretes.DashboardPetSitter;
using DashboardPetSitterDal = DALPetSitting.Entities.DashboardPetSitter;

namespace BLLPetSitting.Mappers
{
    public static class DashboardPetSitterMapper
    {
        public static DashboardPetSitterBll ToBll(this DashboardPetSitterDal Entity)
        {
            return new DashboardPetSitterBll()
            {
                ID = Entity.ID,
                LastName = Entity.LastName,
                FirstName = Entity.FirstName,
                BirthDate = Entity.BirthDate,
                Email = Entity.Email,
                Score = Entity.Score,
                PetPreference = Entity.PetPreference
            };
        }

        public static DashboardPetSitterDal ToDal(this DashboardPetSitterBll Bll)
        {
            return new DashboardPetSitterDal()
            {
                ID = Bll.ID,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                BirthDate = Bll.BirthDate,
                Email = Bll.Email,
                Score = Bll.Score,
                PetPreference = Bll.PetPreference
            };
        }
    }
}
