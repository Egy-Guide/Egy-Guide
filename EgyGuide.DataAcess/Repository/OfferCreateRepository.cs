using System;
using System.Collections.Generic;
using EgyGuide.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.DataAccess;
using EgyGuide.DataAccess.Data;

namespace EgyGuide.DataAccess.Repository
{
    public class OfferCreateRepository : Repository<TripDetail>, IOfferCreateRepository
    {
        private readonly ApplicationDbContext _db;
        public OfferCreateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(TripDetail tripDetail)
        {
            var objFromDb = _db.TripDetails.FirstOrDefault(s => s.TripId == tripDetail.TripId);
            if (objFromDb != null)
            {
                
                objFromDb.City = tripDetail.City;
                objFromDb.Title = tripDetail.Title;
                objFromDb.SelectedPlaces = tripDetail.SelectedPlaces;
                objFromDb.Days = tripDetail.Days;
                objFromDb.Nights = tripDetail.Nights;
                objFromDb.Transport = tripDetail.Transport;
                objFromDb.MeetingPlace = tripDetail.MeetingPlace;
                objFromDb.MeetingDate = tripDetail.MeetingDate;
                objFromDb.Price = tripDetail.Price;
                objFromDb.Description = tripDetail.Description;
                
                
                objFromDb.SelectedLanguages = tripDetail.SelectedLanguages;
                objFromDb.MaxTravellers = tripDetail.MaxTravellers;
               


                _db.SaveChanges();
            }
            else
            {
                throw new System.NullReferenceException();
            }

        }
    }
}
