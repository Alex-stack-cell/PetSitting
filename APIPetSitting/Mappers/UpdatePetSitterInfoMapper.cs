using UpdatePetSitterInfoApi = APIPetSitting.Models.Concretes.Users.Updates.UpdatePetSitterInfo;
using UpdatePetSitterInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdatePetSitterInfo;

namespace APIPetSitting.Mappers
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
            return new UpdatePetSitterInfoBll()
            {
                Id = Api.Id,
                LastName = Api.LastName,
                FirstName = Api.FirstName,
                Email = Api.Email,
                PetPreference = Api.PetPreference
            };
        }
    }
}
