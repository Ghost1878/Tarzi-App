using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tarzi_Backend.Data.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public GenericRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Add(T t)
        {
            if (t != null)
            {
                _db.Set<T>().Add(t);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            if (id != 0)
            {
                var entity = await _db.Set<T>().FindAsync(id);
                _db.Set<T>().Remove(entity);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task Update(int id)
        {
            if (id != 0)
            {
                var entity = await GetById(id);
                _db.Set<T>().Update(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}