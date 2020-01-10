using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABP.TPLMS.Migrations
{
    public partial class AddEntityCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: false),
                    CargoCode = table.Column<string>(maxLength: 50, nullable: true),
                    HSCode = table.Column<string>(maxLength: 10, nullable: true),
                    CargoName = table.Column<string>(maxLength: 250, nullable: true),
                    Spcf = table.Column<string>(maxLength: 512, nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Curr = table.Column<string>(nullable: true),
                    Package = table.Column<string>(nullable: true),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Vol = table.Column<decimal>(nullable: false),
                    MinNum = table.Column<decimal>(nullable: false),
                    MaxNum = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    GrossWt = table.Column<decimal>(nullable: false),
                    NetWt = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    UpdOper = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
