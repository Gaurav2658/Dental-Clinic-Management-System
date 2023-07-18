using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class SupplierMasterController : Controller
    {
        private readonly SupplierMasterRepository _supplierRepository;

        public SupplierMasterController(SupplierMasterRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SupplierCreate(int id)
        {
            if (id != null)
            {
                var supplier = await _supplierRepository.GetSupplierById(id);
                if (supplier != null)
                {
                    return View(supplier);
                }
            }

            return View(new SupplierMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> SupplierCreate(SupplierMaster supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.Id == 0)
                {

                    await _supplierRepository.SupplierInsert(supplier);
                }
                else
                {
                    await _supplierRepository.UpdateSupplier(supplier);
                }

                return RedirectToAction("GetAllSupplier", "SupplierMaster");
            }

            return View(supplier);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSupplier()
        {
            var supplier = await _supplierRepository.GetAllSupplier();
         
            return View(supplier);
        }


        [HttpPost]
        public async Task<IActionResult> SupplierDelete(int id, SupplierMaster u)
        {

            var success = await _supplierRepository.DeleteSupplier(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllSupplier));
            }
            else
            {
                return NotFound();
            }
        }

    }
}

