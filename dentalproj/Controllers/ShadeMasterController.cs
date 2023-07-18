using DataAccessLibrary.Model.ServiceMaster;
using DataAccessLibrary.Model.ShadeMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class ShadeMasterController : Controller
    {
        private readonly ShadeMasterRepository _shadeRepository;

        public ShadeMasterController(ShadeMasterRepository shadeRepository)
        {
            _shadeRepository = shadeRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> ShadeCreate(int id)
        {
            if (id != null)
            {
                var shade = await _shadeRepository.GetShadeById(id);
                if (shade != null)
                {
                    return View(shade);
                }
            }

            return View(new ShadeMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ShadeCreate(ShadeMaster shade)
        {
            if (ModelState.IsValid)
            {
                if (shade.Id == 0)
                {

                    await _shadeRepository.ShadeInsert(shade);
                }
                else
                {
                    await _shadeRepository.UpdateShade(shade);
                }

                return RedirectToAction("GetAllShade", "ShadeMaster");
            }

            return View(shade);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShade()
        {
            var shade = await _shadeRepository.GetAllShade();
            return View(shade);
        }

       
        [HttpPost]
        public async Task<IActionResult> ShadeDelete(int id, ShadeMaster u)
        {

            var success = await _shadeRepository.ShadeDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllShade));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
