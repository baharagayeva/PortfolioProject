using Business.Abstract;
using Core.Helpers;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IPositionService _positionService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonController(IPersonService personSevice, IPositionService positionService, IWebHostEnvironment webHostEnvironment)
        {
            _personService = personSevice;
            _positionService = positionService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var result = _personService.GetAll().Data;
            return View(result);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Positions"] = _positionService.GetAll().Data;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Person person)
        {
            string fileName = "";
            string download = "";
            fileName = Upload(person, fileName);
            download = Download(person, download);

            var result = _personService.Add(person, fileName, download);
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
                return View(person);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewData["Positions"] = _positionService.GetAll().Data;
            var person = _personService.GetById(id).Data;

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {

            var exsistingProfile = _personService.GetById(person.ID).Data;
            string filename = exsistingProfile.ProfileImgPath;
            string download = exsistingProfile.CVPath;

            if (person.ImgFile == null)
            {
                person.ProfileImgPath = exsistingProfile.ProfileImgPath;
            }
            else
            {
                filename = Upload(person, filename);

            }

            if (person.CvFile == null)
            {
                person.CVPath = exsistingProfile.CVPath;
            }
            else
            {
                download = Download(person, download);
            }

            var result = _personService.Update(person, filename, download);
            //validation codes
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
                return View(person);
            }
        }

        public IActionResult Delete(int id)
        {
            var person = _personService.GetById(id).Data;

            if (person != null)
            {
                person.Deleted = person.ID;
                _personService.Delete(person);

                return RedirectToAction("index");
            }

            // handle the case when the position is not found
            return NotFound();
        }

        public string Upload(Person person, string filename)
        {
            if (person.ImgFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + person.ImgFile.FileName;
                string folder = "Image/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.ImgFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }

        }

        public string Download(Person person, string filename)
        {
            if (person.CvFile != null)
            {
                string download = Guid.NewGuid().ToString() + "_" + person.CvFile.FileName;
                string folder = "Cv/";
                folder += download;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                person.CvFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return download;
            }
            else
            {
                return null;
            }

        }
    }
}
