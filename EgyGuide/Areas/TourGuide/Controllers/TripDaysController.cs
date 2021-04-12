using EgyGuide.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    public class TripDaysController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public TripDaysDetail tripDays { get; set; }

        public TripDaysController(IUnitOfWork unit, IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            _unit = unit;
            _hostEnvironment = hostEnvironment;
            _db = db;

        }

        [HttpPost]
        public void SaveList(TripDaysDetail[] ItemList)
        {
            //here there is an exception, must edit it.
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();

            var count = lastRecord.Days;

            

            for (int i = 0; i < count; i++)
            {
                tripDays = ItemList[i];
                tripDays.DayNum = i + 1;
                tripDays.TripId = lastRecord.TripId;
                _unit.TripDays.Add(tripDays);

            }
            _unit.Save();

           

        }
        [Route("trip-days")]
        public IActionResult TripDays(int? id)
        {
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();
            var count = lastRecord.Days;
            ViewData["count"] = count;
            


            if (id == null)
            {
                //this is for create
                return View(tripDays);
            }
            //this is for edit
            tripDays = _unit.TripDays.Get(id.GetValueOrDefault());
            if (tripDays.TripDetail == null)
            {
                return NotFound();
            }
            return View(tripDays);

        }


        [Route("trip-days")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TripDays()
        {
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();
            var count = lastRecord.Days;
            if (ModelState.IsValid)
            {

               return RedirectToAction("OfferedCreateDone","TripDays");
            }
            return View(tripDays);
            //else
            //{

            //    var lastRows = _db.TripDaysDetails.Where(x => x.TripId == lastRecord.TripId);
            //    _unit.TripDays.Remove(lastRecord.TripId);
            //    return View(tripDays);
            //}
        }


        //public void UploadImage(int i)
        //{
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var files = HttpContext.Request.Form.Files;

        //    if (files.Count > 0)
        //    {
        //        string fileName = Guid.NewGuid().ToString();
        //        var uploads = Path.Combine(webRootPath, @"Trips\Trip-days");
        //        var extension = Path.GetExtension(files[i].FileName);
        //        var fullPath = uploads + fileName + extension;
        //        if (System.IO.File.Exists(fullPath))
        //        {
        //            System.IO.File.Delete(fullPath);

        //        }

        //        using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //        {
        //            files[i].CopyTo(filesStreams);
        //        }
        //        tripDays.ImageUrl = @"\Trips\Trip-days\" + fileName + extension;


        //        //// Upload image to Database
        //        //tripDays.ImageUrl = @"Trips\\Trip-days\\" + imageName + extension;
        //    }

        //}

        [Route("offered-create-done")]
        public IActionResult OfferedCreateDone()
        {
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unit.OfferCreate.GetAll(includeProperties: "City");
            return Json(new { data = allObj });
        }

        

        #endregion

    }
}