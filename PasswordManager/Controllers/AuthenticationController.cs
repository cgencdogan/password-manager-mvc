using Common.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PasswordManager.Controllers;
public class AuthenticationController : Controller {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register() {
        return View();
    }

    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserForRegisterVM userForRegisterVM) {
        var userForRegister = new IdentityUser {
            UserName = userForRegisterVM.UserName,
            Email = userForRegisterVM.Email,
        };

        var userResult = await _userManager.CreateAsync(userForRegister, userForRegisterVM.Password);

        if (userResult.Succeeded) {
            return Ok();
        }

        return BadRequest(userResult.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserForLoginVM userForLoginVM) {
        if (string.IsNullOrEmpty(userForLoginVM.UserName)) {
            return BadRequest("Giriş başarısız.");
        }
        var user = await _userManager.FindByNameAsync(userForLoginVM.UserName);
        if (user != null) {
            var signInResult = await _signInManager.PasswordSignInAsync(user, userForLoginVM.Password, userForLoginVM.RememberMe, false);

            if (signInResult.Succeeded) {
                return Ok();
            }
        }

        return BadRequest("Giriş başarısız.");
    }

    public async Task<IActionResult> Logout() {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}
