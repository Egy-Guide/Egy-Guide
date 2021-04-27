using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public BlogController(
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment,
            UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }
        [BindProperty]
        public BlogVM BlogVM { get; set; }
        [BindProperty]
        public BlogIndexVM BlogIndexVM { get; set; }

        [Route("blog")]
        public IActionResult Index(int page = 1)
        {


            BlogIndexVM = new BlogIndexVM()
            {
                Blogs = _unitOfWork.Blog.GetAll(includeProperties: "Category,ApplicationUser")
                                        .OrderByDescending(b => b.Date),
            };

            var count = BlogIndexVM.Blogs.Count();
            BlogIndexVM.Blogs = BlogIndexVM.Blogs.Skip((page - 1) * 2).Take(2);

            BlogIndexVM.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = 2,
                TotalItems = count,
                UrlParam = "/blog?page=:"
            };

            return View(BlogIndexVM);
        }

        [Route("blog/archive")]
        public IActionResult Archive(DateTime date, int page = 1)
        {            
            BlogIndexVM = new BlogIndexVM()
            {
                Blogs = _unitOfWork.Blog.GetAll(includeProperties: "Category,ApplicationUser")
                                        .Where(b => b.Date.Year == date.Year)
                                        .Where(b => b.Date.Month == date.Month)
                                        .OrderByDescending(b => b.Date),
            };

            var count = BlogIndexVM.Blogs.Count();
            BlogIndexVM.Blogs = BlogIndexVM.Blogs.Skip((page - 1) * 2).Take(2);

            BlogIndexVM.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = 2,
                TotalItems = count,
                UrlParam = "/blog/archive?date=" + date.ToString("MMMM yyyy") + "&page=:"
            };

            return View(BlogIndexVM);
        }
        [Route("blog/category")]
        public IActionResult Category(string category, int page = 1)
        {
            BlogIndexVM = new BlogIndexVM()
            {
                Blogs = _unitOfWork.Blog.GetAll(includeProperties: "Category,ApplicationUser")
                                        .Where(b => b.Category.Name == category)
                                        .OrderByDescending(b => b.Date),
            };

            var count = BlogIndexVM.Blogs.Count();
            BlogIndexVM.Blogs = BlogIndexVM.Blogs.Skip((page - 1) * 2).Take(2);

            BlogIndexVM.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = 2,
                TotalItems = count,
                UrlParam = "/blog/category?category=" + category + "&page=:"
            };

            return View(BlogIndexVM);
        }

        [Route("blog-single")]
        public IActionResult BlogSingle(int id)
        {
            if (id == 0)
                return RedirectToAction(nameof(Index));

            BlogIndexVM blogIndexVM = new BlogIndexVM()
            {
                Blog = _unitOfWork.Blog.GetFirstOrDefault(b => b.Id == id, includeProperties: "Category,ApplicationUser"),
                Blogs = _unitOfWork.Blog.GetAll(includeProperties: "Category"),
            };

            blogIndexVM.Blog.Views++;
            _unitOfWork.Save();

            return View(blogIndexVM);
        }

        [Authorize]
        [Route("blog-create")]
        public IActionResult BlogCreate(int? id)
        {
            BlogVM = new BlogVM()
            {
                Blog = new Blog(),
                CategoryList = _unitOfWork.Category.GetAll().Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                })
            };

            // This for Create
            if (id == null)
                return View(BlogVM);

            // This for Update
            BlogVM.Blog = _unitOfWork.Blog.Get(id.GetValueOrDefault());

            if (BlogVM.Blog == null)
                return NotFound();

            return View(BlogVM);
        }

        [Route("blog-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlogCreate()
        {            
            if (ModelState.IsValid)
            {
                // Get wwwroot path
                string rootPath = _hostEnvironment.WebRootPath;
                // Get the image which is uploaded by submit form
                var image = HttpContext.Request.Form.Files;

                #region Create
                
                // This for Create
                if (BlogVM.Blog.Id == 0)
                {
                    BlogVM.Blog.Date = DateTime.Now;
                    //BlogVM.Blog.Views = 0;

                    // Uploaded Successfully, if the user choose an image.
                    if (image.Count > 0)
                        UploadImage(rootPath, image);
                    else
                    {
                        // Set a default Image, if the user does not upload
                        BlogVM.Blog.ImageURL = @"\images\blog\blog_default.png";
                    }

                    BlogVM.Blog.UserId = _userManager.GetUserId(User);
                    _unitOfWork.Blog.Add(BlogVM.Blog);
                }
                #endregion

                #region Update

                // This for Update
                else
                {
                    // Get the current image to save it, if the user updated without change the image
                    var objFromDb = _unitOfWork.Blog.Get(BlogVM.Blog.Id);
                    BlogVM.Blog.ImageURL = objFromDb.ImageURL;

                    // Updated with change the image
                    if (image.Count > 0)
                    {
                        // MUST delete the old image from physical
                        if (BlogVM.Blog.ImageURL != null)
                        {
                            string imagePath = Path.Combine(rootPath, BlogVM.Blog.ImageURL.TrimStart('\\'));
                            if (System.IO.File.Exists(imagePath))
                                System.IO.File.Delete(imagePath);
                        }

                        UploadImage(rootPath, image);
                    }

                    _unitOfWork.Blog.Update(BlogVM.Blog);
                }                

                #endregion

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                BlogVM.CategoryList = _unitOfWork.Category.GetAll().Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.Id.ToString()
                });
            }

            return View(BlogVM);
        }

        #region APIs
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedBlog = _unitOfWork.Blog.Get(id);

            if (deletedBlog == null)
                return Json(new { success = false });

            _unitOfWork.Blog.Remove(deletedBlog);
            _unitOfWork.Save();

            return Json(new { success = true });
        }
        #endregion

        public void UploadImage(string rootPath, IFormFileCollection image)
        {
            // The folder path where the images will be uploded
            string folderPath = Path.Combine(rootPath, @"images\blog");
            // Generate a unique image name
            string imageName = Guid.NewGuid().ToString();
            // Get the extension of the image
            string extension = Path.GetExtension(image[0].FileName);
            // ImageURL
            string imageURL = Path.Combine(folderPath, imageName + extension);

            // Upload image to physical storage
            FileStream fileStream = new FileStream(imageURL, FileMode.Create);
            image[0].CopyToAsync(fileStream);

            // Upload image to Database
            BlogVM.Blog.ImageURL = @"\images\blog\" + imageName + extension;
        }        
    }
}
