using System.Collections.Generic;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class CategoryService : GenericRepo<Category, ApplicationDbContext>
    {
        public CategoryService(ApplicationDbContext db) : base(db)
        {

        }

    }
}