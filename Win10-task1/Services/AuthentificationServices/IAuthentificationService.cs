using System.Threading.Tasks;
using Win10_task1.Models;

namespace Win10_task1.Services.AuthentificationServices
{
    interface IAuthentificationService
    {
        Task Register(string lastName, string firstName, string surName, string login, string password);
        Task<User> Login(string login, string password);
    }
}
