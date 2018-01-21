using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ATMSData.Models;

namespace ATMSData.Migrations
{
    [DbContext(typeof(TrafficAccidentManagementContext))]
    [Migration("20180121073252_I will always love u")]
    partial class Iwillalwaysloveu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATMSData.Models.AccidentRecord", b =>
                {
                    b.Property<string>("AccidentRecordID");

                    b.Property<string>("City");

                    b.Property<string>("Descriptions");

                    b.Property<string>("SubCity");

                    b.HasKey("AccidentRecordID");

                    b.ToTable("AccidentRecords");
                });

            modelBuilder.Entity("ATMSData.Models.CauseOn", b =>
                {
                    b.Property<string>("AccidentRecordID");

                    b.Property<string>("VehicleID");

                    b.Property<string>("VehicleCost");

                    b.HasKey("AccidentRecordID", "VehicleID");

                    b.HasIndex("VehicleID");

                    b.ToTable("CausesOn");
                });

            modelBuilder.Entity("ATMSData.Models.Damage", b =>
                {
                    b.Property<string>("ProperietyID");

                    b.Property<string>("AccidentRecordID");

                    b.Property<string>("ProperietyCost");

                    b.HasKey("ProperietyID");

                    b.HasIndex("AccidentRecordID");

                    b.ToTable("Damages");
                });

            modelBuilder.Entity("ATMSData.Models.Driver", b =>
                {
                    b.Property<string>("DriverID");

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("FirstName");

                    b.Property<string>("Job");

                    b.Property<string>("LastName");

                    b.Property<string>("SecondName");

                    b.Property<string>("sex");

                    b.HasKey("DriverID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("ATMSData.Models.Factory", b =>
                {
                    b.Property<int>("FactorID");

                    b.Property<string>("FactorType");

                    b.HasKey("FactorID");

                    b.ToTable("Factories");
                });

            modelBuilder.Entity("ATMSData.Models.FactoryAndAccident", b =>
                {
                    b.Property<string>("AccidentRecordId");

                    b.Property<int>("FactoryId");

                    b.HasKey("AccidentRecordId", "FactoryId");

                    b.HasIndex("FactoryId");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("ATMSData.Models.Injures", b =>
                {
                    b.Property<string>("VictimID");

                    b.Property<string>("AccidentRecordID");

                    b.HasKey("VictimID");

                    b.HasIndex("AccidentRecordID");

                    b.ToTable("Injures");
                });

            modelBuilder.Entity("ATMSData.Models.Involve", b =>
                {
                    b.Property<string>("DriverID");

                    b.Property<string>("AccidentRecordID");

                    b.HasKey("DriverID", "AccidentRecordID");

                    b.HasIndex("AccidentRecordID");

                    b.ToTable("Involves");
                });

            modelBuilder.Entity("ATMSData.Models.Occur", b =>
                {
                    b.Property<DateTime>("AccidentTime");

                    b.Property<string>("AccidentRecordID");

                    b.Property<string>("RoadGeometryRoadName");

                    b.HasKey("AccidentTime", "AccidentRecordID");

                    b.HasIndex("AccidentRecordID");

                    b.HasIndex("RoadGeometryRoadName");

                    b.ToTable("Occurs");
                });

            modelBuilder.Entity("ATMSData.Models.Properiety", b =>
                {
                    b.Property<string>("ProperietyID");

                    b.Property<string>("ProperietyType");

                    b.HasKey("ProperietyID");

                    b.ToTable("Properieties");
                });

            modelBuilder.Entity("ATMSData.Models.RoadGeometry", b =>
                {
                    b.Property<string>("RoadName");

                    b.Property<double>("AADT");

                    b.Property<double>("ADT");

                    b.Property<double>("CarriageWidth");

                    b.Property<string>("HorizontalFeature");

                    b.Property<string>("JunctionControl");

                    b.Property<string>("JunctionType");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longutide");

                    b.Property<short>("NoLine");

                    b.Property<string>("RoadClassifaction");

                    b.Property<double>("RoadWidth");

                    b.Property<double>("ShoulderWidth");

                    b.Property<short>("SpeedLimit");

                    b.Property<string>("SurfaceType");

                    b.Property<string>("TrafficMovement");

                    b.Property<string>("VerticalFeature");

                    b.HasKey("RoadName");

                    b.ToTable("RoadGeometries");
                });

            modelBuilder.Entity("ATMSData.Models.Vehicle", b =>
                {
                    b.Property<string>("VehicleID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VehicleType");

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ATMSData.Models.Victim", b =>
                {
                    b.Property<string>("VictimID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("FirstName");

                    b.Property<string>("Job");

                    b.Property<string>("LastName");

                    b.Property<string>("SecondName");

                    b.Property<string>("sex");

                    b.HasKey("VictimID");

                    b.ToTable("Victims");
                });

            modelBuilder.Entity("ATMSData.Models.CauseOn", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecords")
                        .WithMany("CausesOn")
                        .HasForeignKey("AccidentRecordID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATMSData.Models.Vehicle", "Vehicles")
                        .WithMany("CausesOn")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMSData.Models.Damage", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecords")
                        .WithMany("Damages")
                        .HasForeignKey("AccidentRecordID");

                    b.HasOne("ATMSData.Models.Properiety", "Properieties")
                        .WithMany("Damages")
                        .HasForeignKey("ProperietyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMSData.Models.FactoryAndAccident", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecords")
                        .WithMany("FactrieAccidents")
                        .HasForeignKey("AccidentRecordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATMSData.Models.Factory", "Factories")
                        .WithMany("AccidentFactries")
                        .HasForeignKey("FactoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMSData.Models.Injures", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecords")
                        .WithMany("Injures")
                        .HasForeignKey("AccidentRecordID");

                    b.HasOne("ATMSData.Models.Victim", "Victims")
                        .WithMany("Injures")
                        .HasForeignKey("VictimID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMSData.Models.Involve", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecords")
                        .WithMany("Involves")
                        .HasForeignKey("AccidentRecordID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATMSData.Models.Driver", "Drivers")
                        .WithMany("Involves")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ATMSData.Models.Occur", b =>
                {
                    b.HasOne("ATMSData.Models.AccidentRecord", "AccidentRecord")
                        .WithMany("Occurs")
                        .HasForeignKey("AccidentRecordID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ATMSData.Models.RoadGeometry", "RoadGeometry")
                        .WithMany("Occurs")
                        .HasForeignKey("RoadGeometryRoadName");
                });
        }
    }
}
