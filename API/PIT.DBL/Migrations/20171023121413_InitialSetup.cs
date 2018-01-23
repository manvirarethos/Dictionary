using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PIT.DBL.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "longtext", nullable: true),
                    City = table.Column<string>(type: "longtext", nullable: true),
                    ContactNumber = table.Column<string>(type: "longtext", nullable: true),
                    Country = table.Column<string>(type: "longtext", nullable: true),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    PinCode = table.Column<string>(type: "longtext", nullable: true),
                    State = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    StyleClass = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    RoleForType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    ContactNumber = table.Column<string>(type: "longtext", nullable: true),
                    CreatedID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    Hash = table.Column<string>(type: "longtext", nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: true),
                    ModifiedID = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    Salt = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    ModifiedID = table.Column<int>(type: "int", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuTask_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuTaskID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleTask_MenuTask_MenuTaskID",
                        column: x => x.MenuTaskID,
                        principalTable: "MenuTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleTask_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MenuTaskID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubTask_MenuTask_MenuTaskID",
                        column: x => x.MenuTaskID,
                        principalTable: "MenuTask",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuTask_MenuID",
                table: "MenuTask",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleTask_MenuTaskID",
                table: "RoleTask",
                column: "MenuTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleTask_RoleID",
                table: "RoleTask",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_MenuTaskID",
                table: "SubTask",
                column: "MenuTaskID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyID",
                table: "User",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleTask");

            migrationBuilder.DropTable(
                name: "SubTask");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "MenuTask");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
