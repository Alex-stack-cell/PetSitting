using UpdateOwnerInfoApi = APIPetSitting.Models.Concretes.Users.Updates.UpdateOwnerInfo;
using UpdateOwnerInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdateOwnerInfo;

namespace APIPetSitting.Mappers
{
    public static class UpdateOwnerInfoMapper
    {
        public static UpdateOwnerInfoApi ToApi(this UpdateOwnerInfoBll Bll)
        {
            return new UpdateOwnerInfoApi()
            {
                Id = Bll.Id,
                LastName = Bll.LastName,
                FirstName= Bll.FirstName, 
                Email = Bll.Email
            };
        }

        public static UpdateOwnerInfoBll ToBll(this UpdateOwnerInfoApi Api)
        {
            return new UpdateOwnerInfoBll()
            {
                Id = Api.Id,
                LastName = Api.LastName,
                FirstName = Api.FirstName,
                Email = Api.Email
            };
        }
    }
}
