using ChezubaManagement.Models;
using ChezubaManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChezubaManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(IProjectRepository projectRepository, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _projectRepository = projectRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public ViewResult List()
        {
            var model = _projectRepository.GetAllProjects();
            return View(model);
        }

        [Route("Account/Details /{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Project = _projectRepository.GetProject(id ?? 1),
                PageTitle = " Project Details "
            };

            return View(homeDetailsViewModel);

        }

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

       [AcceptVerbs("Get" , "Post")]
        public async Task<IActionResult> IsEmailInUse(String email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} applied previously application is pending");

            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user);

                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("success", "account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public ViewResult Success()
        {
            return View();
        }
    }

}


