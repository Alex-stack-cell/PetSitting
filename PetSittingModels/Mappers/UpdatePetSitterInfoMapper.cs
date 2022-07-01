using UpdatePetSitterInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdatePetSitterInfo;
using UpdatePetSitterInfoDal = DALPetSitting.Entities.Users.Updates.UpdatePetSitterInfo;

namespace BLLPetSitting.Mappers
{
    public static class UpdatePetSitterInfoMapper
    {
        public static UpdatePetSitterInfoDal toDal(this UpdatePetSitterInfoBll Bll)
        {
            return new UpdatePetSitterInfoDal()
            {
                Id = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                Email = Bll.Email,
                PetPreference = Bll.PetPreference
            };
        }

        public static UpdatePetSitterInfoBll toBll(this UpdatePetSitterInfoDal Entity)
        {
            UpdatePetSitterInfoBll updateSitterInfo = new UpdatePetSitterInfoBll(Entity.LastName, Entity.FirstName, Entity.Email);
            updateSitterInfo.Id = Entity.Id;

            return updateSitterInfo;
        }
    }
}
