using DataAccessLibrary.Model.AdviceMaster;
using DataAccessLibrary.Model.ObservationMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class ObservationMasterController : Controller
    {
        private readonly ObservationMasterRepository _ObserRepository;

        public ObservationMasterController(ObservationMasterRepository ObserRepository)
        {
            _ObserRepository = ObserRepository;
        }


        [HttpGet]
        public async Task<IActionResult> ObservationCreate(int id)
        {
            if (id != null)
            {
                var Obser = await _ObserRepository.GetObservationById(id);
                if (Obser != null)
                {
                    return View(Obser);
                }
            }

            return View(new ObservationMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ObservationCreate(ObservationMaster Obser)
        {
            if (ModelState.IsValid)
            {
                if (Obser.Id == 0)
                {

                    await _ObserRepository.ObservationInsert(Obser);
                }
                else
                {
                    await _ObserRepository.UpdateObservation(Obser);
                }
                return RedirectToAction("GetAllObservation", "ObservationMaster");
            }
            return View(Obser);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllObservation()
        {
            var Obser = await _ObserRepository.GetAllObservation();
            return View(Obser);
        }

        
        [HttpPost]
        public async Task<IActionResult> ObservationDelete(int id, ObservationMaster a)
        {

            var success = await _ObserRepository.ObservationDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllObservation));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
