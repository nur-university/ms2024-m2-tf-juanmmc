using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsAndDeliveries.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pgcrypto;");

            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    locationLatitude = table.Column<double>(type: "double precision", nullable: true),
                    locationLongitude = table.Column<double>(type: "double precision", nullable: true),
                    locationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identificationNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    scheduledDeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deliveryId = table.Column<Guid>(type: "uuid", nullable: false),
                    patientId = table.Column<string>(type: "text", nullable: false),
                    patientName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    patientEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patientPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    deliveryAddress = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    deliveryLatitude = table.Column<double>(type: "double precision", nullable: false),
                    deliveryLongitude = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    evidencePhotoUrl = table.Column<string>(type: "text", nullable: true),
                    evidenceReceiverName = table.Column<string>(type: "text", nullable: true),
                    evidenceReceiverSignature = table.Column<string>(type: "text", nullable: true),
                    evidenceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    evidenceObservations = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deliveryRoute",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    scheduledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    deliveryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryRoute", x => x.id);
                    table.ForeignKey(
                        name: "FK_deliveryRoute_delivery_deliveryId",
                        column: x => x.deliveryId,
                        principalTable: "delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packageAssignment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    deliveryId = table.Column<Guid>(type: "uuid", nullable: false),
                    packageId = table.Column<Guid>(type: "uuid", nullable: false),
                    scheduledDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packageAssignment", x => new { x.deliveryId, x.id });
                    table.ForeignKey(
                        name: "FK_packageAssignment_delivery_deliveryId",
                        column: x => x.deliveryId,
                        principalTable: "delivery",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliveryIncident",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    packageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryIncident", x => x.id);
                    table.ForeignKey(
                        name: "FK_deliveryIncident_package_packageId",
                        column: x => x.packageId,
                        principalTable: "package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deliveryStop",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    deliveryRouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    packageId = table.Column<Guid>(type: "uuid", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryStop", x => new { x.deliveryRouteId, x.id });
                    table.ForeignKey(
                        name: "FK_deliveryStop_deliveryRoute_deliveryRouteId",
                        column: x => x.deliveryRouteId,
                        principalTable: "deliveryRoute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deliveryIncident_packageId",
                table: "deliveryIncident",
                column: "packageId");

            migrationBuilder.CreateIndex(
                name: "IX_deliveryRoute_deliveryId",
                table: "deliveryRoute",
                column: "deliveryId");

            migrationBuilder.Sql("ALTER TABLE \"packageAssignment\" ALTER COLUMN id SET DEFAULT gen_random_uuid();");
            migrationBuilder.Sql("ALTER TABLE \"deliveryStop\" ALTER COLUMN id SET DEFAULT gen_random_uuid();");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveryIncident");

            migrationBuilder.DropTable(
                name: "deliveryStop");

            migrationBuilder.DropTable(
                name: "packageAssignment");

            migrationBuilder.DropTable(
                name: "package");

            migrationBuilder.DropTable(
                name: "deliveryRoute");

            migrationBuilder.DropTable(
                name: "delivery");
        }
    }
}
