using DataAccessLibrary.Model.AdviceMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class AdviceMasterController : Controller
    {
        private readonly AdviceMasterRepository _adviceRepository;

        public AdviceMasterController(AdviceMasterRepository adviceRepository)
        {
            _adviceRepository = adviceRepository;
        }
      

        [HttpGet]
        public async Task<IActionResult> AdviceCreate(int id)
        {
            if (id != null)
            {
                var Advice = await _adviceRepository.GetAdviceById(id);
                if (Advice != null)
                {
                    return View(Advice);
                }
            }

            return View(new AdviceMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AdviceCreate(AdviceMaster Advice)
        {
            if (ModelState.IsValid)
            {
                if (Advice.Id == 0)
                {

                    await _adviceRepository.AdviceInsert(Advice);
                }
                else
                {
                    await _adviceRepository.UpdateAdvice(Advice);
                }
                return RedirectToAction("GetAllAdvice", "AdviceMaster");
            }
            return View(Advice);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdvice()
        {
            var Advice = await _adviceRepository.GetAllAdvice();
            return View(Advice);
        }

     
        [HttpPost]
        public async Task<IActionResult> AdviceDelete(int id, AdviceMaster a)
        {

            var success = await _adviceRepository.AdviceDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllAdvice));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
