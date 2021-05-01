using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senior_Project.Migrations
{
    public partial class seniorproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    garageName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    GarageId = table.Column<int>(type: "INTEGER", nullable: false),
                    approval = table.Column<bool>(type: "INTEGER", nullable: false),
                    longitude = table.Column<float>(type: "REAL", nullable: false),
                    lattitude = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    userRole = table.Column<string>(type: "TEXT", nullable: true),
                    loginTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    logoutTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    GarageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "statusOfVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    mechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    approval = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statusOfVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    vehicleType = table.Column<string>(type: "TEXT", nullable: true),
                    plateNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    plateCode = table.Column<int>(type: "INTEGER", nullable: false),
                    countryCode = table.Column<string>(type: "TEXT", nullable: true),
                    color = table.Column<string>(type: "TEXT", nullable: true),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sender = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    objectId = table.Column<int>(type: "INTEGER", nullable: false),
                    received = table.Column<bool>(type: "INTEGER", nullable: false),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    mechanicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Mechanics_mechanicId",
                        column: x => x.mechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "additionalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    statusOfVehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    expectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    serviceFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    totalPrice = table.Column<float>(type: "REAL", nullable: false),
                    approved = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additionalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_additionalServices_statusOfVehicles_statusOfVehicleId",
                        column: x => x.statusOfVehicleId,
                        principalTable: "statusOfVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "onGoingServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    statusOfVehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    expectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    serviceFinished = table.Column<bool>(type: "INTEGER", nullable: false),
                    totalPrice = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onGoingServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_onGoingServices_statusOfVehicles_statusOfVehicleId",
                        column: x => x.statusOfVehicleId,
                        principalTable: "statusOfVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    serviceName = table.Column<string>(type: "TEXT", nullable: true),
                    estimatedPrice = table.Column<float>(type: "REAL", nullable: false),
                    removed = table.Column<bool>(type: "INTEGER", nullable: false),
                    additionalServiceId = table.Column<int>(type: "INTEGER", nullable: true),
                    onGoingServiceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_additionalServices_additionalServiceId",
                        column: x => x.additionalServiceId,
                        principalTable: "additionalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_onGoingServices_onGoingServiceId",
                        column: x => x.onGoingServiceId,
                        principalTable: "onGoingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    garageName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    phoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    rating = table.Column<float>(type: "REAL", nullable: false),
                    removed = table.Column<bool>(type: "INTEGER", nullable: false),
                    available = table.Column<bool>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GarageId = table.Column<int>(type: "INTEGER", nullable: false),
                    longitude = table.Column<float>(type: "REAL", nullable: false),
                    latitude = table.Column<float>(type: "REAL", nullable: false),
                    ApplicationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceAssistanceRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    customerId = table.Column<int>(type: "INTEGER", nullable: false),
                    garageId = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    approval = table.Column<bool>(type: "INTEGER", nullable: false),
                    longitude = table.Column<float>(type: "REAL", nullable: false),
                    lattitude = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceAssistanceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceAssistanceRequests_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceAssistanceRequests_Garages_garageId",
                        column: x => x.garageId,
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceAssistanceRequests_Mechanics_mechanicId",
                        column: x => x.mechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_additionalServices_statusOfVehicleId",
                table: "additionalServices",
                column: "statusOfVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_ServiceId",
                table: "Garages",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ApplicationId",
                table: "Locations",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GarageId",
                table: "Locations",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_customerId",
                table: "Notifications",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_mechanicId",
                table: "Notifications",
                column: "mechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_onGoingServices_statusOfVehicleId",
                table: "onGoingServices",
                column: "statusOfVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceAssistanceRequests_customerId",
                table: "serviceAssistanceRequests",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceAssistanceRequests_garageId",
                table: "serviceAssistanceRequests",
                column: "garageId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceAssistanceRequests_mechanicId",
                table: "serviceAssistanceRequests",
                column: "mechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_additionalServiceId",
                table: "Services",
                column: "additionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_onGoingServiceId",
                table: "Services",
                column: "onGoingServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_customerId",
                table: "Vehicles",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "LogTimes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "serviceAssistanceRequests");

            migrationBuilder.DropTable(
                name: "SystemAdmins");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "additionalServices");

            migrationBuilder.DropTable(
                name: "onGoingServices");

            migrationBuilder.DropTable(
                name: "statusOfVehicles");
        }
    }
}
