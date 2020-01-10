using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABP.TPLMS.Migrations
{
    public partial class AddEntityModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Url = table.Column<string>(maxLength: 255, nullable: false),
                    HotKey = table.Column<string>(maxLength: 255, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    RequiresAuthentication = table.Column<bool>(nullable: false),
                    IsAutoExpand = table.Column<bool>(nullable: false),
                    IconName = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ParentName = table.Column<string>(maxLength: 255, nullable: false),
                    RequiredPermissionName = table.Column<string>(maxLength: 255, nullable: true),
                    SortNo = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modules");
        }
    }
}
