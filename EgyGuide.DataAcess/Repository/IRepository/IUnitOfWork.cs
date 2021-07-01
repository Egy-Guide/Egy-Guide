using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyGuide.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        IGuideUserRepository GuideUser { get; }
        IGuideUserDetailsRepository GuideUserDetails { get; }
        ICategoryRepository Category { get; }
        IBlogRepository Blog { get; }
        ITripDaysRepository TripDays { get; }
        IOfferCreateRepository OfferCreate { get; }
        IRequestedRepository Requested { get; }
        ITripBookingRepository TripBooking { get; }
        ITravellerDetailsRepository TravellerDetails { get; }
        void Save();
    }
}
