using System.Collections.Generic;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class CustomerService : IGenericRepo<Customer>
    {
        private readonly IGenericRepo<Customer> _repo;

        public CustomerService(IGenericRepo<Customer> repo)
        {
            _repo = repo;
        }
        public async Task Add(Customer customer)
        {
            await _repo.Add(customer);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task Update(int id)
        {
            await _repo.Update(id);
        }
    }
}