
using DataAccessLibrary.Model;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Repository.ComplaintMasterRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace dentalproj.Controllers
{
    public class CaseComplaintMasterController : Controller
    {
        public class CaseComplaintController : Controller
        {
            private readonly CaseComplaintRepository _casecomplaintRepository;
            private readonly CaseMasterRepository _caseRepository;
            private readonly ComplaintMasterRepository _complaintRepository;

            public CaseComplaintController(CaseComplaintRepository casecomplaintRepository, CaseMasterRepository caseRepository, ComplaintMasterRepository complaintRepository)
            {
                _casecomplaintRepository = casecomplaintRepository;
                _caseRepository = caseRepository;
                _complaintRepository = complaintRepository;
            }
            [HttpGet]
            public async Task<IActionResult> CaseComplaintCreate(int id)
            {


                if (id != null)
                {
                    var comp = await _casecomplaintRepository.GetCaseComplaintById(id);
                    if (comp != null)
                    {
                        var casee = await _caseRepository.GetAllCase();
                        var compp = await _complaintRepository.GetAllComplaint();
                        ViewBag.casee = new SelectList(casee, "Id", "CNo", comp.CaseId);
                        ViewBag.compp = new SelectList(compp, "Id", "Name", comp.Cid);
                        return View(comp);
                    }
                }

                var defaultS = await _caseRepository.GetAllCase();
                var defaulti = await _complaintRepository.GetAllComplaint();
                ViewBag.casee = new SelectList(defaultS, "Id", "CNo");
                ViewBag.compp = new SelectList(defaulti, "Id", "Name");

                return View(new CaseComplaint());
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> CaseComplaintCreate(CaseComplaint complaint)
            {
                if (ModelState.IsValid)
                {

                    if (complaint.Id == 0)
                    {
                        await _casecomplaintRepository.CaseComplaintInsert(complaint);
                    }
                    else
                    {
                        await _casecomplaintRepository.CaseComplaintUpdate(complaint);
                    }
                    return RedirectToAction("GetAllCaseComplaint");
                }

                var casee = await _caseRepository.GetAllCase();
                var compp = await _complaintRepository.GetAllComplaint();
                ViewBag.casee = new SelectList(casee, "Id", "CNo", complaint.CaseId);
                ViewBag.compp = new SelectList(compp, "Id", "Name", complaint.Cid);

                return View(complaint);
            }
            [HttpGet]
            public async Task<IActionResult> GetAllCaseComplaint()
            {
                var casecomp = await _casecomplaintRepository.GetAllCaseComplaint();
                var casemas = await _caseRepository.GetAllCase();
                var Complain = await _complaintRepository.GetAllComplaint();


                ViewData["Case"] = casemas.ToDictionary(s => s.Id, s => s.CNo);
                ViewData["Complain"] = Complain.ToDictionary(s => s.Id, s => s.Name);

                return View(casecomp);
            }
        }
    }
}





