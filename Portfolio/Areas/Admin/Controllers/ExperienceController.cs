using Business.Abstract;
using Core.Helpers;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IPositionService _positionService;
        public ExperienceController(IExperienceService experienceService, IPositionService positionService)
        {
            _experienceService = experienceService;
            _positionService = positionService;
        }
        public IActionResult Index()
        {
            var result = _experienceService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Experience experience)
        {
           
            var result = _experienceService.Add(experience);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Positions"] = _positionService.GetAll().Data;
                foreach (var error in result.Messages)
                {
                    ModelState.Remove(result.Data[result.Messages.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.Messages.IndexOf(error)], error);
                }
                return View(experience);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            var experience = _experienceService.GetById(id).Data;
            return View(experience);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            var result = _experienceService.Update(experience);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Positions"] = _positionService.GetAll().Data;
                foreach (var error in result.Messages)
                {
                    ModelState.Remove(result.Data[result.Messages.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.Messages.IndexOf(error)], error);
                }
                return View(experience);
            }
        }
        public IActionResult Delete(int id)
        {
            var experience = _experienceService.GetById(id).Data;
            if (experience != null)
            {
                experience.Deleted = experience.ID;
                _experienceService.Delete(experience);

                return RedirectToAction("index");
            }

            // handle the case when the position is not found
            return NotFound();
        }
    }
}
