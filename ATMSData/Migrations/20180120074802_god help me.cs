using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ATMSData.Migrations
{
    public partial class godhelpme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccidentRecords",
                columns: table => new
                {
                    AccidentRecordID = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Descriptions = table.Column<string>(nullable: true),
                    SubCity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentRecords", x => x.AccidentRecordID);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                });

            migrationBuilder.CreateTable(
                name: "Factories",
                columns: table => new
                {
                    FactorID = table.Column<int>(nullable: false),
                    FactorType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factories", x => x.FactorID);
                });

            migrationBuilder.CreateTable(
                name: "Properieties",
                columns: table => new
                {
                    ProperietyID = table.Column<string>(nullable: false),
                    ProperietyType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properieties", x => x.ProperietyID);
                });

            migrationBuilder.CreateTable(
                name: "RoadGeometries",
                columns: table => new
                {
                    RoadName = table.Column<string>(nullable: false),
                    AADT = table.Column<double>(nullable: false),
                    ADT = table.Column<double>(nullable: false),
                    CarriageWidth = table.Column<double>(nullable: false),
                    HorizontalFeature = table.Column<string>(nullable: true),
                    JunctionControl = table.Column<string>(nullable: true),
                    JunctionType = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longutide = table.Column<string>(nullable: true),
                    NoLine = table.Column<short>(nullable: false),
                    RoadClassifaction = table.Column<string>(nullable: true),
                    RoadWidth = table.Column<double>(nullable: false),
                    ShoulderWidth = table.Column<double>(nullable: false),
                    SpeedLimit = table.Column<short>(nullable: false),
                    SurfaceType = table.Column<string>(nullable: true),
                    TrafficMovement = table.Column<string>(nullable: true),
                    VerticalFeature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadGeometries", x => x.RoadName);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<string>(nullable: false),
                    VehicleType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    VictimID = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.VictimID);
                });

            migrationBuilder.CreateTable(
                name: "Involves",
                columns: table => new
                {
                    DriverID = table.Column<string>(nullable: false),
                    AccidentRecordID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Involves", x => new { x.DriverID, x.AccidentRecordID });
                    table.ForeignKey(
                        name: "FK_Involves_AccidentRecords_AccidentRecordID",
                        column: x => x.AccidentRecordID,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Involves_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactoryAndAccident",
                columns: table => new
                {
                    AccidentRecordId = table.Column<string>(nullable: false),
                    FactoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryAndAccident", x => new { x.AccidentRecordId, x.FactoryId });
                    table.ForeignKey(
                        name: "FK_FactoryAndAccident_AccidentRecords_AccidentRecordId",
                        column: x => x.AccidentRecordId,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactoryAndAccident_Factories_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factories",
                        principalColumn: "FactorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Damages",
                columns: table => new
                {
                    ProperietyID = table.Column<string>(nullable: false),
                    AccidentRecordID = table.Column<string>(nullable: true),
                    ProperietyCost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damages", x => x.ProperietyID);
                    table.ForeignKey(
                        name: "FK_Damages_AccidentRecords_AccidentRecordID",
                        column: x => x.AccidentRecordID,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Damages_Properieties_ProperietyID",
                        column: x => x.ProperietyID,
                        principalTable: "Properieties",
                        principalColumn: "ProperietyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occurs",
                columns: table => new
                {
                    AccidentTime = table.Column<DateTime>(nullable: false),
                    AccidentRecordID = table.Column<string>(nullable: false),
                    RoadGeometryRoadName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurs", x => new { x.AccidentTime, x.AccidentRecordID });
                    table.ForeignKey(
                        name: "FK_Occurs_AccidentRecords_AccidentRecordID",
                        column: x => x.AccidentRecordID,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occurs_RoadGeometries_RoadGeometryRoadName",
                        column: x => x.RoadGeometryRoadName,
                        principalTable: "RoadGeometries",
                        principalColumn: "RoadName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CausesOn",
                columns: table => new
                {
                    AccidentRecordID = table.Column<string>(nullable: false),
                    VehicleID = table.Column<string>(nullable: false),
                    VehicleCost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausesOn", x => new { x.AccidentRecordID, x.VehicleID });
                    table.ForeignKey(
                        name: "FK_CausesOn_AccidentRecords_AccidentRecordID",
                        column: x => x.AccidentRecordID,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CausesOn_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Injures",
                columns: table => new
                {
                    VictimID = table.Column<string>(nullable: false),
                    AccidentRecordID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injures", x => x.VictimID);
                    table.ForeignKey(
                        name: "FK_Injures_AccidentRecords_AccidentRecordID",
                        column: x => x.AccidentRecordID,
                        principalTable: "AccidentRecords",
                        principalColumn: "AccidentRecordID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Injures_Victims_VictimID",
                        column: x => x.VictimID,
                        principalTable: "Victims",
                        principalColumn: "VictimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CausesOn_VehicleID",
                table: "CausesOn",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Damages_AccidentRecordID",
                table: "Damages",
                column: "AccidentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryAndAccident_FactoryId",
                table: "FactoryAndAccident",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Injures_AccidentRecordID",
                table: "Injures",
                column: "AccidentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Involves_AccidentRecordID",
                table: "Involves",
                column: "AccidentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Occurs_AccidentRecordID",
                table: "Occurs",
                column: "AccidentRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Occurs_RoadGeometryRoadName",
                table: "Occurs",
                column: "RoadGeometryRoadName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CausesOn");

            migrationBuilder.DropTable(
                name: "Damages");

            migrationBuilder.DropTable(
                name: "FactoryAndAccident");

            migrationBuilder.DropTable(
                name: "Injures");

            migrationBuilder.DropTable(
                name: "Involves");

            migrationBuilder.DropTable(
                name: "Occurs");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Properieties");

            migrationBuilder.DropTable(
                name: "Factories");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "AccidentRecords");

            migrationBuilder.DropTable(
                name: "RoadGeometries");
        }
    }
}
