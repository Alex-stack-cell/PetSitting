using DashboardAPI = APIPetSitting.Models.Concretes.Dashboards.DashboardPetSitter;
using DashboardBll = BLLPetSitting.Concretes.Dashboards.DashboardPetSitter;

namespace APIPetSitting.Mappers.Users.DashBoard
{
    public static class DashboardPetSitterMapper
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
                Score = Bll.Score,
                PetPreference = Bll.PetPreference,
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
                PetPreference = Api.PetPreference,
            };
        }
    }
}






