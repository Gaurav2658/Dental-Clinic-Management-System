using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dentalproj.Controllers
{
    public class ItemAssignMasterController : Controller
    {
        private readonly ItemAssignMasterRepository _itemassignRepository;
        private readonly CategoryMasterRepository _CategoryRepository;
        private readonly ItemMasterRepository _itemRepository;


        public ItemAssignMasterController(ItemAssignMasterRepository itemassignRepository, CategoryMasterRepository categoryRepository,ItemMasterRepository itemrepository)
        {
            _itemassignRepository = itemassignRepository;
            _CategoryRepository = categoryRepository;
            _itemRepository = itemrepository;
        }

        [HttpGet]
        public async Task<IActionResult> ItemAssignCreate(int id)
        {
            if (id != null)
            {
                var itemassign = await _itemassignRepository.GetItemAssignById(id);
                if (itemassign != null)
                {
                    var category = await _CategoryRepository.GetAllCat();
                    var item = await _itemRepository.GetAllItem();
                    ViewBag.Cat = new SelectList(category, "Id", "Name",itemassign.CatId);
                    ViewBag.Item = new SelectList(item, "Id", "ItemName", itemassign.ItemId);
                    return View(itemassign);
                }
            }

            var defaultCat = await _CategoryRepository.GetAllCat();
            var defaultitem = await _itemRepository.GetAllItem();

            ViewBag.Cat = new SelectList(defaultCat, "Id", "Name");
            ViewBag.Item = new SelectList(defaultitem, "Id", "ItemName");


            return View(new ItemAssignMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ItemAssignCreate(ItemAssignMaster assign)
        {
            if (ModelState.IsValid)
            {
                assign.TotalAmount = assign.OpeningQty * assign.OpeningRate;

                if (assign.Id == 0)
                {
                    await _itemassignRepository.ItemAssignInsert(assign);
                }
                else
                {
                    await _itemassignRepository.UpdateItemAssign(assign);
                }
                return RedirectToAction("GetAllItemAssign");
            }

            var category = await _CategoryRepository.GetAllCat();
            ViewBag.Cat = new SelectList(category, "Id", "Name", assign.CatId);
            var Item = await _itemRepository.GetAllItem();
            ViewBag.Item = new SelectList(Item, "Id", "ItemName", assign.ItemId);

            return View(assign);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllItemAssign()
        {
            var ItemAssign = await _itemassignRepository.GetAllItemAssign();
            var category = await _CategoryRepository.GetAllCat();
            var item = await _itemRepository.GetAllItem();

            ViewData["Category"] = category.ToDictionary(s => s.Id, s => s.Name);
            ViewData["Item"] = item.ToDictionary(s => s.Id, s => s.ItemName);
            return View(ItemAssign);
        }


        [HttpPost]
        public async Task<IActionResult> ItemAssignDelete(int id, ItemAssignMaster a)
        {
            var success = await _itemassignRepository.ItemAssignDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllItemAssign));
            }
            else
            {
                return NotFound();
            }
        }
    }

}
