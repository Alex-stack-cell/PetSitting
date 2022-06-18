using AccountApi = APIPetSitting.Models.Account;
using AccountBll = BLLPetSitting.Concretes.Account;

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
