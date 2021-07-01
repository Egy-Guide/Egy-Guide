using EgyGuide.DataAccess.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public BookingController(IUnitOfWork unitOfWork, ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _db = db;
            _userManager = userManager;
        }

        [BindProperty]
        public BookingVM BookingVM { get; set; }

        [Authorize]
        [Route("booking")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            BookingVM = new BookingVM()
            {
                TripDetail = _db.TripDetails.FirstOrDefault(t => t.TripId == id)
            };
            
            return View(BookingVM);
        }

        [Route("booking")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                //After fills the travellers's information, Make booking

                string userId = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User)).Id;

                //Generate Unique Booking Number
                string bookingNo = SD.GenBookingNo(_db.TripBookings.Select(tB => tB.BookingNo).ToList());

                // Booking Processing
                BookingVM.TripBooking.TouristId = userId;
                BookingVM.TripBooking.BookingNo = bookingNo;
                BookingVM.TripBooking.BookingDate = DateTime.Now;
                BookingVM.TripBooking.BookingStatus = SD.BookingStatusConfirmation;
                BookingVM.TripBooking.PaymentStatus = SD.PaymentStatusPending;
                BookingVM.TripBooking.PaymentDate = DateTime.Now;

                // Save Booking in DB First
                _unitOfWork.TripBooking.Add(BookingVM.TripBooking);
                _unitOfWork.Save();

                // Save Traveller's information
                foreach (var travellerDetails in BookingVM.TravellersDetails)
                    travellerDetails.BookingId = BookingVM.TripBooking.BookingId;

                _db.TravellersDetails.AddRange(BookingVM.TravellersDetails);
                _unitOfWork.Save();

                return RedirectToAction("BookingConfirmation", new { bookingId = BookingVM.TripBooking.BookingId });
            }

            return View(BookingVM);
        }

        [Authorize]
        [Route("booking-confirmation")]
        public IActionResult BookingConfirmation(int bookingId)
        {
            bool isBookingIdExist = _db.TripBookings.Select(tB => tB.BookingId).Contains(bookingId);

            if (bookingId == 0 || !isBookingIdExist)
                return NotFound();

            var tripBooking = _unitOfWork.TripBooking.GetFirstOrDefault(tB => tB.BookingId == bookingId, includeProperties: "TripDetail,ApplicationUser");

            // Only accees to own bookings
            if (tripBooking.TouristId != _userManager.GetUserId(User))
                return Unauthorized();

            return View(tripBooking);
        }

        #region Api
        [HttpPost]
        public IActionResult GetNoTravellers(DateTime tripDateFrom, DateTime tripDateTo, string noTravellers)
        {
            TempData["NoTravellers"] = noTravellers;
            TempData["tripDateFrom"] = tripDateFrom;
            TempData["tripDateTo"] = tripDateTo;
            return Json(new { success = true });
        }
        #endregion
    }
}
