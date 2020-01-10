using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABP.TPLMS.Migrations
{
    public partial class AddEntityOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    HotKey = table.Column<string>(maxLength: 255, nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    ParentName = table.Column<string>(maxLength: 255, nullable: false),
                    IsLeaf = table.Column<bool>(nullable: false),
                    IsAutoExpand = table.Column<bool>(nullable: false),
                    IconName = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    BizCode = table.Column<string>(maxLength: 255, nullable: true),
                    CustomCode = table.Column<string>(maxLength: 100, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    CreateId = table.Column<int>(nullable: false),
                    SortNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orgs");
        }
    }
}
