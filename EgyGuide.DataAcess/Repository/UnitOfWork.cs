using EgyGuide.Data;
using EgyGuide.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            OfferCreate = new OfferCreateRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            TripDays = new TripDaysRepository(_db);
            Requested = new RequestedRepository(_db);
        }

        public IOfferCreateRepository OfferCreate { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public ITripDaysRepository TripDays { get; private set; }
        public IRequestedRepository Requested { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
