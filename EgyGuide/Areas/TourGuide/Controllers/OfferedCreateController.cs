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

            OfferCreateVM tripVM = new OfferCreateVM()
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
        public void SaveList( string ItemList )
        {
            // save the value into session to can use it again in other functions
            //must initialze a key
            var key = "my-key";
            
            HttpContext.Session.SetString(key, ItemList);
            

           
        }
        [Route("offered-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexPost(OfferCreateVM tripVM)
        {

            if (ModelState.IsValid)
            {
                //retrive the value that in the session
                //must initialize the same key i initialized before
                var key = "my-key";
                var dataFromView = HttpContext.Session.GetString(key);
                
                if (tripVM.TripDetail.TripId == 0)
                {
                    //save the data from view into trip table
                    tripVM.TripDetail.SelcetedStyles = dataFromView ;
                    //save all the model
                    _unit.OfferCreate.Add(tripVM.TripDetail);
                    _unit.Save();
                     
                    
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
                    // coveret the data from view into list so i can loop through it
                    var data = dataFromView.Split(',').ToList();
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
