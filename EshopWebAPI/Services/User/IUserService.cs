using EshopWeb.CoreLayer.DTOs.Users;
using EshopWeb.CoreLayer.Utilities;

namespace EshopWebAPI.Services.User
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetById(int id);
        OperationResult CreateUser(CreateDto command);
        OperationResult EditUser(EditDto command);
    }
}
