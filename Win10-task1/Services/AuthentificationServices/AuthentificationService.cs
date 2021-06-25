using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Win10_task1.Exceptions;
using Win10_task1.Models;
using Win10_task1.Services.DataServices;

namespace Win10_task1.Services.AuthentificationServices
{
    class AuthentificationService : IAuthentificationService
    {
        private IUserService _userService;
        private IPasswordHasher _passwordHasher;

        public AuthentificationService()
        {
            _userService = new UserService();
            _passwordHasher = new PasswordHasher();
        }

        public async Task<User> Login(string login, string password)
        {
            User authorizedUser = await _userService.GetUserByLogin(login);
            if (authorizedUser == null)
                throw new AuthentificationException("Пользователя с данным логином не существует.", login, password);
            else
            {
                PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(authorizedUser.PasswordHash, password);
                if (verificationResult != PasswordVerificationResult.Success)
                    throw new AuthentificationException("Вы ввели не верный пароль.", login, password);
            }
            return authorizedUser;
        }

        public async Task Register(string lastName, string firstName, string surName, string login, string password)
        {
            User userByLogin = await _userService.GetUserByLogin(login);
            if (userByLogin != null)
            {
                throw new AuthentificationException("Пользователь с данным логином уже существует.", login, password);
            }
            string hashedPassword = _passwordHasher.HashPassword(password);
            User user = new User()
            {
                LastName = lastName,
                FirstName = firstName,
                SurName = surName,
                Login = login,
                PasswordHash = hashedPassword
            };
            await _userService.Create(user);
        }
    }
}
