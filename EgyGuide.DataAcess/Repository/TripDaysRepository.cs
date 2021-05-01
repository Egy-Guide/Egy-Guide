using System;
using System.Collections.Generic;
using EgyGuide.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EgyGuide.DataAccess.Repository.IRepository;

using EgyGuide.DataAccess.Data;

namespace EgyGuide.DataAccess.Repository
{
    public class TripDaysRepository : Repository<TripDaysDetail>, ITripDaysRepository
    {
        private readonly ApplicationDbContext _db;
        public TripDaysRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(TripDaysDetail tripDaysDetail)
        {
            var objFromDb = _db.TripDaysDetails.FirstOrDefault(s => s.TripId == tripDaysDetail.TripId);
            if (objFromDb != null)
            {
                
                objFromDb.DayNum = tripDaysDetail.DayNum;
                objFromDb.TimeFrom = tripDaysDetail.TimeFrom;
                objFromDb.TimeTo = tripDaysDetail.TimeTo;
                objFromDb.ImageUrl = tripDaysDetail.ImageUrl;
                objFromDb.Title = tripDaysDetail.Title;
                objFromDb.Remark = tripDaysDetail.Remark;
                objFromDb.Description = tripDaysDetail.Description;
               

                _db.SaveChanges();
            }
            else
            {
                throw new System.NullReferenceException();
            }

        }
    }
}
