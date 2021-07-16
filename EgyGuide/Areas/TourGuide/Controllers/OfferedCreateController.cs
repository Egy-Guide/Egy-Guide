
using EgyGuide.DataAccess.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using EgyGuide.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Roles = SD.Role_User_Tour_Guide)]
    public class OfferedCreateController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OfferCreateVM tripVM { get; set; }

        [BindProperty]
        public TripDaysDetail tripDays { get; set; }
        public OfferedCreateController(
            IUnitOfWork unit,
            IWebHostEnvironment hostEnvironment,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext db
        )
        {
            _unit = unit;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
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
            int guideId = _unit.GuideUser.GetFirstOrDefault(g => g.UserId == _userManager.GetUserId(User)).Id;
            tripVM.TripDetail = _unit.OfferCreate.Get(id.GetValueOrDefault());
            tripVM.Included = _db.Includeds.Where(i => i.TripId == tripVM.TripDetail.TripId);
            tripVM.Excluded = _db.Excludeds.Where(i => i.TripId == tripVM.TripDetail.TripId);
            tripVM.Galleries = _db.Galleries.Where(i => i.TripId == tripVM.TripDetail.TripId);
            tripVM.TripDaysDetail = _db.TripDaysDetails.Where(i => i.TripId == tripVM.TripDetail.TripId);
            
            if (tripVM.TripDetail == null || tripVM.TripDetail.GuideId != guideId)
            {
                return NotFound();
            }
            return View(tripVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void UpdateTripDays(TripDaysDetail[] ItemList , int id)
        {
            
            if (ItemList != null)
            {
                for(int i =0; i < ItemList.Count(); i++)
                {
                    tripDays = ItemList[i];
                    var objFromDb = _unit.TripDays.Get(id);
                    objFromDb.TimeFrom = tripDays.TimeFrom;
                    objFromDb.TimeTo = tripDays.TimeTo;
                    objFromDb.ImageUrl = tripDays.ImageUrl;
                    objFromDb.Title = tripDays.Title;
                    objFromDb.Remark = tripDays.Remark;
                    objFromDb.Description = tripDays.Description;
                }
                _unit.Save();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public void UpdateEncluded(string ItemList, int id)
        {
            // save the value into session to can use it again in other functions
            //must initialze a key

            if (ItemList != null && id != 0)
            {
                var data = ItemList.Split(",");
                var dataList = data.ToList();
                var count = dataList.Count();
                var iterator = 0;
                var includeds = _db.Includeds.Where(e => e.TripId == id);
                foreach (var included in includeds)
                {
                    if (iterator < count)
                    {
                        included.Title = dataList[iterator];
                        iterator++;
                    }
                }
                _unit.Save();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public void UpdateExcluded(string ItemList, int id)
        {
            // save the value into session to can use it again in other functions
            //must initialze a key

            if (ItemList != null && id != 0)
            {
                var data = ItemList.Split(",");
                var dataList = data.ToList();
                var count = dataList.Count();
                var iterator = 0;
                var excludeds = _db.Excludeds.Where(e => e.TripId == id);
                foreach (var excluded in excludeds)
                {
                    if (iterator < count)
                    {
                        excluded.Title = dataList[iterator];
                        iterator++;
                    }
                }
                _unit.Save();
            }
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
                
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _hostEnvironment.WebRootPath;
                


                if (tripVM.TripDetail.TripId == 0 )
                {

                    tripVM.TripDetail.GuideId = _unit.GuideUser.GetFirstOrDefault(g => g.UserId == _userManager.GetUserId(User)).Id;
                   
                    //save the data from view into trip table
                    tripVM.TripDetail.SelcetedStyles = dataFromView;

                    //save cover image 
                    if (files.Count > 0)
                        UploadImage(webRootPath, files);
                    //save all the model
                    _unit.OfferCreate.Add(tripVM.TripDetail);

                    _unit.Save();

                    SavePlaces();

                    if (dataFromView != null)
                    {
                        SaveStyles(dataFromView);
                    }

                    if (dataEncluded != null)
                    {
                        SaveEncludedTexts(dataEncluded);
                    }
                    if (dataExcluded != null)
                    {
                        SaveExcludedTexts(dataExcluded);
                    }
                    var lastRecord = _db.TripDetails.OrderByDescending(i => i.TripId).FirstOrDefault();

                    UploadImages(lastRecord.TripId);
                    _db.SaveChanges();


                }
                else
                {
                    if (tripVM.TripDetail.TripId != 0 )
                    {
                        //update images
                        
                        var images = _db.Galleries.Where(i => i.TripId == tripVM.TripDetail.TripId);
                        if (files.Count > 0)
                        {
                            foreach (var image in images)
                                {
                                   if(image.URL != null)
                                    {
                                       string imagePath = Path.Combine(webRootPath, image.URL.TrimStart('\\'));
                                        if (System.IO.File.Exists(imagePath))
                                       {
                                           System.IO.File.Delete(imagePath);
                                       }
                                    }
                                }
                            if (images != null) {
                                _db.Galleries.RemoveRange(images);
                                
                            }
                            UploadImages(tripVM.TripDetail.TripId);
                           
                            
                        }
                        else
                        {
                            //here, when we want to edit the trip but not change images
                            foreach(var image in images)
                            {
                                var gallery = new Gallery()
                                {

                                    URL = image.URL,
                                    TripId = tripVM.TripDetail.TripId

                                };
                            }
                        }
                       
                        //remove previous selected styles and put new
                        tripVM.TripDetail.SelcetedStyles = dataFromView;
                        
                        _db.SelectedStyles.RemoveRange(_db.SelectedStyles.Where(s => s.TripId == tripVM.TripDetail.TripId));


                        // save into selected styles table
                        if (dataFromView != null)
                        {
                            
                            var data = dataFromView.Split(',').ToList();

                            foreach (var item in data)
                            {
                                var selectedStyle = new SelectedStyle()
                                {
                                    StyleId = Convert.ToInt16(item),
                                    TripId = tripVM.TripDetail.TripId
                                };
                                _db.SelectedStyles.Add(selectedStyle);
                            }
                        }

                        //update all model
                        _unit.OfferCreate.Update(tripVM.TripDetail);
                        _unit.Save();
                        return RedirectToAction("OfferedCreateDone", "TripDays", new { area = "TourGuide" });
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction("TripDays","TripDays",new { area="TourGuide"});
            }
            else
            {
               
                var cityList = await _db.Cities.ToListAsync();
                
                tripVM.CityList = cityList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.CityId.ToString()
                });
                
                tripVM.TripStyles = _db.TripStyles;



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
        public void UploadImage(string rootPath, IFormFileCollection image)
        {
            // The folder path where the images will be uploded
            string folderPath = Path.Combine(rootPath, @"Trips\Cover");
            // Generate a unique image name
            string imageName = Guid.NewGuid().ToString();
            // Get the extension of the image
            string extension = Path.GetExtension(image[0].FileName);
            // ImageURL
            string imageURL = Path.Combine(folderPath, imageName + extension);

            // Upload image to physical storage
            using (var fileStream = new FileStream(imageURL, FileMode.Create))
            {
                image[0].CopyTo(fileStream);
                fileStream.Dispose();
            }

            // Upload image to Database
            tripVM.TripDetail.CoverImageUrl = @"\Trips\Cover\" + imageName + extension;
        }

        public void UploadImages(int id)
        {

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            tripVM.TripDetail.SelectedImages = new List<Gallery>();

            for (var i = 0; i < files.Count; i++)
            {
                var uploads = Path.Combine(webRootPath, @"Trips\gallery");
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(files[i].FileName);
                string fullPath = uploads + fileName + extension;
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);

                }
                using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[i].CopyTo(filesStreams);
                    filesStreams.Dispose();
                }

                var gallery = new Gallery()
                {

                    URL = @"/Trips/gallery/" + fileName + extension,
                    TripId = id,

                };
                tripVM.TripDetail.SelectedImages.Add(gallery);

            }
           
        }
        //public void EditImages()
        //{
            
        //    string webRootPath = _hostEnvironment.WebRootPath;
        //    var files = HttpContext.Request.Form.Files;

        //    tripVM.TripDetail.SelectedImages = new List<Gallery>();

        //    for (var i = 0; i < files.Count; i++)
        //    {
        //        var uploads = Path.Combine(webRootPath, @"Trips\gallery");
        //        var fileName = Guid.NewGuid().ToString();
        //        var extension = Path.GetExtension(files[i].FileName);
        //        string fullPath = Path.Combine(uploads, fileName + extension);
                
        //        using (var filesStreams = new FileStream(fullPath, FileMode.Create))
        //        {
        //            files[i].CopyTo(filesStreams);
        //            filesStreams.Dispose();
        //        }
        //        var gallery = new Gallery()
        //        {

        //            URL = @"\Trips\gallery\" + fileName + extension,
        //            TripId = tripVM.TripDetail.TripId,

        //        };
        //        tripVM.TripDetail.SelectedImages.Add(gallery);
                
        //    }
            
        //}
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
                _db.SaveChanges();

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
                _db.SaveChanges();

            }
        }

       

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unit.OfferCreate.GetAll(includeProperties: "City");
            return Json(new { data = allObj });
        }

       
        #region APIs
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // delete trip from trips table
            var deletedTrip = _unit.OfferCreate.Get(id);
            if (deletedTrip == null)
                return Json(new { success = false });

            _unit.OfferCreate.Remove(deletedTrip);

            // delete days of trip from trip days table 
            _unit.TripDays.RemoveRange(_db.TripDaysDetails.Where(i => i.TripId == id));

            //delete images 
            //must delete images from physical
            string webRootPath = _hostEnvironment.WebRootPath;

            foreach (var image in _db.Galleries.Where(i => i.TripId == id))
            {
                if (image.URL != null)
                {
                    string imagePath = Path.Combine(webRootPath, image.URL.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }
            //delete from galleries table from its table
            _db.Galleries.RemoveRange(_db.Galleries.Where(i => i.TripId == id));

            // delete includes of trip from its table
            _db.Includeds.RemoveRange(_db.Includeds.Where(i => i.TripId == id));

            // delete excludeds of trip from its table
            _db.Excludeds.RemoveRange(_db.Excludeds.Where(i => i.TripId == id));

            // delete places of trip from its table
            _db.Places.RemoveRange(_db.Places.Where(i => i.TripId == id));
            
            // delete selected styles of trip from its table
            _db.SelectedStyles.RemoveRange(_db.SelectedStyles.Where(i => i.TripId == id));
            
            //save aLL
            _unit.Save();

            return Json(new { success = true });
        }
        #endregion
        #endregion

    }
}

