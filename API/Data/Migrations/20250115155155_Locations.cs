using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Locations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefuseCompany",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefuseCompanyID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefuseCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<double>(type: "float", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FTLDealerID = table.Column<long>(type: "bigint", nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefuseCompany", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RefuseLocation",
                columns: table => new
                {
                    LocationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    RegionID = table.Column<long>(type: "bigint", nullable: false),
                    LocationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefuseLocation", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "RefuseRegion",
                columns: table => new
                {
                    RegionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<long>(type: "bigint", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefuseRegion", x => x.RegionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefuseCompany");

            migrationBuilder.DropTable(
                name: "RefuseLocation");

            migrationBuilder.DropTable(
                name: "RefuseRegion");
        }
    }
}
