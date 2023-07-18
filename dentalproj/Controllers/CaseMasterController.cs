
using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace dentalproj.Controllers
{
    public class CaseMasterController : Controller
    {
        private readonly CaseMasterRepository _caseRepository;
        private readonly PatientMasterRepository _patientRepository;
        private readonly UserMasterRepository _userRepository;

        public CaseMasterController(CaseMasterRepository caseRepository, PatientMasterRepository patientRepository, UserMasterRepository userRepository)
        {
            _caseRepository = caseRepository;
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CaseCreate(int id)
        {
            if (id != null)
            {
                var Case = await _caseRepository.GetCaseById(id);
                if (Case != null)
                {
                    var patient = await _patientRepository.GetAllPatient();
                    var user = await _userRepository.GetAllUser();
                    ViewBag.Pat = new SelectList(patient, "Id", "PatientName", Case.PId);
                    ViewBag.Phone = new SelectList(patient, "Id", "PhoneNo", Case.PhonNo);

                    ViewBag.User = new SelectList(user, "Id", "Name", Case.DId);

                    return View(Case);
                }
            }

            var defaultPat = await _patientRepository.GetAllPatient();

            ViewBag.Pat = new SelectList(defaultPat, "Id", "PatientName");
            ViewBag.Phone = new SelectList(defaultPat, "Id", "PhoneNo");
            // Retrieve all users from the UserMaster table
            var allUsers = await _userRepository.GetAllUser();
            // Filter the users to get only doctors (Type = 1)
            var doctors = allUsers.Where(u => u.Type == 1);
            ViewBag.User = new SelectList(doctors, "Id", "Name");
            return View(new CaseMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CaseCreate(CaseMaster Case)
        {
            if (true)
            {
                if (Case.Id == 0)
                {
                    await _caseRepository.CaseInsert(Case);
                }
                else
                {
                    await _caseRepository.UpdateCase(Case);
                }
                return RedirectToAction("GetAllCase");
            }

            var patient = await _patientRepository.GetAllPatient();
            ViewBag.Pat = new SelectList(patient, "Id", "PatientName", Case.PId);
            ViewBag.Phone = new SelectList(patient, "Id", "PhoneNo");

            var allUsers = await _userRepository.GetAllUser();


            var doctors = allUsers.Where(u => u.Type == 1);
            ViewBag.User = new SelectList(doctors, "Id", "Name", Case.DId);
            return View(Case);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCase()
        {
            var Case = await _caseRepository.GetAllCase();
            var Patient = await _patientRepository.GetAllPatient();
            var User = await _userRepository.GetAllUser();
            ViewData["Patient"] = Patient.ToDictionary(s => s.Id, s => s.PatientName);
            ViewData["PhoneNo"] = Patient.ToDictionary(s => s.Id, s => s.PhoneNo);
            ViewData["User"] = User.ToDictionary(s => s.Id, s => s.Name);
            return View(Case);
        }

        [HttpPost]
        public async Task<IActionResult> CaseDelete(int id, CaseMaster a)
        {
            var success = await _caseRepository.CaseDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllCase));
            }
            else
            {
                return NotFound();
            }
        }

    }
}

