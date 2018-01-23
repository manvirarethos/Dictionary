using PIT.BAL.Model;
using PIT.DBL.Schema;

namespace PIT.BAL.Interfaces
{
    public interface IAuth
    {

        ResultModel GetAll();
        ResultModel GetById(int Id);
        ResultModel Insert(ApplicationUserModel obj);
        ResultModel Update(ApplicationUserModel obj);
        ResultModel Delete(int Id);

        ResultModel VerifyUser(LoginModel obj);
        ResultModel ChangePassword(ChangePasswordModel obj);

    }
}
