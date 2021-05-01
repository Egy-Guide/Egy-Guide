using EgyGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository.IRepository
{
    public interface IRequestedRepository : IRepository<Requested>
    {
        void Update(Requested requested);
    }
}
