using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class ClinicController : Controller
    {
        // GET: ClinicController
        public ActionResult Patient()
        {
            return View();
        }
        public ActionResult AddPatient()
        {
            return View();
        }
        public ActionResult EditPatient()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult EditAppointment()
        {
            return View();
        }
        public ActionResult AddAppointment()
        {
            return View();
        }
        public ActionResult Case()
        {
            return View();
        }
        public ActionResult AddCase()
        {
            return View();
        }
        public ActionResult EditCase()
        {
            return View();
        }
        public ActionResult CasePayment()
        {
            return View();
        }


        // GET: ClinicController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClinicController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClinicController/Create
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

        // GET: ClinicController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClinicController/Edit/5
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

        // GET: ClinicController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClinicController/Delete/5
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
