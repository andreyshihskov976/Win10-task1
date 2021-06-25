using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Win10_task1.Services.DataServices
{
    interface IDataService<T> : IDisposable
        where T : class
    {
        Task LoadAsync();
        Task<ICollection<T>> GetList();
        T GetById(Guid id);
        Task Create(T item);
        Task Delete(T item);
        Task Update(T item);
        Task SaveAsync();
    }
}
