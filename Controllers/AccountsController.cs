using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskIdentity.Data;
using TaskIdentity.Models.ViewModel;

namespace TaskIdentity.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signinManger;

        public AccountsController(ApplicationDbContext context,UserManager<IdentityUser>userManager,SignInManager<IdentityUser> signinManger) 
        {
            this.context = context;
            this.userManager = userManager;
            this.signinManger = signinManger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                UserName = model.Email,
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signinManger.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);

            if (result.Succeeded) {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
           
        }

    }
}
