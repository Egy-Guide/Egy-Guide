using EgyGuide.Utility;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models.ViewModels;
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
    
    [Authorize(Roles = SD.Role_User_Tour_Guide)]
    public class GuideDashboardToursController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public GuideDashboardToursController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        [Route("guide/dashboard/my-tours")]
        public IActionResult Index()
        {
            var guideUserId = _unitOfWork.GuideUser.GetFirstOrDefault(u => u.UserId == _userManager.GetUserId(User)).Id;
            var trips = _unitOfWork.OfferCreate.GetAll(g => g.GuideId == guideUserId);

            GuideUserVM GuideUserVM = new GuideUserVM()
            {
                GuideUser = _unitOfWork.GuideUser.GetFirstOrDefault(u => u.UserId == _userManager.GetUserId(User), includeProperties: "ApplicationUser"),
                Trips = trips
            };


            return View(GuideUserVM);
        }

        
    }
}
