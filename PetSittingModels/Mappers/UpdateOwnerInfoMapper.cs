using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateOwnerInfoDal = DALPetSitting.Entities.Users.Updates.UpdateOwnerInfo;
using UpdateOwnerInfoBll = BLLPetSitting.Concretes.Users.Updates.UpdateOwnerInfo;

namespace BLLPetSitting.Mappers
{
    public static class UpdateOwnerInfoMapper
    {
        public static UpdateOwnerInfoDal toDal( this UpdateOwnerInfoBll Bll)
        {
            return new UpdateOwnerInfoDal()
            {
                Id = Bll.Id,
                LastName = Bll.LastName,
                FirstName = Bll.FirstName,
                Email = Bll.Email
            };
        }

        public static UpdateOwnerInfoBll toBll(this UpdateOwnerInfoDal Entity)
        {
            UpdateOwnerInfoBll updateOwnerInfo =  new UpdateOwnerInfoBll(Entity.LastName, Entity.FirstName, Entity.Email);
            updateOwnerInfo.Id = Entity.Id;

            return updateOwnerInfo;
        }
    }
}
