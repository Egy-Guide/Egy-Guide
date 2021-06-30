using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    [Route("guide/profile")]
    [Authorize(Roles = SD.Role_User_Tour_Guide)]
    public class GuideProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public GuideProfileController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public GuideUserVM GuideUserVM { get; set; }

        public IActionResult Index()
        {

            GuideUserVM = new GuideUserVM()
            {
                GuideUser = _unitOfWork.GuideUser.GetFirstOrDefault(u => u.UserId == _userManager.GetUserId(User), includeProperties: "ApplicationUser"),
            };

            if (GuideUserVM.GuideUser == null)
                return NotFound();

            // Get Current Guide User
            GuideUserVM.GuideUserDetails = _unitOfWork.GuideUserDetails.GetFirstOrDefault(u => u.GuideId == GuideUserVM.GuideUser.Id);

            // New Guide User
            if (GuideUserVM.GuideUserDetails == null)
            {
                GuideUserVM.GuideUserDetails = new GuideUserDetails()
                {
                    GuideId = GuideUserVM.GuideUser.Id,
                    PrivateTransportation = "No",
                    PublicTransportation = "Yes",
                };

                _unitOfWork.GuideUserDetails.Add(GuideUserVM.GuideUserDetails);
                _unitOfWork.Save();
            }

            return View(GuideUserVM);
        }

        [Route("tours")]
        public IActionResult Tours()
        {
            return View();
        }
        
        [Route("gallery")]
        public IActionResult Gallery()
        {
            return View();
        }

    }
}
