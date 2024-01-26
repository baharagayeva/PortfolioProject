using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IWebHostEnvironment _webHostEnvironment;

       public ServiceController(IServiceService serviceService, IWebHostEnvironment webHostEnvironment)
        {
            _serviceService = serviceService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var result = _serviceService.GetAll().Data;
            return View(result);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Service service)
        {
            _serviceService.Add(service);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _serviceService.GetById(id).Data;
            return View(service);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            var existingService = _serviceService.GetById(service.ID).Data;

            existingService.Title = service.Title;
            existingService.Description = service.Description;
            existingService.IconName = service.IconName;

            _serviceService.Update(existingService);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var service = _serviceService.GetById(id).Data;

            if(service != null)
            {
                service.Deleted = service.ID;
                _serviceService.Delete(service);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
        
    }
}
