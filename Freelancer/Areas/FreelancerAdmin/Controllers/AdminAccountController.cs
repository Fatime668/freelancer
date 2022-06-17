using Freelancer.Areas.FreelancerAdmin.ViewModels;
using Freelancer.Models;
using Freelancer.Utilities;
using Freelancer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Areas.FreelancerAdmin.Controllers
{
    [Area("FreelancerAdmin")]
    public class AdminAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminAccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(AdminRegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = new AppUser
            {
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                Email = register.Email,
                UserName = register.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            foreach (var roles in register.Roles)
            {
                await _userManager.AddToRoleAsync(user, roles.ToString());
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Dashboard");



        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AdminLoginVM login)
        {
            AppUser user = await _userManager.FindByNameAsync(login.Username);
            if (user == null) return View();

            IList<string> roles = await _userManager.GetRolesAsync(user);
            string adminRole = roles.FirstOrDefault(r => r.ToLower().Trim() == Roles.Admin.ToString().ToLower().Trim());
            string superAdminRole = roles.FirstOrDefault(r => r.ToLower().Trim() == Roles.SuperAdmin.ToString().ToLower().Trim());
            if (adminRole == null && superAdminRole == null)
            {
                ModelState.AddModelError("", "Something went wrong. Please try again");
                return View();
            }
            else
            {
                if (login.RememberMe)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);

                    if (!result.Succeeded)
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                            return View();
                        }
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }
                }
                else
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);
                    if (!result.Succeeded)
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                            return View();
                        }
                        ModelState.AddModelError("", "Username or Password is incorrect");
                        return View();
                    }
                }

                return RedirectToAction("Index", "Dashboard");
            }

        }
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();
            EditVM adminEdit = new EditVM
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Username = user.UserName

            };
            return View(adminEdit);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AdminEditVM user)
        {
            AppUser exitedUser = await _userManager.FindByNameAsync(User.Identity.Name);
            EditVM adminEdit = new EditVM
            {
                Firstname = exitedUser.Firstname,
                Lastname = exitedUser.Lastname,
                Email = exitedUser.Email,
                Username = exitedUser.UserName
            };
            if (ModelState.IsValid) return View(adminEdit);
            bool result = user.Password == null && user.CurrentPassword == null && user.ConfirmPassword != null;
            if (user.Email == null || user.Email != exitedUser.Email)
            {
                ModelState.AddModelError("", "You can't change your email");
                return View(adminEdit);
            }
            if (result)
            {
                exitedUser.Firstname = user.FirstName;
                exitedUser.Lastname = user.LastName;
                exitedUser.UserName = user.Username;
                await _userManager.UpdateAsync(exitedUser);
            }
            else
            {
                exitedUser.Firstname = user.FirstName;
                exitedUser.Lastname = user.LastName;
                exitedUser.UserName = user.Username;
                if (adminEdit.CurrentPassword == user.Password)
                {
                    ModelState.AddModelError("", "You can't change password with the same password");
                    return View();
                }
                IdentityResult resultEdit = await _userManager.ChangePasswordAsync(exitedUser, user.CurrentPassword, user.Password);

                if (!resultEdit.Succeeded)
                {
                    foreach (IdentityError err in resultEdit.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                    return View(adminEdit);

                }
            }
            return RedirectToAction("Index", "Dashboard");

        }
        public IActionResult Show()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Dashboard");
        }
        public async Task CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
            await _roleManager.CreateAsync(new IdentityRole { Name = Roles.SuperAdmin.ToString() });
            await _roleManager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
        }
    }
}
