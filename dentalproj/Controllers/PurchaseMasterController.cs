using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dentalproj.Controllers
{
    public class PurchaseMasterController : Controller
    {
        private readonly PurchaseMasterRepository _purchaseRepository;
        private readonly SupplierMasterRepository _supplierRepository;
        private readonly ItemMasterRepository _itemRepository;

        public PurchaseMasterController(PurchaseMasterRepository purchaseRepository, SupplierMasterRepository supplierRepository, ItemMasterRepository itemRepository)
        {
            _purchaseRepository = purchaseRepository;
            _supplierRepository = supplierRepository;
            _itemRepository = itemRepository;
        }
       
        [HttpGet]
        public async Task<IActionResult> PurchaseCreate(int id)
        {
            if (id != null)
            {
                var purchase = await _purchaseRepository.GetPurchaseById(id);
                if (purchase != null)
                {
                    var suppliers = await _supplierRepository.GetAllSupplier();
                    var item = await _itemRepository.GetAllItem();
                    ViewBag.Suppliers = new SelectList(suppliers, "Id", "CompanyName", purchase.SId);
                    ViewBag.Item = new SelectList(item, "Id", "ItemName", purchase.ItemId);
                    return View(purchase);
                }
            }

            var defaultSuppliers = await _supplierRepository.GetAllSupplier();
            var defaultitem = await _itemRepository.GetAllItem();
            ViewBag.Suppliers = new SelectList(defaultSuppliers, "Id", "CompanyName");
            ViewBag.Item = new SelectList(defaultitem, "Id", "ItemName");

            return View(new PurchaseMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PurchaseCreate(PurchaseMaster purchase)
        {
            if (ModelState.IsValid)
            {
                purchase.TotalAmount = purchase.Qty * purchase.Rate;

                if (purchase.Id == 0)
                {
                    await _purchaseRepository.PurchaseInsert(purchase);
                }
                else
                {
                    await _purchaseRepository.UpdatePurchase(purchase);
                }
                return RedirectToAction("GetAllPurchase");
            }

            var suppliers = await _supplierRepository.GetAllSupplier();
            ViewBag.Suppliers = new SelectList(suppliers, "Id", "CompanyName", purchase.SId);
            var Item = await _itemRepository.GetAllItem();
            ViewBag.Item = new SelectList(Item, "Id", "ItemName", purchase.ItemId);

            return View(purchase);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPurchase()
        {
            var purchases = await _purchaseRepository.GetAllPurchase();
            var suppliers = await _supplierRepository.GetAllSupplier();
            var item = await _itemRepository.GetAllItem();


            ViewData["Suppliers"] = suppliers.ToDictionary(s => s.Id, s => s.CompanyName);
            ViewData["Item"] = item.ToDictionary(s => s.Id, s => s.ItemName);

            return View(purchases);
        }


        [HttpPost]
        public async Task<IActionResult> PurchaseDelete(int id, PurchaseMaster a)
        {
            var success = await _purchaseRepository.PurchaseDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllPurchase));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
