using Microsoft.AspNetCore.Identity;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Helpers
{
    public class Seeder
    {
        // private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public Seeder(/*ApplicationDbContext db,*/ UserManager<ApplicationUser> userManager)
        {
            //_db = db;
            _userManager = userManager;
        }
        public void SeedData()
        {
            AddNewType(new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.com",
                PasswordHash = "admin"
            });


        }
        private void AddNewType(ApplicationUser user)
        {
            //var userExist = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            var userExist = _userManager.FindByIdAsync(user.Id);
            if (userExist == null)
            {
                _userManager.CreateAsync(user, user.PasswordHash);
            }
        }
    }
}