using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Route("tourist/profile")]
    [Authorize(Roles = SD.Role_User_Tourist)]
    public class TouristProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public TouristProfileController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [BindProperty]
        public ApplicationUser TouristUser { get; set; }

        public IActionResult Index()
        {
            TouristUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == _userManager.GetUserId(User));

            if (TouristUser == null)
                return NotFound();

            return View(TouristUser);
        }

        //[Route("tours")]
        //public IActionResult Tours()
        //{
        //    return View();
        //}

    }
}
