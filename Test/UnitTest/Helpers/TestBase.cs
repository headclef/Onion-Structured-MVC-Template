using AutoMapper;
using Infrastructure.Services.Abstract;
using Moq;

namespace UnitTest.Helpers
{
    public class TestBase
    {
        #region Properties
        protected readonly Mock<ILogService> _logService = new();
        protected readonly Mock<IMapper> _mapper = new();
        protected readonly Mock<IUnitOfWork> _unitOfWork = new();
        protected readonly Mock<IMailService> _mailService = new();
        #endregion
    }
}