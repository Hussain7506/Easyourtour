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
    [Migration("20240831160708_editingcolumns")]
    partial class editingcolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayItinerary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayNumber")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<int?>("TransportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("HotelId");

                    b.HasIndex("HotelRoomId");

                    b.HasIndex("LocationId");

                    b.HasIndex("TemplateId");

                    b.HasIndex("TransportId");

                    b.ToTable("DayItineraries");
                });

            modelBuilder.Entity("DayItineraryRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DayItineraryId")
                        .HasColumnType("int");

                    b.Property<int>("ExtraPersons")
                        .HasColumnType("int");

                    b.Property<int>("HotelRoomId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<double>("TotalRoomCost")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DayItineraryId");

                    b.HasIndex("HotelRoomId");

                    b.ToTable("DayItineraryRoom");
                });

            modelBuilder.Entity("Easyourtour.Models.DayItinerarySightseeing", b =>
                {
                    b.Property<int>("DayItineraryId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("SightseeingId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("DayItineraryId", "SightseeingId");

                    b.HasIndex("SightseeingId");

                    b.ToTable("DayItinerarySightseeings");
                });

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

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

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

                    b.Property<double>("FinalCost")
                        .HasColumnType("float");

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

            modelBuilder.Entity("DayItinerary", b =>
                {
                    b.HasOne("Easyourtour.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Easyourtour.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Easyourtour.Models.HotelRoom", "HotelRoom")
                        .WithMany()
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Easyourtour.Models.Template", "Template")
                        .WithMany("DayItineraries")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.Transport", "Transport")
                        .WithMany()
                        .HasForeignKey("TransportId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Destination");

                    b.Navigation("Hotel");

                    b.Navigation("HotelRoom");

                    b.Navigation("Location");

                    b.Navigation("Template");

                    b.Navigation("Transport");
                });

            modelBuilder.Entity("DayItineraryRoom", b =>
                {
                    b.HasOne("DayItinerary", "DayItinerary")
                        .WithMany("DayItineraryRooms")
                        .HasForeignKey("DayItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.HotelRoom", "HotelRoom")
                        .WithMany()
                        .HasForeignKey("HotelRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayItinerary");

                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Easyourtour.Models.DayItinerarySightseeing", b =>
                {
                    b.HasOne("DayItinerary", "DayItinerary")
                        .WithMany("DayItinerarySightseeings")
                        .HasForeignKey("DayItineraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Easyourtour.Models.Sightseeing", "Sightseeing")
                        .WithMany()
                        .HasForeignKey("SightseeingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayItinerary");

                    b.Navigation("Sightseeing");
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

            modelBuilder.Entity("Easyourtour.Models.Transport", b =>
                {
                    b.HasOne("Easyourtour.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DayItinerary", b =>
                {
                    b.Navigation("DayItineraryRooms");

                    b.Navigation("DayItinerarySightseeings");
                });

            modelBuilder.Entity("Easyourtour.Models.Hotel", b =>
                {
                    b.Navigation("HotelImages");
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
                    b.Navigation("DayItineraries");
                });
#pragma warning restore 612, 618
        }
    }
}