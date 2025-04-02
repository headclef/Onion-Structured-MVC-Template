using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Enums;
using Infrastructure.Models;
using Infrastructure.Services.Abstract;
using Persistence.Parameters.Concrete;
using System.Linq.Expressions;

namespace Infrastructure.Services.Concrete
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        private readonly IMailService _mailService;
        #endregion
        #region Constructors
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogService logService, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logService = logService;
            _mailService = mailService;
        }
        #endregion
        #region Methods
        public async Task<ModelResponse<UserModel>> InsertAsync(UserModel model)
        {
            try
            {
                // Check if the model is null
                if (model == null || string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
                {
                    _logService.WriteLog(LogLevel.Error, "User insert failed: Model or required fields are null.");
                    return new ModelResponse<UserModel>().Fail("Firstname or lastname is required.");
                }

                // Map the model to the entity
                var userEntity = _mapper.Map<User>(model);

                // Insert the user
                var user = await _unitOfWork.Users.AddAsync(userEntity, CancellationToken.None);

                // Check if the user adding is successful
                if (!user.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User insert is unsuccessful. Reason: {user.Error.Message}");
                    return new ModelResponse<UserModel>().Fail("User insert is unsuccessful");
                }

                // Log information
                _logService.WriteLog(LogLevel.Information, "User added successfully");

                // Map the entity to the model
                var userModelResult = _mapper.Map<UserModel>(user.Data);

                try
                {
                    // Send email
                    await _mailService.SendEmailAsync(userModelResult.Email, EmailType.Welcome, new Dictionary<string, string>
                    {
                        { "FirstName", userModelResult.FirstName },
                        { "LastName", userModelResult.LastName }
                    });
                }
                catch (Exception innerException)
                {
                    // Log the error
                    _logService.WriteLog(LogLevel.Warning, $"User inserted successfully but email could not be sent. Reason: {innerException.Message}");
                }

                // Return the result
                return new ModelResponse<UserModel>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<UserModel>().Fail("An error occured while adding user.");
            }
        }

        public async Task<ModelResponse<UserModel>> UpdateAsync(UserModel model)
        {
            try
            {
                // Check if the model is null or required fields are null
                if (model == null || string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName) || model.Id <= 0)
                {
                    _logService.WriteLog(LogLevel.Error, "User update failed: Model or required fields are null.");
                    return new ModelResponse<UserModel>().Fail("Firstname or lastname is required.");
                }

                // Check if the user exists
                var userExists = await _unitOfWork.Users.GetByIdAsync(model.Id, CancellationToken.None);
                if (!userExists.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User with Id {model.Id} could not be found.");
                    return new ModelResponse<UserModel>().Fail("User not found.");
                }

                // Map the model to the entity
                var userEntity = _mapper.Map<User>(model);

                // Check if the user updating is successful
                if (!userExists.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User update is unsuccessful. Reason: {userExists.Error.Message}");
                    return new ModelResponse<UserModel>().Fail("User update is unsuccessful");
                }

                // Log information
                _logService.WriteLog(LogLevel.Information, "User updated successfully");

                try
                {
                    // Send email
                    await _mailService.SendEmailAsync(userExists.Data.Email, EmailType.AccountUpdate, new Dictionary<string, string>
                    {
                        { "FirstName", model.FirstName },
                        { "LastName", model.LastName }
                    });
                }
                catch (Exception innerException)
                {
                    // Log the error
                    _logService.WriteLog(LogLevel.Warning, $"User updated successfully but email could not be sent. Reason: {innerException.Message}");
                }

                // Map the entity to the model
                var userModelResult = _mapper.Map<UserModel>(userExists.Data);

                // Return the result
                return new ModelResponse<UserModel>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<UserModel>().Fail("An error occured while updating user.");
            }
        }

        public async Task<ModelResponse<UserModel>> DeleteAsync(UserModel model)
        {
            try
            {
                // Check if the model is null or required fields are null
                if (model == null || model.Id <= 0)
                {
                    _logService.WriteLog(LogLevel.Error, "User delete failed: Model or required fields are null.");
                    return new ModelResponse<UserModel>().Fail("Invalid User Id.");
                }

                // Check if the user exists
                var userExists = await _unitOfWork.Users.GetByIdAsync(model.Id, CancellationToken.None);
                if (!userExists.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User with Id {model.Id} could not be found.");
                    return new ModelResponse<UserModel>().Fail("User not found.");
                }

                // Delete the user
                var user = await _unitOfWork.Users.DeleteAsync(model.Id, CancellationToken.None);

                // Check if the user deleting is successful
                if (!user.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User with Id {model.Id} could not be deleted.");
                    return new ModelResponse<UserModel>().Fail("User could not be deleted.");
                }

                // Log information
                _logService.WriteLog(LogLevel.Information, "User deleted successfully");

                // Email the user
                try
                {
                    await _mailService.SendEmailAsync(userExists.Data.Email, EmailType.AccountDelete, new Dictionary<string, string>
                    {
                        { "FirstName", userExists.Data.FirstName },
                        { "LastName", userExists.Data.LastName }
                    });
                }
                catch (Exception innerException)
                {
                    // Log the error
                    _logService.WriteLog(LogLevel.Warning, $"User deleted successfully but email could not be sent. Reason: {innerException.Message}");
                }

                // Map the entity to the model
                var userModelResult = _mapper.Map<UserModel>(userExists.Data);

                // Return the result
                return new ModelResponse<UserModel>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<UserModel>().Fail("An error occured while deleting user.");
            }
        }

        public async Task<ModelResponse<UserModel>> GetByIdAsync(int id)
        {
            try
            {
                // Check if the id is valid
                if (id <= 0)
                {
                    _logService.WriteLog(LogLevel.Error, "User get failed: Invalid Id.");
                    return new ModelResponse<UserModel>().Fail("Invalid User Id.");
                }

                // Get the user
                var user = await _unitOfWork.Users.GetByIdAsync(id, CancellationToken.None);

                // Check if the user getting is successful
                if (!user.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Error, $"User with Id {id} could not be found.");
                    return new ModelResponse<UserModel>().Fail("User not found.");
                }

                // Map the entity to the model
                var userModelResult = _mapper.Map<UserModel>(user.Data);

                // Return the result
                return new ModelResponse<UserModel>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<UserModel>().Fail("An error occured while getting user.");
            }
        }

        public async Task<ModelResponse<UserModel>> GetByEmailAsync(string email)
        {
            try
            {
                // Check if the email is valid
                if (string.IsNullOrWhiteSpace(email))
                {
                    _logService.WriteLog(LogLevel.Error, "User get failed: Invalid Email.");
                    return new ModelResponse<UserModel>().Fail("Invalid Email.");
                }

                // Get the user
                var user = await _unitOfWork.Users.GetByEmailAsync(email, CancellationToken.None);

                // Check if the user is empty
                if (user.Data is null)
                {
                    _logService.WriteLog(LogLevel.Information, $"User with Email {email} could not be found.");
                    return new ModelResponse<UserModel>().Fail("User not found.");
                }

                // Map the entity to the model
                var userModelResult = _mapper.Map<UserModel>(user.Data);

                // Return the result
                return new ModelResponse<UserModel>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<UserModel>().Fail("An error occured while getting user.");
            }
        }

        public async Task<ModelResponse<IEnumerable<UserModel>>> GetAllAsync()
        {
            try
            {
                // Check if there are any users
                var users = await _unitOfWork.Users.GetAllAsync(CancellationToken.None);
                if (!users.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Information, $"An error occured while getting users. Reason: {users.Error.Message}");
                    return new ModelResponse<IEnumerable<UserModel>>().Fail("An error occured while getting users.");
                }
                else if (users.Data == null || !users.Data.Any())
                {
                    _logService.WriteLog(LogLevel.Information, "No users found.");
                    return new ModelResponse<IEnumerable<UserModel>>().Fail("No users found.");
                }

                // Map the entities to the models
                var userModelResult = _mapper.Map<IEnumerable<UserModel>>(users.Data);

                // Return the result
                return new ModelResponse<IEnumerable<UserModel>>().Success(userModelResult);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new ModelResponse<IEnumerable<UserModel>>().Fail("An error occured while getting users.");
            }
        }

        public async Task<PagedModelResponse<IEnumerable<UserModel>>> GetAllByParametersAsync(ListRequestParameter parameter)
        {
            try
            {
                // Define
                Expression<Func<User, bool>>? expression = null;

                // Check if the parameter is null
                if (!string.IsNullOrWhiteSpace(parameter.Search))
                {
                    expression = x => x.FirstName.Contains(parameter.Search) || x.LastName.Contains(parameter.Search) || x.Email.Contains(parameter.Search);
                }

                // Order by
                Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null;

                // Check if the parameter is null
                if (!string.IsNullOrWhiteSpace(parameter.SortBy))
                {
                    // Define
                    bool ascending = parameter.SortOrder?.ToLower() == "asc";

                    // Order by
                    orderBy = parameter.SortBy switch
                    {
                        "FirstName" => x => ascending ? x.OrderBy(y => y.FirstName) : x.OrderByDescending(y => y.FirstName),
                        "LastName" => x => ascending ? x.OrderBy(y => y.LastName) : x.OrderByDescending(y => y.LastName),
                        "Email" => x => ascending ? x.OrderBy(y => y.Email) : x.OrderByDescending(y => y.Email),
                        _ => x => x.OrderBy(y => y.Id)
                    };
                }

                // Date filter
                Func<IQueryable<User>, IQueryable<User>>? filter = null;

                // Get the users
                var users = await _unitOfWork.Users.GetAllByParametersAsync(
                    expression,
                    orderBy,
                    filter,
                    parameter.PageNumber,
                    parameter.PageSize,
                    false,
                    true,
                    false,
                    CancellationToken.None
                );

                // Check if the users getting is successful
                if (!users.IsSuccess)
                {
                    _logService.WriteLog(LogLevel.Information, $"An error occured while getting users. Reason: {users.Error.Message}");
                    return new PagedModelResponse<IEnumerable<UserModel>>().Fail("An error occured while getting users.");
                }
                else if (users.Data == null || !users.Data.Any())
                {
                    _logService.WriteLog(LogLevel.Information, "No users found.");
                    return new PagedModelResponse<IEnumerable<UserModel>>().Fail("No users found.");
                }

                // Map the entities to the models
                var userModelResult = _mapper.Map<IEnumerable<UserModel>>(users.Data);

                // Return the result
                return new PagedModelResponse<IEnumerable<UserModel>>().Success(userModelResult, users.PageNumber, users.PageSize, users.TotalPages, users.TotalItems);
            }
            catch (Exception exception)
            {
                // Log the error
                _logService.WriteLog(LogLevel.Error, exception.Message);

                // Return the result
                return new PagedModelResponse<IEnumerable<UserModel>>().Fail("An error occured while getting users.");
            }
        }
        #endregion
    }
}