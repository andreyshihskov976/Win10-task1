using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Win10_task1.Models;

namespace Win10_task1.Services.DataServices
{
    class ProcessService : IForeignDataService<Process>
    {
        protected ToDoListContext _context { get; private set; }

        public ProcessService()
        {
            _context = new ToDoListContext();
        }

        public async Task Create(Process item)
        {
            _context.Processes.Add(item);
            await SaveAsync();
        }

        public async Task Create(Process item, Guid id)
        {
            item.UserId = id;
            _context.Processes.Add(item);
            await SaveAsync();
        }

        public async Task Delete(Process item)
        {
            _context.Processes.Remove(item);
            await SaveAsync();
        }

        public Process GetById(Guid id)
        {
            return _context.Processes.Find(id);
        }

        public async Task<ICollection<Process>> GetList()
        {
            return await _context.Processes.ToListAsync();
        }

        public async Task<ICollection<Process>> GetListById(Guid id)
        {
            return await _context.Processes.Where(process => process.User.Id == id).ToListAsync();
        }

        public async Task LoadAsync()
        {
            await _context.Processes.LoadAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Process item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
