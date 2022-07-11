using EshopWeb.CoreLayer.DTOs.Users;
using EshopWeb.CoreLayer.Utilities;
using EshopWebAPI.Context;
using EshopWeb.DataLayer.Entities;

namespace EshopWebAPI.Services.User
{
    public class UserService : IUserService
    {
        private readonly MyDbContext _context;
        public UserService(MyDbContext context)
        {
            _context = context;
        }
        public List<UserDto> GetAllUsers()
        {
            return _context.users.Select(u => new UserDto()
            {
                ID = u.ID,
                Name = u.Name,
                Family = u.Family,
                UserName = u.UserName,
                UserRole = u.UserRole,
                Password = u.Password,
            }).ToList();
        }
        public OperationResult CreateUser(CreateDto command)
        {
            if (command == null)
                return OperationResult.Error("مقداری وارد نشده است");

            var isUserExists = _context.users.Any(u => u.UserName == command.UserName);
            if (isUserExists)
                return OperationResult.Error("این نام کاربری قبلا ثبت شده است");


            _context.users.Add(new Users()
            {
                Name = command.Name,
                Family = command.Family,
                UserName = command.UserName,
                Password = command.Password,
                UserRole = Role.User,
            });

            _context.SaveChanges();
            return OperationResult.Success();
        }
        public OperationResult EditUser(EditDto command)
        {
            if (command == null)
                return OperationResult.Error("مقداری وارد نشده است");

            var user = _context.users.FirstOrDefault(user => user.ID == command.ID);
            if (user == null) return OperationResult.NotFound("کاربری با این آیدی یافت نشد");

            //var isUserExists = _context.users.Any(u => u.UserName == command.UserName);
            //if (!isUserExists)
            //    return OperationResult.Error("این نام کاربری قبلا ثبت شده است");

            user.UserName = command.UserName;
            user.Name = command.Name;
            user.Family=command.Family;
            user.Password = command.Password;


            _context.SaveChanges();

            return OperationResult.Success();
        }
        public UserDto GetById(int id)
        {
            var user = _context.users.FirstOrDefault(user => user.ID == id);

            if (user == null) return null;

            return new UserDto()
            {
                ID = user.ID,
                UserName = user.UserName,
                Name = user.Name,
                Family = user.Family,
                Password = user.Password,
                UserRole = user.UserRole,
            };
        }
    }
}
