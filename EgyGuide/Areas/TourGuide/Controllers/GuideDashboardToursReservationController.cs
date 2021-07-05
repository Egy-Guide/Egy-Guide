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
        public IActionResult Index(int id)
        {
            if (id == 0)
                return NotFound();

            var key = "my-key";

            HttpContext.Session.SetInt32(key, id);
            return View();
        }

        #region API CALLS
        
        [HttpGet]
        public IActionResult TourSells()
        {
            var key = "my-key";
            var tripId = HttpContext.Session.GetInt32(key);
            var trips = _unitOfWork.TripBooking.GetAll(g =>
            (g.TripId == tripId) && (g.BookingStatus == SD.BookingStatusConfirmation || g.BookingStatus == SD.BookingStatusCompleted),
            includeProperties: "TripDetail,ApplicationUser").Select(g => new
            {
                bookingId = g.BookingId,
                tripTitle = g.TripDetail.Title,
                userFirstName = g.ApplicationUser.FirstName,
                email = g.Email,
                phoneNumber = g.PhoneNumber,
                bookingDate = g.BookingDate.ToString("dd/MMMM/yyyy"),
                bookingStatus = g.BookingStatus
            });

            return Json(new { data = trips });
        }

        [HttpPost]
        public IActionResult TripCompleted(int bookingId)
        {
            if (bookingId == 0)
                return NotFound();

            var booking = _unitOfWork.TripBooking.GetFirstOrDefault(tB => tB.BookingId == bookingId);
            booking.BookingStatus = SD.BookingStatusCompleted;
            _unitOfWork.Save();

            return Json(new { success = true });
        }
        #endregion
    }
}
