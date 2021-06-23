using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    public class GuideDashboardProfileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;

        public GuideDashboardProfileController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public GuideUserVM GuideUserVM { get; set; }
        private string CurrentUserId
        {
            get { return _userManager.GetUserId(User); }
        }
        private int CurrentGuideId
        {
            get { return _unitOfWork.GuideUser.GetFirstOrDefault(g => g.UserId == CurrentUserId).Id; }
        }

        [Route("guide/dashboard/edit-profile")]
        public IActionResult Index(int? id)
        {
            GuideUserVM = new GuideUserVM()
            {
                GuideUser = _unitOfWork.GuideUser.GetFirstOrDefault(u => u.UserId == CurrentUserId, includeProperties: "ApplicationUser")
            };

            if (GuideUserVM == null)
                return NotFound();

            return View(GuideUserVM);
        }

        [Route("guide/dashboard/edit-profile")]
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
                var image = GuideUserVM.GuideUser.ApplicationUser.Image;

                if (image != null)
                {
                    // MUST delete the old image from physical
                    if (userImageFromDb != null)
                    {
                        string imagePath = Path.Combine(rootPath, userImageFromDb.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                            System.IO.File.Delete(imagePath);
                    }

                    UploadImage(rootPath, image, "guide-profile-images");
                }

                else
                {
                    // Get the current image to save it, if the user updated without change the image

                    try
                    {
                        GuideUserVM.GuideUser.ApplicationUser.ImageUrl = userImageFromDb;
                    }
                    catch (Exception)
                    {
                        GuideUserVM.GuideUser.ApplicationUser.ImageUrl = @"\images\avatar.jpg";
                    }

                }

                _unitOfWork.GuideUser.Update(GuideUserVM.GuideUser);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index), "GuideProfile");
            }

            return View();
        }

        [Route("guide/dashboard/information")]
        public IActionResult Information()
        {
            GuideUserVM = new GuideUserVM()
            {
                GuideUserDetails = _unitOfWork.GuideUserDetails.GetFirstOrDefault(g => g.GuideId == CurrentGuideId)
            };

            if (GuideUserVM == null)
                return NotFound();

            return View(GuideUserVM);
        }

        [Route("guide/dashboard/information")]
        [HttpPost]
        [ActionName("Information")]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostInformation()
        {

            if (ModelState.IsValid)
            {
                // Get wwwroot path
                string rootPath = _hostEnvironment.WebRootPath;
                // Get the image which is uploaded by submit form
                var image = GuideUserVM.GuideUserDetails.CertificateImage;

                #region Create

                if (GuideUserVM.GuideUserDetails.Id == 0)
                {
                    if (image != null)
                        UploadImage(rootPath, image, "guide-certificates");

                    GuideUserVM.GuideUserDetails.GuideId = _unitOfWork.GuideUser.GetFirstOrDefault(g => g.UserId == CurrentUserId).Id;
                    _unitOfWork.GuideUserDetails.Add(GuideUserVM.GuideUserDetails);
                }

                #endregion

                #region Update

                else
                {
                    // Get the current certificate to save it, if the user updated without change the image
                    string userImageFromDb = _unitOfWork.GuideUserDetails.GetFirstOrDefault(g => g.GuideId == CurrentGuideId).CertificateUrl;

                    GuideUserVM.GuideUserDetails.CertificateUrl = userImageFromDb;

                    // Updated with change the image
                    if (image != null)
                    {
                        // MUST delete the old image from physical
                        if (GuideUserVM.GuideUserDetails.CertificateUrl != null)
                        {
                            string imagePath = Path.Combine(rootPath, GuideUserVM.GuideUserDetails.CertificateUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(imagePath))
                                System.IO.File.Delete(imagePath);

                        }

                        UploadImage(rootPath, image, "guide-certificates");
                    }

                    _unitOfWork.GuideUserDetails.Update(GuideUserVM.GuideUserDetails);
                }

                #endregion

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index), "GuideProfile");
            }

            return View();
        }

        public void UploadImage(string rootPath, IFormFile image, string folderName)
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
            GuideUserVM.GuideUserDetails.CertificateUrl = @"/images/" + folderName + @"/" + imageName + extension;
        }
    }
}
