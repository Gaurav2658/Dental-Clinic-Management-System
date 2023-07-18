using DataAccessLibrary.Model.ShadeMaster;
using DataAccessLibrary.Model.UnitMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class UnitMasterController : Controller
    {
        private readonly UnitMasterRepository _unitRepository;

        public UnitMasterController(UnitMasterRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> UnitCreate(int id)
        {
            if (id != null)
            {
                var unit = await _unitRepository.GetUnitById(id);
                if (unit != null)
                {
                    return View(unit);
                }
            }

            return View(new UnitMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UnitCreate(UnitMaster unit)
        {
            if (ModelState.IsValid)
            {
                if (unit.Id == 0)
                {

                    await _unitRepository.UnitInsert(unit);
                }
                else
                {
                    await _unitRepository.UpdateUnit(unit);
                }

                return RedirectToAction("GetAllUnit", "UnitMaster");
            }

            return View(unit);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUnit()
        {
            var unit = await _unitRepository.GetAllUnit();
            return View(unit);
        }


   
        [HttpPost]
        public async Task<IActionResult> UnitDelete(int id, UnitMaster u)
        {

            var success = await _unitRepository.UnitDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllUnit));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
