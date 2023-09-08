using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRAFETY.Bd.Entity.Empresas;
using TRAFETY.Bd.Entity.Personas;
using TRAFETY.Bd.Entity.Salidas;
using TRAFETY.Bd.Entity.TTipo;
using TRAFETY.Bd.Usuario;

namespace TRAFETY.Bd.Contexto
{
    public class Context : IdentityDbContext<User>
    {
        #region DBSET
        #region EMPRESAS
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EmpresaGuia> EmpresaGuias { get; set; }
        public DbSet<EmpresaStaff> EmpresaStaffs { get; set; }
        #endregion

        #region PERSONAS
        public DbSet<Guia> Guias { get; set; }
        public DbSet<GuiaActividad> GuiaActividades { get; set; }
        public DbSet<GuiaDoc> GuiaDocs { get; set; }
        public DbSet<GuiaFicha> GuiaFichas { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<ParticipanteContacto> ParticipanteContactos { get; set; }
        public DbSet<ParticipanteDoc> ParticipanteDocs { get; set; }
        public DbSet<ParticipanteFicha> ParticipanteFichas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        #endregion

        #region SALIDAS
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<SalidaDoc> SalidaDocs { get; set; }
        public DbSet<SalidaGuia> SalidaGuias { get; set; }
        public DbSet<SalidaProgramada> SalidaProgramadas { get; set; }
        public DbSet<SalidaProgramadaDoc> SalidaProgramadaDocs { get; set; }
        public DbSet<SalidaProgramadaGuiaDoc> SalidaProgramadaGuiaDocs { get; set; }
        public DbSet<SalidaProgramadaGuiaFicha> SalidaProgramadaGuiaFichas { get; set; }
        public DbSet<SalidaProgramadaParticipante> SalidaProgramadaParticipantes { get; set; }
        public DbSet<SalidaProgramadaParticipanteDoc> SalidaProgramadaParticipanteDocs { get; set; }
        public DbSet<SalidaProgramadaParticipanteFicha> SalidaProgramadaParticipanteFichas { get; set; }
        public DbSet<SalidaStaff> SalidaStaffs { get; set; }
        public DbSet<SalidaStaffDoc> SalidaStaffDocs { get; set; }
        public DbSet<SalidaStaffFicha> SalidaStaffFichas { get; set; }
        #endregion

        #region TTIPO
        public DbSet<TContacto> TContactos { get; set; }
        public DbSet<TEmpresa> TEmpresas { get; set; }
        public DbSet<TGuia> TGuias { get; set; }
        public DbSet<TOrganizacion> TOrganizaciones { get; set; }
        public DbSet<TStaff> TStaffs { get; set; }
        #endregion
        #endregion

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.G­etEntityTypes()
                                          .SelectMany(t => t.GetForeignKeys())
                                          .Where(fk => !fk.IsOwnership
                                                       && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(builder);

            //if(this.Roles.ToListAsync() == null)
            //{
            //    var rolAdmin = new IdentityRole();
            //    rolAdmin.Name = "admin";
            //    rolAdmin.NormalizedName = "ADMIN";
            //    var guid = new Guid();

            //    rolAdmin.Id = guid.ToString();
            //    this.Roles.AddAsync(rolAdmin);
            //}
        }

    }
}
//#region EMPRESAS
//#endregion

//#region PERSONAS
//#endregion

//#region SALIDAS
//#endregion

//#region TTIPO
//#endregion
