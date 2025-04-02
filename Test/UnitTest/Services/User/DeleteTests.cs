using Infrastructure.Models;
using Infrastructure.Services.Concrete;
using UnitTest.Helpers;
using UnitTest.Mocks;
using UnitTest.Services.User.Common;
using Xunit;

namespace UnitTest.Services.User
{
    public class DeleteTests : UserTestBase
    {
        #region Properties
        private readonly UserService _userService;
        #endregion
        #region Constructors
        public DeleteTests()
        {
            _userService = CreateUserService();
        }
        #endregion
        #region Methods
        [Theory]
        [MemberData(nameof(FakeUserData.InvalidUsers), MemberType = typeof(FakeUserData))]
        public async Task DeleteAsync_ShouldReturnFail_WhenUserIsInvalid(UserModel model)
        {
            // Act
            var result = await _userService.DeleteAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFail_WhenIdIsMissing()
        {
            // Arrange
            var model = FakeUserData.MissingId();

            // Act
            var result = await _userService.DeleteAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.IdIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFail_WhenUserDoesNotExist()
        {
            // Arrange
            var model = FakeUserData.ValidUserModel();

            // Act
            var result = await _userService.DeleteAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserNotFound, result.Error.Message);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFail_WhenUserIsDeleted()
        {
            // Arrange
            var model = FakeUserData.ValidUserModel();
            model.IsDeleted = true;

            // Act
            var result = await _userService.DeleteAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserIsNotActive, result.Error.Message);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnSuccess_WhenUserIsValid()
        {
            // Arrange
            var model = FakeUserData.ValidUserModel();

            // Act
            var result = await _userService.DeleteAsync(model);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }
        #endregion
    }
}