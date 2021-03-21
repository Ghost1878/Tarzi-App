using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tarzi_Backend.Data.Repos
{
    public class GenericRepo<T, TContext> : IGenericRepo<T> where T : class
    where TContext : DbContext
    {
        private readonly TContext _db;

        public GenericRepo(TContext db)
        {
            _db = db;
        }

        public IEnumerable<T> CountRecords { get; set; }

        public async Task Add(T t)
        {
            try
            {
                if (t != null)
                {
                    _db.Set<T>().Add(t);
                    await _db.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    var entity = await _db.Set<T>().FindAsync(id);
                    _db.Set<T>().Remove(entity);
                    await _db.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

            }

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var entity = await _db.Set<T>().FindAsync(id);
                return entity;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task Update(T t)
        {
            try
            {
                if (t != null)
                {
                    _db.Set<T>().Update(t);
                    await _db.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}