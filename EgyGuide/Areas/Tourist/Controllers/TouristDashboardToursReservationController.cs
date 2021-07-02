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
using Microsoft.AspNetCore.Http;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Authorize(Roles = SD.Role_User_Tourist)]


    public class TouristDashboardToursReservationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public TouristDashboardToursReservationController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }
        [Route("tourist/dashboard/my-reservation")]

        public IActionResult Index()
        {
           
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult Reservations()
        {
            var userId = _userManager.GetUserId(User);


            var trips = _unitOfWork.TripBooking.GetAll(includeProperties: "TripDetail").Where(g => g.TouristId == userId);
            return Json(new { data = trips });
        }
        #endregion
    }
}
