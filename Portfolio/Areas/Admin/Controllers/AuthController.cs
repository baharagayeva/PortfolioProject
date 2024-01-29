using Entities.Concrete.TableModels;
using Entities.Concrete.TableModels.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDTO userDTO) 
        { 
            var checkUsername = await _userManager.FindByNameAsync(userDTO.Username);
            if(checkUsername is not  null) 
            {
               var signInResult = await _signInManager.PasswordSignInAsync(checkUsername, userDTO.Password, false, false);
                if (signInResult.Succeeded) 
                { 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        
        }
    }
}
