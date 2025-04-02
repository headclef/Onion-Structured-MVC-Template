using Infrastructure.Services.Concrete;
using UnitTest.Helpers;
using UnitTest.Services.User.Common;
using Xunit;

namespace UnitTest.Services.User
{
    public class GetByIdTests : UserTestBase
    {
        #region Properties
        private readonly UserService _userService;
        #endregion
        #region Constructors
        public GetByIdTests()
        {
            _userService = CreateUserService();
        }
        #endregion
        #region Methods
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetByIdAsync_ShouldReturnFail_WhenIdIsInvalid(int id)
        {
            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.IdIsInvalid, result.Error.Message);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnFail_WhenIdIsMissing()
        {
            // Arrange
            var id = 0;

            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.IdIsRequired, result.Error.Message);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnFail_WhenUserDoesNotExist()
        {
            // Arrange
            var id = 1000000; // User does not exist

            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorMessages.User.UserNotFound, result.Error.Message);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnSuccess_WhenUserIsValid()
        {
            // Arrange
            var id = 1; // User exists

            // Act
            var result = await _userService.GetByIdAsync(id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
        }
        #endregion
    }
}