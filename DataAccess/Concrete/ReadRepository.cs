using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    //Write Ve Read core katmanındada olabilirdi bence ?
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly Context _context;

        public ReadRepository(Context context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>(); // direk T'den de giderdik ama boyle daha temiz gozukucek

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable(); //querable olması ıcın türü değiştirdik dbset'ti
            
            if (!tracking) 
                query = query.AsNoTracking();

            return query;
            
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
