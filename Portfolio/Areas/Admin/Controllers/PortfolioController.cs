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
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IWorkCategoryService _workCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PortfolioController(IPortfolioService portfolioService, IWorkCategoryService workCategoryService, IWebHostEnvironment webHostEnvironment)
        {
            _portfolioService = portfolioService;
            _workCategoryService = workCategoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var result = _portfolioService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["WorkCategories"] = _workCategoryService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Portfoli portfoli)
        {
            string fileName = "";

            fileName = Upload(portfoli, fileName);

            var result = _portfolioService.Add(portfoli,fileName);

            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["WorkCategories"] = _workCategoryService.GetAll().Data;
                foreach (var error in result.Messages)
                {
                    ModelState.Remove(result.Data[result.Messages.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.Messages.IndexOf(error)], error);
                }
                return View(portfoli);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["WorkCategories"] = _workCategoryService.GetAll().Data;

            var portfolio = _portfolioService.GetById(id).Data;
            return View(portfolio);
        }

        [HttpPost]
        public IActionResult Edit(Portfoli portfoli)
        {
            var existingPortfolio = _portfolioService.GetById(portfoli.ID).Data;

            existingPortfolio.Title = portfoli.Title;
            existingPortfolio.WorkCategory = portfoli.WorkCategory;

            string filename = existingPortfolio.WorkImgPath;

            if (portfoli.workImgFile == null)
            {
                portfoli.WorkImgPath = filename;
            }
            else
            {
                filename = Upload(portfoli, filename);
            }

            var result = _portfolioService.Update(portfoli, filename);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["WorkCategories"] = _workCategoryService.GetAll().Data;
                foreach (var error in result.Messages)
                {
                    ModelState.Remove(result.Data[result.Messages.IndexOf(error)]);
                    ModelState.AddModelError(result.Data[result.Messages.IndexOf(error)], error);
                }
                return View(portfoli);
            }
        }
        public IActionResult Delete(int id)
        {
            var portfolio = _portfolioService.GetById(id).Data;

            if(portfolio != null)
            {
                portfolio.Deleted = portfolio.ID;
                _portfolioService.Delete(portfolio);

                return RedirectToAction("index");
            }

            // handle the case when the position is not found
            return NotFound();
        }

        public string Upload(Portfoli portfoli, string filename)
        {
           

            if (portfoli.workImgFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + portfoli.workImgFile.FileName;
                string folder = "Image/WorkImages/";
                folder += fileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                portfoli.workImgFile.CopyTo(new FileStream(serverFolder, FileMode.Create));
                return fileName;
            }
            else
            {
                return null;
            }
            
        }
    }
}
