﻿using System;
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
        ICategoryRepository Category { get; }
        IBlogRepository Blog { get; }
        void Save();
    }
}