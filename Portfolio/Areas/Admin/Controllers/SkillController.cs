using Business.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            var result = _skillService.GetAll().Data;
            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            _skillService.Add(skill);

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var skill = _skillService.GetById(id).Data;
            return View(skill);
        }

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            var existingSkill = _skillService.GetById(skill.ID).Data;

            existingSkill.Name = skill.Name;

            _skillService.Update(existingSkill);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var skill = _skillService.GetById(id).Data;

            if(skill != null)
            {
                skill.Deleted = skill.ID;
                _skillService.Delete(skill);

                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
