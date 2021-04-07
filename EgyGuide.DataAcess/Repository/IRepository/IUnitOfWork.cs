using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IOfferCreateRepository OfferCreate { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ITripDaysRepository TripDays { get; }
        void Save();
    }
}
