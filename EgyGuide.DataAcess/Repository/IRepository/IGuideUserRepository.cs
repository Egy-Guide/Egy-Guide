using EgyGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository.IRepository
{
    public interface IGuideUserRepository : IRepository<GuideUser>
    {
        void Update(GuideUser guideUser);
    }
}
