using DataAccessLibrary.Model.CategoryMaster;
using DataAccessLibrary.Model.UnitMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class CategoryMasterController : Controller
    {
        private readonly CategoryMasterRepository _catRepository;

        public CategoryMasterController(CategoryMasterRepository catRepository)
        {
            _catRepository = catRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryCreate(int id)
        {
            if (id != null)
            {
                var cat = await _catRepository.GetCatById(id);
                if (cat != null)
                {
                    return View(cat);
                }
            }

            return View(new CategoryMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CategoryCreate(CategoryMaster cat)
        {
            if (ModelState.IsValid)
            {
                if (cat.Id == 0)
                {

                    await _catRepository.CategoryInsert(cat);
                }
                else
                {
                    await _catRepository.UpdateCategory(cat);
                }

                return RedirectToAction("GetAllCat", "CategoryMaster");
            }

            return View(cat);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCat()
        {
            var cat = await _catRepository.GetAllCat();
            return View(cat);
        }



        [HttpPost]
        public async Task<IActionResult> CategoryDelete(int id, CategoryMaster u)
        {

            var success = await _catRepository.CategoryDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllCat));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
