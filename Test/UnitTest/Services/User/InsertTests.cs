using Infrastructure.Models;
using Infrastructure.Services.Concrete;
using UnitTest.Helpers;
using UnitTest.Mocks;
using UnitTest.Services.User.Common;
using Xunit;

namespace UnitTest.Services.User
{
    public class UserServiceTests : UserTestBase
    {
        #region Properties
        private readonly UserService _userService;
        #endregion
        #region Constructors
        public UserServiceTests()
        {
            _userService = CreateUserService();
        }
        #endregion
        #region Methods
        [Theory]
        [MemberData(nameof(FakeUserData.InvalidUsers), MemberType = typeof(FakeUserData))]
        public async Task InsertAsync_ShouldReturnFail_WhenUserIsInvalid(UserModel model)
        {
            // Act
            var result = await _userService.InsertAsync(model);
            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenFirstNameIsMissing()
        {
            // Arrange
            var model = FakeUserData.MissingFirstName();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserFirstNameIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenLastNameIsMissing()
        {
            // Arrange
            var model = FakeUserData.MissingLastName();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserLastNameIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenEmailIsMissing()
        {
            // Arrange
            var model = FakeUserData.MissingEmail();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.EmailIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenEmailIsInvalid()
        {
            // Arrange
            var model = FakeUserData.InvalidEmail();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.EmailIsInvalid, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenPasswordIsMissing()
        {
            // Arrange
            var model = FakeUserData.MissingPassword();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.PasswordIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenInsertDateIsInvalid()
        {
            // Arrange
            var model = FakeUserData.InvalidInsertDate();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserInsertDateIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnFail_WhenUserAlreadyDeleted()
        {
            // Arrange
            var model = FakeUserData.InvalidActivity();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserIsNotActive, result.Error.Message);
        }

        [Fact]
        public async Task InsertAsync_ShouldReturnSuccess_WhenUserIsValid()
        {
            // Arrange
            var model = FakeUserData.ValidUserModel();

            // Act
            var result = await _userService.InsertAsync(model);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }
        #endregion
    }
}