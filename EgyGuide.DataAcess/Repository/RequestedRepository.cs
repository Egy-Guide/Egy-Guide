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
    public class RequestedRepository : Repository<Requested>, IRequestedRepository
    {
        private readonly ApplicationDbContext _db;
        public RequestedRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(Requested requested)
        {
            var objFromDb = _db.Requested.FirstOrDefault(s => s.TripId == requested.TripId);
            if (objFromDb != null)
            {
                //edit
                _db.SaveChanges();
            }
            else
            {
                throw new System.NullReferenceException();
            }

        }
    }
}
