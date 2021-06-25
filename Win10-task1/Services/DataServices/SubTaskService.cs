using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Win10_task1.Models;

namespace Win10_task1.Services.DataServices
{
    class SubTaskService : IForeignDataService<SubTask>
    {
        protected ToDoListContext _context { get; private set; }

        public SubTaskService()
        {
            _context = new ToDoListContext();
        }

        public async Task Create(SubTask item)
        {
            _context.SubTasks.Add(item);
            await SaveAsync();
        }

        public async Task Create(SubTask item, Guid id)
        {
            item.ProcessId = id;
            _context.SubTasks.Add(item);
            await SaveAsync();
        }
        public async Task Delete(SubTask item)
        {
            _context.SubTasks.Remove(item);
            await SaveAsync();
        }

        public SubTask GetById(Guid id)
        {
            return _context.SubTasks.Find(id);
        }

        public async Task<ICollection<SubTask>> GetList()
        {
            return await _context.SubTasks.ToListAsync();
        }

        public async Task<ICollection<SubTask>> GetListById(Guid id)
        {
            return await _context.SubTasks.Where(subTask => subTask.Process.Id == id).ToListAsync();
        }

        public async Task LoadAsync()
        {
            await _context.SubTasks.LoadAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(SubTask item)
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
