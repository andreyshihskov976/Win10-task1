using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Win10_task1.Services.DataServices
{
    interface IForeignDataService<T> : IDataService<T> where T : class
    {
        Task<ICollection<T>> GetListById(Guid id);
        Task Create(T item, Guid id);
    }
}
