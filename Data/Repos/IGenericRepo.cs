using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tarzi_Backend.Data.Repos
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        public IEnumerable<T> CountRecords { get; set; }
        Task Add(T t);
        Task Update(T t);
        Task Delete(int id);
        Task<T> GetById(int id);
    }
}