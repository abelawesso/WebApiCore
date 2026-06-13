using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPICRUD.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WebApi");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "WebApi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "The name of the country"),
                    DateOfIndependence = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "The date of independence"),
                    Motto = table.Column<string>(type: "text", nullable: false, comment: "The national motto"),
                    Population = table.Column<long>(type: "bigint", nullable: false, comment: "The population of the country"),
                    CurrencyCode = table.Column<string>(type: "text", nullable: false, comment: "The currency code"),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Motto",
                schema: "WebApi",
                table: "Countries",
                column: "Motto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                schema: "WebApi",
                table: "Countries",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries",
                schema: "WebApi");
        }
    }
}
