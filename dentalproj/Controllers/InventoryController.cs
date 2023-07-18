using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class InventoryController : Controller
    {
        // GET: InventoryController
        public ActionResult ItemConsumption()
        {
            return View();
        }
        public ActionResult AddItemConsumption()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItemConsumption(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ItemConsumption));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditItemConsumption()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItemConsumption(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ItemConsumption));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Item()
        {
            return View();
        }
        public ActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Item));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditItem()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Item));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CategoryList()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(CategoryList));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategory(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(CategoryList));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ItemAssign()
        {
            return View();
        }
        public ActionResult AddItemAssign()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItemAssign(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ItemAssign));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditItemAssign()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItemAssign(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(ItemAssign));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Unit()
        {
            return View();
        }
        public ActionResult AddUnit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUnit(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Unit));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditUnit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUnit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Unit));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
