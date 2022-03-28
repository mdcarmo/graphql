using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ex_graphql.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "IdentificationNumber", "Name" },
                values: new object[] { new Guid("b2b439e7-e6ab-495b-bc99-a7eae85ba6d3"), "johndoe@doe.com", "123456789", "John Doe" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "IdentificationNumber", "Name" },
                values: new object[] { new Guid("6e2eccf5-0204-45c5-b519-a49944fa08c8"), "mariedoe@doe.com", "12345678", "Marie Doe" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "Price", "Quantity", "Status", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("51da8c52-a597-441e-96a6-e658a8138286"), new DateTime(2022, 3, 27, 20, 36, 23, 93, DateTimeKind.Local).AddTicks(6628), new Guid("b2b439e7-e6ab-495b-bc99-a7eae85ba6d3"), 24m, 10, 0, "PETR4", 0 },
                    { new Guid("37b95c65-58ff-4d2c-b0cd-64ac721c5946"), new DateTime(2022, 3, 27, 20, 36, 23, 94, DateTimeKind.Local).AddTicks(5969), new Guid("b2b439e7-e6ab-495b-bc99-a7eae85ba6d3"), 4m, 100, 1, "OIBR3", 0 },
                    { new Guid("f9d55c8b-7a63-4896-8ab1-2144d38c35a2"), new DateTime(2022, 3, 27, 20, 36, 23, 94, DateTimeKind.Local).AddTicks(5983), new Guid("6e2eccf5-0204-45c5-b519-a49944fa08c8"), 24m, 10, 1, "BBDC4", 1 },
                    { new Guid("d1cf20bb-a220-4952-8904-a6231e2ed91a"), new DateTime(2022, 3, 27, 20, 36, 23, 94, DateTimeKind.Local).AddTicks(5986), new Guid("6e2eccf5-0204-45c5-b519-a49944fa08c8"), 24m, 20, 0, "PETR4", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
