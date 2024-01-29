using Business.Abstract;
using Entities.Concrete.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IServiceService _serviceService;
        private readonly IExperienceService _experienceService;
        private readonly ISkillService _skillService;
        private readonly ISkillDetailService _skillDetailService;
        private readonly IWorkCategoryService _workCategoryService;
        private readonly IPortfolioService _portfolioService;
        private readonly IPositionService _positionService;

        public HomeController(IPersonService personService, IServiceService serviceService, IExperienceService experienceService, ISkillService skillService, ISkillDetailService skillDetailService, IWorkCategoryService workCategoryService, IPortfolioService portfolioService, IPositionService positionService)
        {
            _personService = personService;
            _serviceService = serviceService;
            _experienceService = experienceService;
            _skillService = skillService;
            _skillDetailService = skillDetailService;
            _workCategoryService = workCategoryService;
            _portfolioService = portfolioService;
            _positionService = positionService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var personData = _personService.GetAll().Data[0];
            var experienceData = _experienceService.GetAll().Data;
            var serviceData = _serviceService.GetAll().Data;
            var skillDetailData = _skillDetailService.GetAll().Data;
            var workCategoryData =_workCategoryService.GetAll().Data;
            var portfolioData = _portfolioService.GetAll().Data;
            var positionData = _positionService.GetAll().Data;


            HomeViewModel homeViewModel = new()
            {
                Person = personData,
                Experiences = experienceData,
                Services = serviceData,
                SkillDetails = skillDetailData,
                WorkCategories = workCategoryData,
                Portfolis = portfolioData,
                Positions = positionData
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}