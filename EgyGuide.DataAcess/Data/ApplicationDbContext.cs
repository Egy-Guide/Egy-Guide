﻿using EgyGuide.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EgyGuide.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Guide> Guides { get; set; }
   
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Place> Places { get; set; }
        
        public DbSet<SelectedStyle> SelectedStyles { get; set; }
        public DbSet<TripStyle> TripStyles { get; set; }
        
        public DbSet<TripDetail> TripDetails { get; set; }
        public DbSet<TripDaysDetail> TripDaysDetails { get; set; }

        
    }
}
