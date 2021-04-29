using EgyGuide.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgyGuide.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Follower>().HasKey(f => new { f.UserId, f.FollowerId });
        //}

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<GuideUser> GuideUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Follower> Followers { get; set; }       
    }
}
