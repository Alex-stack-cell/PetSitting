using AccountApi = APIPetSitting.Models.Concretes.Auth.Account;
using AccountBll = BLLPetSitting.Concretes.Auth.Account;

namespace APIPetSitting.Mappers
{
    public static class AccountMapper
    {
        public static AccountApi ToApi(this AccountBll Bll)
        {
            return new AccountApi()
            {
                ID = Bll.ID,
                Email = Bll.Email,
                FirstName = Bll.FirstName,
                Passwd = Bll.Passwd,

            };
        }
        public static AccountBll ToBll(this AccountApi Api)
        {
            return new AccountBll()
            {
                ID = Api.ID,
                Email = Api.Email,
                FirstName = Api.FirstName,
            };
        }

    }
}
