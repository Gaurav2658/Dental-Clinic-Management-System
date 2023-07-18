using DataAccessLibrary.Model.ComplaintMaster;
using DataAccessLibrary.Repository;
using DataAccessLibrary.Repository.ComplaintMasterRepository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class ComplaintMasterController : Controller
    {
        private readonly ComplaintMasterRepository _complaintRepository;

        public ComplaintMasterController(ComplaintMasterRepository complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }
    

        [HttpGet]
        public async Task<IActionResult> ComplaintCreate(int id)
        {
            if (id != null)
            {
                var complaint = await _complaintRepository.GetComplaintById(id);
                if (complaint != null)
                {
                    return View(complaint);
                }
            }

            return View(new ComplaintMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ComplaintCreate(ComplaintMaster complaint)
        {
            if (ModelState.IsValid)
            {
                if (complaint.Id == 0)
                {

                    await _complaintRepository.ComplaintInsert(complaint);
                }
                else
                {
                    await _complaintRepository.UpdateComplaint(complaint);
                }
                return RedirectToAction("GetAllComplaint", "ComplaintMaster");
            }
            return View(complaint);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComplaint()
        {
            var Complaint = await _complaintRepository.GetAllComplaint();
            return View(Complaint);
        }

     

        [HttpPost]
        public async Task<IActionResult> ComplaintDelete(int id, ComplaintMaster c)
        {

            var success = await _complaintRepository.ComplaintDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllComplaint));
            }
            else
            {
                return NotFound();
            }
        }

    }
}

