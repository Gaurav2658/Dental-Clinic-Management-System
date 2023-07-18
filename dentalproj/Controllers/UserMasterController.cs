using DataAccessLibrary.Model.UserMaster;
using DataAccessLibrary.Repository;
using dentalproj.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.CodeAnalysis.Scripting;
using System.Security.Cryptography;

namespace dentalproj.Controllers
{
    public class UserMasterController : Controller
    {
        private readonly UserMasterRepository _userRepository;

        public UserMasterController(UserMasterRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> CreateAsync(int id)
        {
            if (id != null)
            {
                var user = await _userRepository.GetUserById(id);
                if (user != null)
                {
                    return View(user);
                }
            }

            return View(new UserMaster());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(UserMaster user)
        {
            if (ModelState.IsValid)
            {
                if (user.Id == 0)
                {
                       
                    await _userRepository.InsertUser(user);
                }
                else
                {
                    await _userRepository.UpdateUser(user);
                }

                return RedirectToAction("GetAllUsers", "UserMaster"); 
            }

            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUser();
            return View(users);
        }

      
        [HttpPost]
        public async Task<IActionResult>DeleteUser(int id,UserMaster u)
        {
            
            var success =await _userRepository.DeleteUser(id);
            if(success)
            {
                return RedirectToAction(nameof(GetAllUsers));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
