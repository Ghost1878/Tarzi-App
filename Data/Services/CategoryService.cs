using System.Collections.Generic;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class CategoryService : IGenericRepo<Category>
    {
        private readonly IGenericRepo<Category> _repo;

        public CategoryService(IGenericRepo<Category> repo)
        {
            _repo = repo;
        }
        public async Task Add(Category category)
        {
            await _repo.Add(category);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(int id)
        {
            await _repo.Update(id);
        }
    }
}