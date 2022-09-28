using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Usertypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Usertypeid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Userid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserContact = table.Column<int>(type: "int", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usertypeid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Userid);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_Usertypeid",
                        column: x => x.Usertypeid,
                        principalTable: "UserTypes",
                        principalColumn: "Usertypeid");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderTotalAmount = table.Column<float>(type: "real", nullable: false),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Orderid);
                    table.ForeignKey(
                        name: "FK_Orders_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Userid");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Paymentid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orderid = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Paymentid);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orders",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Payments_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Userid");
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistorys",
                columns: table => new
                {
                    TransactionReportid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderid = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: true),
                    Paymentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistorys", x => x.TransactionReportid);
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Orders_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Orders",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Payments_Paymentid",
                        column: x => x.Paymentid,
                        principalTable: "Payments",
                        principalColumn: "Paymentid");
                    table.ForeignKey(
                        name: "FK_TransactionHistorys_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "Userid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Userid",
                table: "Orders",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Orderid",
                table: "Payments",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Userid",
                table: "Payments",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_Orderid",
                table: "TransactionHistorys",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_Paymentid",
                table: "TransactionHistorys",
                column: "Paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistorys_Userid",
                table: "TransactionHistorys",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Usertypeid",
                table: "Users",
                column: "Usertypeid");
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
