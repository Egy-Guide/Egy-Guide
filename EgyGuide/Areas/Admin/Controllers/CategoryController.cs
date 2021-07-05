using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Category Category { get; set; }

        [Route("category")]
        [Authorize(Roles = SD.Role_User_Admin)]
        public IActionResult Index()
        {
            IEnumerable<Category> Category = _unitOfWork.Category.GetAll();
            return View(Category);
        }

        [Route("category-create")]
        public IActionResult CategoryCreate(int? id)
        {
            Category = new Category();

            if (id == null)
            {
                // This for Create
                return View(Category);
            }

            // This for Update
            Category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (Category == null)
                return NotFound();

            return View(Category);
        }

        [Route("category-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CategoryCreate()
        {
            if (ModelState.IsValid)
            {
                if (Category.Id == 0)
                    _unitOfWork.Category.Add(Category);
                
                // Update
                _unitOfWork.Category.Update(Category);

                _unitOfWork.Save();                
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if (objFromDb == null)
                return Json(new { success = false });

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true });
        }
    }
}
