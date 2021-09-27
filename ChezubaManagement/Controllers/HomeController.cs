using ChezubaManagement.Models;
using ChezubaManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;

namespace ChezubaManagement.Controllers
{
    public class HomeController : Controller
    {

        private  readonly IProjectRepository _projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            var model = _projectRepository.GetAllProjects();
            return View(model);
        }

        

        [Route("Home/Details /{id?}")]
        public ViewResult Details( int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Project = _projectRepository.GetProject(id??1),
                PageTitle = " Project Details "
            }; 
           
            return View(homeDetailsViewModel);

        }

       

        [HttpGet]
        public ActionResult Create()
        {

            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Create(Project project)
        {
            Project newProject = _projectRepository.Add(project);
            return RedirectToAction("details", new { id = newProject.Id });
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Project project = _projectRepository.GetProject(id);
            ProjectEditViewModel projectEditViewModel = new ProjectEditViewModel
            {
                Id = project.Id,
                Heading = project.Heading,
                NGO_name = project.NGO_name,
                Site = project.Site,
                Duration = project.Duration,
                Time_com = project.Time_com,
                Address = project.Address,
                Name = project.Name,
                Phone = project.Phone
            };
            return View(projectEditViewModel);
        }

        [HttpPost]
        public RedirectToActionResult Edit(ProjectEditViewModel model)
        {
            Project project = _projectRepository.GetProject(model.Id);
            project.Heading = model.Heading;
            project.NGO_name = model.NGO_name;
            project.Site = model.Site;
            project.Duration = model.Duration;
            project.Time_com = model.Time_com;
            project.Address = model.Address;
            project.Name = model.Name;
            project.Phone = model.Phone;

            _projectRepository.Update(project);
            return RedirectToAction("list");
        }

       



    }
}
