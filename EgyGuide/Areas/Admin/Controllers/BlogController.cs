using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("admin/blog")]
        [Authorize(Roles = SD.Role_User_Admin)]
        public IActionResult Index()
        {
            return View();
        }

        #region API's Calls
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = _unitOfWork.Blog.GetAll(includeProperties: "ApplicationUser").Select(b => new
            {
                id = b.Id,
                title = SD.SubstringByWords(b.Title, 10),
                date = b.Date.ToString("MMMM d, yyyy"),
                createdBy = b.ApplicationUser.FirstName + " " + b.ApplicationUser.LastName,
                views = b.Views,
                status = b.Status
            });

            return Json(new { data = blogs });
        }

        [HttpPost]
        public IActionResult Active(int id)
        {
            var blog = _unitOfWork.Blog.Get(id);

            if (blog == null)
                return Json(new { success = false });

            blog.Status = "active";
            _unitOfWork.Save();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult Unactive(int id)
        {
            var blog = _unitOfWork.Blog.Get(id);

            if (blog == null)
                return Json(new { success = false });

            blog.Status = "unactive";
            _unitOfWork.Save();

            return Json(new { success = true });
        }

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

    }
}
