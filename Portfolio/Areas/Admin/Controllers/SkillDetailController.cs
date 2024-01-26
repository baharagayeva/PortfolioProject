using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillDetailController : Controller
    {
        private readonly ISkillDetailService _skillDetailService;
        private readonly ISkillService _skillService;
        public SkillDetailController(ISkillDetailService skillDetailService, ISkillService skillService)
        {
            _skillDetailService = skillDetailService;
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            var result = _skillDetailService.GetAll().Data;
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Skills"] = _skillService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Add(SkillDetail skillDetail)
        {
           
            _skillDetailService.Add(skillDetail);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Skills"] = _skillService.GetAll().Data;
            
            var skillDetail = _skillDetailService.GetById(id).Data;
            return View(skillDetail);

        }
        [HttpPost]
        public IActionResult Edit(SkillDetail skillDetail)
        {
            var existingSkillDetail = _skillDetailService.GetById(skillDetail.ID).Data;

            existingSkillDetail.Skill = skillDetail.Skill;
            existingSkillDetail.Level = skillDetail.Level;

            _skillDetailService.Update(existingSkillDetail);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var skillDetail = _skillDetailService.GetById(id).Data;

            if(skillDetail != null)
            {
                skillDetail.Deleted = skillDetail.ID;
                _skillDetailService.Delete(skillDetail);

                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
