using EgyGuide.DataAccess.Data;
using EgyGuide.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository.IRepository
{
    public class GuideUserRepository : Repository<GuideUser>, IGuideUserRepository 
    {
        private readonly ApplicationDbContext _db;
        public GuideUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(GuideUser guideUser)
        {
            var objFromDb = _db.GuideUsers.Where(g => g.Id == guideUser.Id).Include("ApplicationUser").FirstOrDefault();

            if (objFromDb != null)
            {
                objFromDb.ApplicationUser.FirstName = guideUser.ApplicationUser.FirstName;
                objFromDb.ApplicationUser.LastName = guideUser.ApplicationUser.LastName;
                objFromDb.ApplicationUser.Email = guideUser.ApplicationUser.Email;
                objFromDb.ApplicationUser.PhoneNumber = guideUser.ApplicationUser.PhoneNumber;
                objFromDb.ApplicationUser.Nationality = guideUser.ApplicationUser.Nationality;
                objFromDb.ApplicationUser.Country = guideUser.ApplicationUser.Country;
                objFromDb.ApplicationUser.City = guideUser.ApplicationUser.City;
                objFromDb.ApplicationUser.ImageUrl = guideUser.ApplicationUser.ImageUrl;
                objFromDb.YearExperience = guideUser.YearExperience;
                objFromDb.PricePerHour = guideUser.PricePerHour;
                objFromDb.ServiceArea = guideUser.ServiceArea;
                objFromDb.Language = guideUser.Language;
                objFromDb.FacebookProfile = guideUser.FacebookProfile;
                objFromDb.TwitterProfile = guideUser.TwitterProfile;
                objFromDb.InstagramProfile = guideUser.InstagramProfile;
                objFromDb.YoutubeProfile = guideUser.YoutubeProfile;
            }
        }
    }
}
