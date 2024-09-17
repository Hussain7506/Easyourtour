﻿// <auto-generated />
using System;
using Easyourtour.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Easyourtour.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240915114707_AssigningcorrectdtypetoMiscellaneous")]
    partial class AssigningcorrectdtypetoMiscellaneous
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Easyourtour.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("Easyourtour.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelDestinationDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int>("ExtraBeds")
                        .HasColumnType("int");

                    b.Property<int?>("HotelDestinationOptionId")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Inclusions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NumRooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("HotelDestinationOptionId");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelRoomId");

                    b.HasIndex("LocationId");

                    b.ToTable("HotelDestinationDays");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelDestinationOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("HotelDestinationOptions");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelImages");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Inclusions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<double>("extrachargeperperson")
                        .HasColumnType("float");

                    b.Property<double>("priceoffseason")
                        .HasColumnType("float");

                    b.Property<double>("priceonseason")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelRoomImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelRoomId");

                    b.ToTable("HotelRoomImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Easyourtour.Models.LocationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Sightseeing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("EntryFee")
                        .HasColumnType("float");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelSightseeingDayId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TravelSightseeingDayId");

                    b.ToTable("Sightseeings");
                });

            modelBuilder.Entity("Easyourtour.Models.SightseeingImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SightseeingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SightseeingId");

                    b.ToTable("SightseeingImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfKids")
                        .HasColumnType("int");

                    b.Property<string>("StarRatingPreference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Easyourtour.Models.TemplateCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FinalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HotelCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<decimal>("TravelCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateCost");
                });

            modelBuilder.Entity("Easyourtour.Models.Transport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseDistance")
                        .HasColumnType("int");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<int>("CarCap")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("PricePerKm")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Transports");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseDistance")
                        .HasColumnType("int");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<int>("Kilometers")
                        .HasColumnType("int");

                    b.Property<double>("Miscellaneous")
                        .HasColumnType("float");

                    b.Property<string>("SightseeingSpotIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TravelSightseeingOptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarTypeId");

                    b.HasIndex("TravelSightseeingOptionId");

                    b.ToTable("TravelSightseeingDays");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TravelSightseeingOptions");
                });

            modelBuilder.Entity("Easyourtour.Models.Hotel", b =>
                {
                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelDestinationDay", b =>
                {
                    b.HasOne("Easyourtour.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.HotelDestinationOption", null)
                        .WithMany("HotelDestinationDays")
                        .HasForeignKey("HotelDestinationOptionId");

                    b.HasOne("Easyourtour.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.HotelRoom", "HotelRoom")
                        .WithMany()
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Hotel");

                    b.Navigation("HotelRoom");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelDestinationOption", b =>
                {
                    b.HasOne("Easyourtour.Models.Template", null)
                        .WithMany("HotelDestinationOptions")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Easyourtour.Models.HotelImage", b =>
                {
                    b.HasOne("Easyourtour.Models.Hotel", "Hotel")
                        .WithMany("HotelImages")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelRoom", b =>
                {
                    b.HasOne("Easyourtour.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelRoomImage", b =>
                {
                    b.HasOne("Easyourtour.Models.HotelRoom", "HotelRoom")
                        .WithMany("HotelRoomImages")
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Easyourtour.Models.Location", b =>
                {
                    b.HasOne("Easyourtour.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("Easyourtour.Models.LocationImage", b =>
                {
                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany("LocationImages")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Easyourtour.Models.Sightseeing", b =>
                {
                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.TravelSightseeingDay", null)
                        .WithMany("SightseeingSpots")
                        .HasForeignKey("TravelSightseeingDayId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Easyourtour.Models.SightseeingImage", b =>
                {
                    b.HasOne("Easyourtour.Models.Sightseeing", "Sightseeing")
                        .WithMany("SightseeingImages")
                        .HasForeignKey("SightseeingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sightseeing");
                });

            modelBuilder.Entity("Easyourtour.Models.TemplateCost", b =>
                {
                    b.HasOne("Easyourtour.Models.Template", null)
                        .WithMany("TemplateCosts")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Easyourtour.Models.Transport", b =>
                {
                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingDay", b =>
                {
                    b.HasOne("Easyourtour.Models.Transport", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.TravelSightseeingOption", null)
                        .WithMany("TravelSightseeingDays")
                        .HasForeignKey("TravelSightseeingOptionId");

                    b.Navigation("CarType");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingOption", b =>
                {
                    b.HasOne("Easyourtour.Models.Template", null)
                        .WithMany("TravelSightseeingOptions")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Easyourtour.Models.Hotel", b =>
                {
                    b.Navigation("HotelImages");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelDestinationOption", b =>
                {
                    b.Navigation("HotelDestinationDays");
                });

            modelBuilder.Entity("Easyourtour.Models.HotelRoom", b =>
                {
                    b.Navigation("HotelRoomImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Location", b =>
                {
                    b.Navigation("LocationImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Sightseeing", b =>
                {
                    b.Navigation("SightseeingImages");
                });

            modelBuilder.Entity("Easyourtour.Models.Template", b =>
                {
                    b.Navigation("HotelDestinationOptions");

                    b.Navigation("TemplateCosts");

                    b.Navigation("TravelSightseeingOptions");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingDay", b =>
                {
                    b.Navigation("SightseeingSpots");
                });

            modelBuilder.Entity("Easyourtour.Models.TravelSightseeingOption", b =>
                {
                    b.Navigation("TravelSightseeingDays");
                });
#pragma warning restore 612, 618
        }
    }
}