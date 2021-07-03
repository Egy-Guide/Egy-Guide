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
using Microsoft.AspNetCore.Http;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    
    [Authorize(Roles = SD.Role_User_Tour_Guide)]
    public class GuideDashboardToursReservationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public GuideDashboardToursReservationController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        [Route("guide/dashboard/my-tours/sells")]
        public IActionResult Index(string id)
        {
            var key = "my-key";

            HttpContext.Session.SetString(key, id);
            return View();
        }

        #region API CALLS
        
        [HttpGet]
        public IActionResult TourSells()
        {
            var key = "my-key";
            var id = HttpContext.Session.GetString(key);
            int idParsed = Int32.Parse(id);
            var trips = _unitOfWork.TripBooking.GetAll(g => 
            (g.TripId == idParsed) && (g.BookingStatus == SD.BookingStatusConfirmation || g.BookingStatus == SD.BookingStatusCompleted),
            includeProperties: "TripDetail,ApplicationUser");
            return Json(new { data = trips });
        }
        #endregion
    }
}
