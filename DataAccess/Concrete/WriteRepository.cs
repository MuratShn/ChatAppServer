using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly Context _context;

        public WriteRepository(Context context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            var entity = await Table.AddAsync(model);
            return entity.State == EntityState.Added; 
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            try
            {
                await Table.AddRangeAsync(datas);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public bool Remove(T model)
        {
            var entity = Table.Remove(model);

            return entity.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            Table.Remove(model);
            return true;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool Update(T model)
        {
            var entity = Table.Update(model);
            return entity.State == EntityState.Modified;
        }
    }
}
