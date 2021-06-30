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
    public class GuideUserDetailsRepository : Repository<GuideUserDetails>, IGuideUserDetailsRepository 
    {
        private readonly ApplicationDbContext _db;
        public GuideUserDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(GuideUserDetails guideUserDetails)
        {
            var objFromDb = _db.GuideUsersDetails.FirstOrDefault(g => g.Id == guideUserDetails.Id);

            if (objFromDb != null)
            {
                objFromDb.Introduction = guideUserDetails.Introduction;
                objFromDb.Street = guideUserDetails.Street;
                objFromDb.State = guideUserDetails.State;
                objFromDb.ZipCode = guideUserDetails.ZipCode;
                objFromDb.PrivateTransportation = guideUserDetails.PrivateTransportation;
                objFromDb.PublicTransportation = guideUserDetails.PublicTransportation;
                objFromDb.MoreDetails = guideUserDetails.MoreDetails;
                objFromDb.Birthday = guideUserDetails.Birthday;
                objFromDb.SpecialRemark = guideUserDetails.SpecialRemark;
                objFromDb.CertificateUrl = guideUserDetails.CertificateUrl;
            }
        }
    }
}
