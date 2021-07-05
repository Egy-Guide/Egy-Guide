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
            var blogs = _unitOfWork.Blog.GetAll().OrderByDescending(b => b.Date).Take(5);
            return View(blogs);
        }

        [Route("admin/blog/active")]
        [HttpPost]
        public IActionResult Active(int id)
        {
            var blog = _unitOfWork.Blog.Get(id);
            blog.Status = "active";
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        [Route("admin/blog/unactive")]
        [HttpPost]
        public IActionResult Unactive(int id)
        {
            var blog = _unitOfWork.Blog.Get(id);
            blog.Status = "unactive";
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
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

    }
}
