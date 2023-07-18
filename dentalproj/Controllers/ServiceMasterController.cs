using DataAccessLibrary.Model.ServiceMaster;
using DataAccessLibrary.Model.UserMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class ServiceMasterController : Controller
    {
        private readonly ServiceMasterRepository _serviceRepository;

        public ServiceMasterController(ServiceMasterRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
       

        [HttpGet]
        public async Task<IActionResult> ServiceCreate(int id)
        {
            if (id != null)
            {
                var service = await _serviceRepository.GetServiceById(id);
                if (service != null)
                {
                    return View(service);
                }
            }

            return View(new ServiceMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ServiceCreate(ServiceMaster service)
        {
            if (ModelState.IsValid)
            {
                if (service.Id == 0)
                {

                    await _serviceRepository.ServiceInsert(service);
                }
                else
                {
                    await _serviceRepository.UpdateService(service);
                }

                return RedirectToAction("GetAllService", "ServiceMaster");
            }

            return View(service);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllService()
        {
            var service = await _serviceRepository.GetAllService();
            return View(service);
        }

       
        [HttpPost]
        public async Task<IActionResult> ServiceDelete(int id, ServiceMaster u)
        {

            var success = await _serviceRepository.ServiceDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllService));
            }
            else
            {
                return NotFound();
            }
        }

    }

}
