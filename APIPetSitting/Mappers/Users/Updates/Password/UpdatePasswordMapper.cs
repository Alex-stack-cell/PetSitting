using BLL = BLLPetSitting.Concretes.Users.Updates.UpdatePassword;
using API = APIPetSitting.Models.Concretes.Users.Updates.UpdatePassword;
namespace APIPetSitting.Mappers.Users.Updates.Password
{
    public static class UpdatePasswordMapper
    {
        public static API toApi(this BLL UpdatePassword)
        {
            return new API { id = UpdatePassword.id, currentPassword = UpdatePassword.currentPassword, newPassword = UpdatePassword.newPassword, confirmNewPassword = UpdatePassword.confirmNewPassword };
        }

        public static BLL toBll(this API UpdatePassword)
        {
            return new BLL { id = UpdatePassword.id, currentPassword = UpdatePassword.currentPassword, newPassword = UpdatePassword.newPassword, confirmNewPassword = UpdatePassword.confirmNewPassword };
        }
    }
}
