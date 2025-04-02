using Infrastructure.Services.Concrete;
using UnitTest.Helpers;

namespace UnitTest.Services.User.Common
{
    public class UserTestBase : TestBase
    {
        #region Methods
        protected UserService CreateUserService()
        {
            return new UserService(
                _unitOfWork.Object,
                _mapper.Object,
                _logService.Object,
                _mailService.Object
            );
        }
        #endregion
    }
}