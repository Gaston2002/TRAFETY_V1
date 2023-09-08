using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRAFETY.Bd.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('45391b4f-d47a-4772-9f96-83b1313508c1', 'admin', 'ADMIN')");
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('28585fd8-2cf0-4276-bd43-9244bdbfcb83', 'participante', 'PARTICIPANTE')");
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles(Id, Name, NormalizedName)
                               VALUES('a9991887-40bc-49c5-8ab6-3e3751ef8d14', 'anonimo', 'ANONIMO')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = '45391b4f-d47a-4772-9f96-83b1313508c1'");
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = '28585fd8-2cf0-4276-bd43-9244bdbfcb83'");
            migrationBuilder.Sql("DELETE AspNetRoles WHERE Id = 'a9991887-40bc-49c5-8ab6-3e3751ef8d14'");
        }
    }
}
