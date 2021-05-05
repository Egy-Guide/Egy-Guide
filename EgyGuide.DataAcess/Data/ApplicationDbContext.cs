﻿using EgyGuide.Models;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new { Id = 1, Name = "Business", },
                new { Id = 2, Name = "Commerce", },
                new { Id = 3, Name = "Adventure", }
            );

            builder.Entity<City>().HasData(
                new { CityId = 1, Name = "Alexandria", },
                new { CityId = 2, Name = "Cairo", }
            );

            base.OnModelCreating(builder);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Follower>().HasKey(f => new { f.UserId, f.FollowerId });
        //}


        public DbSet<City> Cities { get; set; }
        public DbSet<Gallery> Galleries { get; set; }   
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Place> Places { get; set; }
        
        public DbSet<SelectedStyle> SelectedStyles { get; set; }
        public DbSet<TripStyle> TripStyles { get; set; }
        
        public DbSet<TripDetail> TripDetails { get; set; }
        public DbSet<TripDaysDetail> TripDaysDetails { get; set; }
        public DbSet<Included> Includeds { get; set; }
        public DbSet<Excluded> Excludeds { get; set; }
        public DbSet<Requested> Requested { get; set; }
        public DbSet<RequestedSelectedStyle> RequestedSelectedStyle { get; set; }
        public DbSet<RequestedInfo> RequestedInfo { get; set; }
        public DbSet<GuideUser> GuideUsers { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Follower> Followers { get; set; }       
    }
}
