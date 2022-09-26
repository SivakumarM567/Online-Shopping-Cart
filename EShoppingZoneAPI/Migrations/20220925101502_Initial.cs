using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EShoppingZoneAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    User_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.User_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User_firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_contact = table.Column<int>(type: "int", nullable: false),
                    User_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeUser_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeUser_type_id",
                        column: x => x.UserTypeUser_type_id,
                        principalTable: "UserTypes",
                        principalColumn: "User_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_quantity = table.Column<int>(type: "int", nullable: false),
                    Order_totalAmount = table.Column<float>(type: "real", nullable: false),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payment_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id");
                    table.ForeignKey(
                        name: "FK_Payments_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistorys",
                columns: table => new
                {
                    Transaction_reportid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Payment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistorys", x => x.Transaction_reportid);
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Orders_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Orders",
                        principalColumn: "Order_id");
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Payments_Payment_id",
                        column: x => x.Payment_id,
                        principalTable: "Payments",
                        principalColumn: "Payment_id");
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_User_id",
                table: "Orders",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Order_id",
                table: "Payments",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_User_id",
                table: "Payments",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_Order_id",
                table: "TransactionHistorys",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_Payment_id",
                table: "TransactionHistorys",
                column: "Payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_User_id",
                table: "TransactionHistorys",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeUser_type_id",
                table: "Users",
                column: "UserTypeUser_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionHistorys");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
