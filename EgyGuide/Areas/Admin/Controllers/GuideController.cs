using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public GuideController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [Route("/admin/guide")]
        [Authorize(Roles = SD.Role_User_Admin)]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/guide-details")]
        public IActionResult GuideDetails(int id)
        {
            if (id == 0)
                return NotFound();

            var guide = _unitOfWork.GuideUser.GetFirstOrDefault(g => g.Id == id, includeProperties: "ApplicationUser");

            return View(guide);
        }

        #region API's Calls

        [HttpGet]
        public IActionResult GetGuides()
        {
            var guides = _unitOfWork.GuideUser.GetAll(includeProperties: "ApplicationUser").Select(g => new
            {
                id = g.Id,
                guideName = g.ApplicationUser.FirstName + " " + g.ApplicationUser.LastName,
                status = g.Status,
                registrationDate = g.RegistrationDate.ToString("dd/MMMM/yyy hh:mm")
            });

            return Json(new { data = guides });
        }

        [HttpPost]
        public async Task<IActionResult> Approved(int id)
        {
            if (id == 0)
                return NotFound();

            var guide = _unitOfWork.GuideUser.GetFirstOrDefault(g => g.Id == id);
            var user = await _userManager.FindByIdAsync(guide.UserId);

            // Change the guide role
            await _userManager.RemoveFromRoleAsync(user, SD.Role_User_Suspended_Guide);
            await _userManager.AddToRoleAsync(user, SD.Role_User_Tour_Guide);

            guide.Status = SD.GuideStatusApproved;
            _unitOfWork.Save();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Locked(int id)
        {
            if (id == 0)
                return NotFound();

            var guide = _unitOfWork.GuideUser.GetFirstOrDefault(g => g.Id == id);
            var user = await _userManager.FindByIdAsync(guide.UserId);

            var futureDateLocked = DateTime.Now.AddYears(1000);
            await _userManager.SetLockoutEndDateAsync(user, futureDateLocked);

            guide.Status = SD.GuideStatusLocked;
            _unitOfWork.Save();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> UnLocked(int id)
        {
            if (id == 0)
                return NotFound();

            var guide = _unitOfWork.GuideUser.GetFirstOrDefault(g => g.Id == id);
            var user = await _userManager.FindByIdAsync(guide.UserId);

            await _userManager.SetLockoutEndDateAsync(user, DateTime.Now - TimeSpan.FromMinutes(1));

            guide.Status = SD.GuideStatusApproved;
            _unitOfWork.Save();

            return Json(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var deletedGuide = _unitOfWork.GuideUser.Get(id);
            var user = await _userManager.FindByIdAsync(deletedGuide.UserId);

            if (deletedGuide == null)
                return Json(new { success = false });

            _unitOfWork.GuideUser.Remove(deletedGuide);
            await _userManager.DeleteAsync(user);

            _unitOfWork.Save();

            return Json(new { success = true });
        }
        #endregion
    }
}
