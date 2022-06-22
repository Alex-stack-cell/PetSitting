using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountBll = BLLPetSitting.Concretes.Auth.Account;
using AccountEntity = DALPetSitting.Entities.Auth.Account;

namespace BLLPetSitting.Mappers
{
    public static class AccountMapper
    {
        public static AccountBll ToBll(this AccountEntity Entity)
        {
            return new AccountBll()
            {
                ID = Entity.ID,
                Email = Entity.Email,
                FirstName = Entity.FirstName,
            };
        }

        public static AccountEntity ToDal(this AccountBll Bll)
        {
            return new AccountEntity()
            {
                ID = Bll.ID,
                Email = Bll.Email,
                FirstName = Bll.FirstName,
                Passwd = Bll.Passwd,
            };
        }
    }
}
