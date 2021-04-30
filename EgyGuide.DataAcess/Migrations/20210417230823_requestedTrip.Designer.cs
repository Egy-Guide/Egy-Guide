﻿// <auto-generated />
using System;
using EgyGuide.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EgyGuide.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210417230823_requestedTrip")]
    partial class requestedTrip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("EgyGuide.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EgyGuide.Models.Excluded", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Excludeds");
                });

            modelBuilder.Entity("EgyGuide.Models.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("TripDetailTripId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TripDetailTripId");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("EgyGuide.Models.Guide", b =>
                {
                    b.Property<int>("GuideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Languages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerHour")
                        .HasColumnType("real");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearExperinces")
                        .HasColumnType("int");

                    b.Property<string>("face_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("insta_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("twitter_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("youtube_link")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuideId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CityId");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("EgyGuide.Models.Included", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Includeds");
                });

            modelBuilder.Entity("EgyGuide.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("PlaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TripDetailTripId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("PlaceId");

                    b.HasIndex("TripDetailTripId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("EgyGuide.Models.Requested", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Budget")
                        .HasColumnType("real");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<int>("NumTravellers")
                        .HasColumnType("int");

                    b.Property<string>("SelcetedStyles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.HasIndex("CityId");

                    b.ToTable("Requested");
                });

            modelBuilder.Entity("EgyGuide.Models.RequestedSelectedStyle", b =>
                {
                    b.Property<int>("SelectedStyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("RequestedTripId")
                        .HasColumnType("int");

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int?>("TripStyleStyleId")
                        .HasColumnType("int");

                    b.HasKey("SelectedStyleId");

                    b.HasIndex("RequestedTripId");

                    b.HasIndex("TripStyleStyleId");

                    b.ToTable("RequestedSelectedStyle");
                });

            modelBuilder.Entity("EgyGuide.Models.SelectedStyle", b =>
                {
                    b.Property<int>("SelectedStyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<int?>("TripDetailTripId")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int?>("TripStyleStyleId")
                        .HasColumnType("int");

                    b.HasKey("SelectedStyleId");

                    b.HasIndex("TripDetailTripId");

                    b.HasIndex("TripStyleStyleId");

                    b.ToTable("SelectedStyles");
                });

            modelBuilder.Entity("EgyGuide.Models.TripDaysDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DayNum")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripDaysDetails");
                });

            modelBuilder.Entity("EgyGuide.Models.TripDetail", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaxTravellers")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeetingPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelcetedStyles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedPlaces")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedTags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Transport")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TripId");

                    b.HasIndex("CityId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("EgyGuide.Models.TripStyle", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("bit");

                    b.Property<string>("StyleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StyleId");

                    b.ToTable("TripStyles");
                });

            modelBuilder.Entity("ExcludedTripDetail", b =>
                {
                    b.Property<int>("ExcludedId")
                        .HasColumnType("int");

                    b.Property<int>("TripDetailsTripId")
                        .HasColumnType("int");

                    b.HasKey("ExcludedId", "TripDetailsTripId");

                    b.HasIndex("TripDetailsTripId");

                    b.ToTable("ExcludedTripDetail");
                });

            modelBuilder.Entity("IncludedTripDetail", b =>
                {
                    b.Property<int>("IncludedId")
                        .HasColumnType("int");

                    b.Property<int>("TripDetailsTripId")
                        .HasColumnType("int");

                    b.HasKey("IncludedId", "TripDetailsTripId");

                    b.HasIndex("TripDetailsTripId");

                    b.ToTable("IncludedTripDetail");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EgyGuide.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Brief")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("EgyGuide.Models.Gallery", b =>
                {
                    b.HasOne("EgyGuide.Models.TripDetail", "TripDetail")
                        .WithMany("SelectedImages")
                        .HasForeignKey("TripDetailTripId");

                    b.Navigation("TripDetail");
                });

            modelBuilder.Entity("EgyGuide.Models.Guide", b =>
                {
                    b.HasOne("EgyGuide.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("EgyGuide.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("City");
                });

            modelBuilder.Entity("EgyGuide.Models.Place", b =>
                {
                    b.HasOne("EgyGuide.Models.TripDetail", "TripDetail")
                        .WithMany()
                        .HasForeignKey("TripDetailTripId");

                    b.Navigation("TripDetail");
                });

            modelBuilder.Entity("EgyGuide.Models.Requested", b =>
                {
                    b.HasOne("EgyGuide.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("EgyGuide.Models.RequestedSelectedStyle", b =>
                {
                    b.HasOne("EgyGuide.Models.Requested", "Requested")
                        .WithMany()
                        .HasForeignKey("RequestedTripId");

                    b.HasOne("EgyGuide.Models.TripStyle", "TripStyle")
                        .WithMany()
                        .HasForeignKey("TripStyleStyleId");

                    b.Navigation("Requested");

                    b.Navigation("TripStyle");
                });

            modelBuilder.Entity("EgyGuide.Models.SelectedStyle", b =>
                {
                    b.HasOne("EgyGuide.Models.TripDetail", "TripDetail")
                        .WithMany()
                        .HasForeignKey("TripDetailTripId");

                    b.HasOne("EgyGuide.Models.TripStyle", "TripStyle")
                        .WithMany("SelectedStyle")
                        .HasForeignKey("TripStyleStyleId");

                    b.Navigation("TripDetail");

                    b.Navigation("TripStyle");
                });

            modelBuilder.Entity("EgyGuide.Models.TripDaysDetail", b =>
                {
                    b.HasOne("EgyGuide.Models.TripDetail", "TripDetail")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TripDetail");
                });

            modelBuilder.Entity("EgyGuide.Models.TripDetail", b =>
                {
                    b.HasOne("EgyGuide.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ExcludedTripDetail", b =>
                {
                    b.HasOne("EgyGuide.Models.Excluded", null)
                        .WithMany()
                        .HasForeignKey("ExcludedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EgyGuide.Models.TripDetail", null)
                        .WithMany()
                        .HasForeignKey("TripDetailsTripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IncludedTripDetail", b =>
                {
                    b.HasOne("EgyGuide.Models.Included", null)
                        .WithMany()
                        .HasForeignKey("IncludedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EgyGuide.Models.TripDetail", null)
                        .WithMany()
                        .HasForeignKey("TripDetailsTripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EgyGuide.Models.TripDetail", b =>
                {
                    b.Navigation("SelectedImages");
                });

            modelBuilder.Entity("EgyGuide.Models.TripStyle", b =>
                {
                    b.Navigation("SelectedStyle");
                });
#pragma warning restore 612, 618
        }
    }
}
