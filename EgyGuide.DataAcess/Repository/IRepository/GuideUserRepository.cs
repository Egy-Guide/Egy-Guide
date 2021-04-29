using EgyGuide.DataAccess.Data;
using EgyGuide.Models;
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

        }
    }
}
