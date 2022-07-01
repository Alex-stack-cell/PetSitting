using DashboardAPI = APIPetSitting.Models.Concretes.Dashboards.DashboardOwner;
using DashboardBll = BLLPetSitting.Concretes.Dashboards.DashboardOwner;

namespace APIPetSitting.Mappers.Users.DashBoard
{
    public static class DashboardOwnerMapper
    {
        public static DashboardAPI ToApi(this DashboardBll Bll)
        {
            return new DashboardAPI()
            {
                ID = Bll.ID,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                BirthDate = Bll.BirthDate,
                Email = Bll.Email,
                Score = Bll.Score
            };
        }
        public static DashboardBll ToBll(this DashboardAPI Api)
        {
            return new DashboardBll()
            {
                ID = Api.ID,
                LastName = Api.LastName,
                FirstName = Api.FirstName,
                BirthDate = Api.BirthDate,
                Email = Api.Email,
                Score = Api.Score,
            };
        }
    }
}
