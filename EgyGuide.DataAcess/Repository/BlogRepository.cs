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
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Blog blog)
        {
            var objFromDb = _db.Blogs.FirstOrDefault(c => c.Id == blog.Id);

            if (objFromDb != null)
            {
                objFromDb.Title = blog.Title;
                objFromDb.Descripition = blog.Descripition;
                objFromDb.CategoryId = blog.CategoryId;
                objFromDb.ImageURL = blog.ImageURL;                
            }
        }
    }
}
