using EgyGuide.DataAccess.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using EgyGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository
{
    public class TravellerDetailsRepository : Repository<TravellerDetails>, ITravellerDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public TravellerDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
