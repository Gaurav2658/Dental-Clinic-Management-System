using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Receipt()
        {
            return View();
        }

        public ActionResult AllPayment()
        {
            return View();
        }
       
        public ActionResult AddPayment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(AllPayment));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPayment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPayment(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(AllPayment));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Purchase()
        {
            return View();
        }
        public ActionResult AddPurchase()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPurchase(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Purchase));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPurchase()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPurchase(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Purchase));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Supplier()
        {
            return View();
        }

        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSupplier(FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Supplier));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditSupplier()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Supplier));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
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

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
