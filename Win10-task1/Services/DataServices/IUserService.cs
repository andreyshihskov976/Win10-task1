using System.Threading.Tasks;
using Win10_task1.Models;

namespace Win10_task1.Services.DataServices
{
    interface IUserService : IDataService<User>
    {
        Task<User> GetUserByLogin(string login);
    }
}
