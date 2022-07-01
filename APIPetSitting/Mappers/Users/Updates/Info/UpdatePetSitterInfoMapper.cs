using UpdatePetSitterInfoApi = APIPetSitting.Models.Concretes.Users.Updates.UpdatePetSitterInfo;
using UpdatePetSitterInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdatePetSitterInfo;

namespace APIPetSitting.Mappers.Users.Updates.Info
{
    public static class UpdatePetSitterInfoMapper
    {
        public static UpdatePetSitterInfoApi ToApi(this UpdatePetSitterInfoBll Bll)
        {
            return new UpdatePetSitterInfoApi()
            {
                Id = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                Email = Bll.Email,
                PetPreference = Bll.PetPreference,
            };
        }

        public static UpdatePetSitterInfoBll ToBll(this UpdatePetSitterInfoApi Api)
        {
            UpdatePetSitterInfoBll updatePetSitterInfo = new UpdatePetSitterInfoBll(Api.LastName, Api.FirstName, Api.Email);

            updatePetSitterInfo.Id = Api.Id;
            updatePetSitterInfo.PetPreference = Api.PetPreference;
            return updatePetSitterInfo;
        }
    }
}
