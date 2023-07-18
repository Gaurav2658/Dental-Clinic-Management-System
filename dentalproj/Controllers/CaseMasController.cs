using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Repository.ComplaintMasterRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dentalproj.Controllers
{
	public class CaseMasController : Controller
	{
		private readonly CaseMasRepository _caseRepository;
		private readonly PatientMasterRepository _patientRepository;
		private readonly UserMasterRepository _userRepository;
		private readonly ComplaintMasterRepository _complaintRepository;
		private readonly ObservationMasterRepository _obserRepository;
		private readonly AdviceMasterRepository _adviceRepository;
		private readonly ServiceMasterRepository _serviceRepository;
		private readonly MedicineMasterRepository _medicineRepository;

		public CaseMasController(CaseMasRepository caseRepository, PatientMasterRepository patientRepository, UserMasterRepository userRepository,ComplaintMasterRepository complaintRepository,ObservationMasterRepository obserRepository,AdviceMasterRepository AdviceRepository,ServiceMasterRepository ServiceRepository,MedicineMasterRepository medicineRepository)
		{
			_caseRepository = caseRepository;
			_patientRepository = patientRepository;
			_userRepository = userRepository;
			_complaintRepository = complaintRepository;
			_obserRepository = obserRepository;
			_adviceRepository = AdviceRepository;
			_serviceRepository = ServiceRepository;
			_medicineRepository = medicineRepository;
		}

		[HttpGet]
		public async Task<IActionResult> CaseCreate(int id)
		{
			if (id != null)
			{
				var Case = await _caseRepository.GetCaseMasById(id);
				if (Case != null)
				{
					var patient = await _patientRepository.GetAllPatient();
					var user = await _userRepository.GetAllUser();
					var complaint = await _complaintRepository.GetAllComplaint();
					var observation = await _obserRepository.GetAllObservation();
					var advice = await _adviceRepository.GetAllAdvice();
					var service = await _serviceRepository.GetAllService();
					var medicine = await _medicineRepository.GetAllMedicine();
				

					ViewBag.Pat = new SelectList(patient, "Id", "PatientName", Case.PId);
					ViewBag.Phone = new SelectList(patient, "Id", "PhoneNo", Case.PhonNo);
					ViewBag.User = new SelectList(user, "Id", "Name", Case.DId);
					ViewBag.comp = new SelectList(complaint, "Id", "Name", Case.CmpId);
					ViewBag.obser = new SelectList(observation, "Id", "Name", Case.ObserId);
					ViewBag.advice = new SelectList(advice, "Id", "Name", Case.AdviceId);
					ViewBag.service = new SelectList(service, "Id", "Name", Case.ServiceId);
					ViewBag.medicine = new SelectList(medicine, "Id", "Name", Case.MedicineId);
					return View(Case);
				}
			}

			var defaultPat = await _patientRepository.GetAllPatient();
			var defaultComplaint = await _complaintRepository.GetAllComplaint();
			var defaultObservation = await _obserRepository.GetAllObservation();
			var defaultadvice = await _adviceRepository.GetAllAdvice();
			var defaultservice = await _serviceRepository.GetAllService();
			var defaultmedicine = await _medicineRepository.GetAllMedicine();
			ViewBag.Pat = new SelectList(defaultPat, "Id", "PatientName");
			ViewBag.Phone = new SelectList(defaultPat, "Id", "PhoneNo");
			ViewBag.comp = new SelectList(defaultComplaint, "Id", "Name");
			ViewBag.obser = new SelectList(defaultObservation, "Id", "Name");
			ViewBag.advice = new SelectList(defaultadvice, "Id", "Name");
			ViewBag.service = new SelectList(defaultservice, "Id", "Name");
			ViewBag.medicine = new SelectList(defaultmedicine, "Id", "Name");
			// Retrieve all users from the UserMaster table
			var allUsers = await _userRepository.GetAllUser();
			// Filter the users to get only doctors (Type = 1)
			var doctors = allUsers.Where(u => u.Type == 1);
			ViewBag.User = new SelectList(doctors, "Id", "Name");
			return View(new CaseMas());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CaseCreate(CaseMas Case)
		{
			if (true)
			{
				if (Case.Id == 0)
				{
					await _caseRepository.CaseMasInsert(Case);
				}
				else
				{
					await _caseRepository.UpdateCaseMas(Case);
				}
				return RedirectToAction("GetAllCaseMas");
			}

			var patient = await _patientRepository.GetAllPatient();
			var complaint = await _complaintRepository.GetAllComplaint();
			var Observation = await _obserRepository.GetAllObservation();
			var advice = await _adviceRepository.GetAllAdvice();
			var service = await _serviceRepository.GetAllService();
			var medicine = await _medicineRepository.GetAllMedicine();
			ViewBag.Pat = new SelectList(patient, "Id", "PatientName", Case.PId);
			ViewBag.Phone = new SelectList(patient, "Id", "PhoneNo",Case.PhonNo);
			ViewBag.comp = new SelectList(complaint, "Id", "Name", Case.CmpId);
			ViewBag.obser = new SelectList(Observation, "Id", "Name", Case.ObserId);
			ViewBag.advice = new SelectList(advice, "Id", "Name", Case.AdviceId);
			ViewBag.service = new SelectList(service, "Id", "Name", Case.ServiceId);
			ViewBag.medicine = new SelectList(medicine, "Id", "Name", Case.MedicineId);
		

			var allUsers = await _userRepository.GetAllUser();
			var doctors = allUsers.Where(u => u.Type == 1);
			ViewBag.User = new SelectList(doctors, "Id", "Name", Case.DId);
			return View(Case);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCaseMas()
		{
			var Case = await _caseRepository.GetAllCaseMas();
			var Patient = await _patientRepository.GetAllPatient();
			var User = await _userRepository.GetAllUser();
			var complaint = await _complaintRepository.GetAllComplaint();
			var Observation = await _obserRepository.GetAllObservation();
			var advice = await _adviceRepository.GetAllAdvice();
			var service = await _serviceRepository.GetAllService();
			var medicine = await _medicineRepository.GetAllMedicine();
			ViewData["Patient"] = Patient.ToDictionary(s => s.Id, s => s.PatientName);
			ViewData["PhoneNo"] = Patient.ToDictionary(s => s.Id, s => s.PhoneNo);
			ViewData["User"] = User.ToDictionary(s => s.Id, s => s.Name);
			ViewData["Complaint"] = User.ToDictionary(s => s.Id, s => s.Name);
			ViewData["Observation"] = User.ToDictionary(s => s.Id, s => s.Name);
			ViewData["Advice"] = User.ToDictionary(s => s.Id, s => s.Name);
			ViewData["Service"] = User.ToDictionary(s => s.Id, s => s.Name);
			ViewData["Medicine"] = User.ToDictionary(s => s.Id, s => s.Name);
			return View(Case);
		}

		[HttpPost]
		public async Task<IActionResult> CaseMasDelete(int id, CaseMas a)
		{
			var success = await _caseRepository.CaseMasDelete(id);
			if (success)
			{
				return RedirectToAction(nameof(GetAllCaseMas));
			}
			else
			{
				return NotFound();
			}
		}
        [HttpGet]
        public async Task<IActionResult> CaseView(int? id)
        {
            if (id != null)
            {
                var Case = await _caseRepository.GetCaseMasById(id.Value);
                if (Case != null)
                {
                    return View(Case);
                }
            }

            return View(new CaseMas());
        }

    }
}
