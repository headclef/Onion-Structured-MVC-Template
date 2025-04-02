using Infrastructure.Services.Concrete;
using UnitTest.Helpers;
using UnitTest.Services.User.Common;
using Xunit;

namespace UnitTest.Services.User
{
    public class GetByEmailTests : UserTestBase
    {
        #region Properties
        private readonly UserService _userService;
        #endregion
        #region Constructors
        public GetByEmailTests()
        {
            _userService = CreateUserService();
        }
        #endregion
        #region Methods
        [Fact]
        public async Task GetByEmailAsync_ShouldReturnFail_WhenEmailIsMissing()
        {
            // Arrange
            var email = string.Empty;

            // Act
            var result = await _userService.GetByEmailAsync(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.EmailIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task GetByEmailAsync_ShouldReturnFail_WhenEmailIsInvalid()
        {
            // Arrange
            var email = "invalidemail";

            // Act
            var result = await _userService.GetByEmailAsync(email);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.EmailIsInvalid, result.Error.Message);
        }
        #endregion
    }
}