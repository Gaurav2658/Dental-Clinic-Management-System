using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dentalproj.Controllers
{
    public class AppointmentMasterController : Controller
    {
        private readonly AppointmentMasterRepository _appointmentRepository;
        private readonly PatientMasterRepository _PatientRepository;
        private readonly UserMasterRepository _userRepository;


        public AppointmentMasterController(AppointmentMasterRepository appointmentRepository, PatientMasterRepository patientRepository, UserMasterRepository userrepository)
        {
            _appointmentRepository = appointmentRepository;
            _PatientRepository = patientRepository;
            _userRepository = userrepository;
        }

        [HttpGet]
        public async Task<IActionResult> AppointmentCreate(int id)
        {
            if (id != null)
            {
                var appointment = await _appointmentRepository.GetAppointmentById(id);
                if (appointment != null)
                {
                    var patient = await _PatientRepository.GetAllPatient();
                    var user = await _userRepository.GetAllUser();

                    ViewBag.Pat = new SelectList(patient, "Id", "PatientName", appointment.PId);
                    ViewBag.Dr = new SelectList(user, "Id", "Name", appointment.DId);
                    return View(appointment);
                }
            }

            var defaultCat = await _PatientRepository.GetAllPatient();
            var defaultitem = await _userRepository.GetAllUser();

            ViewBag.Pat = new SelectList(defaultCat, "Id", "PatientName");
            ViewBag.Dr = new SelectList(defaultitem, "Id", "Name");


            return View(new AppointmentMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AppointmentCreate(AppointmentMaster appointment)
        {
            if (ModelState.IsValid)
            {


                if (appointment.Id == 0)
                {
                    await _appointmentRepository.AppointmentInsert(appointment);
                }
                else
                {
                    await _appointmentRepository.AppointmentUpdate(appointment);
                }
                return RedirectToAction("GetAllAppointment");
            }

            var appoint = await _PatientRepository.GetAllPatient();
            ViewBag.Pat = new SelectList(appoint, "Id", "PatientName", appointment.PId);
            var user = await _userRepository.GetAllUser();
            ViewBag.Dr = new SelectList(user, "Id", "Name", appointment.DId);

            return View(appointment);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            var appoitment = await _appointmentRepository.GetAllAppointment();
            var patient = await _PatientRepository.GetAllPatient();
            var user = await _userRepository.GetAllUser();

            ViewData["Patient"] = patient.ToDictionary(s => s.Id, s => s.PatientName);
            ViewData["User"] = user.ToDictionary(s => s.Id, s => s.Name);
            return View(appoitment);
        }


        [HttpPost]
        public async Task<IActionResult> AppointmentDelete(int id, AppointmentMaster a)
        {
            var success = await _appointmentRepository.AppointmentDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllAppointment));
            }
            else
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> AppointCal()
        {
            return View();
        }
    }
}
