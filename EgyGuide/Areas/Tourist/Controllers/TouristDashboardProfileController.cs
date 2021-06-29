using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    [Authorize(Roles = SD.Role_User_Tourist)]
    public class TouristDashboardProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public TouristDashboardProfileController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public ApplicationUser TouristUser { get; set; }
        private string CurrentUserId
        {
            get { return _userManager.GetUserId(User); }
        }
 
        [Route("tourist/dashboard/edit-profile")]
        public IActionResult Index(int? id)
        {

            TouristUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == CurrentUserId);

            if (TouristUser == null)
                return NotFound();

            return View(TouristUser);
        }

        [Route("tourist/dashboard/edit-profile")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {

            if (ModelState.IsValid)
            {
                // Get user's image from db
                string userImageFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(u => u.Id == CurrentUserId).ImageUrl;

                // Get wwwroot path
                string rootPath = _hostEnvironment.WebRootPath;
                // Get the image which is uploaded by submit form
                var image = TouristUser.Image;

                if (image != null)
                {
                    // MUST delete the old image from physical
                    if (userImageFromDb != null)
                    {
                        string imagePath = Path.Combine(rootPath, userImageFromDb.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                            System.IO.File.Delete(imagePath);
                    }

                    TouristUser.ImageUrl = UploadImage(rootPath, image, "tourist-profile-images");
                }

                else
                {
                    // Get the current image to save it, if the user updated without change the image

                    try
                    {
                        TouristUser.ImageUrl = userImageFromDb;
                    }
                    catch (Exception)
                    {
                        TouristUser.ImageUrl = @"\images\avatar.jpg";
                    }

                }

                _unitOfWork.ApplicationUser.Update(TouristUser);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index), "TouristProfile");
            }

            return View();
        }

        public string UploadImage(string rootPath, IFormFile image, string folderName)
        {
            // The folder path where the images will be uploded
            string folderPath = Path.Combine(rootPath, @"images\" + folderName);
            // Generate a unique image name
            string imageName = Guid.NewGuid().ToString();
            // Get the extension of the image
            string extension = Path.GetExtension(image.FileName);
            // ImageURL
            string imageURL = Path.Combine(folderPath, imageName + extension);

            // Upload image to physical storage
            using (var fileStream = new FileStream(imageURL, FileMode.Create))
            {
                image.CopyTo(fileStream);
                fileStream.Dispose();
            }

            // Upload image to Database
            string imgSrc = @"/images/" + folderName + @"/" + imageName + extension;
            return imgSrc;
        }
    }
}
