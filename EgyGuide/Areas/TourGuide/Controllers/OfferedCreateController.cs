using EgyGuide.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.TourGuide.Controllers
{
    [Area("TourGuide")]
    public class OfferedCreateController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OfferCreateVM tripVM { get; set; }

        public OfferedCreateController(IUnitOfWork unit, IWebHostEnvironment hostEnvironment, ApplicationDbContext db)
        {
            _unit = unit;
            _hostEnvironment = hostEnvironment;
            _db = db;

        }


        [Route("offered-create")]
        public async Task<IActionResult> Index(int? id)
        {

            var cityList = await _db.Cities.ToListAsync();

             tripVM = new OfferCreateVM()
            {
                TripStyles = _db.TripStyles,
                TripDetail = new TripDetail(),
                CityList = cityList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.CityId.ToString()
                }),


            };

            if (id == null)
            {
                //this is for create
                return View(tripVM);
            }
            //this is for edit
            tripVM.TripDetail = _unit.OfferCreate.Get(id.GetValueOrDefault());
            if (tripVM.TripDetail == null)
            {
                return NotFound();
            }
            return View(tripVM);

        }

        [HttpPost]
        public void SaveList(string ItemList)
        {
            // save the value into session to can use it again in other functions
            //must initialze a key
            var key = "my-key";

            HttpContext.Session.SetString(key, ItemList);
        }
        [HttpPost]
        public void SaveEncluded(string ItemList)
        {
            var key2 = "encluded";

            HttpContext.Session.SetString(key2, ItemList);

        }
        [HttpPost]
        public void SaveExecluded(string ItemList)
        {
            var key3 = "excluded";

            HttpContext.Session.SetString(key3, ItemList);

        }
        
        [Route("offered-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {

            if (ModelState.IsValid)
            {
             
                //retrive the value that in the session
                //must initialize the same key i initialized before
                var key = "my-key";
                var dataFromView = HttpContext.Session.GetString(key);

                var key2 = "encluded";
                var dataEncluded = HttpContext.Session.GetString(key2);

                var key3 = "excluded";
                var dataExcluded = HttpContext.Session.GetString(key3);

                if (tripVM.TripDetail.TripId == 0 )
                {
                   
                    //save the data from view into trip table
                    tripVM.TripDetail.SelcetedStyles = dataFromView;
                    //save all the model
                    _unit.OfferCreate.Add(tripVM.TripDetail);
                    _unit.Save();

                    SavePlaces();

                    SaveStyles(dataFromView);

                    SaveEncludedTexts(dataEncluded);
                    SaveExcludedTexts(dataExcluded);

                    UploadImages();

                    _db.SaveChanges();

                }
                else
                {
                    _unit.OfferCreate.Update(tripVM.TripDetail);
                    _unit.Save();
                }



                return RedirectToAction(nameof(OfferedCreateDone));
            }
            else
            {
               
                var cityList = await _db.Cities.ToListAsync();
                tripVM.CityList = cityList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.CityId.ToString()
                });

                if (tripVM.TripDetail.TripId != 0)
                {
                    tripVM.TripDetail = _unit.OfferCreate.Get(tripVM.TripDetail.TripId);
                }
                
            }
            return View(tripVM);
        }

        public void SavePlaces()
        {
            // want to save every place that the tourguide enter in the trip

            // get the last trip that i have  recently added so i can get the id
            //of it to save places in places table with the id of the trip

            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();
            string selectedPlaces = tripVM.TripDetail.SelectedPlaces;
            string[] places = selectedPlaces.Split(null);
            foreach (string place in places)
            {
                Place Place = new Place();
                Place.PlaceName = place;
                Place.TripId = lastRecord.TripId;
                _db.Places.Add(Place);

            }
        }
        public void UploadImages()
        {
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            tripVM.TripDetail.SelectedImages = new List<Gallery>();

            for (var i = 0; i < files.Count; i++)
            {
                var uploads = Path.Combine(webRootPath, @"Trips/gallery");
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(files[i].FileName);
                string fullPath = uploads + fileName + extension;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                }
                var gallery = new Gallery()
                {

                    URL = @"\Trips\gallery\" + fileName + extension,
                    TripId = lastRecord.TripId,

                };
                tripVM.TripDetail.SelectedImages.Add(gallery);

            }
        }
        public void SaveStyles(string dataFromView)
        {
            // coveret the data from view into list so i can loop through it
            var data = dataFromView.Split(',').ToList();

            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();
            // save into selected styles table
            foreach (var item in data)
            {
                var selectedStyle = new SelectedStyle()
                {
                    StyleId = Convert.ToInt16(item),
                    TripId = lastRecord.TripId
                };
                _db.SelectedStyles.Add(selectedStyle);
            }
        }
        public void SaveEncludedTexts(string ItemList)
        {
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();

            var data = ItemList.Split(",");
            var dataList = data.ToList();

            for (var i = 0; i < dataList.Count; i++)
            {
                Included included = new Included();
                included.Title = data[i];
                included.TripId = lastRecord.TripId;
                _db.Includeds.Add(included);
               

            }
        }
        public void SaveExcludedTexts(string ItemList)
        {
            var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();

            var data = ItemList.Split(",");
            var dataList = data.ToList();

            for (var i = 0; i < dataList.Count; i++)
            {
                Excluded excluded = new Excluded();
                excluded.Title = data[i];
                excluded.TripId = lastRecord.TripId;
                _db.Excludeds.Add(excluded);


            }
        }
        
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

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _unit.OfferCreate.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error while deleting" });
        //    }
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));
        //    if (System.IO.File.Exists(imagePath))
        //    {
        //        System.IO.File.Delete(imagePath);
        //    }
        //    _unit.OfferCreate.Remove(objFromDb);
        //    _unit.Save();
        //    return Json(new { success = true, message = "Delete Successful" });

        //}

        #endregion

    }
}