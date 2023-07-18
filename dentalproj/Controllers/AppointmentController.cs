using System;
using Microsoft.AspNetCore.Mvc;
using DataAccessLibrary;
using DataAccessLibrary.Model;

namespace AppointmentController.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentRepository appointmentRepository;

        public AppointmentController(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        // GET: Appointment/Index
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAppointments()
        {
            var appointments = appointmentRepository.GetAppointments();
            return Json(appointments);
        }

        [HttpPost]
        public IActionResult SaveAppointment([FromBody] AppointmentMaster appointment)
        {
            appointmentRepository.SaveAppointment(appointment);
            return Json(new { status = true });
        }

        [HttpPost]
        public IActionResult DeleteAppointment(int id)
        {
            appointmentRepository.DeleteAppointment(id);
            return Json(new { status = true });
        }
    }
}
