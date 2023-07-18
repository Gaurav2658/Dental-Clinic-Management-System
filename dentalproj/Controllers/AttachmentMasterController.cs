using DataAccessLibrary.Model.AttachmentMaster;
using DataAccessLibrary.Model.ShadeMaster;
using DataAccessLibrary.Repository;
using Microsoft.AspNetCore.Mvc;

namespace dentalproj.Controllers
{
    public class AttachmentMasterController : Controller
    {
        private readonly AttachmentMasterRepository _attachRepository;

        public AttachmentMasterController(AttachmentMasterRepository attachRepository)
        {
            _attachRepository = attachRepository;
        }
        [HttpGet]
        public async Task<IActionResult> AttachmentCreate(int id)
        {
            if (id != null)
            {
                var attach = await _attachRepository.GetAttachmentById(id);
                if (attach != null)
                {
                    return View(attach);
                }
            }

            return View(new AttachmentMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AttachmentCreate(AttachmentMaster attach)
        {
            if (ModelState.IsValid)
            {
                if (attach.Id == 0)
                {

                    await _attachRepository.AttachmentInsert(attach);
                }
                else
                {
                    await _attachRepository.UpdateAttachment(attach);
                }

                return RedirectToAction("GetAllAttachment", "AttachmentMaster");
            }

            return View(attach);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAttachment()
        {
            var attach = await _attachRepository.GetAllAttachment();
            return View(attach);
        }

     
      
        [HttpPost]
        public async Task<IActionResult> AttachmentDelete(int id, AttachmentMaster u)
        {

            var success = await _attachRepository.AttachmentDelete(id);
            if (success)
            {
                return RedirectToAction(nameof(GetAllAttachment));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
