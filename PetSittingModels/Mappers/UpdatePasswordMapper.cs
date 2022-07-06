using Bll = BLLPetSitting.Concretes.Users.Updates.UpdatePassword;
using Dal = DALPetSitting.Entities.Users.Updates.UpdatePassword;

namespace BLLPetSitting.Mappers
{
    public static class UpdatePasswordMapper
    {
        public static Bll ToBll(this Dal UpdatePassword)
        {
            return new Bll { id = UpdatePassword.id, currentPassword = UpdatePassword.currentPassword, newPassword = UpdatePassword.newPassword, confirmNewPassword = UpdatePassword.confirmNewPassword };
        }

        public static Dal ToDal(this Bll UpdatePassword)
        {
            return new Dal { id = UpdatePassword.id, currentPassword = UpdatePassword.currentPassword, newPassword = UpdatePassword.newPassword, confirmNewPassword = UpdatePassword.confirmNewPassword };
        }
    }
}
