using EgyGuide.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("booking")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            
            return View();
        }
        
        [Route("booking-confirmation")]
        public IActionResult BookingConfirmation()
        {
            return View();
        }

        #region Api
        [HttpPost]
        public IActionResult GetNoTravellers(string noTravellers)
        {
            TempData["NoTravellers"] = noTravellers;
            return Json(new { success = true });
        }
        #endregion
    }
}
