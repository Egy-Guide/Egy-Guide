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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser applicationUser)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == applicationUser.Id);

            if (objFromDb != null)
            {
                objFromDb.FirstName = applicationUser.FirstName;
                objFromDb.LastName = applicationUser.LastName;
                objFromDb.Email = applicationUser.Email;
                objFromDb.PhoneNumber = applicationUser.PhoneNumber;
                objFromDb.Nationality = applicationUser.Nationality;
                objFromDb.Country = applicationUser.Country;
                objFromDb.City = applicationUser.City;
                objFromDb.Brief = applicationUser.Brief;
                objFromDb.ImageUrl = applicationUser.ImageUrl;
            }
        }
    }
}
