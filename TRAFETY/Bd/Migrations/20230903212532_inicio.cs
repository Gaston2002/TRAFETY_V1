using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace TRAFETY.Bd.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActividadId = table.Column<int>(type: "int", nullable: true),
                    ActividadPadreId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividades_Actividades_ActividadPadreId",
                        column: x => x.ActividadPadreId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TContactos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEmpresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TGuias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TGuias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TOrganizaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOrganizaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TStaffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Licencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TEmpresaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_TEmpresas_TEmpresaId",
                        column: x => x.TEmpresaId,
                        principalTable: "TEmpresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Guias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TGuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guias_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guias_TGuias_TGuiaId",
                        column: x => x.TGuiaId,
                        principalTable: "TGuias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TContactoId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipanteContactos_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipanteContactos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipanteContactos_TContactos_TContactoId",
                        column: x => x.TContactoId,
                        principalTable: "TContactos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipanteDocs_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipanteFichas_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TStaffId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaStaffs_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaStaffs_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaStaffs_TStaffs_TStaffId",
                        column: x => x.TStaffId,
                        principalTable: "TStaffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaGuias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaGuias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaGuias_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmpresaGuias_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuiaActividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaActividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuiaActividades_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuiaActividades_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuiaDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuiaDocs_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuiaFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuiaFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuiaFichas_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    PuntoSalida = table.Column<Point>(type: "geography", nullable: true),
                    PuntoLlegada = table.Column<Point>(type: "geography", nullable: true),
                    TOrganizacionId = table.Column<int>(type: "int", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ubicacion = table.Column<Point>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salidas_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salidas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salidas_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Salidas_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salidas_TOrganizaciones_TOrganizacionId",
                        column: x => x.TOrganizacionId,
                        principalTable: "TOrganizaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaDocs_Salidas_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaGuias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaId = table.Column<int>(type: "int", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaGuias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaGuias_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaGuias_Salidas_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaId = table.Column<int>(type: "int", nullable: false),
                    FechaSalida = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FechaRegreso = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadas_Salidas_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaDocs_SalidaProgramadas_SalidaProgramadaId",
                        column: x => x.SalidaProgramadaId,
                        principalTable: "SalidaProgramadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaGuiaDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaId = table.Column<int>(type: "int", nullable: false),
                    SalidaGuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaGuiaDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaGuiaDocs_SalidaGuias_SalidaGuiaId",
                        column: x => x.SalidaGuiaId,
                        principalTable: "SalidaGuias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaGuiaDocs_SalidaProgramadas_SalidaProgramadaId",
                        column: x => x.SalidaProgramadaId,
                        principalTable: "SalidaProgramadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaGuiaFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaId = table.Column<int>(type: "int", nullable: false),
                    SalidaGuiaId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaGuiaFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaGuiaFichas_SalidaGuias_SalidaGuiaId",
                        column: x => x.SalidaGuiaId,
                        principalTable: "SalidaGuias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaGuiaFichas_SalidaProgramadas_SalidaProgramadaId",
                        column: x => x.SalidaProgramadaId,
                        principalTable: "SalidaProgramadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaId = table.Column<int>(type: "int", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipantes_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipantes_SalidaProgramadas_SalidaProgramadaId",
                        column: x => x.SalidaProgramadaId,
                        principalTable: "SalidaProgramadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaId = table.Column<int>(type: "int", nullable: false),
                    GuiaId = table.Column<int>(type: "int", nullable: false),
                    TStaffId = table.Column<int>(type: "int", nullable: false),
                    SalidaId = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaStaffs_Guias_GuiaId",
                        column: x => x.GuiaId,
                        principalTable: "Guias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaStaffs_SalidaProgramadas_SalidaProgramadaId",
                        column: x => x.SalidaProgramadaId,
                        principalTable: "SalidaProgramadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaStaffs_Salidas_SalidaId",
                        column: x => x.SalidaId,
                        principalTable: "Salidas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalidaStaffs_TStaffs_TStaffId",
                        column: x => x.TStaffId,
                        principalTable: "TStaffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaParticipanteDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaParticipanteId = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaParticipanteDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipanteDocs_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipanteDocs_SalidaProgramadaParticipantes_SalidaProgramadaParticipanteId",
                        column: x => x.SalidaProgramadaParticipanteId,
                        principalTable: "SalidaProgramadaParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaProgramadaParticipanteFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaProgramadaParticipanteId = table.Column<int>(type: "int", nullable: false),
                    ParticipanteId = table.Column<int>(type: "int", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaProgramadaParticipanteFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipanteFichas_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalidaProgramadaParticipanteFichas_SalidaProgramadaParticipantes_SalidaProgramadaParticipanteId",
                        column: x => x.SalidaProgramadaParticipanteId,
                        principalTable: "SalidaProgramadaParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaStaffDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaStaffId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    NomDoc = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PathDoc = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaStaffDocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaStaffDocs_SalidaStaffs_SalidaStaffId",
                        column: x => x.SalidaStaffId,
                        principalTable: "SalidaStaffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaStaffFichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalidaStaffId = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCrea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCrea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModif = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdBaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaStaffFichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaStaffFichas_SalidaStaffs_SalidaStaffId",
                        column: x => x.SalidaStaffId,
                        principalTable: "SalidaStaffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "Actividad_Codigo_UQ",
                table: "Actividades",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_ActividadPadreId",
                table: "Actividades",
                column: "ActividadPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmpresaContacto_EmpresaId_GuiaId_UQ",
                table: "EmpresaGuias",
                columns: new[] { "EmpresaId", "GuiaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaGuias_GuiaId",
                table: "EmpresaGuias",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "EmpresaLicencia_UQ",
                table: "Empresas",
                column: "Licencia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TEmpresaId",
                table: "Empresas",
                column: "TEmpresaId");

            migrationBuilder.CreateIndex(
                name: "EmpresaStaff_EmpresaId_PersonaId_UQ",
                table: "EmpresaStaffs",
                columns: new[] { "EmpresaId", "PersonaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaStaffs_PersonaId",
                table: "EmpresaStaffs",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaStaffs_TStaffId",
                table: "EmpresaStaffs",
                column: "TStaffId");

            migrationBuilder.CreateIndex(
                name: "GuiaActividad_GuiaId_ActividadId_UQ",
                table: "GuiaActividades",
                columns: new[] { "GuiaId", "ActividadId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuiaActividades_ActividadId",
                table: "GuiaActividades",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "GuiaDoc_NomDoc_UQ",
                table: "GuiaDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuiaDocs_GuiaId",
                table: "GuiaDocs",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "GuiaFicha_Codigo_UQ",
                table: "GuiaFichas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuiaFichas_GuiaId",
                table: "GuiaFichas",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "GuiaPersona_UQ",
                table: "Guias",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guias_TGuiaId",
                table: "Guias",
                column: "TGuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteContactos_PersonaId",
                table: "ParticipanteContactos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteContactos_TContactoId",
                table: "ParticipanteContactos",
                column: "TContactoId");

            migrationBuilder.CreateIndex(
                name: "ParticipanteContacto_ParticipanteId_PersonaId_UQ",
                table: "ParticipanteContactos",
                columns: new[] { "ParticipanteId", "PersonaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteDocs_ParticipanteId",
                table: "ParticipanteDocs",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "ParticipanteDoc_NomDoc_UQ",
                table: "ParticipanteDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteFichas_ParticipanteId",
                table: "ParticipanteFichas",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "ParticipanteFicha_Codigo_UQ",
                table: "ParticipanteFichas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ParticipantePersona_UQ",
                table: "Participantes",
                column: "PersonaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonaEmail_UQ",
                table: "Personas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaDocs_SalidaId",
                table: "SalidaDocs",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "SalidaDoc_NomDoc_UQ",
                table: "SalidaDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaGuias_GuiaId",
                table: "SalidaGuias",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "SalidaGuia_SalidaId_GuiaId_UQ",
                table: "SalidaGuias",
                columns: new[] { "SalidaId", "GuiaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaDocs_SalidaProgramadaId",
                table: "SalidaProgramadaDocs",
                column: "SalidaProgramadaId");

            migrationBuilder.CreateIndex(
                name: "SalidaProgramadaDoc_NomDoc_UQ",
                table: "SalidaProgramadaDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaGuiaDocs_SalidaGuiaId",
                table: "SalidaProgramadaGuiaDocs",
                column: "SalidaGuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaGuiaDocs_SalidaProgramadaId",
                table: "SalidaProgramadaGuiaDocs",
                column: "SalidaProgramadaId");

            migrationBuilder.CreateIndex(
                name: "SalidaProgramadaGuiaDoc_NomDoc_UQ",
                table: "SalidaProgramadaGuiaDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaGuiaFichas_SalidaGuiaId",
                table: "SalidaProgramadaGuiaFichas",
                column: "SalidaGuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaGuiaFichas_SalidaProgramadaId",
                table: "SalidaProgramadaGuiaFichas",
                column: "SalidaProgramadaId");

            migrationBuilder.CreateIndex(
                name: "SalidaProgramadaGuiaFicha_Codigo_UQ",
                table: "SalidaProgramadaGuiaFichas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaParticipanteDocs_ParticipanteId",
                table: "SalidaProgramadaParticipanteDocs",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaParticipanteDocs_SalidaProgramadaParticipanteId",
                table: "SalidaProgramadaParticipanteDocs",
                column: "SalidaProgramadaParticipanteId");

            migrationBuilder.CreateIndex(
                name: "SalidaProgramadaParticipanteDoc_NomDoc_UQ",
                table: "SalidaProgramadaParticipanteDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaParticipanteFichas_ParticipanteId",
                table: "SalidaProgramadaParticipanteFichas",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaParticipanteFichas_SalidaProgramadaParticipanteId",
                table: "SalidaProgramadaParticipanteFichas",
                column: "SalidaProgramadaParticipanteId");

            migrationBuilder.CreateIndex(
                name: "SalidaProgramadaParticipanteFicha_Codigo_UQ",
                table: "SalidaProgramadaParticipanteFichas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadaParticipantes_ParticipanteId",
                table: "SalidaProgramadaParticipantes",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "SalidaParticipante_SalidaProgramadaId_ParticipanteId_UQ",
                table: "SalidaProgramadaParticipantes",
                columns: new[] { "SalidaProgramadaId", "ParticipanteId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaProgramadas_SalidaId",
                table: "SalidaProgramadas",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_ActividadId",
                table: "Salidas",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_EmpresaId",
                table: "Salidas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_GuiaId",
                table: "Salidas",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_PersonaId",
                table: "Salidas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Salidas_TOrganizacionId",
                table: "Salidas",
                column: "TOrganizacionId");

            migrationBuilder.CreateIndex(
                name: "OrgSalida_Codigo_UQ",
                table: "Salidas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaStaffDocs_SalidaStaffId",
                table: "SalidaStaffDocs",
                column: "SalidaStaffId");

            migrationBuilder.CreateIndex(
                name: "SalidaStaffDoc_NomDoc_UQ",
                table: "SalidaStaffDocs",
                column: "NomDoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaStaffFichas_SalidaStaffId",
                table: "SalidaStaffFichas",
                column: "SalidaStaffId");

            migrationBuilder.CreateIndex(
                name: "SalidaStaffFicha_Codigo_UQ",
                table: "SalidaStaffFichas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalidaStaffs_GuiaId",
                table: "SalidaStaffs",
                column: "GuiaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaStaffs_SalidaId",
                table: "SalidaStaffs",
                column: "SalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaStaffs_TStaffId",
                table: "SalidaStaffs",
                column: "TStaffId");

            migrationBuilder.CreateIndex(
                name: "SalidaStaff_SalidaProgramadaId_GuiaId_UQ",
                table: "SalidaStaffs",
                columns: new[] { "SalidaProgramadaId", "GuiaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TContacto_Codigo_UQ",
                table: "TContactos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TEmpresa_Codigo_UQ",
                table: "TEmpresas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TGuia_Codigo_UQ",
                table: "TGuias",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TOrganizacion_Codigo_UQ",
                table: "TOrganizaciones",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TStaff_Codigo_UQ",
                table: "TStaffs",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmpresaGuias");

            migrationBuilder.DropTable(
                name: "EmpresaStaffs");

            migrationBuilder.DropTable(
                name: "GuiaActividades");

            migrationBuilder.DropTable(
                name: "GuiaDocs");

            migrationBuilder.DropTable(
                name: "GuiaFichas");

            migrationBuilder.DropTable(
                name: "ParticipanteContactos");

            migrationBuilder.DropTable(
                name: "ParticipanteDocs");

            migrationBuilder.DropTable(
                name: "ParticipanteFichas");

            migrationBuilder.DropTable(
                name: "SalidaDocs");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaDocs");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaGuiaDocs");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaGuiaFichas");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaParticipanteDocs");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaParticipanteFichas");

            migrationBuilder.DropTable(
                name: "SalidaStaffDocs");

            migrationBuilder.DropTable(
                name: "SalidaStaffFichas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TContactos");

            migrationBuilder.DropTable(
                name: "SalidaGuias");

            migrationBuilder.DropTable(
                name: "SalidaProgramadaParticipantes");

            migrationBuilder.DropTable(
                name: "SalidaStaffs");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "SalidaProgramadas");

            migrationBuilder.DropTable(
                name: "TStaffs");

            migrationBuilder.DropTable(
                name: "Salidas");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Guias");

            migrationBuilder.DropTable(
                name: "TOrganizaciones");

            migrationBuilder.DropTable(
                name: "TEmpresas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TGuias");
        }
    }
}
