using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dentalproj.Controllers
{
    public class ItemMasterController : Controller
    {
        private readonly ItemMasterRepository _itemRepository;
        private readonly UnitMasterRepository _unitRepository;

        public ItemMasterController(ItemMasterRepository itemRepository, UnitMasterRepository unitRepository)
        {
            _itemRepository = itemRepository;
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ItemCreate(int id)
        {
            if (id != null)
            {
                var item = await _itemRepository.GetItemById(id);
                if (item != null)
                {
                    var Unit = await _unitRepository.GetAllUnit();
                    ViewBag.Unit= new SelectList(Unit, "Id", "Name", item.UId);
                    return View(item);
                }
            }

            var defaultUnit = await _unitRepository.GetAllUnit();
            ViewBag.Unit = new SelectList(defaultUnit, "Id", "Name");

            return View(new ItemMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ItemCreate(ItemMaster item)
        {
            if (ModelState.IsValid)
            {

                if (item.Id == 0)
                {
                    await _itemRepository.ItemInsert(item);
                }
                else
                {
                    await _itemRepository.UpdateItem(item);
                }
                return RedirectToAction("GetAllItem");
            }

            var Unit = await _unitRepository.GetAllUnit();
            ViewBag.Unit = new SelectList(Unit, "Id", "Name", item.UId);

            return View(item);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {
            var item = await _itemRepository.GetAllItem();
            var unit = await _unitRepository.GetAllUnit();

            ViewData["Unit"] = unit.ToDictionary(s => s.Id, s => s.Name);

            return View(item);
        }


        [HttpPost]
        public async Task<IActionResult> ItemDelete(int id, ItemMaster a)
        {
            var success = await _itemRepository.ItemDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllItem));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
