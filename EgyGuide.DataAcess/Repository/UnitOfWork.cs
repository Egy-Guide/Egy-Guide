using EgyGuide.DataAccess.Data;
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
            ApplicationUser = new ApplicationUserRepository(_db);
            GuideUser = new GuideUserRepository(_db);
            GuideUserDetails = new GuideUserDetailsRepository(_db);
            Category = new CategoryRepository(_db);
            Blog = new BlogRepository(_db);
            TripDays = new TripDaysRepository(_db);
            OfferCreate = new OfferCreateRepository(_db);
            Requested = new RequestedRepository(_db);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IGuideUserRepository GuideUser { get; private set; }
        public IGuideUserDetailsRepository GuideUserDetails { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public IBlogRepository Blog { get; private set; }

        public ITripDaysRepository TripDays { get; private set; }

        public IOfferCreateRepository OfferCreate { get; private set; }
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
