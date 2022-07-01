using UpdateOwnerInfoApi = APIPetSitting.Models.Concretes.Users.Updates.UpdateOwnerInfo;
using UpdateOwnerInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdateOwnerInfo;

namespace APIPetSitting.Mappers.Users.Updates.Info
{
    public static class UpdateOwnerInfoMapper
    {
        public static UpdateOwnerInfoApi ToApi(this UpdateOwnerInfoBll Bll)
        {
            return new UpdateOwnerInfoApi()
            {
                Id = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                Email = Bll.Email
            };
        }

        public static UpdateOwnerInfoBll ToBll(this UpdateOwnerInfoApi Api)
        {
            UpdateOwnerInfoBll updateOwnerInfo = new UpdateOwnerInfoBll(Api.LastName, Api.FirstName, Api.Email);
            updateOwnerInfo.Id = Api.Id;

            return updateOwnerInfo;
        }
    }
}
