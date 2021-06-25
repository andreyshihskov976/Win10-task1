using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Win10_task1.Models;

namespace Win10_task1.Services.DataServices
{
    class UserService : IUserService
    {
        protected ToDoListContext _context { get; private set; }
        public UserService()
        {
            _context = new ToDoListContext();
        }

        public async Task Create(User item)
        {
            _context.Users.Add(item);
            await SaveAsync();
        }

        public async Task Delete(User item)
        {
            _context.Users.Remove(item);
            await SaveAsync();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public async Task<ICollection<User>> GetList()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task LoadAsync()
        {
            await _context.Users.LoadAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(User item)
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
