using DashboardOwnerBll = BLLPetSitting.Concretes.Dashboards.DashboardOwner;
using DashboardOwnerDal = DALPetSitting.Entities.Dashboards.DashboardOwner;

namespace BLLPetSitting.Mappers
{
    public static class DashboardOwnerMapper
    {
        public static DashboardOwnerBll ToBll(this DashboardOwnerDal Entity)
        {
            return new DashboardOwnerBll()
            {
                ID = Entity.ID,
                LastName = Entity.LastName,
                FirstName = Entity.FirstName,
                BirthDate = Entity.BirthDate,
                Email = Entity.Email,
                Score = Entity.Score,
            };
        }

        public static DashboardOwnerDal ToDal(this DashboardOwnerBll Bll)
        {
            return new DashboardOwnerDal()
            {
                ID = Bll.ID,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                BirthDate = Bll.BirthDate,
                Email = Bll.Email,
                Score = Bll.Score
            };
        }
    }
}
