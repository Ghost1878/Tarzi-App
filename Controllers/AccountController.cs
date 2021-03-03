using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarzi_Backend.Data.Services;
using Tarzi_Backend.Models;
using Tarzi_Backend.ViewModels;

namespace Tarzi_Backend.Controllers
{
   // [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly CustomerService _customerService;
        private SignInManager<ApplicationUser> _singInManager;
        public AccountController(CustomerService customerService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _singInManager = signInManager;
            _userManager = userManager;
            _customerService = customerService;
        }
        public IActionResult Dashboard()
        {
          

                return View();
             
            //return RedirectToAction(nameof(Login));

        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users == null)
            {
                return View();
            }
            return View(users);
        }


        [HttpGet]
        public async Task< IActionResult> Register(string userId)
        {
            if (userId ==string.Empty)
            {
            return View();
            }
            else
            {
                var user = await _userManager.FindByIdAsync(userId);
                return View(user);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = applicationUser.FirstName,
                    LastName = applicationUser.LastName,
                    PhoneNumber = applicationUser.PhoneNumber,
                    UserName = applicationUser.Email,
                    Email = applicationUser.Email,
                };
                var result = await _userManager.CreateAsync(user, applicationUser.PasswordHash);
                if (result.Succeeded)
                {
                    await _singInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(applicationUser);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            if (_singInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(Dashboard));
            }
                ViewData["ReturnUrl"] = returnUrl;
                return   View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login user, string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _singInManager.PasswordSignInAsync(user.Email, user.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Dashboard));
                }
                ModelState.AddModelError(string.Empty, "اسم المستخدم او كلمة المرور غير صحيحة");
            }
            return View(user);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
/***

    private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public DashBoardController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            Login loginModel = new Login();
            return View(loginModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login loginInfo)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginInfo.Email);
                if (await _userManager.CheckPasswordAsync(user, loginInfo.Password) == false)
                {
                    ModelState.AddModelError("message", "cradentials wrong");
                    return View(loginInfo);
                }
                var resault = await _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, lockoutOnFailure: false, isPersistent: false);
                if (resault.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "DashBoard");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(loginInfo);
                }
            }
            return View(loginInfo);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
***/