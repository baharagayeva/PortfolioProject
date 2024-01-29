using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class WorkCategoryController : Controller
    {
        private readonly IWorkCategoryService _workCategoryService;
        public WorkCategoryController(IWorkCategoryService workCategoryService)
        {
            _workCategoryService = workCategoryService;
        }

        public IActionResult Index()
        {
            var workCategory = _workCategoryService.GetAll().Data;

            return View(workCategory);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(WorkCategory workCategory)
        {
            _workCategoryService.Add(workCategory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var workCategory = _workCategoryService.GetById(id).Data;

            return View(workCategory);
        }

        [HttpPost]
        public IActionResult Edit(WorkCategory workCategory)
        {
            var existingWorkCategory = _workCategoryService.GetById(workCategory.ID).Data;

            existingWorkCategory.Name = workCategory.Name;
            
            _workCategoryService.Update(existingWorkCategory);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var workCategory = _workCategoryService.GetById(id).Data;

            if(workCategory != null)
            {
                workCategory.Deleted = workCategory.ID;
                _workCategoryService.Delete(workCategory);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
