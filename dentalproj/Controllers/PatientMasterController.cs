using DataAccessLibrary.Model;
using DataAccessLibrary.Model.AdviceMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class PatientMasterController : Controller
    {
        private readonly PatientMasterRepository _PatientRepository;

        public PatientMasterController(PatientMasterRepository PatientRepository)
        {
            _PatientRepository = PatientRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PatientCreate(int id)
        {
            if (id != null)
            {
                var patient = await _PatientRepository.GetPatientById(id);
                if (patient != null)
                {
                    return View(patient);
                }
            }

            return View(new PatientMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> PatientCreate(PatientMaster Patient)
        {
            if (ModelState.IsValid)
            {
                if (Patient.Id == 0)
                {

                    await _PatientRepository.PatientInsert(Patient);
                }
                else
                {
                    await _PatientRepository.UpdatePatient(Patient);
                }
                return RedirectToAction("GetAllPatient", "PatientMaster");
            }
            return View(Patient);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatient()
        {
            var Patient = await _PatientRepository.GetAllPatient();
            return View(Patient);
        }
		[HttpGet]
		public async Task<IActionResult> PatientView(int? id)
		{
			if (id != null)
			{
				var patient = await _PatientRepository.GetPatientById(id.Value);
				if (patient != null)
				{
					return View(patient);
				}
			}

			return View(new PatientMaster());
		}

		[HttpPost]
        public async Task<IActionResult> PatientDelete(int id, AdviceMaster a)
        {

            var success = await _PatientRepository.PatientDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllPatient));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
