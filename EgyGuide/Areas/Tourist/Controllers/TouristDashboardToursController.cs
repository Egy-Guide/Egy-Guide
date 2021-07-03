using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Utility;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("tourist/dashboard/my-tours")]
    [Authorize(Roles = SD.Role_User_Tourist)]


    public class TouristDashboardToursController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public TouristDashboardToursController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var touristId = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User)).Id;
            var trips = _unitOfWork.Requested.GetAll().Where(g => g.UserId == touristId);


            TouristVM touristVM = new TouristVM()
            {

                //User = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User), includeProperties: "IdentityUser"),
                Trips = trips
            };
            return View(touristVM);
        }
    }
}
