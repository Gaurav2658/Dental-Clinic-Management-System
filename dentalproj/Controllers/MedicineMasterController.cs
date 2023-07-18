using DataAccessLibrary.Model.AdviceMaster;
using DataAccessLibrary.Model.MedicineMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class MedicineMasterController : Controller
    {
        private readonly MedicineMasterRepository _MedicineRepository;

        public MedicineMasterController(MedicineMasterRepository medicineRepository)
        {
            _MedicineRepository = medicineRepository;
        }
       

        [HttpGet]
        public async Task<IActionResult> MedicineCreate(int id)
        {
            if (id != null)
            {
                var medicine = await _MedicineRepository.GetMedicineById(id);
                if (medicine != null)
                {
                    return View(medicine);
                }
            }

            return View(new MedicineMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> MedicineCreate(MedicineMaster medicine)
        {
            if (ModelState.IsValid)
            {
                if (medicine.Id == 0)
                {

                    await _MedicineRepository.MedicineInsert(medicine);
                }
                else
                {
                    await _MedicineRepository.UpdateMedicine(medicine);
                }
                return RedirectToAction("GetAllMedicine", "MedicineMaster");
            }
            return View(medicine);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicine()
        {
            var medicine = await _MedicineRepository.GetAllMedicine();
            return View(medicine);
        }

      
        [HttpPost]
        public async Task<IActionResult> MedicineDelete(int id, MedicineMaster m)
        {

            var success = await _MedicineRepository.MedicineDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllMedicine));
            }
            else
            {
                return NotFound();
            }
        }

    }
}