using EgyGuide.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using EgyGuide.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyGuide.Areas.Tourist.Controllers
{
    [Area("Tourist")]    
    public class RequestedCreateController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public RequestedVM requestedVM { get; set; }
        public RequestedCreateController(ApplicationDbContext db, IUnitOfWork unit)
        {
            _unit = unit;
            _db = db;
        }
        [Route("requested-create")]
        public async Task<IActionResult> Index(int? id)
        {
            var cityList = await _db.Cities.ToListAsync();
            requestedVM = new RequestedVM()
            {
                TripStyles = _db.TripStyles,
                Requested = new Requested(),
                CityList = cityList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.CityId.ToString()
                }),
            };
            if (id == null)
            {
                //this is for create
                return View(requestedVM);
            }
            requestedVM.Requested = _unit.Requested.Get(id.GetValueOrDefault());
            if (requestedVM.Requested == null)
            {
                return NotFound();
            }
            return View(requestedVM);
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
        public void SaveInfo(string ItemList)
        {
            var key2 = "Info";

            HttpContext.Session.SetString(key2, ItemList);

        }

        [Route("requested-create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index()
        {
            if (ModelState.IsValid)
            {
                var key = "my-key";
                var dataFromView = HttpContext.Session.GetString(key);

                var key2 = "Info";
                var dataInfo = HttpContext.Session.GetString(key2);

                if (requestedVM.Requested.TripId == 0)
                {

                    //save the data from view into trip table
                    requestedVM.Requested.SelcetedStyles = dataFromView;
                    //save all the model
                    _unit.Requested.Add(requestedVM.Requested);
                    _unit.Save();

                    SaveStyles(dataFromView);
                    SaveInfoTexts(dataInfo);
                    _db.SaveChanges();
                }
                else
                {
                    _unit.Requested.Update(requestedVM.Requested);
                    _unit.Save();
                }
                return RedirectToAction("RequestedCreateDone");
            }
            else
            {
                var cityList = await _db.Cities.ToListAsync();
                requestedVM.CityList = cityList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.CityId.ToString()
                });

                if (requestedVM.Requested.TripId != 0)
                {
                    requestedVM.Requested = _unit.Requested.Get(requestedVM.Requested.TripId);
                }
            }
            return View(requestedVM);
        }
        public void SaveStyles(string dataFromView)
        {
            // coveret the data from view into list so i can loop through it
            var data = dataFromView.Split(',').ToList();

            var lastRecord = _db.Requested.OrderByDescending(i => i.TripId).FirstOrDefault();
            // save into selected styles table
            foreach (var item in data)
            {
                var selectedStyle = new RequestedSelectedStyle()
                {
                    StyleId = Convert.ToInt16(item),
                    TripId = lastRecord.TripId
                };
                _db.RequestedSelectedStyle.Add(selectedStyle);
            }
        }

        public void SaveInfoTexts(string ItemList)
        {
            var lastRecord = _db.Requested.OrderByDescending(i => i.TripId).FirstOrDefault();

            var data = ItemList.Split(",");
            var dataList = data.ToList();

            for (var i = 0; i < dataList.Count; i++)
            {
                RequestedInfo Info = new RequestedInfo();
                Info.Title = data[i];
                Info.TripId = lastRecord.TripId;
                _db.RequestedInfo.Add(Info);


            }
        }

        [Route("requested-create-done")]
        public IActionResult RequestedCreateDone()
        {
            return View();
        }
    }
}
