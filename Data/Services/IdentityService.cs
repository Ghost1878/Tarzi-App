using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tarzi_Backend.Data.Repos;
using Tarzi_Backend.Models;

namespace Tarzi_Backend.Data.Services
{
    public class IdentityService : GenericRepo<ApplicationUser, ApplicationDbContext>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public ApplicationUser appUser { get; set; }

        public IdentityService(ApplicationDbContext db, UserManager<ApplicationUser> userManager) : base(db)
        {
            _userManager = userManager;
        }
        public async Task Create(ApplicationUser user)
        {
            try
            {
                var usr = new ApplicationUser
                {
                    Email = appUser.Email,
                    UserName = appUser.UserName,
                };
                IdentityResult result = await _userManager.CreateAsync(usr, appUser.PasswordHash);
                if (result.Succeeded)
                {

                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}